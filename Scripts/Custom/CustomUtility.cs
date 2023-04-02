using System.Linq;
using Server.Items;

namespace Server.Custom
{
	public class CustomUtility
	{
		public static bool ConsumeGoldInBank(Mobile m, int amount)
		{
			var bankBox = m.BankBox;
			var goldPiles = bankBox.FindItemsByType(typeof(Gold));
			var goldSum = goldPiles.Sum(f => f.Amount);

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
