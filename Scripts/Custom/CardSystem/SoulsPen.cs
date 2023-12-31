using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class SoulsPen : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefSoulsCrafting.CraftSystem; } }

		[Constructable]
		public SoulsPen() : base( 0x10E7 )
		{
			Name = "Plume de reviviscence";
			Hue = 2962;
			Weight = 4.0;
		}

		[Constructable]
		public SoulsPen( int uses ) : base( uses, 0x10E7 )
		{
			Name = "Plume de reviviscence";
			Hue = 2962;
			Weight = 4.0;
		}

		public SoulsPen( Serial serial ) : base( serial )
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