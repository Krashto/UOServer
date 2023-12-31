using System.Linq;
using Server.Mobiles;
using Server.Network;

namespace Server.Gumps
{
  public class CreationRaceGump : CreationBaseGump
    {
        public CreationRaceGump(CustomPlayerMobile from, CreationPerso creationPerso) : base(from, creationPerso, "Choix de la race", false, creationPerso.Race != null)
        {
            int x = XBase;
            int y = YBase;
            int line = 0;
            int scale = 21;

            AddSection(x - 10, y, 300, 357, "Races");
			AddSection(x + 291, y, 309, 357, "Apparence");

			var allRaces = Race.AllRaces.OrderBy(f => f.Name);

			foreach (Race race in allRaces)
            {
				string color = race == creationPerso.Race ? "#FFCC00" : "#FFFFFF";
				AddButtonHtml(x + 20, y + scale * line++ + 50, race.Name, 200, 40, race.RaceID + 100, color);
            }

            if (creationPerso.Race != null)
            {
                AddBackground(x + 325, y + 20, 200, 250,2629);// -- Le noire est pas un pure noire, alors sa fait pas ... Transformer en pure noire dans les gumps ? ? 
                m_Creation.Hue = creationPerso.Hue == -1 ? creationPerso.Race.SkinHues[0] : creationPerso.Hue;
                AddImage(x + 355, y + 30, creationPerso.Race.GetGumpId(creationPerso.Female, m_Creation.Hue - 1), m_Creation.Hue - 1);
                AddColorChoice(x + 435 - creationPerso.Race.SkinHues.Length * 9, y + 275, 10, creationPerso.Race.SkinHues);
            }
            else
                AddImage(x + 375, y + 80, 495); // Mettre en else du if suivant..

            string raceName = "Aucune";
            string raceBackground = "Aucune race selectionnée";

            if (m_Creation.Race != null)
            {
                raceName = m_Creation.Race.Name;
                raceBackground = m_Creation.Race.Background;
            }

            AddSection(x - 10, y + 358, 610, 250, raceName, raceBackground);
        }
        public override void OnResponse(NetState sender, RelayInfo info)
        {
			CustomPlayerMobile from = (CustomPlayerMobile)sender.Mobile;

			if (from.Deleted || !from.Alive)
				return;

            if (info.ButtonID >= 10 && info.ButtonID < 100)
            {
                m_Creation.Hue = m_Creation.Race.SkinHues[info.ButtonID - 10];
                from.SendGump(new CreationRaceGump(from, m_Creation));
            }
            else if (info.ButtonID >= 100 && info.ButtonID < 1000)
            {
                m_Creation.Race = (BaseRace)Race.GetRace(info.ButtonID - 100);
                from.SendGump(new CreationRaceGump(from, m_Creation));
            }
            else if (info.ButtonID == 1001) //Next
            {
                from.SendGump(new InfoGeneralGump(from,m_Creation));
            }
        }
    }
}
