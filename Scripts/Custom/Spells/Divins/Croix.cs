using System;
using Server.Mobiles;
using Server.Items;
using Server.Spells;
using Server.Gumps;
using Server.Custom.Aptitudes;

namespace Server.Items
{
    [FlipableAttribute(0x2, 0x3, 0x4, 0x5)]
	public class Croix : Item
	{
		[Constructable]
        public Croix() : base(0x2)
		{
			Weight = 85.0;
            Name = "croix";
		}

        public Croix(Serial serial) : base(serial)
		{
		}

        public override void OnDoubleClick(Mobile from)
        {
            CustomPlayerMobile m = from as CustomPlayerMobile;

            if (m != null)
            {
                if (!m.CanSee(this) || !m.InRange(Location, 4))
                {
                    m.SendLocalizedMessage(500446); // That is too far away.
                }
                else if (m.GetAptitudeValue(NAptitude.MagieAncestrale) <= 0)
                {
                    m.SendMessage("Vous devez préalablement avoir au moins 1 dans l'aptitude 'Dévouement Céleste' pour prier.");
                }
                else if (m.IsPraying)
                {
                    m.SendMessage("Vous êtes déjà en train de prier.");
                }
                else
                {
                    m.CloseGump(typeof(Religion.ReligionGump));
                    m.CloseGump(typeof(Religion.PriereGump));

                    m.SendGump(new Religion.ReligionGump(m, 0, this));
                }
            }
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}