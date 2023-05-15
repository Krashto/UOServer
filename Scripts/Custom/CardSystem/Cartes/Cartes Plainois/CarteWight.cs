namespace Server.Items
{
	public class CarteWight : BaseCard
	{
		public override int Level => 2;
		public override CardEnchantType EnchantType => CardEnchantType.DefendChance;

		[Constructable]
		public CarteWight() : base(1940)
		{
			Name = "Carte Wight";
		}
		
		public CarteWight( Serial serial ) : base( serial )
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