namespace Server.Items
{
    public class Hamburger1 : BaseFood
    {
        [Constructable]
        public Hamburger1() : this(1) { }
        [Constructable]
        public Hamburger1(int amount) : base(amount, 0xA40F)
        {
            Weight = 1.0;
            Stackable = true;
            Hue = 0x457;
            FillFactor = 3;
            Name = "Hamburger";
        }
        public Hamburger1(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
