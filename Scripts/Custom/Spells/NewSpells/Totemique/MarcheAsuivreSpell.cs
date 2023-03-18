﻿using Server.Custom.Aptitudes;
using Server.Spells;
using VitaNex.FX;

namespace Server.Custom.Spells.NewSpells.Totemique
{
	public class MarcheAsuivreSpell : Spell
	{
		private static readonly SpellInfo m_Info = new SpellInfo(
			"Marche à suivre", "Marche à suivre",
			SpellCircle.Eighth,
			269,
			9070,
			Reagent.Bloodmoss,
			Reagent.MandrakeRoot,
			Reagent.SpidersSilk);

		public override int RequiredAptitudeValue { get { return 10; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Totemique }; } }
		public override SkillName CastSkill { get { return SkillName.AnimalTaming; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public MarcheAsuivreSpell(Mobile caster, Item scroll)
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
				ExplodeFX.Bee.CreateInstance(totem.Location, totem.Map, 1);
				totem.CantWalk = false;
			}
		}
	}
}
