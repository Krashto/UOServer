using System;
using Server;

namespace Server.Items
{
	public class BlueBookSoixanteQuinze : BaseBook
	{
		[Constructable]
		public BlueBookSoixanteQuinze() : base( 0xFF2, 75, true )
		{
		}

		[Constructable]
		public BlueBookSoixanteQuinze( int pageCount, bool writable ) : base( 0xFF2, pageCount, writable )
		{
		}

		[Constructable]
		public BlueBookSoixanteQuinze( string title, string author, int pageCount, bool writable ) : base( 0xFF2, title, author, pageCount, writable )
		{
		}

		public BlueBookSoixanteQuinze( Serial serial ) : base( serial )
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