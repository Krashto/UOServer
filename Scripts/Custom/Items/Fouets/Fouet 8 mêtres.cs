using System;

namespace Server.Items
{
	public class Fouet8 : Fouet
    {
		[Constructable]
        public Fouet8() : base(8)
		{
			Name = "Fouet (8 m)";
			Weight = 3;
		}

        public Fouet8(Serial serial) : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}