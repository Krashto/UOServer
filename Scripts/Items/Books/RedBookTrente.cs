using System;
using Server;

namespace Server.Items
{
	public class RedBookTrente : BaseBook
	{
		[Constructable]
		public RedBookTrente() : base( 0xFF1, 30, true )
		{
		}

		[Constructable]
		public RedBookTrente( int pageCount, bool writable ) : base( 0xFF2, pageCount, writable )
		{
		}

		[Constructable]
		public RedBookTrente( string title, string author, int pageCount, bool writable ) : base( 0xFF2, title, author, pageCount, writable )
		{
		}

		public RedBookTrente( Serial serial ) : base( serial )
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