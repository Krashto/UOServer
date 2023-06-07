using Server.Custom.Aptitudes;
using Server.Mobiles;
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
				Reagent.EssenceChasseur
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
				if (CompagnonAnimalSpell.Table.Contains(Caster))
				{
					var bc = CompagnonAnimalSpell.Table[Caster] as BaseCreature;

					if (bc != null)
					{
						double toHeal = Caster.Skills[CastSkill].Value * 0.3 + Caster.Skills[DamageSkill].Value * 0.3;
						toHeal += Utility.RandomMinMax(5, 10);

						toHeal = SpellHelper.AdjustValue(Caster, toHeal, Aptitude.Chasseur);

						bc.Heal((int)toHeal);

						CustomUtility.ApplySimpleSpellEffect(bc, "Soin animalier", AptitudeColor.Chasseur, SpellEffectType.Heal);
					}
				}
				else
					Caster.SendMessage("Vous n'avez pas de compagnon avec vous.");
			}

			FinishSequence();
		}
	}
}