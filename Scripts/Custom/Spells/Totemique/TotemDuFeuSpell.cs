using Server.Custom.Aptitudes;
using Server.Spells;
using System;

namespace Server.Custom.Spells.NewSpells.Totemique
{
    public class TotemDeFeuSpell : Spell
    {
        private static readonly SpellInfo m_Info = new SpellInfo(
				"Totem de feu", "[Totem de feu]",
				SpellCircle.Eighth,
				269,
				9050,
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

			if (!BaseTotem.CanSummonTotemType(Caster, typeof(TotemDeFeu)))
			{
				Caster.SendMessage("Vous avez déjà ce type de totem.");
				return false;
			}

			if ((Caster.Followers + 2) > Caster.FollowersMax || CustomUtility.GetFollowersCount(Caster) >= 4)
			{
				Caster.SendLocalizedMessage(1049645); // You have too many followers to summon that creature.
				return false;
			}

			return true;
		}

		public TotemDeFeuSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override void OnCast()
        {
            if (CheckSequence())
            {
				var duration = GetDurationForSpell(300);
				var totem = new TotemDeFeu();
				SpellHelper.Summon(totem, Caster, 0x217, duration, false, false);
				totem.CantWalk = true;
				CustomUtility.ApplySimpleSpellEffect(Caster, "Totem du feu", duration, AptitudeColor.Totemique, SpellEffectType.Summon);
			}

			FinishSequence();
        }
    }
}
