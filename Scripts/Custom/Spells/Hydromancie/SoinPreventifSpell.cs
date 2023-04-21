using System;
using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;

namespace Server.Custom.Spells.NewSpells.Hydromancie
{
	public class SoinPreventifSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Soin preventif", "[Soin preventif]",
				SpellCircle.First,
				236,
				9031,
				Reagent.EssenceHydromancie
			);

		public override int RequiredAptitudeValue { get { return 3; } }
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
			if (!Caster.CanSee(m))
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			else if (CheckSequence())
			{
				SpellHelper.Turn(Caster, m);

				Caster.MoveToWorld(m.Location, m.Map);

				//m.MagicDamageAbsorb = 50;
				//m.MeleeDamageAbsorb = 50;

				Timer t = new InternalTimer(Caster, m);
				t.Start();

				CustomUtility.ApplySimpleSpellEffect(Caster, "Soin preventif", AptitudeColor.Hydromancie, SpellEffectType.Heal);
			}

			FinishSequence();
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

				m_MaxCount = 5;
			}

			protected override void OnTick()
			{
				if (!m_Mobile.Alive || m_Mobile.Deleted)
				{
					Stop();
				}
				else
				{
					double toHeal = Math.Max(1, Utility.RandomMinMax(10 + m_Count, (10 + m_Count) * 2));

					if (AvatarDuFroidSpell.IsActive(m_From))
						toHeal *= 1.5;

					m_Mobile.Heal((int)toHeal);

					CustomUtility.ApplySimpleSpellEffect(m_Mobile, "Soin preventif", AptitudeColor.Hydromancie, SpellEffectType.Heal);

					if (++m_Count >= m_MaxCount)
					{
						CustomUtility.ApplySimpleSpellEffect(m_Mobile, "Soin preventif", AptitudeColor.Hydromancie, SpellSequenceType.End);
						Stop();
					}
				}
			}
		}
	}
}
