using Server.Custom.Aptitudes;
using Server.Spells;
using System;

namespace Server.Custom.Spells.NewSpells.Totemique
{
    public class TotemDeauSpell : Spell
    {
        private static readonly SpellInfo m_Info = new SpellInfo(
				"Totem d'eau", "[Totem d'eau]",
				SpellCircle.Eighth,
				269,
				9070,
				Reagent.EssenceTotemique
			);

		public override int RequiredAptitudeValue { get { return 2; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Totemique }; } }
		public override SkillName CastSkill { get { return SkillName.AnimalTaming; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }
		
		public TotemDeauSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

		public override bool CheckCast()
		{
			if (!base.CheckCast())
				return false;

			if ((Caster.Followers + 2) > Caster.FollowersMax || CustomUtility.GetFollowerCount(Caster) >= 4)
			{
				Caster.SendLocalizedMessage(1049645); // You have too many followers to summon that creature.
				return false;
			}

			return true;
		}

		public override void OnCast()
        {
            if (CheckSequence())
            {
				TimeSpan duration = TimeSpan.FromMinutes(10);
				var totem = new TotemDeau();
				SpellHelper.Summon(totem, Caster, 0x217, duration, false, false);
				totem.CantWalk = true;
				CustomUtility.ApplySimpleSpellEffect(Caster, "Totem d'eau", duration, AptitudeColor.Totemique, SpellEffectType.Summon);
			}

			FinishSequence();
        }
    }
}
