using System.Linq;
using Server.Items;

namespace Server.Custom
{
	public class CustomUtility
	{
		public static int GetGoldAmountInBank(Mobile m)
		{
			var goldPiles = GetGoldPilesInBank(m);
			return goldPiles.Sum(f => f.Amount);
		}

		public static Item[] GetGoldPilesInBank(Mobile m)
		{
			var bankBox = m.BankBox;
			return bankBox.FindItemsByType(typeof(Gold));
		}

		public static bool ConsumeGoldInBank(Mobile m, int amount)
		{
			var goldPiles = GetGoldPilesInBank(m);
			var goldSum = GetGoldAmountInBank(m);

			if (goldPiles == null || goldSum < amount)
			{
				m.SendMessage("Vous n'avez pas les fonds suffisants dans votre coffre de banque.");
				return false;
			}

			int index = goldPiles.Length - 1;
			while (amount > 0 && index >= 0)
			{
				var gold = goldPiles[index];

				if (gold.Amount > amount)
				{
					gold.Amount -= amount;
					amount = 0;
				}
				else
				{
					amount -= gold.Amount;
					gold.Delete();
				}

				index--;
			}

			return amount <= 0;
		}
	}
}
