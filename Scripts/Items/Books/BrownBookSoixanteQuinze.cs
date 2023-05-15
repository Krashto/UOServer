using System;
using Server;

namespace Server.Items
{
	public class BrownBookSoixanteQuinze : BaseBook
	{
		[Constructable]
		public BrownBookSoixanteQuinze() : base( 0xFEF, 75, true )
		{
		}

		[Constructable]
		public BrownBookSoixanteQuinze( int pageCount, bool writable ) : base( 0xFF2, pageCount, writable )
		{
		}

		[Constructable]
		public BrownBookSoixanteQuinze( string title, string author, int pageCount, bool writable ) : base( 0xFF2, title, author, pageCount, writable )
		{
		}

		public BrownBookSoixanteQuinze( Serial serial ) : base( serial )
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