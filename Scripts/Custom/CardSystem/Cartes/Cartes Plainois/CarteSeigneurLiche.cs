namespace Server.Items
{
	public class CarteSeigneurLiche : BaseCard
	{
		public override int Level => 4;
		public override CardEnchantType EnchantType => CardEnchantType.PoisonResistance;

		[Constructable]
		public CarteSeigneurLiche() : base(1940)
		{
			Name = "Carte Seigneur Liche";
		}

		public CarteSeigneurLiche( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}