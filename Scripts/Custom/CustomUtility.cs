using System;
using System.Linq;

namespace Server.Custom
{
	public class CustomUtility
	{
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
