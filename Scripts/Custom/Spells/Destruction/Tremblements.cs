using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;
using Server.Custom.Aptitudes;

namespace Server.Spells
{
	public class TremblementsSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Tremblements", "In Vas Por",
				SpellCircle.Third,
				233,
				9012,
				false,
				Reagent.Bloodmoss,
				Reagent.Ginseng,
				Reagent.SulfurousAsh
            );

        public override int RequiredAptitudeValue { get { return 1; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.Destruction }; } }

        public TremblementsSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
		{
        }

		public override void OnCast()
		{
			if ( CheckSequence() )
			{
				ArrayList targets = new ArrayList();

				Map map = Caster.Map;

				if ( map != null )
                {
                    double tile = SpellHelper.AdjustValue(Caster, 1 + (int)(Caster.Skills[CastSkill].Value / 12.0), NAptitude.Destruction);

                    if (tile > 12)
                        tile = 12;

					foreach ( Mobile m in Caster.GetMobilesInRange( (int)tile ) )
					{
                        if (Caster != m && SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeHarmful(m, false) && !CustomPlayerMobile.IsInEquipe(Caster, m))
							targets.Add( m );
					}
				}

                Caster.PlaySound(0x2F3);

                for ( int i = 0; i < targets.Count; ++i )
				{
                    Mobile m = (Mobile)targets[i];

                    Disturb(m);

                    double damage = GetNewAosDamage(m, 8, 1, 6, true);

                    damage = (int)SpellHelper.AdjustValue(Caster, damage, NAptitude.Destruction);

                    Caster.DoHarmful( m );
					SpellHelper.Damage( TimeSpan.Zero, m, Caster, damage, 100, 0, 0, 0, 0 );
				}
			}

			FinishSequence();
		}
	}
}