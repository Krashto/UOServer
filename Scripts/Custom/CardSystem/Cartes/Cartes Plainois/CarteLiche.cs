namespace Server.Items
{
	public class CarteLiche : BaseCard
	{
		public override int Level => 6;
		public override CardEnchantType EnchantType => CardEnchantType.LowerRegCost;

		[Constructable]
		public CarteLiche() : base(1940)
		{
			Name = "Carte Liche";
		}
		
		public CarteLiche(Serial serial) : base(serial)
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