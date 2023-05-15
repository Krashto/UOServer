using System;
using Server;

namespace Server.Items
{
	public class RedBookSoixanteQuinze : BaseBook
	{
		[Constructable]
		public RedBookSoixanteQuinze() : base( 0xFF1, 75, true )
		{
		}

		[Constructable]
		public RedBookSoixanteQuinze( int pageCount, bool writable ) : base( 0xFF2, pageCount, writable )
		{
		}

		[Constructable]
		public RedBookSoixanteQuinze( string title, string author, int pageCount, bool writable ) : base( 0xFF2, title, author, pageCount, writable )
		{
		}

		public RedBookSoixanteQuinze( Serial serial ) : base( serial )
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