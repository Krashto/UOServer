using System; 
using Server; 
using Server.Multis; 
using Server.Network; 
using Server.Mobiles;

namespace Server.Items
{
    public class SecureGarden : BaseContainer
    {
        private Mobile m_Player;

        public override int DefaultGumpID { get { return 0x3C; } }
        public override int DefaultDropSound { get { return 0x42; } }

        public override Rectangle2D Bounds
        {
            get { return new Rectangle2D(16, 51, 168, 73); }
        }

        public SecureGarden(Mobile player)
            : base(0xE76)
        {
            m_Player = player;
            ItemID = 3649;
            Visible = true;
            Movable = false;
            MaxItems = 50;
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public Mobile Player
        {
            get
            {
                return m_Player;
            }
            set
            {
                m_Player = value;
                InvalidateProperties();
            }
        }

        public override int MaxWeight
        {
            get
            {
                return 0;
            }
        }

        public SecureGarden(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version 

            writer.Write(m_Player);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            m_Player = (PlayerMobile)reader.ReadMobile();
        }

        public override TimeSpan DecayTime
        {
            get
            {
                return TimeSpan.FromDays(100);
            }
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            if (m_Player != null)
                list.Add("Garden Secure");
            else
                base.AddNameProperty(list);
        }

        public override void OnAosSingleClick(Mobile from)
        {
            if (m_Player != null)
            {
                LabelTo(from, "Garden Secure");

                if (CheckContentDisplay(from))
                    LabelTo(from, "({0} items, {1} stones)", TotalItems, TotalWeight);
            }
            else
            {
                base.OnAosSingleClick(from);
            }
        }

        public override bool IsAccessibleTo(Mobile m)
        {
            if ((m == m_Player || m.AccessLevel >= AccessLevel.GameMaster))
            {
                return true;
            }
            else
            {
                return false;
            }
            //return m == m_Player && base.IsAccessibleTo(m);
        }
    }
}