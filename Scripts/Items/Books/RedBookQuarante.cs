using System;
using Server;

namespace Server.Items
{
	public class RedBookQuarante : BaseBook
	{
		[Constructable]
		public RedBookQuarante() : base( 0xFF1, 40, true )
		{
		}

		[Constructable]
		public RedBookQuarante( int pageCount, bool writable ) : base( 0xFF2, pageCount, writable )
		{
		}

		[Constructable]
		public RedBookQuarante( string title, string author, int pageCount, bool writable ) : base( 0xFF2, title, author, pageCount, writable )
		{
		}

		public RedBookQuarante( Serial serial ) : base( serial )
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