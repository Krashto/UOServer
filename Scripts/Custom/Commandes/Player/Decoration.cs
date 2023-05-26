using Server.Gumps;
using Server.Commands;
using Server.Custom;

namespace Server.Scripts.Commands
{
    public class Decoration
    {
        public static void Initialize()
        {
            CommandSystem.Register("Decoration", AccessLevel.Player, new CommandEventHandler(Decoration_OnCommand));
        }

        [Usage("Decoration")]
        [Description("Permet l'acces aux joueurs de plusieurs commandes de decoration.")]
        public static void Decoration_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

			if (CustomUtility.IsInDungeonRegion(from.Location))
			{
				from.SendMessage("Vous ne pouvez pas utiliser cette commande dans les donjons !");
				return;
			}

			from.SendGump(new DecorationGump(from));
        }
    }
}
