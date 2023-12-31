using Server.Mobiles;
using Server.Network;
using Server.Accounting;

namespace Server.Gumps
{
  public class CreationRerollGump : CreationBaseGump
    {
        public CreationRerollGump(CustomPlayerMobile from, CreationPerso creationPerso) : base(from, creationPerso, "Transfert", true, true)
        {
            int x = XBase;
            int y = YBase;
            int line = 0;
            int scale = 25;
            int space = 115;

            AddSection(x - 10, y, 610, 470, "Transfert");     

            int Range = 0;

            int SpaceRanger = 50;

            Account acc = (Account)from.Account;

            for (int i = 0; i < 7; i++)
            {
                if (acc.Reroll.Count > i)
                {
                    Reroll rero = acc.Reroll[i];

                    string hueText = "#ffffff";

                    if (rero == creationPerso.Reroll)
                    {
                        hueText = "#ffcc00";
                    }

					AddButtonHtml(x + 5, y + 35 + SpaceRanger * Range, "Nom: " + rero.Name, 200, 25, Range + 100, hueText);
					AddHtmlTexteColored(x + 23, y + 35 + Range * SpaceRanger + 20, 200,  "Expériences: " + rero.Experience, hueText);
				}

                Range += 1;
            }
        
            string TransfertSelect = "Aucun transfert";

            if (creationPerso.Reroll != null)
                TransfertSelect = creationPerso.Reroll.Name + " \n\nExpériences: " + creationPerso.Reroll.Experience;

            AddSection(x - 10, y + 471, 610, 135, "Informations", TransfertSelect);
        }
        public override void OnResponse(NetState sender, RelayInfo info)
        {
           CustomPlayerMobile from = (CustomPlayerMobile)sender.Mobile;

            if (info.ButtonID >= 100 && info.ButtonID < 110)
            {
                Reroll newReroll = ((Account)from.Account).Reroll[info.ButtonID - 100];

                if (m_Creation.Reroll == newReroll)
                    m_Creation.Reroll = null;
                else
                    m_Creation.Reroll = newReroll;
                m_From.SendGump(new CreationRerollGump(from, m_Creation));
            }

			if (info.ButtonID == 1001)
            {
                from.SendGump(new CreationValidationGump(from, m_Creation));
            }
            else if (info.ButtonID == 1000 || info.ButtonID == 0)
            {
                //from.SendGump(new CreationGodGump(from, m_Creation));
            }
        }
    }
}
