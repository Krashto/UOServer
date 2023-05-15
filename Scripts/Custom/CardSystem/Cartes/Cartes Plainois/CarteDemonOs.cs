namespace Server.Items
{
	public class CarteDemonOs : BaseCard
	{
		public override int Level => 1;
		public override CardEnchantType EnchantType => CardEnchantType.CastSpeed;

		[Constructable]
		public CarteDemonOs() : base(1940)
		{
			Name = "Carte Demon d'Os";
		}

		public CarteDemonOs(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}