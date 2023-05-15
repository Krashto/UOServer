using System;
using Server;

namespace Server.Items
{
	public class TanBookCinquante : BaseBook
	{
		[Constructable]
		public TanBookCinquante() : base( 0xFF0, 50, true )
		{
		}

		[Constructable]
		public TanBookCinquante( int pageCount, bool writable ) : base( 0xFF2, pageCount, writable )
		{
		}

		[Constructable]
		public TanBookCinquante( string title, string author, int pageCount, bool writable ) : base( 0xFF2, title, author, pageCount, writable )
		{
		}

		public TanBookCinquante( Serial serial ) : base( serial )
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