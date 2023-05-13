using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Server.Accounting;
using Server.Commands;
using Server.Items;

namespace Server.Custom.Commandes.GameMaster
{
	internal class GenerateAccounts
	{
		public static void Initialize()
		{
			CommandSystem.Register("GenerateAccounts", AccessLevel.Owner, new CommandEventHandler(GenerateAccounts_OnCommand));
		}

		[Usage("GenerateAccounts")]
		[Description("Permet de générer les accounts à partir d'un fichier texte")]
		public static void GenerateAccounts_OnCommand(CommandEventArgs e)
		{
			StreamReader sr = new StreamReader("Inscriptions.txt");
			string line = sr.ReadLine();

			while (line != null)
			{
				var split = line.Split(';');
				if (split.Length == 2)
				{
					string user = split[0];
					string password = split[1];

					if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(password))
					{
						var acc = new Account(user, password);
						Accounts.Add(acc);
					}
				}

				line = sr.ReadLine();
			}
		}
	}
}
