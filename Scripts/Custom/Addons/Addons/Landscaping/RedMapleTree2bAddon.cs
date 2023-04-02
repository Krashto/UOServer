/////////////////////////////////////////////////
//
// Automatically generated by the
// AddonGenerator script by Arya
//
/////////////////////////////////////////////////
using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class RedMapleTree2bAddon : BaseAddon
	{
		public override BaseAddonDeed Deed
		{
			get
			{
				return new RedMapleTree2bAddonDeed();
			}
		}

		[ Constructable ]
		public RedMapleTree2bAddon()
		{
			AddonComponent ac = null;
			ac = new AddonComponent( 9341 );
			AddComponent( ac, 0, 0, 0 );
			ac = new AddonComponent( 9337 );
			AddComponent( ac, 0, 0, 0 );

		}

		public RedMapleTree2bAddon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class RedMapleTree2bAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new RedMapleTree2bAddon();
			}
		}

		[Constructable]
		public RedMapleTree2bAddonDeed()
		{
			Name = "RedMapleTree2b";
		}

		public RedMapleTree2bAddonDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void	Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}