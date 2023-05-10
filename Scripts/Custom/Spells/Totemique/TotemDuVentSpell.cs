using Server.Custom.Aptitudes;
using Server.Spells;
using System;

namespace Server.Custom.Spells.NewSpells.Totemique
{
    public class TotemDuVentSpell : Spell
    {
        private static readonly SpellInfo m_Info = new SpellInfo(
				"Totem du vent", "[Totem du vent]",
				SpellCircle.Eighth,
				269,
				9010,
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

			if ((Caster.Followers + 2) > Caster.FollowersMax || CustomUtility.GetFollowerCount(Caster) >= 4)
			{
				Caster.SendLocalizedMessage(1049645); // You have too many followers to summon that creature.
				return false;
			}

			return true;
		}

		public TotemDuVentSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override void OnCast()
        {
            if (CheckSequence())
            {
				TimeSpan duration = TimeSpan.FromMinutes(10);
				var totem = new TotemDuVent();
				SpellHelper.Summon(totem, Caster, 0x217, duration, false, false);
				totem.CantWalk = true;
				CustomUtility.ApplySimpleSpellEffect(Caster, "Totem du vent", duration, AptitudeColor.Totemique, SpellEffectType.Summon);
			}

			FinishSequence();
        }
    }
}
