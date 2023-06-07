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

		public override int RequiredAptitudeValue { get { return 1; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Totemique }; } }
		public override SkillName CastSkill { get { return SkillName.AnimalTaming; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }
		public override bool CheckCast()
		{
			if (!base.CheckCast())
				return false;

			if (!BaseTotem.CanSummonTotemType(Caster, typeof(BaseTotemDeTerre)))
			{
				Caster.SendMessage("Vous avez déjà ce type de totem.");
				return false;
			}

			if ((Caster.Followers + 2) > Caster.FollowersMax || CustomUtility.GetFollowersCount(Caster) >= 4)
			{
				Caster.SendLocalizedMessage(1049645); // You have too many followers to summon that creature.
				return false;
			}


			if ((Caster.Followers + 2) > Caster.FollowersMax || CustomUtility.GetFollowersCount(Caster) >= 4)
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
				BaseTotem totem;

				if (Caster is CustomPlayerMobile pm)
				{
					if (pm.Aptitudes.Totemique >= 7)
						totem = new TotemDeTerreUltime();
					else if (pm.Aptitudes.Totemique >= 4)
						totem = new TotemDeTerreAvance();
					else
						totem = new TotemDeTerre();
				}
				else
					totem = new TotemDeTerre();

				var duration = GetDurationForSpell(300);
				SpellHelper.Summon(totem, Caster, 0x217, duration, false, false);
				totem.CantWalk = true;
				CustomUtility.ApplySimpleSpellEffect(Caster, "Totem de terre", duration, AptitudeColor.Totemique, SpellEffectType.Summon);
			}

			FinishSequence();
        }
    }
}
