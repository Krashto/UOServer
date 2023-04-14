using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Custom
{
	public class CustomUtility
	{
		public static Item GetRandomItemByBaseType(Type baseType)
		{
			var itemList = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(domainAssembly => domainAssembly.GetTypes())
				.Where(type => baseType.IsAssignableFrom(type) && /*type != baseType && */!type.IsAbstract/* && type.IsValueType && type.GetConstructor(Type.EmptyTypes) != null*/)
				.ToArray();

			var rnd = Utility.Random(0, itemList.Length - 1);
			var item = Activator.CreateInstance(itemList[rnd]) as Item;
			return item;
		}
		public static Item GetRandomItemFromList(List<Type> itemList)
		{
			var rnd = Utility.Random(0, itemList.Count - 1);
			var item = Activator.CreateInstance(itemList[rnd]) as Item;
			return item;
		}

		public static int GetItemAmountInBank(Mobile m, Type type)
		{
			var goldPiles = GetItemPilesInBank(m, type);
			return goldPiles.Sum(f => f.Amount);
		}

		public static Item[] GetItemPilesInBank(Mobile m, Type type)
		{
			var bankBox = m.BankBox;
			return bankBox.FindItemsByType(type);
		}

		public static bool ConsumeItemInBank(Mobile m, Type type, int amount)
		{
			var piles = GetItemPilesInBank(m, type);
			var qty = GetItemAmountInBank(m, type);

			if (piles == null || qty < amount)
			{
				var item = (Item)Activator.CreateInstance(type);
				if (!string.IsNullOrEmpty(item.Name))
					m.SendMessage($"Vous n'avez pas la quantité suffisante de {item.Name} dans votre coffre de banque.");
				else
					m.SendMessage($"Vous n'avez pas la quantité suffisante de {item.GetType()} dans votre coffre de banque.");
				item.Delete();
				return false;
			}

			int index = piles.Length - 1;
			while (amount > 0 && index >= 0)
			{
				var item = piles[index];

				if (item.Amount > amount)
				{
					item.Amount -= amount;
					amount = 0;
				}
				else
				{
					amount -= item.Amount;
					item.Delete();
				}

				index--;
			}

			return amount <= 0;
		}
	}
}
