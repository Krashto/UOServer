using Server.Mobiles;

namespace Server.Items
{
    [TypeAlias("Server.Items.BouraFur", "Server.Items.KepetchFur")]
    public class Fur : Item
    {
        [Constructable]
        public Fur()
            : this(FurType.None, 1)
        {
        }

        [Constructable]
        public Fur(FurType type, int amount)
            : base(0x11F4)
        {
            Stackable = true;
            Amount = amount;
			Name = "Fourrure";

            switch (type)
            {
                default:
                case FurType.None: Hue = 0; break;
                case FurType.Green: Hue = 58; break;
                case FurType.LightBrown: Hue = 1541; break;
                case FurType.Yellow: Hue = 153; break;
                case FurType.Brown: Hue = 343; break;
            }
        }

        public Fur(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
