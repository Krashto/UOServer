namespace Server.Custom.Packaging.Packages
{
	public  class Materiaux : Item
	{
		[Constructable]
		public Materiaux() : base(0x1876)
		{
			Name = "Materiaux";
			Hue = 2930;
			Weight = 0.3;
			Stackable = true;
		}

		public Materiaux(Serial serial)
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
