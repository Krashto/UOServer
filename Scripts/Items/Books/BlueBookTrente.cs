using System;
using Server;

namespace Server.Items
{
	public class BlueBookTrente : BaseBook
	{
		[Constructable]
		public BlueBookTrente() : base( 0xFF2, 30, true )
		{
		}

		[Constructable]
		public BlueBookTrente( int pageCount, bool writable ) : base( 0xFF2, pageCount, writable )
		{
		}

		[Constructable]
		public BlueBookTrente( string title, string author, int pageCount, bool writable ) : base( 0xFF2, title, author, pageCount, writable )
		{
		}

		public BlueBookTrente( Serial serial ) : base( serial )
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