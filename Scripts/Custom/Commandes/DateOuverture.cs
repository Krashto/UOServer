using Server.Commands;
using Server.Gumps;

namespace Server.Scripts.Commands
{
    public class DateOuverture
    {
        public static void Initialize()
        {
            CommandSystem.Register("DateOuverture", AccessLevel.Administrator, new CommandEventHandler(DateOuverture_OnCommand));
        }

        [Usage("DateOuverture")]
        [Description("Permet de savoir la date d'ouverture")]
        public static void DateOuverture_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;
			from.SendGump(new DateOuvertureGump());
        }
    }
}