// Automatically generated by the
// AddonGenerator script by Arya
// Generator edited 10.Mar.07 by Papler
using System;
using Server;
using Server.Items;
namespace Server.Items
{
	public class PottedColumbinePurpleAddon : BaseAddon {
		public override BaseAddonDeed Deed{get{return new PottedColumbinePurpleAddonDeed();}}
		[ Constructable ]
		public PottedColumbinePurpleAddon()
		{
			AddonComponent ac = null;
			ac = new AddonComponent( 7870 );
			ac.Hue = 16;
			ac.Name = "columbine";
			AddComponent( ac, 0, 0, 7 );

			ac = new AddonComponent( 3332 );
			ac.Name = "leaves";
			AddComponent( ac, 0, 0, 3 );

			ac = new AddonComponent( 4551 );
			ac.Name = "Potted Columbine";
			AddComponent( ac, 0, 0, 0 );


		}
		public PottedColumbinePurpleAddon( Serial serial ) : base( serial ){}
		public override void Serialize( GenericWriter writer ){base.Serialize( writer );writer.Write( 0 );}
		public override void Deserialize( GenericReader reader ){base.Deserialize( reader );reader.ReadInt();}
	}

	public class PottedColumbinePurpleAddonDeed : BaseAddonDeed {
		public override BaseAddon Addon{get{return new PottedColumbinePurpleAddon();}}
		[Constructable]
		public PottedColumbinePurpleAddonDeed(){Name = "PottedColumbinePurple";}
		public PottedColumbinePurpleAddonDeed( Serial serial ) : base( serial ){}
		public override void Serialize( GenericWriter writer ){	base.Serialize( writer );writer.Write( 0 );}
		public override void	Deserialize( GenericReader reader )	{base.Deserialize( reader );reader.ReadInt();}
	}
}