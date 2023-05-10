using System;
using Server.Targeting;
using Server.Custom.Aptitudes;
using System.Collections;
using Server.Spells;
using Server.Network;
using Server.Custom.Spells.NewSpells.Polymorphie;

namespace Server.Custom.Spells.NewSpells.Chasseur
{
	public class CoupDansLeGenouSpell : Spell
	{
		private static Hashtable m_Timers = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Coup dans le genou", "[Coup dans le genou]",
				SpellCircle.Eighth,
				239,
				9021,
				Reagent.EssenceChasseur
			);

		public override int RequiredAptitudeValue { get { return 9; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Chasseur }; } }
		public override SkillName CastSkill { get { return SkillName.Tracking; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public CoupDansLeGenouSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(Mobile m)
		{
			if (!Caster.CanSee(m))
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			else if (CheckSequence())
			{
				SpellHelper.Turn(Caster, m);

				if (!IndomptableSpell.IsActive(m))
				{
					Deactivate(m);

					var duration = GetDurationForSpell(3);

					Timer t = new InternalTimer(m, DateTime.Now + duration);
					m_Timers[m] = t;
					t.Start();

					m.SendSpeedControl(SpeedControlType.WalkSpeed);

					CustomUtility.ApplySimpleSpellEffect(m, "Coup dans le genou", duration, AptitudeColor.Chasseur, SpellEffectType.Malus);
				}
				else
				{
					Caster.SendMessage("Votre cible est immunisée aux ralentissements.");
				}
			}

			FinishSequence();
		}

		public static bool IsActive(Mobile attacker)
		{
			return m_Timers.ContainsKey(attacker);
		}

		public static void Deactivate(Mobile m)
		{
			if (m == null)
				return;

			var t = (Timer)m_Timers[m];

			if (t != null)
			{
				t.Stop();
				m_Timers.Remove(m);
				m.SendSpeedControl(SpeedControlType.Disable);
				CustomUtility.ApplySimpleSpellEffect(m, "Coup dans le genou", AptitudeColor.Chasseur, SpellSequenceType.End, SpellEffectType.Malus);
			}
		}

		public class InternalTimer : Timer
		{
			private Mobile m_Mobile;
			private DateTime m_EndTime;

			public InternalTimer(Mobile m, DateTime endTime) : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
			{
				m_Mobile = m;
				m_EndTime = endTime;

				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				if (DateTime.Now >= m_EndTime && m_Timers.Contains(m_Mobile) || m_Mobile == null || m_Mobile.Deleted || !m_Mobile.Alive)
				{
					Deactivate(m_Mobile);
					Stop();
				}
			}
		}

		private class InternalTarget : Target
		{
			private CoupDansLeGenouSpell m_Owner;

			public InternalTarget(CoupDansLeGenouSpell owner)
				: base(12, false, TargetFlags.Beneficial)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is Mobile)
					m_Owner.Target((Mobile)o);
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}