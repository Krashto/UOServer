using System.Collections;
using Server.Targeting;
using Server.Mobiles;
using Server.Items;
using Server.Custom.Aptitudes;

namespace Server.Spells
{
	public class NResurrectionSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Resurrection", "An Corp",
				SpellCircle.Sixth,
				245,
				9062,
				Reagent.Bloodmoss,
				Reagent.Garlic,
				Reagent.Ginseng
            );

        public override int RequiredAptitudeValue { get { return 4; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.Medecine }; } }

        public NResurrectionSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public void Target( Corpse c )
		{
            Mobile m = c.Owner;

			if ( !Caster.CanSee( c ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if ( m == Caster )
			{
				Caster.SendLocalizedMessage( 501039 ); // Thou can not resurrect thyself.
			}
			else if ( !Caster.InRange( c, 5 ) )
			{
				Caster.SendLocalizedMessage( 501042 ); // Target is not close enough.
			}
			else if ( !m.Player )
			{
				Caster.SendLocalizedMessage( 501043 ); // Target is not a being.
			}
			else if ( CheckSequence() && m != null)
			{
                CustomPlayerMobile pm = m as CustomPlayerMobile;
                
                if (pm != null && Caster is CustomPlayerMobile && !pm.Alive)
                {
                    SpellHelper.Turn(Caster, pm);

                    pm.PlaySound(0x214);
                    pm.FixedEffect(0x376A, 10, 16);

                    pm.Location = c.Location;
                    pm.Frozen = false;

                    pm.Direction = c.Direction;
                    pm.Animate(21, 5, 1, false, false, 0);

                    pm.Resurrect();

                    if (c != null)
                    {
                        ArrayList list = new ArrayList();

                        foreach (Item item in c.Items)
                        {
                            list.Add(item);
                        }

                        foreach (Item item in list)
                        {
                            if (item.Layer == Layer.Hair || item.Layer == Layer.FacialHair)
                                item.Delete();

                            if (item is BaseRaceGumps || c.EquipItems.Contains(item))
                            {
                                if (!m.EquipItem(item))
                                    m.AddToBackpack(item);
                            }
                            else
                            {
                                m.AddToBackpack(item);
                            }
                        }
                    }

                    pm.CheckStatTimers();
                }
                else
                    Caster.SendMessage("Vous devez cibler le corps d'un joueur MORT !");
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
            private NResurrectionSpell m_Owner;

            public InternalTarget(NResurrectionSpell owner)
                : base(3, false, TargetFlags.Beneficial)
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
                Corpse c = o as Corpse;

                if (c != null && c.Owner is CustomPlayerMobile)
				{
					m_Owner.Target(c);
				}
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}