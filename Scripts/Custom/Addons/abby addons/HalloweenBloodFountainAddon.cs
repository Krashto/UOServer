// Automatically generated by the
// AddonGenerator script by Arya
// Generator edited 10.Mar.07 by Papler
using System;
using Server;
using Server.Items;
namespace Server.Items
{
	public class HalloweenBloodFountainAddon : BaseAddon {
		public override BaseAddonDeed Deed{get{return new HalloweenBloodFountainAddonDeed();}}
		[ Constructable ]
		public HalloweenBloodFountainAddon()
		{
			AddonComponent ac = null;
			ac = new AddonComponent( 6045 );
			ac.Hue = 33;
			ac.Name = "blood";
			AddComponent( ac, 3, 4, 0 );

			ac = new AddonComponent( 6046 );
			ac.Hue = 33;
			ac.Name = "blood";
			AddComponent( ac, 3, 3, 0 );

			ac = new AddonComponent( 6053 );
			ac.Hue = 33;
			ac.Name = "blood";
			AddComponent( ac, 3, 2, 0 );

			ac = new AddonComponent( 7400 );
			AddComponent( ac, 2, 4, 1 );

			ac = new AddonComponent( 13422 );
			ac.Hue = 33;
			ac.Name = "blood";
			AddComponent( ac, 2, 4, 0 );

			ac = new AddonComponent( 13422 );
			ac.Hue = 33;
			ac.Name = "blood";
			AddComponent( ac, 2, 3, 0 );

			ac = new AddonComponent( 6057 );
			ac.Hue = 33;
			ac.Name = "blood";
			AddComponent( ac, 2, 2, 0 );

			ac = new AddonComponent( 7401 );
			AddComponent( ac, 2, 1, 16 );

			ac = new AddonComponent( 5696 );
			AddComponent( ac, 2, 1, 0 );

			ac = new AddonComponent( 6046 );
			ac.Hue = 33;
			ac.Name = "blood";
			AddComponent( ac, 2, 1, 0 );

			ac = new AddonComponent( 7374 );
			AddComponent( ac, 2, 1, 0 );

			ac = new AddonComponent( 7401 );
			AddComponent( ac, 2, 0, 16 );

			ac = new AddonComponent( 5696 );
			AddComponent( ac, 2, 0, 0 );

			ac = new AddonComponent( 7383 );
			ac.Name = "blood";
			AddComponent( ac, 2, 0, 0 );

			ac = new AddonComponent( 4310 );
			AddComponent( ac, 2, -1, 0 );

			ac = new AddonComponent( 7398 );
			AddComponent( ac, 2, -1, 0 );

			ac = new AddonComponent( 7368 );
			AddComponent( ac, 2, -1, 0 );

			ac = new AddonComponent( 7407 );
			AddComponent( ac, 2, -2, 2 );

			ac = new AddonComponent( 1874 );
			ac.Hue = 942;
			AddComponent( ac, 2, -2, 0 );

			ac = new AddonComponent( 6941 );
			AddComponent( ac, 2, -3, 2 );

			ac = new AddonComponent( 4313 );
			ac.Hue = 962;
			AddComponent( ac, 2, -3, 0 );

			ac = new AddonComponent( 6941 );
			AddComponent( ac, 2, -4, 0 );

			ac = new AddonComponent( 4306 );
			ac.Hue = 962;
			AddComponent( ac, 2, -4, 0 );

			ac = new AddonComponent( 13422 );
			ac.Hue = 33;
			ac.Name = "blood";
			AddComponent( ac, 1, 4, 0 );

			ac = new AddonComponent( 4310 );
			AddComponent( ac, 1, 3, 1 );

			ac = new AddonComponent( 7601 );
			AddComponent( ac, 1, 3, 1 );

			ac = new AddonComponent( 13422 );
			ac.Hue = 33;
			ac.Name = "blood";
			AddComponent( ac, 1, 3, 0 );

			ac = new AddonComponent( 13422 );
			ac.Hue = 33;
			AddComponent( ac, 1, 2, 0 );

			ac = new AddonComponent( 634 );
			ac.Hue = 962;
			AddComponent( ac, 1, 2, 0 );

			ac = new AddonComponent( 635 );
			ac.Hue = 942;
			AddComponent( ac, 1, 2, 0 );

			ac = new AddonComponent( 13422 );
			ac.Hue = 33;
			ac.Name = "blood";
			AddComponent( ac, 1, 1, 0 );

			ac = new AddonComponent( 633 );
			ac.Hue = 962;
			AddComponent( ac, 1, 1, 0 );

			ac = new AddonComponent( 13443 );
			ac.Hue = 33;
			AddComponent( ac, 1, 0, 0 );

			ac = new AddonComponent( 633 );
			ac.Hue = 942;
			AddComponent( ac, 1, 0, 0 );

			ac = new AddonComponent( 13443 );
			ac.Hue = 33;
			AddComponent( ac, 1, -1, 0 );

			ac = new AddonComponent( 636 );
			ac.Hue = 942;
			AddComponent( ac, 1, -1, 0 );

			ac = new AddonComponent( 1301 );
			AddComponent( ac, 1, -2, 5 );

			ac = new AddonComponent( 636 );
			ac.Hue = 942;
			AddComponent( ac, 1, -2, 0 );

			ac = new AddonComponent( 635 );
			ac.Hue = 942;
			AddComponent( ac, 1, -2, 0 );

			ac = new AddonComponent( 642 );
			ac.Hue = 962;
			AddComponent( ac, 1, -3, 0 );

			ac = new AddonComponent( 13443 );
			ac.Hue = 33;
			AddComponent( ac, 1, -3, 0 );

			ac = new AddonComponent( 631 );
			ac.Hue = 942;
			AddComponent( ac, 1, -3, 0 );

			ac = new AddonComponent( 642 );
			ac.Hue = 942;
			AddComponent( ac, 1, -4, 0 );

			ac = new AddonComponent( 641 );
			ac.Hue = 962;
			AddComponent( ac, 1, -5, 0 );

			ac = new AddonComponent( 7406 );
			AddComponent( ac, 0, 4, 1 );

			ac = new AddonComponent( 13422 );
			ac.Hue = 33;
			ac.Name = "blood";
			AddComponent( ac, 0, 4, 0 );

			ac = new AddonComponent( 13422 );
			ac.Hue = 33;
			ac.Name = "blood";
			AddComponent( ac, 0, 3, 0 );

			ac = new AddonComponent( 13422 );
			ac.Hue = 33;
			AddComponent( ac, 0, 2, 0 );

			ac = new AddonComponent( 632 );
			ac.Hue = 942;
			AddComponent( ac, 0, 2, 0 );

			ac = new AddonComponent( 7394 );
			AddComponent( ac, 0, 1, 1 );

			ac = new AddonComponent( 13422 );
			ac.Hue = 33;
			ac.Name = "blood";
			AddComponent( ac, 0, 1, 0 );

			ac = new AddonComponent( 7408 );
			AddComponent( ac, 0, 0, 1 );

			ac = new AddonComponent( 13443 );
			ac.Hue = 33;
			ac.Name = "blood";
			AddComponent( ac, 0, 0, 0 );

			ac = new AddonComponent( 4310 );
			AddComponent( ac, 0, -1, 1 );

			ac = new AddonComponent( 13443 );
			ac.Hue = 33;
			ac.Name = "blood";
			AddComponent( ac, 0, -1, 0 );

			ac = new AddonComponent( 7402 );
			AddComponent( ac, 0, -1, 0 );

			ac = new AddonComponent( 7408 );
			ac.Hue = 33;
			AddComponent( ac, 0, -2, 5 );

			ac = new AddonComponent( 1301 );
			AddComponent( ac, 0, -2, 5 );

			ac = new AddonComponent( 635 );
			ac.Hue = 942;
			AddComponent( ac, 0, -2, 0 );

			ac = new AddonComponent( 7584 );
			AddComponent( ac, 0, -3, 15 );

			ac = new AddonComponent( 13443 );
			ac.Hue = 33;
			AddComponent( ac, 0, -3, 0 );

			ac = new AddonComponent( 13579 );
			ac.Hue = 33;
			ac.Name = "blood";
			AddComponent( ac, 0, -3, 10 );

			ac = new AddonComponent( 631 );
			ac.Hue = 942;
			AddComponent( ac, 0, -3, 0 );

			ac = new AddonComponent( 6041 );
			ac.Hue = 33;
			ac.Name = "blood";
			AddComponent( ac, 0, -4, 0 );

			ac = new AddonComponent( 7408 );
			AddComponent( ac, 0, -4, 16 );

			ac = new AddonComponent( 13422 );
			ac.Hue = 33;
			ac.Name = "blood";
			AddComponent( ac, 0, -4, 15 );

			ac = new AddonComponent( 13422 );
			ac.Hue = 33;
			AddComponent( ac, 0, -4, 12 );

			ac = new AddonComponent( 641 );
			ac.Hue = 962;
			AddComponent( ac, 0, -5, 0 );

			ac = new AddonComponent( 7599 );
			AddComponent( ac, -1, 4, 1 );

			ac = new AddonComponent( 13422 );
			ac.Hue = 33;
			ac.Name = "blood";
			AddComponent( ac, -1, 4, 0 );

			ac = new AddonComponent( 7405 );
			AddComponent( ac, -1, 3, 1 );

			ac = new AddonComponent( 7588 );
			AddComponent( ac, -1, 3, 1 );

			ac = new AddonComponent( 13422 );
			ac.Hue = 33;
			ac.Name = "blood";
			AddComponent( ac, -1, 3, 0 );

			ac = new AddonComponent( 13422 );
			ac.Hue = 33;
			AddComponent( ac, -1, 2, 0 );

			ac = new AddonComponent( 631 );
			ac.Hue = 942;
			AddComponent( ac, -1, 2, 0 );

			ac = new AddonComponent( 7405 );
			AddComponent( ac, -1, 1, 1 );

			ac = new AddonComponent( 7587 );
			AddComponent( ac, -1, 1, 1 );

			ac = new AddonComponent( 13422 );
			ac.Hue = 33;
			ac.Name = "blood";
			AddComponent( ac, -1, 1, 0 );

			ac = new AddonComponent( 13443 );
			ac.Hue = 33;
			ac.Name = "blood";
			AddComponent( ac, -1, 0, 0 );

			ac = new AddonComponent( 13443 );
			ac.Hue = 33;
			ac.Name = "blood";
			AddComponent( ac, -1, -1, 0 );

			ac = new AddonComponent( 7398 );
			AddComponent( ac, -1, -1, 0 );

			ac = new AddonComponent( 7397 );
			AddComponent( ac, -1, -1, 0 );

			ac = new AddonComponent( 1301 );
			AddComponent( ac, -1, -2, 5 );

			ac = new AddonComponent( 632 );
			ac.Hue = 942;
			AddComponent( ac, -1, -2, 0 );

			ac = new AddonComponent( 13443 );
			ac.Hue = 33;
			AddComponent( ac, -1, -3, 0 );

			ac = new AddonComponent( 13579 );
			ac.Hue = 33;
			ac.Name = "blood";
			AddComponent( ac, -1, -3, 10 );

			ac = new AddonComponent( 631 );
			ac.Hue = 942;
			AddComponent( ac, -1, -3, 0 );

			ac = new AddonComponent( 7405 );
			AddComponent( ac, -1, -4, 16 );

			ac = new AddonComponent( 13422 );
			ac.Hue = 33;
			ac.Name = "blood";
			AddComponent( ac, -1, -4, 15 );

			ac = new AddonComponent( 13422 );
			ac.Hue = 33;
			AddComponent( ac, -1, -4, 0 );

			ac = new AddonComponent( 641 );
			ac.Hue = 962;
			AddComponent( ac, -1, -5, 0 );

			ac = new AddonComponent( 13422 );
			ac.Hue = 33;
			ac.Name = "blood";
			AddComponent( ac, -2, 4, 0 );

			ac = new AddonComponent( 13422 );
			ac.Hue = 33;
			ac.Name = "blood";
			AddComponent( ac, -2, 3, 0 );

			ac = new AddonComponent( 6060 );
			ac.Hue = 33;
			AddComponent( ac, -2, 2, 0 );

			ac = new AddonComponent( 636 );
			ac.Hue = 942;
			AddComponent( ac, -2, 2, 0 );

			ac = new AddonComponent( 633 );
			ac.Hue = 962;
			AddComponent( ac, -2, 1, 0 );

			ac = new AddonComponent( 633 );
			ac.Hue = 962;
			AddComponent( ac, -2, 0, 0 );

			ac = new AddonComponent( 634 );
			ac.Hue = 942;
			AddComponent( ac, -2, -1, 0 );

			ac = new AddonComponent( 1876 );
			ac.Hue = 942;
			AddComponent( ac, -2, -2, 0 );

			ac = new AddonComponent( 642 );
			ac.Hue = 942;
			AddComponent( ac, -2, -3, 0 );

			ac = new AddonComponent( 642 );
			ac.Hue = 962;
			AddComponent( ac, -2, -4, 0 );

			ac = new AddonComponent( 6051 );
			ac.Hue = 33;
			ac.Name = "blood";
			AddComponent( ac, -3, 4, 0 );

			ac = new AddonComponent( 6051 );
			ac.Hue = 33;
			ac.Name = "blood";
			AddComponent( ac, -3, 3, 0 );

			ac = new AddonComponent( 6054 );
			ac.Hue = 33;
			ac.Name = "blood";
			AddComponent( ac, -3, 2, 0 );

			ac = new AddonComponent( 6055 );
			ac.Hue = 33;
			ac.Name = "blood";
			AddComponent( ac, 3, 5, 0 );

			ac = new AddonComponent( 6058 );
			ac.Hue = 33;
			ac.Name = "blood";
			AddComponent( ac, 2, 5, 0 );

			ac = new AddonComponent( 13422 );
			ac.Hue = 33;
			AddComponent( ac, 1, 5, 0 );

			ac = new AddonComponent( 7390 );
			AddComponent( ac, 0, 5, 1 );

			ac = new AddonComponent( 13422 );
			ac.Hue = 33;
			AddComponent( ac, 0, 5, 0 );

			ac = new AddonComponent( 13422 );
			ac.Hue = 33;
			AddComponent( ac, -1, 5, 0 );

			ac = new AddonComponent( 6059 );
			ac.Hue = 33;
			ac.Name = "blood";
			AddComponent( ac, -2, 5, 0 );

			ac = new AddonComponent( 6056 );
			ac.Hue = 33;
			ac.Name = "blood";
			AddComponent( ac, -3, 5, 0 );


		}
		public HalloweenBloodFountainAddon( Serial serial ) : base( serial ){}
		public override void Serialize( GenericWriter writer ){base.Serialize( writer );writer.Write( 0 );}
		public override void Deserialize( GenericReader reader ){base.Deserialize( reader );reader.ReadInt();}
	}

	public class HalloweenBloodFountainAddonDeed : BaseAddonDeed {
		public override BaseAddon Addon{get{return new HalloweenBloodFountainAddon();}}
		[Constructable]
		public HalloweenBloodFountainAddonDeed(){Name = "HalloweenBloodFountain";}
		public HalloweenBloodFountainAddonDeed( Serial serial ) : base( serial ){}
		public override void Serialize( GenericWriter writer ){	base.Serialize( writer );writer.Write( 0 );}
		public override void	Deserialize( GenericReader reader )	{base.Deserialize( reader );reader.ReadInt();}
	}
}