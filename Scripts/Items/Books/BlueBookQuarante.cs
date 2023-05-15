using System;
using Server;

namespace Server.Items
{
	public class BlueBookQuarante : BaseBook
	{
		[Constructable]
		public BlueBookQuarante() : base( 0xFF2, 40, true )
		{
		}

		[Constructable]
		public BlueBookQuarante( int pageCount, bool writable ) : base( 0xFF2, pageCount, writable )
		{
		}

		[Constructable]
		public BlueBookQuarante( string title, string author, int pageCount, bool writable ) : base( 0xFF2, title, author, pageCount, writable )
		{
		}

		public BlueBookQuarante( Serial serial ) : base( serial )
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