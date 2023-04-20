namespace Server.Items
{
	public class EssencePolymorphie : BaseReagent
	{
		[Constructable]
		public EssencePolymorphie() : this(1)
		{
		}

		[Constructable]
		public EssencePolymorphie(int amount) : base(0x0F91, amount)
		{
			Name = "Essence: Polymorphie";
			Hue = 2661;
		}

		public EssencePolymorphie(Serial serial) : base(serial)
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