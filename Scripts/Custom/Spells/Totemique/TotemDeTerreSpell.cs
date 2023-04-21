using Server.Custom.Aptitudes;
using Server.Mobiles;
using Server.Spells;
using System;

namespace Server.Custom.Spells.NewSpells.Totemique
{
    public class TotemDeTerreSpell : Spell
    {
        private static readonly SpellInfo m_Info = new SpellInfo(
				"Totem de terre", "[Totem de terre]",
				SpellCircle.Eighth,
				269,
				9020,
				Reagent.EssenceTotemique
			);

		public override int RequiredAptitudeValue { get { return 3; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Totemique }; } }
		public override SkillName CastSkill { get { return SkillName.AnimalTaming; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }
		public override bool CheckCast()
		{
			if (!base.CheckCast())
				return false;

			if ((Caster.Followers + 1) > Caster.FollowersMax)
			{
				Caster.SendLocalizedMessage(1049645); // You have too many followers to summon that creature.
				return false;
			}

			return true;
		}

		public TotemDeTerreSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override void OnCast()
        {
            if (CheckSequence())
            {
                TimeSpan duration = TimeSpan.FromSeconds((2 * Caster.Skills.Magery.Fixed) / 5);
				var totem = new TotemDeTerre();
				SpellHelper.Summon(totem, Caster, 0x217, duration, false, false);
				totem.CantWalk = true;
				CustomUtility.ApplySimpleSpellEffect(Caster, "Totem de terre", duration, AptitudeColor.Totemique, SpellEffectType.Summon);
			}

			FinishSequence();
        }
    }
}
