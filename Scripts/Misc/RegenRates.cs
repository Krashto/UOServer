using Server.Custom.Spells.NewSpells.Geomancie;
using Server.Custom.Spells.NewSpells.Martial;
using Server.Custom.Spells.NewSpells.Polymorphie;
using Server.Custom.Spells.NewSpells.Roublardise;
using Server.Items;
using Server.Mobiles;
using Server.Spells;
using System;
using System.Collections.Generic;

namespace Server.Misc
{
    public delegate int RegenBonusHandler(Mobile from);

    public class RegenRates
    {
        public static List<RegenBonusHandler> HitsBonusHandlers = new List<RegenBonusHandler>();
        public static List<RegenBonusHandler> StamBonusHandlers = new List<RegenBonusHandler>();
        public static List<RegenBonusHandler> ManaBonusHandlers = new List<RegenBonusHandler>();

        [CallPriority(10)]
        public static void Configure()
        {
            Mobile.DefaultHitsRate = TimeSpan.FromSeconds(11.0);
            Mobile.DefaultStamRate = TimeSpan.FromSeconds(7.0);
            Mobile.DefaultManaRate = TimeSpan.FromSeconds(7.0);

            Mobile.ManaRegenRateHandler = Mobile_ManaRegenRate;
            Mobile.StamRegenRateHandler = Mobile_StamRegenRate;
            Mobile.HitsRegenRateHandler = Mobile_HitsRegenRate;
        }

        public static double GetArmorOffset(Mobile from)
        {
            double rating =  GetArmorMeditationValue(from.NeckArmor as BaseArmor);
				   rating += GetArmorMeditationValue(from.HandArmor as BaseArmor);
				   rating += GetArmorMeditationValue(from.HeadArmor as BaseArmor);
				   rating += GetArmorMeditationValue(from.ArmsArmor as BaseArmor);
				   rating += GetArmorMeditationValue(from.LegsArmor as BaseArmor);
				   rating += GetArmorMeditationValue(from.ChestArmor as BaseArmor);

            return rating;
        }

        private static void CheckBonusSkill(Mobile m, int cur, int max, SkillName skill)
        {
            if (!m.Alive)
                return;

            double n = (double)cur / max;
            double v = Math.Sqrt(m.Skills[skill].Value * 0.005);

            n *= (1.0 - v);
            n += v;

            m.CheckSkill(skill, n);
        }

        private static TimeSpan Mobile_HitsRegenRate(Mobile from)
        {
            return TimeSpan.FromSeconds(1.0 / (0.1 * (1 + HitPointRegen(from))));
        }

        private static TimeSpan Mobile_StamRegenRate(Mobile from)
        {
            if (from.Skills == null)
                return Mobile.DefaultStamRate;

            CheckBonusSkill(from, from.Stam, from.StamMax, SkillName.Focus);

            double bonus = from.Skills[SkillName.Focus].Value * 0.1;

            bonus += StamRegen(from);

            double rate = 1.0 / (1.42 + (bonus / 100));

            if (from is BaseCreature && ((BaseCreature)from).IsMonster)
            {
                rate *= 1.95;
            }

            return TimeSpan.FromSeconds(rate);

        }

        private static TimeSpan Mobile_ManaRegenRate(Mobile from)
        {
            if (from.Skills == null)
                return Mobile.DefaultManaRate;

            if (!from.Meditating)
                CheckBonusSkill(from, from.Mana, from.ManaMax, SkillName.Meditation);

            double rate;
            double armorPenaltyScalar = GetArmorOffset(from);

            double med = from.Skills[SkillName.Meditation].Value;
            double focus = from.Skills[SkillName.Focus].Value;

            double focusBonus = focus / 200;

			CheckBonusSkill(from, from.Mana, from.ManaMax, SkillName.Focus);

            var medBonus = (0.0075 * med) + (0.0025 * from.Int);

            if (medBonus >= 100.0)
                medBonus *= 1.1;

            if (from.Meditating)
            {
                medBonus *= 2;
            }

            double itemBase = ((((med / 2) + (focus / 4)) / 90) * .65) + 2.35;
            double intensityBonus = Math.Sqrt(ManaRegen(from));

            double itemBonus = ((itemBase * intensityBonus) - (itemBase - 1)) / 10;

            rate = 1.0 / ((0.2 + focusBonus + medBonus + itemBonus) * (1 - armorPenaltyScalar));

            if (double.IsNaN(rate))
            {
                return Mobile.DefaultManaRate;
            }

            return TimeSpan.FromSeconds(rate);
        }

        public static double HitPointRegen(Mobile from)
        {
            double points = AosAttributes.GetValue(from, AosAttribute.RegenHits);

            if (from is BaseCreature)
                points += ((BaseCreature)from).DefaultHitsRegen;

			points += FormeGivranteSpell.GetValue(from);

			points += SecondSouffleSpell.GetValue(from);

			if (PresenceInspiranteSpell.IsActive(from))
				points += 10;

			if (from is CustomPlayerMobile pm)
				points += pm.Attributs.Constitution / 50;

			CheckBonusSkill(from, from.Hits, from.HitsMax, SkillName.Cooking);

			points += from.Skills[SkillName.Cooking].Value / 50;

			points += BarrabHemolymphConcentrate.HPRegenBonus(from);

            foreach (RegenBonusHandler handler in HitsBonusHandlers)
                points += handler(from);

			if (points < 0)
				points = 0;

			return points;
        }

        public static double StamRegen(Mobile from)
        {
            double points = AosAttributes.GetValue(from, AosAttribute.RegenStam);

            if (from is BaseCreature)
                points += ((BaseCreature)from).DefaultStamRegen;

			if (FormeEnsanglanteeSpell.IsActive(from))
                points += 15;

			if (from is CustomPlayerMobile pm)
				points += pm.Attributs.Endurance / 10;

			if (points < -1)
                points = -1;

            foreach (RegenBonusHandler handler in StamBonusHandlers)
                points += handler(from);

            return points;
        }

        public static double ManaRegen(Mobile from)
        {
            double points = AosAttributes.GetValue(from, AosAttribute.RegenMana);

            if (from is BaseCreature)
                points += ((BaseCreature)from).DefaultManaRegen;

			points += FormeMetalliqueSpell.GetValue(from);

			if (AdrenalineSpell.IsActive(from))
				points += 10;

			if (FormeCristallineSpell.IsActive(from))
				points += 15;

			if (FormeEnsanglanteeSpell.IsActive(from))
				points += 3;

			if (from is CustomPlayerMobile pm)
				points += pm.Attributs.Sagesse / 10;

			foreach (RegenBonusHandler handler in ManaBonusHandlers)
                points += handler(from);

            return points;
        }

        public static double GetArmorMeditationValue(BaseArmor ar)
        {
            if (ar == null || ar.ArmorAttributes.MageArmor != 0 || ar.Attributes.SpellChanneling != 0)
                return 0.0;

            switch (ar.MaterialType)
            {
                default: return 0.00;
				case ArmorMaterialType.Plate: return 0.06;
                case ArmorMaterialType.Chainmail: return 0.04;
                case ArmorMaterialType.Ringmail: return 0.02;
            }
        }
    }
}
