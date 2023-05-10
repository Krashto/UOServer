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
	public class CarteSpectreAstral : BaseCard
	{

		[Constructable]
		public CarteSpectreAstral() : base()
		{
			Weight = 0.2;  // ?
			Name = "Chance de toucher";
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

			int augmentper = 2;

			if (item is BaseJewel Jewel)
			{				
				Jewel.Attributes.AttackChance += augmentper;								
			}

			base.Enchant(item, from);
		}

		public override bool DisplayLootType{ get{ return false; } }  // ha ha!

		public CarteSpectreAstral( Serial serial ) : base( serial )
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