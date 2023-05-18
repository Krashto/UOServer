using Server.Custom.Spells.Necromancie.Summons;
using Server.Mobiles;

namespace Server.Custom.Spells.Musique
{
	public class MusicSpellHelper
	{
		public static readonly double MaxBardingDifficulty = 100.0;

		public static bool IsMageryCreature(BaseCreature bc)
		{
			return (bc != null && bc.AI == AIType.AI_Mage && bc.Skills[SkillName.Magery].Base > 5.0);
		}

		public static bool IsFireBreathingCreature(BaseCreature bc)
		{
			if (bc == null)
				return false;

			AbilityProfile profile = bc.AbilityProfile;

			if (profile != null)
			{
				return profile.HasAbility(SpecialAbility.DragonBreath);
			}

			return false;
		}

		public static bool IsPoisonImmune(BaseCreature bc)
		{
			return (bc != null && bc.PoisonImmune != null);
		}

		public static int GetPoisonLevel(BaseCreature bc)
		{
			if (bc == null)
				return 0;

			Poison p = bc.HitPoison;

			if (p == null)
				return 0;

			return p.Level + 1;
		}

		public static double GetBaseDifficulty(Mobile targ)
		{
			double val = (targ.HitsMax * 0.7) + targ.StamMax + targ.ManaMax;

			val += targ.SkillsTotal / 10;

			BaseCreature bc = targ as BaseCreature;

			if (IsMageryCreature(bc))
				val += 100;

			if (IsFireBreathingCreature(bc))
				val += 100;

			if (IsPoisonImmune(bc))
				val += 100;

			if (targ is VampireBat || targ is VampireBatFamiliar)
				val += 100;

			val += GetPoisonLevel(bc) * 20;

			if (val > 700)
				val = 700 + (int)((val - 700) * (3.0 / 11));

			val /= 10;

			if (bc != null && bc.IsParagon)
				val += 40.0;

			if (val > MaxBardingDifficulty)
				val = MaxBardingDifficulty;

			return val;
		}

		public static void PlayInstrumentWell(Mobile from)
		{
			from.PlaySound(0x45);
		}

		public static void PlayInstrumentBadly(Mobile from)
		{
			from.PlaySound(0x46);
		}
	}
}
