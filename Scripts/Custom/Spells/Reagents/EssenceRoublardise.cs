namespace Server.Items
{
	public class EssenceRoublardise : BaseReagent
	{
		[Constructable]
		public EssenceRoublardise() : this(1)
		{
		}

		[Constructable]
		public EssenceRoublardise(int amount) : base(0x0F91, amount)
		{
			Name = "Essence: Roublardise";
			Hue = 1109;
		}

		public EssenceRoublardise(Serial serial) : base(serial)
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