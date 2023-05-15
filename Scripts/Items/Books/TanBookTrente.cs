using System;
using Server;

namespace Server.Items
{
	public class TanBookTrente : BaseBook
	{
		[Constructable]
		public TanBookTrente() : base( 0xFF0, 30, true )
		{
		}

		[Constructable]
		public TanBookTrente( int pageCount, bool writable ) : base( 0xFF2, pageCount, writable )
		{
		}

		[Constructable]
		public TanBookTrente( string title, string author, int pageCount, bool writable ) : base( 0xFF2, title, author, pageCount, writable )
		{
		}

		public TanBookTrente( Serial serial ) : base( serial )
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