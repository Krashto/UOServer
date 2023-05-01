using System;

namespace Server.Items
{
	public class Fouet6 : Fouet
    {
		[Constructable]
        public Fouet6() : base(6)
		{
			Name = "Fouet (6 m)";
			Weight = 3;
		}

        public Fouet6(Serial serial) : base(serial)
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