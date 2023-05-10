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
	public class CarteLicheAncienne : BaseCard
	{

		[Constructable]
		public CarteLicheAncienne() : base()
		{
			Weight = 0.2;  // ?
			Name = "R�sistance au froid";
			Hue = 2584;
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

			int augmentper = 4;

			if (item is BaseJewel Jewel)
			{
				Jewel.Resistances.Cold += augmentper;
			}

			base.Enchant(item, from);
		}


		public CarteLicheAncienne(Serial serial) : base(serial)
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