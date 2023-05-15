namespace Server.Items
{
	public abstract class BaseSoul : Item
	{
		public BaseSoul(int hue, int itemId) : base(itemId)
		{
			Hue = hue;
			Weight = 1.0;
		}

		public BaseSoul( Serial serial ) : base( serial )
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