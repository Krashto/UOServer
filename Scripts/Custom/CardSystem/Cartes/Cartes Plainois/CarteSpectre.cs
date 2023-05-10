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
using Arya.Chess;
using static Server.HueData;

namespace Server.Items
{
	public class CarteSpectre : BaseCard
	{

		[Constructable]
		public CarteSpectre() : base()
		{
			Weight = 0.2;  // ?
			Name = "Diminution du cout en Mana";
			Hue = 1416;
		}

		public override bool CanEnchant(Item item, Mobile from)
		{
			if (item is BaseJewel)
			{
				return true;
			}
			


			from.SendMessage("Vous pouvez enchanter que les bijoux avec cette carte.");


			return base.CanEnchant(item, from);
		}

		public override void Enchant(Item item, Mobile from)
		{

			int augmentper = 3;

			if (item is BaseJewel Jewel)
			{
				Jewel.Attributes.LowerManaCost += augmentper;
			}


			base.Enchant(item, from);
		}


		public CarteSpectre(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}