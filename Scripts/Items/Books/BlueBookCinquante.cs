using System;
using Server;

namespace Server.Items
{
	public class BlueBookCinquante : BaseBook
	{
		[Constructable]
		public BlueBookCinquante() : base( 0xFF2, 50, true )
		{
		}

		[Constructable]
		public BlueBookCinquante( int pageCount, bool writable ) : base( 0xFF2, pageCount, writable )
		{
		}

		[Constructable]
		public BlueBookCinquante( string title, string author, int pageCount, bool writable ) : base( 0xFF2, title, author, pageCount, writable )
		{
		}

		public BlueBookCinquante( Serial serial ) : base( serial )
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