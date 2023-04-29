using System;
using Server.Commands;
using Server.Items;

namespace Server.Scripts.Commands
{
    public class Anonyme
    {
        public static void Initialize()
        {
			CommandSystem.Register("Anonyme", AccessLevel.Player, new CommandEventHandler(Anonyme_OnCommand));
		}

		public static void Anonyme_OnCommand(CommandEventArgs e)
		{
            Mobile from = e.Mobile;

            if (!from.Alive)
                return;

			Item item = from.FindItemOnLayer(Layer.Helm);

			if (item is BaseArmor && ((BaseArmor)item).Anonymous || item is BaseFoulards || item is BaseClothing && ((BaseClothing)item).Anonymous)
			{
				if (string.IsNullOrEmpty(from.NameMod))
					from.NameMod = "Anonyme";
				else
					from.NameMod = null;
			}
			else
				from.SendMessage("Vous devez avoir un casque fermé ou un vêtement qui cache votre visage pour activer cette commande.");
        }
    }
}