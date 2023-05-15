using System;
using Server;

namespace Server.Items
{
	public class RedBookCinquante : BaseBook
	{
		[Constructable]
		public RedBookCinquante() : base( 0xFF1, 50, true )
		{
		}

		[Constructable]
		public RedBookCinquante( int pageCount, bool writable ) : base( 0xFF2, pageCount, writable )
		{
		}

		[Constructable]
		public RedBookCinquante( string title, string author, int pageCount, bool writable ) : base( 0xFF2, title, author, pageCount, writable )
		{
		}

		public RedBookCinquante( Serial serial ) : base( serial )
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