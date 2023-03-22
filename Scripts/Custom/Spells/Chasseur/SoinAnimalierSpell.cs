using Server.Custom.Aptitudes;
using Server.Spells;

namespace Server.Custom.Spells.NewSpells.Chasseur
{
	public class SoinAnimalierSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Soin animalier", "[Soin animalier]",
				SpellCircle.Fourth,
				230,
				9041,
				Reagent.Bloodmoss,
				Reagent.SulfurousAsh,
				Reagent.SulfurousAsh
			);

		public override int RequiredAptitudeValue { get { return 4; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Chasseur }; } }
		public override SkillName CastSkill { get { return SkillName.Tracking; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public SoinAnimalierSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				
			}

			FinishSequence();
		}
	}
}