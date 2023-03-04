using System;
using Server.Custom.Aptitudes;
using Server.Mobiles;

namespace Server.Spells
{
	public class StrangulaireSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Insurection", "Kal Vas Xen An Hur",
				SpellCircle.Fifth,
				269,
				9070,
				false,
				Reagent.Bloodmoss,
				Reagent.NoxCrystal,
				Reagent.GraveDust
			);

        public override int RequiredAptitudeValue { get { return 8; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.Necromancie }; } }

        public override SkillName CastSkill { get { return SkillName.Magery; } }
        public override SkillName DamageSkill { get { return SkillName.Forensics; } }

        public override bool Invocation { get { return true; } }

        public StrangulaireSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
		{
		}

		public override bool CheckCast()
		{
			if ( !base.CheckCast() )
				return false;

			if ( (Caster.Followers + 3) > Caster.FollowersMax )
			{
				Caster.SendLocalizedMessage( 1049645 ); // You have too many followers to summon that creature.
				return false;
			}

			return true;
		}

		public override void OnCast()
		{
			if ( CheckSequence() )
			{
                TimeSpan duration = GetDurationForSpell(30, 1.2);

			    SpellHelper.Summon( new SummonedStrangulaire(), Caster, 0x217, duration, false, false );
			}

			FinishSequence();
		}
	}
}