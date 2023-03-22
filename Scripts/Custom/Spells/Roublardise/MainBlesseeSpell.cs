using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Items;

namespace Server.Custom.Spells.NewSpells.Roublardise
{
	public class MainBlesseeSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Main blessee", "[Main blessee]",
				SpellCircle.Sixth,
				221,
				9032,
				Reagent.Bloodmoss,
				Reagent.MandrakeRoot,
				Reagent.SpidersSilk
			);

		public override int RequiredAptitudeValue { get { return 7; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Roublardise }; } }
		public override SkillName CastSkill { get { return SkillName.Hiding; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public override int CastDelayBase { get { return 0; } }
		public override int CastDelayCircleScalar { get { return 0; } }
		public override int CastDelayFastScalar { get { return 0; } }
		public override int CastDelayPerSecond { get { return 1; } }
		public override int CastDelayMinimum { get { return 0; } }

		public override int CastRecoveryBase { get { return 0; } }
		public override int CastRecoveryCircleScalar { get { return 0; } }
		public override int CastRecoveryFastScalar { get { return 0; } }
		public override int CastRecoveryPerSecond { get { return 1; } }
		public override int CastRecoveryMinimum { get { return 0; } }

		public MainBlesseeSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			WeaponAbility.SetCurrentAbility(Caster, WeaponAbility.Disarm);
			Caster.SendMessage("Votre prochain coup désarmera votre cible.");
			FinishSequence();
		}
	}
}