using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Items;
using System;
using Server.Targeting;

namespace Server.Custom.Spells.NewSpells.Roublardise
{
	public class MainBlesseeSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Main blessee", "[Main blessee]",
				SpellCircle.Sixth,
				221,
				9032,
				Reagent.EssenceRoublardise
			);

		public override int RequiredAptitudeValue { get { return 5; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Roublardise }; } }
		public override SkillName CastSkill { get { return SkillName.Hiding; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public override TimeSpan CastDelayBase => TimeSpan.Zero;
		public override double CastDelayFastScalar => 0;
		public override double CastDelaySecondsPerTick => 1;
		public override TimeSpan CastDelayMinimum => TimeSpan.Zero;

		public override int CastRecoveryBase => 0;
		public override int CastRecoveryFastScalar => 0;
		public override int CastRecoveryPerSecond => 1;
		public override int CastRecoveryMinimum => 0;

		public MainBlesseeSpell(Mobile caster, Item scroll)
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
			else if (CheckHSequence(m))
			{
				Disturb(m);

				SpellHelper.Turn(Caster, m);
				SpellHelper.Turn(m, Caster);

				if (Disarm.DoEffect(Caster, m))
				{
					CustomUtility.ApplySimpleSpellEffect(Caster, "Main blessee", AptitudeColor.Roublardise, SpellEffectType.Bonus);
					CustomUtility.ApplySimpleSpellEffect(m, "Main blessee", AptitudeColor.Roublardise, SpellEffectType.Malus);
				}
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private MainBlesseeSpell m_Owner;

			public InternalTarget(MainBlesseeSpell owner)
				: base(12, false, TargetFlags.Harmful)
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