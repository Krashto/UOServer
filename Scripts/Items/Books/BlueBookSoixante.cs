using System;
using Server;

namespace Server.Items
{
	public class BlueBookSoixante : BaseBook
	{
		[Constructable]
		public BlueBookSoixante() : base( 0xFF2, 60, true )
		{
		}

		[Constructable]
		public BlueBookSoixante( int pageCount, bool writable ) : base( 0xFF2, pageCount, writable )
		{
		}

		[Constructable]
		public BlueBookSoixante( string title, string author, int pageCount, bool writable ) : base( 0xFF2, title, author, pageCount, writable )
		{
		}

		public BlueBookSoixante( Serial serial ) : base( serial )
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