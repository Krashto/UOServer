using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Items;

namespace Server.Custom.Spells.NewSpells.Chasseur
{
	public class CompagnonAnimalSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Compagnon animal", "[Compagnon animal]",
				SpellCircle.Fourth,
				239,
				9021,
				Reagent.MandrakeRoot,
				Reagent.SulfurousAsh,
				Reagent.BlackPearl
			);

		public override int RequiredAptitudeValue { get { return 3; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Chasseur }; } }
		public override SkillName CastSkill { get { return SkillName.Tracking; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public CompagnonAnimalSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
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