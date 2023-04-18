namespace Server.Items
{
    public abstract class BaseShirt : BaseClothing
    {
        public BaseShirt(int itemID)
            : this(itemID, 0)
        {
        }

        public BaseShirt(int itemID, int hue)
            : base(itemID, Layer.MiddleTorso, hue)
        {
        }

        public BaseShirt(Serial serial)
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

    

    [Flipable(0x2794, 0x27DF)]
    public class ClothNinjaJacket : BaseMiddleTorso
	{
        [Constructable]
        public ClothNinjaJacket()
            : this(0)
        {
        }

        [Constructable]
        public ClothNinjaJacket(int hue)
            : base(0x2794, hue)
        {
            Weight = 5.0;
            Layer = Layer.InnerTorso;
        }

        public ClothNinjaJacket(Serial serial)
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

   

    public class ClothChest : BaseClothing
    {
        [Constructable]
        public ClothChest()
            : this(0)
        {
        }

        [Constructable]
        public ClothChest(int hue)
            : base(0x0406, Layer.InnerTorso, hue)
        {
            Weight = 2.0;
        }

        public ClothChest(Serial serial)
            : base(serial)
        {
        }

        public override void OnAdded(object parent)
        {
            base.OnAdded(parent);

            if (parent is Mobile)
            {
                if (((Mobile)parent).Female)
                    ItemID = 0x0405;
                else
                    ItemID = 0x0406;
            }
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

    public class FemaleClothChest : BaseClothing
    {
        [Constructable]
        public FemaleClothChest()
            : this(0)
        {
        }

        [Constructable]
        public FemaleClothChest(int hue)
            : base(0x0405, Layer.InnerTorso, hue)
        {
            Weight = 2.0;
        }

        public FemaleClothChest(Serial serial)
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

    public class MaleClothChest : BaseClothing
    {
        [Constructable]
        public MaleClothChest()
            : this(0)
        {
        }

        [Constructable]
        public MaleClothChest(int hue)
            : base(0x0406, Layer.InnerTorso, hue)
        {
            Weight = 2.0;
        }

        public MaleClothChest(Serial serial)
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
