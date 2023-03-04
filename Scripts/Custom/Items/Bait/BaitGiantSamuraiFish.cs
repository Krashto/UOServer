using System;

namespace Server.Items
{
    public class BaitGiantSamuraiFish : BaseBait
	{
		[Constructable]
		public BaitGiantSamuraiFish() : this( 20 )
		{
		}

		[Constructable]
		public BaitGiantSamuraiFish( int charge ) : base( Bait.GiantSamuraiFish, charge )
		{
		}

		public BaitGiantSamuraiFish( Serial serial ) : base( serial )
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