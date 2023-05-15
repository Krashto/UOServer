namespace Server.Items
{
	public class CarteMageSquelettique : BaseCard
	{
		public override int Level => 4;
		public override CardEnchantType EnchantType => CardEnchantType.BonusMana;

		[Constructable]
		public CarteMageSquelettique() : base(1940)
		{
			Name = "Carte Mage Squelette";
		}

		public CarteMageSquelettique( Serial serial ) : base( serial )
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