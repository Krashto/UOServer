/////////////////////////////////////////////////
//                                             //
// Automatically generated by the              //
// AddonGenerator script by Arya               //
//                                             //
/////////////////////////////////////////////////
using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class MarketStandVegetablesSouthAddon : BaseAddon
	{
		public override BaseAddonDeed Deed
		{
			get
			{
				return new MarketStandVegetablesSouthAddonDeed();
			}
		}

		[ Constructable ]
		public MarketStandVegetablesSouthAddon()
		{
            AddonComponent ac;
			//AddComponent( new AddonComponent( 6786 ), 0, 4, 0 );
            ac = new AddonComponent(6786);
            AddComponent(ac, 0, 4, 0);
            ac.Name = "market stand";
			//AddComponent( new AddonComponent( 6787 ), 0, 1, 0 );
            ac = new AddonComponent(6787);
            AddComponent(ac, 0, 1, 0);
            ac.Name = "market stand";
			//AddComponent( new AddonComponent( 2938 ), 0, 1, 1 );
            ac = new AddonComponent(2938);
            AddComponent(ac, 0, 1, 1);
            ac.Name = "market stand";
            //AddComponent( new AddonComponent( 6787 ), 0, 3, 0 );
            ac = new AddonComponent(6787);
            AddComponent(ac, 0, 3, 0);
            ac.Name = "market stand";
            //AddComponent( new AddonComponent( 2938 ), 0, 3, 1 );
            ac = new AddonComponent(2938);
            AddComponent(ac, 0, 3, 1);
            ac.Name = "market stand";
            //AddComponent( new AddonComponent( 2938 ), 0, 2, 1 );
            ac = new AddonComponent(2938);
            AddComponent(ac, 0, 2, 1);
            ac.Name = "market stand";

			AddComponent( new AddonComponent( 3185 ), 0, 1, 7 );
			AddComponent( new AddonComponent( 3185 ), 0, 1, 3 );
			AddComponent( new AddonComponent( 3185 ), 0, 1, 5 );
			AddComponent( new AddonComponent( 3385 ), 0, 1, 7 );
			AddComponent( new AddonComponent( 3386 ), 0, 1, 8 );
			AddComponent( new AddonComponent( 3196 ), 0, 1, 3 );
			AddComponent( new AddonComponent( 3191 ), 0, 3, 2 );
			AddComponent( new AddonComponent( 3191 ), 0, 3, 3 );
			AddComponent( new AddonComponent( 3191 ), 0, 3, 5 );
			AddComponent( new AddonComponent( 3191 ), 0, 3, 6 );
			AddComponent( new AddonComponent( 3195 ), 0, 3, 0 );
			AddComponent( new AddonComponent( 3192 ), 0, 3, 3 );
			AddComponent( new AddonComponent( 3172 ), 0, 3, 7 );
			AddComponent( new AddonComponent( 3175 ), 0, 3, 5 );
            AddComponent( new AddonComponent( 3195 ), 0, 2, 7 );
			AddComponent( new AddonComponent( 3195 ), 0, 2, 4 );
			AddComponent( new AddonComponent( 3181 ), 0, 2, 5 );
			AddComponent( new AddonComponent( 3181 ), 0, 2, 3 );
			AddComponent( new AddonComponent( 3195 ), 0, 2, 9 );
			AddComponent( new AddonComponent( 3182 ), 0, 2, 8 );
			AddComponent( new AddonComponent( 3173 ), 0, 2, 7 );
			AddComponent( new AddonComponent( 3174 ), 0, 2, 9 );
			

		}

        public MarketStandVegetablesSouthAddon(Serial serial)
            : base(serial)
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

    public class MarketStandVegetablesSouthAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new MarketStandVegetablesSouthAddon();
			}
		}

		[Constructable]
		public MarketStandVegetablesSouthAddonDeed()
		{
			Name = "market stand south addon deed";
		}

        public MarketStandVegetablesSouthAddonDeed(Serial serial)
            : base(serial)
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