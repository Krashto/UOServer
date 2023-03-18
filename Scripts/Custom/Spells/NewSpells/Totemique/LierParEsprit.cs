using Server.Custom.Aptitudes;
using Server.Spells;
using VitaNex.FX;

namespace Server.Custom.Spells.NewSpells.Totemique
{
	public class LierParEspritSpell : Spell
	{
		private static readonly SpellInfo m_Info = new SpellInfo(
			"Lier par l'esprit", "Lier par l'esprit",
			SpellCircle.Eighth,
			269,
			9070,
			Reagent.Bloodmoss,
			Reagent.MandrakeRoot,
			Reagent.SpidersSilk);

		public override int RequiredAptitudeValue { get { return 6; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Totemique }; } }
		public override SkillName CastSkill { get { return SkillName.AnimalTaming; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public LierParEspritSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			var mobiles = Caster.GetMobilesInRange(10);

			foreach (var m in mobiles)
			{
				if (!(m is BaseTotem totem) || totem.ControlMaster != Caster)
					continue;

				SpellHelper.Turn(totem, Caster);
				ConcentricWaveFX.Water.CreateInstance(totem.Location, totem.Map, totem.Direction, (int)totem.GetDistanceToSqrt(Caster));
				totem.MoveToWorld(Caster.Location, Caster.Map);
			}
		}
	}
}
