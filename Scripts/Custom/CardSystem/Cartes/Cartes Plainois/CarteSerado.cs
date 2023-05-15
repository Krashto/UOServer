namespace Server.Items
{
	public class CarteSerado : BaseCard
	{
		public override int Level => 1;
		public override CardEnchantType EnchantType => CardEnchantType.AptitudeGeomancie;

		[Constructable]
		public CarteSerado() : base(1940)
		{
			Name = "Carte Serado";
		}

		public CarteSerado( Serial serial ) : base( serial )
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