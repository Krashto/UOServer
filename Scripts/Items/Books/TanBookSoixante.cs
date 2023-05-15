using System;
using Server;

namespace Server.Items
{
	public class TanBookSoixante : BaseBook
	{
		[Constructable]
		public TanBookSoixante() : base( 0xFF0, 60, true )
		{
		}

		[Constructable]
		public TanBookSoixante( int pageCount, bool writable ) : base( 0xFF2, pageCount, writable )
		{
		}

		[Constructable]
		public TanBookSoixante( string title, string author, int pageCount, bool writable ) : base( 0xFF2, title, author, pageCount, writable )
		{
		}

		public TanBookSoixante( Serial serial ) : base( serial )
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