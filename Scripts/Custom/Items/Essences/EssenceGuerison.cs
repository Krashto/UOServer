namespace Server.Items
{
	public class EssenceGuerison : BaseReagent
	{
		[Constructable]
		public EssenceGuerison() : this(1)
		{
		}

		[Constructable]
		public EssenceGuerison(int amount) : base(0x0F91, amount)
		{
			Name = "Essence: Guérison";
			Hue = 2006;
		}

		public EssenceGuerison(Serial serial) : base(serial)
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