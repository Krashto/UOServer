using System;
using Server;

namespace Server.Items
{
	public class BrownBookTrente : BaseBook
	{
		[Constructable]
		public BrownBookTrente() : base( 0xFEF, 30, true )
		{
		}

		[Constructable]
		public BrownBookTrente( int pageCount, bool writable ) : base( 0xFF2, pageCount, writable )
		{
		}

		[Constructable]
		public BrownBookTrente( string title, string author, int pageCount, bool writable ) : base( 0xFF2, title, author, pageCount, writable )
		{
		}

		public BrownBookTrente( Serial serial ) : base( serial )
		{
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); // version
		}
	}
}