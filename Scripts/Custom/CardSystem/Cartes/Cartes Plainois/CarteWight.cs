using System;
using System.Collections;
using System.Collections.Generic;
using Server.Multis;
using Server.Mobiles;
using Server.Network;
using Server.ContextMenus;
using Server.Spells;
using Server.Targeting;
using Server.Misc;

namespace Server.Items
{
	public class CarteWight : BaseCard
	{

		[Constructable]
		public CarteWight() : base()
		{
			Weight = 0.2;  // ?
			Name = "Carte Wight";
			Hue = 1940;
		}
		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);
			list.Add(String.Format("[Defense +2]"));
		}

		public override bool CanEnchant(Item item, Mobile from)
		{
			 if (item is BaseJewel)
			{
				return true;
			}
			

			from.SendMessage("Vous pouvez enchanter que les Bijoux avec cette carte.");

			return base.CanEnchant(item, from);
		}

		public override void Enchant(Item item, Mobile from)
		{

			int augmentper = 2;

			 if (item is BaseJewel Jewel)
			{			
				Jewel.Attributes.DefendChance += augmentper;				
			}


			base.Enchant(item, from);
		}


		public CarteWight( Serial serial ) : base( serial )
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