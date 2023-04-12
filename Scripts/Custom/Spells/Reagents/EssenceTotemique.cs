namespace Server.Items
{
	public class EssenceTotemique : BaseReagent
	{
		[Constructable]
		public EssenceTotemique() : this(1)
		{
		}

		[Constructable]
		public EssenceTotemique(int amount) : base(0x0F91, amount)
		{
			Name = "Essence: Totemique";
			Hue = 1139;
		}

		public EssenceTotemique(Serial serial) : base(serial)
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