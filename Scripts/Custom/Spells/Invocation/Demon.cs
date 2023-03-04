using System;
using Server.Mobiles;
using Server.Custom.Aptitudes;

namespace Server.Spells
{
    public class DemonSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"D�mon", "Kal Vas Xen Corp",
				SpellCircle.Eighth,
				269,
				9050,
				false,
				Reagent.Bloodmoss,
				Reagent.Garlic,
				Reagent.SpidersSilk
			);

        public override int RequiredAptitudeValue { get { return 12; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.Invocation }; } }

        public override bool Invocation { get { return true; } }

        public DemonSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
		{
		}

		public override bool CheckCast()
		{
			if ( !base.CheckCast() )
				return false;

			if ( (Caster.Followers + 15) > Caster.FollowersMax )
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
                TimeSpan duration = GetDurationForSpell(30, 1.5);

			    SpellHelper.Summon( new SummonedDaemon(), Caster, 0x216, duration, false, false );
			}

			FinishSequence();
		}
	}
}