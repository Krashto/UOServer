using System;
using Server;
using Server.Items;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;
using System.Collections.Generic;
using System.Reflection;
using System.Collections;
using Server.Custom.Packaging.Packages;

namespace Server.Items
{
	public class RecycleBag : Bag
	{
		private int m_ItemsTotal;
		private double m_WeightTotal;

		[Constructable]
		public RecycleBag()
	: this(Utility.RandomBlueHue())
		{
		}

		[Constructable]
		public RecycleBag(int hue)
		{
			Name = "Sac de Recyclage";
			Weight = 2.0;
			Hue = hue;
		}

		public override bool OnDragDrop(Mobile from, Item dropped)
		{
			if (!base.OnDragDrop(from, dropped))
				return false;
			if (dropped is Gold)
				return false;
			if (dropped is BaseContainer)
				seachbag(dropped, from);

			m_WeightTotal += dropped.Weight;
			dropped.Delete();

			Item item = new Marchandise();
			item.Amount = (int)dropped.Weight;
			from.AddToBackpack(item);

			return true;

			return true;
		}

		public override bool OnDragDropInto(Mobile from, Item item, Point3D p)
		{
			if (!base.OnDragDropInto(from, item, p))
				return false;
			if (item is Gold)
				return false;
			if (item.CheckNewbied() || item.Insured || item.PayedInsurance)
				return false;
			if (item is BaseContainer)
				seachbag(item, from);

			m_WeightTotal = item.Weight;
			item.Delete();

			Item newItem = new Marchandise();
			newItem.Amount = (int)item.Weight;
			from.AddToBackpack(newItem);

			return true;
		}

		private void seachbag(Item b, Mobile from)
		{
			BaseContainer bag = (BaseContainer)b;
			List<Item> items = bag.Items;
			List<Item> delme = new List<Item>();
			List<Item> movme = new List<Item>();
			foreach (Item i in items)
			{
				if (i is Gold || i.CheckNewbied() || i.Insured || i.PayedInsurance)
				{
					movme.Add(i);
					continue;
				}
				if (i is BaseContainer)
					seachbag(i, from);
				delme.Add(i);
			}

			foreach (Item i in movme)
			{
				if (!i.Deleted)
					from.PlaceInBackpack(i);
			}

			foreach (Item i in delme)
			{
				if (!i.Deleted)
				{
					m_WeightTotal += i.Weight;
					i.Delete();

					Item newItem = new Marchandise();
					newItem.Amount = (int)i.Weight;
					from.AddToBackpack(newItem);
				}
			}
		}



		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)m_ItemsTotal);
			writer.Write((int)0); // version 
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			m_ItemsTotal = reader.ReadInt();
		
			int version = reader.ReadInt();
			int count = reader.ReadInt();
			for (int i = 0; i < count; i++)
			{

			}
		}
	}
}
