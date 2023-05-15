using System;
using Server;

namespace Server.Items
{
	public class TanBookSoixanteQuinze : BaseBook
	{
		[Constructable]
		public TanBookSoixanteQuinze() : base( 0xFF0, 75, true )
		{
		}

		[Constructable]
		public TanBookSoixanteQuinze( int pageCount, bool writable ) : base( 0xFF2, pageCount, writable )
		{
		}

		[Constructable]
		public TanBookSoixanteQuinze( string title, string author, int pageCount, bool writable ) : base( 0xFF2, title, author, pageCount, writable )
		{
		}

		public TanBookSoixanteQuinze( Serial serial ) : base( serial )
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