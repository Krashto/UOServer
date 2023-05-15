namespace Server.Items
{
	public class CarteCauchemar : BaseCard
	{
		public override int Level => 4;
		public override CardEnchantType EnchantType => CardEnchantType.FireResistance;

		[Constructable]
		public CarteCauchemar() : base(1940)
		{
			Name = "Carte Cauchemar";
		}
		
		public CarteCauchemar(Serial serial) : base(serial)
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