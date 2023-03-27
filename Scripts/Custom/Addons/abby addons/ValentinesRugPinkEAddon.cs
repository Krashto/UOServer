
////////////////////////////////////////
//                                    //
//   Generated by CEO's YAAAG - V1.2  //
// (Yet Another Arya Addon Generator) //
//                                    //
////////////////////////////////////////
using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class ValentinesRugPinkEAddon : BaseAddon
	{
         
            
		public override BaseAddonDeed Deed
		{
			get
			{
				return new ValentinesRugPinkEAddonDeed();
			}
		}

		[ Constructable ]
		public ValentinesRugPinkEAddon()
		{



			AddComplexComponent( (BaseAddon) this, 2730, 0, -1, 0, 31, -1, "", 1);// 1
			AddComplexComponent( (BaseAddon) this, 2730, 1, -1, 0, 31, -1, "", 1);// 2
			AddComplexComponent( (BaseAddon) this, 2734, -1, -1, 0, 31, -1, "", 1);// 3
			AddComplexComponent( (BaseAddon) this, 2735, 2, -1, 0, 31, -1, "", 1);// 4
			AddComplexComponent( (BaseAddon) this, 2755, -2, -2, 0, 31, -1, "", 1);// 5
			AddComplexComponent( (BaseAddon) this, 2757, 3, -2, 0, 31, -1, "", 1);// 6
			AddComplexComponent( (BaseAddon) this, 2806, -2, -1, 0, 31, -1, "", 1);// 7
			AddComplexComponent( (BaseAddon) this, 2807, -1, -2, 0, 31, -1, "", 1);// 8
			AddComplexComponent( (BaseAddon) this, 2807, 2, -2, 0, 31, -1, "", 1);// 9
			AddComplexComponent( (BaseAddon) this, 2807, 1, -2, 0, 31, -1, "", 1);// 10
			AddComplexComponent( (BaseAddon) this, 2807, 0, -2, 0, 31, -1, "", 1);// 11
			AddComplexComponent( (BaseAddon) this, 2808, 3, -1, 0, 31, -1, "", 1);// 12
			AddComplexComponent( (BaseAddon) this, 5287, 0, 0, 0, 31, -1, "", 1);// 13
			AddComplexComponent( (BaseAddon) this, 5288, 0, 1, 0, 31, -1, "", 1);// 14
			AddComplexComponent( (BaseAddon) this, 5289, 1, 1, 0, 31, -1, "", 1);// 15
			AddComplexComponent( (BaseAddon) this, 5290, 1, 0, 0, 31, -1, "", 1);// 16
			AddComplexComponent( (BaseAddon) this, 2731, 2, 0, 0, 31, -1, "", 1);// 17
			AddComplexComponent( (BaseAddon) this, 2731, 2, 1, 0, 31, -1, "", 1);// 18
			AddComplexComponent( (BaseAddon) this, 2732, 1, 2, 0, 31, -1, "", 1);// 19
			AddComplexComponent( (BaseAddon) this, 2732, 0, 2, 0, 31, -1, "", 1);// 20
			AddComplexComponent( (BaseAddon) this, 2733, -1, 0, 0, 31, -1, "", 1);// 21
			AddComplexComponent( (BaseAddon) this, 2733, -1, 1, 0, 31, -1, "", 1);// 22
			AddComplexComponent( (BaseAddon) this, 2736, 2, 2, 0, 31, -1, "", 1);// 23
			AddComplexComponent( (BaseAddon) this, 2737, -1, 2, 0, 31, -1, "", 1);// 24
			AddComplexComponent( (BaseAddon) this, 2754, 3, 3, 0, 31, -1, "", 1);// 25
			AddComplexComponent( (BaseAddon) this, 2756, -2, 3, 0, 31, -1, "", 1);// 26
			AddComplexComponent( (BaseAddon) this, 2806, -2, 0, 0, 31, -1, "", 1);// 27
			AddComplexComponent( (BaseAddon) this, 2806, -2, 1, 0, 31, -1, "", 1);// 28
			AddComplexComponent( (BaseAddon) this, 2806, -2, 2, 0, 31, -1, "", 1);// 29
			AddComplexComponent( (BaseAddon) this, 2808, 3, 0, 0, 31, -1, "", 1);// 30
			AddComplexComponent( (BaseAddon) this, 2808, 3, 1, 0, 31, -1, "", 1);// 31
			AddComplexComponent( (BaseAddon) this, 2808, 3, 2, 0, 31, -1, "", 1);// 32
			AddComplexComponent( (BaseAddon) this, 2809, -1, 3, 0, 31, -1, "", 1);// 33
			AddComplexComponent( (BaseAddon) this, 2809, 0, 3, 0, 31, -1, "", 1);// 34
			AddComplexComponent( (BaseAddon) this, 2809, 1, 3, 0, 31, -1, "", 1);// 35
			AddComplexComponent( (BaseAddon) this, 2809, 2, 3, 0, 31, -1, "", 1);// 36

		}

		public ValentinesRugPinkEAddon( Serial serial ) : base( serial )
		{
		}

        private static void AddComplexComponent(BaseAddon addon, int item, int xoffset, int yoffset, int zoffset, int hue, int lightsource)
        {
            AddComplexComponent(addon, item, xoffset, yoffset, zoffset, hue, lightsource, null, 1);
        }

        private static void AddComplexComponent(BaseAddon addon, int item, int xoffset, int yoffset, int zoffset, int hue, int lightsource, string name, int amount)
        {
            AddonComponent ac;
            ac = new AddonComponent(item);
            if (name != null && name.Length > 0)
                ac.Name = name;
            if (hue != 0)
                ac.Hue = hue;
            if (amount > 1)
            {
                ac.Stackable = true;
                ac.Amount = amount;
            }
            if (lightsource != -1)
                ac.Light = (LightType) lightsource;
            addon.AddComponent(ac, xoffset, yoffset, zoffset);
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

	public class ValentinesRugPinkEAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new ValentinesRugPinkEAddon();
			}
		}

		[Constructable]
		public ValentinesRugPinkEAddonDeed()
		{
			Name = "ValentinesRugPinkE";
		}

		public ValentinesRugPinkEAddonDeed( Serial serial ) : base( serial )
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