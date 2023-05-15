namespace Server.Items
{
	public class CarteSqueletteRapiece : BaseCard
	{
		public override int Level => 4;
		public override CardEnchantType EnchantType => CardEnchantType.WeaponSpeed;

		[Constructable]
		public CarteSqueletteRapiece() : base(1940)
		{
			Name = "Carte Squelette Rapiece";
		}
		
		public CarteSqueletteRapiece( Serial serial ) : base( serial )
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