using System;
using Server;

namespace Server.Items
{
	public class TanBookQuarante : BaseBook
	{
		[Constructable]
		public TanBookQuarante() : base( 0xFF0, 40, true )
		{
		}

		[Constructable]
		public TanBookQuarante( int pageCount, bool writable ) : base( 0xFF2, pageCount, writable )
		{
		}

		[Constructable]
		public TanBookQuarante( string title, string author, int pageCount, bool writable ) : base( 0xFF2, title, author, pageCount, writable )
		{
		}

		public TanBookQuarante( Serial serial ) : base( serial )
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