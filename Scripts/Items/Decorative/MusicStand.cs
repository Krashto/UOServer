namespace Server.Items
{
    [Furniture]
	[Flipable(0xEBB, 0xEBC)]
	public class TallMusicStandLeft : Item
    {
        [Constructable]
        public TallMusicStandLeft()
            : base(0xEBB)
        {
            Weight = 10.0;
			Name = "Grand Lutrin";
        }

        public TallMusicStandLeft(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    [Furniture]
    public class TallMusicStandRight : Item
    {
        [Constructable]
        public TallMusicStandRight()
            : base(0xEBC)
        {
            Weight = 10.0;
        }

        public TallMusicStandRight(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    [Furniture]
	[Flipable(0xEB6, 0xEB8)]
	public class ShortMusicStandLeft : Item
    {
        [Constructable]
        public ShortMusicStandLeft()
            : base(0xEB6)
        {
            Weight = 10.0;
			Name = "Petit Lutrin";
        }

        public ShortMusicStandLeft(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    [Furniture]
    public class ShortMusicStandRight : Item
    {
        [Constructable]
        public ShortMusicStandRight()
            : base(0xEB8)
        {
            Weight = 10.0;
        }

        public ShortMusicStandRight(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}