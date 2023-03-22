using System;
using Server.Network;
using Server.Custom;

namespace Server.Gumps
{
    public class DateOuvertureGump : BaseProjectMGump
	{
        public DateOuvertureGump() : base("Date Ouverture", 250, 200, true)
        {
			int x = XBase;
			int y = YBase;

			DateTime date = CustomPersistence.Ouverture;

			AddHtmlTexte(x +10, y + 20, 250, 60, "Determine la date d'ouverture du serveur pour le système d'expérience.");

			AddHtmlTexte(x + 10, y + 65, 150, "Jour");
			AddTextEntryBg(x + 100, y + 60, 150, 30, 0, 1, date.Day.ToString());

			AddHtmlTexte(x + 10, y + 105, 150, "Mois");
			AddTextEntryBg(x + 100, y + 100, 150, 30, 0, 2, date.Month.ToString());

			AddHtmlTexte(x + 10, y + 145, 150, "Année");
			AddTextEntryBg(x + 100, y + 140, 150, 30, 0, 3, date.Year.ToString());

			AddButton(x + 35, y + 180, 1, 1147);
			AddButton(x + 175, y + 180, 0, 1144);
		}

		public override void OnResponse(NetState sender, RelayInfo info)
        {
			Mobile from = sender.Mobile;

			switch (info.ButtonID)
			{
				case 1:
					{
						int day;
						if (!int.TryParse(info.GetTextEntry(1).Text, out day))
						{
							from.SendMessage("Le jours doit être un nombre de 0 à 31.");
							from.SendGump(new DateOuvertureGump());
							return;
						}
						else if (day < 1 || day > 31)
						{
							from.SendMessage("La cote doit être un nombre de 1 à 31.");
							from.SendGump(new DateOuvertureGump());
							return;
						}

						int month;
						if (!int.TryParse(info.GetTextEntry(2).Text, out month))
						{
							from.SendMessage("Le mois doit être un mois de 1 à 12.");
							from.SendGump(new DateOuvertureGump());
							return;
						}
						else if (month < 1 || month > 12)
						{
							from.SendMessage("Le mois doit être un nombre de 1 à 12.");
							from.SendGump(new DateOuvertureGump());
							return;
						}

						int year;
						if (!int.TryParse(info.GetTextEntry(3).Text, out year))
						{
							from.SendMessage("L'année doit être une année après 2022.");
							from.SendGump(new DateOuvertureGump());
							return;
						}
						else if (year < 2022)
						{
							from.SendMessage("L'année doit être une année après 2022.");
							from.SendGump(new DateOuvertureGump());
							return;
						}

						DateTime newdate;

						try
						{
							newdate = new DateTime(year, month, day);
							CustomPersistence.Ouverture = newdate;
						}
						catch (Exception)
						{
							from.SendMessage("Date invalide.");
							return;
						}

						break;
					}
			}
		}
    }
}
