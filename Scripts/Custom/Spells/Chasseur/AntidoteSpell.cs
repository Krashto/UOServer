using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;

namespace Server.Custom.Spells.NewSpells.Chasseur
{
	public class AntidoteSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Antidote", "[Antidote]",
				SpellCircle.First,
				212,
				9061,
				Reagent.Garlic,
				Reagent.Ginseng
			);

		public override int RequiredAptitudeValue { get { return 1; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Chasseur }; } }
		public override SkillName CastSkill { get { return SkillName.Tracking; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public AntidoteSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			var p = Caster.Poison;

			if (p != null)
			{
				double chanceToCure = 10000 + (int)(Caster.Skills[SkillName.Magery].Value * 75) - (p.Level + 1) * 2500;
				chanceToCure /= 100;

				chanceToCure = SpellHelper.AdjustValue(Caster, chanceToCure, Aptitude.Chasseur);

				if ((int)chanceToCure > Utility.Random(100))
					if (Caster.CurePoison(Caster))
						Caster.SendLocalizedMessage(1010059); // You have been cured of all poisons.
					else
						Caster.SendLocalizedMessage(1010060); // You have failed to cure your target!

				Caster.FixedParticles(0x373A, 10, 15, 5012, EffectLayer.Waist);
				Caster.PlaySound(0x1E0);
			}
			else
				Caster.SendMessage($"Vous n'êtes pas empoisonné{(Caster.Female ? "e" : "")}");

			FinishSequence();
		}
	}
}