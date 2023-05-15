using System;
using Server;

namespace Server.Items
{
	public class BlueBook200 : BaseBook
	{
		[Constructable]
		public BlueBook200() : base( 0xFF2, 200, true )
		{
		}

		[Constructable]
		public BlueBook200( int pageCount, bool writable ) : base( 0xFF2, pageCount, writable )
		{
		}

		[Constructable]
		public BlueBook200( string title, string author, int pageCount, bool writable ) : base( 0xFF2, title, author, pageCount, writable )
		{
		}

		public BlueBook200( Serial serial ) : base( serial )
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