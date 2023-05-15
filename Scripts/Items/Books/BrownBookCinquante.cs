using System;
using Server;

namespace Server.Items
{
	public class BrownBookCinquante : BaseBook
	{
		[Constructable]
		public BrownBookCinquante() : base( 0xFEF, 50, true )
		{
		}

		[Constructable]
		public BrownBookCinquante( int pageCount, bool writable ) : base( 0xFF2, pageCount, writable )
		{
		}

		[Constructable]
		public BrownBookCinquante( string title, string author, int pageCount, bool writable ) : base( 0xFF2, title, author, pageCount, writable )
		{
		}

		public BrownBookCinquante( Serial serial ) : base( serial )
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