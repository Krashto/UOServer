using Server.Mobiles;
using Server.Spells;
using Server.Custom.Aptitudes;

namespace Server.Items
{
	public class Chapelet : Item
	{
        private bool m_Benit;

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Benit
        {
            get { return m_Benit; }
            set { m_Benit = value; }
        }

		[Constructable]
        public Chapelet() : base(12468)
		{
			Weight = 2.0;
            Name = "Chapelet";
            Layer = Layer.Waist;
		}

        public Chapelet(Serial serial) : base(serial)
		{
		}

		public override void OnAosSingleClick(Mobile from)
		{
			base.OnAosSingleClick(from);

			if (Parent != null && (Parent == from || Parent == from.Backpack))
				LabelTo(from, "[b�nit]");
		}

		public override void OnDoubleClick(Mobile from)
        {
            Item waist = from.FindItemOnLayer(Layer.Waist);
            CustomPlayerMobile m = from as CustomPlayerMobile;

            if (m != null)
            {
                if (waist != this)
                    m.SendMessage("Vous devez avoir le chapelet autour de la taille pour prier.");
                else if (!m_Benit)
                    m.SendMessage("Votre chapelet doit �tre b�nit pour prier.");
                else if (m.GetAptitudeValue(NAptitude.MagieAncestrale) == 0)
                    m.SendMessage("Vous devez pr�alablement avoir au moins 1 dans l'aptitude 'D�vouement C�leste' pour prier.");
                else
                    m.SendGump(new Religion.ReligionGump(m, 0, this));
            }
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );

            writer.Write(m_Benit);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

            m_Benit = reader.ReadBool();
		}
	}
}