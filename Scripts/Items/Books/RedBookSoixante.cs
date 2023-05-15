using System;
using Server;

namespace Server.Items
{
	public class RedBookSoixante : BaseBook
	{
		[Constructable]
		public RedBookSoixante() : base( 0xFF1, 60, true )
		{
		}

		[Constructable]
		public RedBookSoixante( int pageCount, bool writable ) : base( 0xFF2, pageCount, writable )
		{
		}

		[Constructable]
		public RedBookSoixante( string title, string author, int pageCount, bool writable ) : base( 0xFF2, title, author, pageCount, writable )
		{
		}

		public RedBookSoixante( Serial serial ) : base( serial )
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