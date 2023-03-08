using System;
using Server.Items;
using Server.Custom.Aptitudes;
using Server.Spells;

namespace Server.Custom.Spells.NewSpells.Chasseur
{
	public class CibleEnVueSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Cible En Vue", "Ort Por Ylem",
				SpellCircle.Second,
				203,
				9031,
				Reagent.Bloodmoss,
				Reagent.MandrakeRoot
			);

		public override int RequiredAptitudeValue { get { return 5; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Chasseur }; } }
		public override SkillName CastSkill { get { return SkillName.Tracking; } }
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

		public CibleEnVueSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			WeaponAbility.SetCurrentAbility(Caster, WeaponAbility.ParalyzingBlow);
			Caster.SendMessage("Votre prochain coup paralysera votre cible.");
			FinishSequence();
		}
	}
}