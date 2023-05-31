using System;
using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Mobiles;
using Server.Network;
using System.Collections;

namespace Server.Custom.Spells.NewSpells.Hydromancie
{
	public class SoinPreventifSpell : Spell
	{
		private static Hashtable m_Timers = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Soin preventif", "[Soin preventif]",
				SpellCircle.First,
				236,
				9031,
				Reagent.EssenceHydromancie
			);

		public override int RequiredAptitudeValue { get { return 6; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Hydromancie }; } }
		public override SkillName CastSkill { get { return SkillName.Meditation; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public SoinPreventifSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(Mobile m)
		{
			if (IsActive(m))
				Deactivate(m);

			if (!Caster.CanSee(m))
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			else if (m.IsDeadBondedPet)
			{
				Caster.SendLocalizedMessage(1060177); // You cannot heal a creature that is already dead!
			}
			else if (m is BaseCreature && ((BaseCreature)m).IsAnimatedDead)
			{
				Caster.SendLocalizedMessage(1061654); // You cannot heal that which is not alive.
			}
			else if (m.Poisoned)
			{
				Caster.LocalOverheadMessage(MessageType.Regular, 0x22, (Caster == m) ? 1005000 : 1010398);
			}
			else if (CheckSequence())
			{
				SpellHelper.Turn(Caster, m);

				Caster.MoveToWorld(m.Location, m.Map);

				Timer t = new InternalTimer(Caster, m);
				m_Timers[m] = t;
				t.Start();

				CustomUtility.ApplySimpleSpellEffect(Caster, "Soin preventif", AptitudeColor.Hydromancie, SpellEffectType.Heal);
			}

			FinishSequence();
		}

		public static bool IsActive(Mobile m)
		{
			return m_Timers.ContainsKey(m);
		}

		public static void Deactivate(Mobile m)
		{
			if (m == null)
				return;

			var t = m_Timers[m] as Timer;

			if (t != null)
			{
				t.Stop();
				m_Timers.Remove(m);
				CustomUtility.ApplySimpleSpellEffect(m, "Soin preventif", AptitudeColor.Hydromancie, SpellSequenceType.End, SpellEffectType.Heal);
			}
		}

		private class InternalTarget : Target
		{
			private SoinPreventifSpell m_Owner;

			public InternalTarget(SoinPreventifSpell owner)
				: base(12, true, TargetFlags.Beneficial)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				var m = o as Mobile;

				if (m != null)
					m_Owner.Target(m);
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}

		private class InternalTimer : Timer
		{
			private readonly Mobile m_From;
			private readonly Mobile m_Mobile;
			private int m_Count;
			private readonly int m_MaxCount;

			public InternalTimer(Mobile from, Mobile m)
				: base(TimeSpan.FromSeconds(2.0), TimeSpan.FromSeconds(2.0))
			{
				m_From = from;
				m_Mobile = m;
				Priority = TimerPriority.TwoFiftyMS;

				m_MaxCount = 3;

				if (from is CustomPlayerMobile pm)
					m_MaxCount = Math.Max(pm.Capacites.Magie, 3);
			}

			protected override void OnTick()
			{
				if (m_Count >= m_MaxCount || m_Mobile == null || m_Mobile.Deleted || !m_Mobile.Alive)
				{
					Deactivate(m_Mobile);
					Stop();
				}
				else
				{
					double toHeal = Math.Max(1, Utility.RandomMinMax(2, 3));

					if (AvatarDuFroidSpell.IsActive(m_From))
						toHeal *= 1.25;

					toHeal += SpellHelper.AdjustValue(m_From, toHeal, Aptitude.Hydromancie);

					m_Mobile.Heal((int)toHeal);

					if (++m_Count >= m_MaxCount)
					{
						Deactivate(m_Mobile);
						Stop();
					}
				}
			}
		}
	}
}
