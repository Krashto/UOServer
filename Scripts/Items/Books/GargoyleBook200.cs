namespace Server.Items
{
    public class GargoyleBook200 : BaseBook
    {
        [Constructable]
        public GargoyleBook200()
            : base(0x238C, 200, true)
        {
        }

        [Constructable]
        public GargoyleBook200(int pageCount, bool writable)
            : base(0x238C, pageCount, writable)
        {
        }

        [Constructable]
        public GargoyleBook200(string title, string author, int pageCount, bool writable)
            : base(0x238C, title, author, pageCount, writable)
        {
        }

        // Intended for defined books only
        public GargoyleBook200(bool writable)
            : base(0x238C, writable)
        {
        }

        public GargoyleBook200(Serial serial)
            : base(serial)
        {
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

			if (version < 2)
			{
				Pages = new BookPageInfo[200];

				for (int i = 0; i < Pages.Length; ++i)
					Pages[i] = new BookPageInfo();
			}
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(2); // version
        }
    }
}