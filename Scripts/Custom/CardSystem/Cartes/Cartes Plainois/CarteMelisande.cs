namespace Server.Items
{
	public class CarteMelisande : BaseCard
	{
		public override int Level => 1;
		public override CardEnchantType EnchantType => CardEnchantType.AptitudeNecromancie;

		[Constructable]
		public CarteMelisande() : base(1940)
		{
			Name = "Carte Lady Melisande";
		}

		public CarteMelisande( Serial serial ) : base( serial )
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