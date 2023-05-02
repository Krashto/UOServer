using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Items;
using System;

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
			if (CheckSequence())
			{
				WeaponAbility.SetCurrentAbility(Caster, WeaponAbility.Disarm);
				CustomUtility.ApplySimpleSpellEffect(Caster, "Main blessee", AptitudeColor.Roublardise);
				Caster.SendMessage("Votre prochain coup désarmera votre cible.");
			}

			FinishSequence();
		}
	}
}