using Server.Custom.Aptitudes;
using Server.Spells;
using VitaNex.FX;

namespace Server.Custom.Spells.NewSpells.Totemique
{
	public class MarcheAsuivreSpell : Spell
	{
		private static readonly SpellInfo m_Info = new SpellInfo(
				"Marche a suivre", "[Marche a suivre]",
				SpellCircle.Eighth,
				269,
				9070,
				Reagent.EssenceTotemique
			);

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
			if (CheckSequence())
			{
				var mobiles = Caster.GetMobilesInRange(25);

				foreach (var m in mobiles)
				{
					if (!(m is BaseTotem totem) || totem.ControlMaster != Caster)
						continue;

					SpellHelper.Turn(totem, Caster);
					ExplodeFX.Bee.CreateInstance(totem.Location, totem.Map, 1);
					totem.CantWalk = false;
					totem.MarcheASuivreEnable = true;
					totem.ControlOrder = Mobiles.OrderType.Follow;
				}
			}
			FinishSequence();
		}
	}
}
