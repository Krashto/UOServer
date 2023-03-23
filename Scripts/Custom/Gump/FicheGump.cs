using System;
using Server.Network;
using Server.Mobiles;
using System.Collections.Generic;
using Server.Custom.Aptitudes;
using Server.Custom.Classes;
using Server.Items;
using System.Linq;
using Server.Custom.Capacites;

namespace Server.Gumps
{
    public class FicheGump : BaseProjectMGump
	{
        private CustomPlayerMobile m_From;
        private CustomPlayerMobile m_GM;

        public FicheGump(CustomPlayerMobile from, CustomPlayerMobile gm) : base("Fiche de personnage", 560, 660, false)
        {
            m_From = from;
            m_GM = gm;

			int x = XBase;
			int y = YBase;

			m_From.InvalidateProperties();

            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;

			int line = 0;
			int space = 20;

			AddSection(x - 10, y + space * line++, 250, space * 8 - 1, "Informations");
			line++;
			AddHtmlTexte(x +10, y + space * line, 100, "Nom");
			AddHtmlTexte(x + 125, y + space * line++, 150, from.GetBaseName());

			AddHtmlTexte(x + 10, y + space * line, 100, "Race");
			AddHtmlTexte(x + 125, y + space * line++, 150, from.Race.Name);

			AddHtmlTexte(x + 10, y + space * line, 100, "Apparence:");
			AddHtmlTexte(x + 125, y + space * line++, 150, from.Apparence());

			AddHtmlTexte(x + 10, y + space * line, 100, "Grandeur:");
			AddHtmlTexte(x + 125, y + space * line++, 150, from.GrandeurString());

			AddHtmlTexte(x + 10, y + space * line, 100, "Grosseur:");
			AddHtmlTexte(x + 125, y + space * line++, 150, from.CorpulenceString());

			line++;

			AddSection(x - 10, y + space * line++, 250, space * 7 - 1, "Expérience");
			line++;
			AddHtmlTexte(x + 10, y + space * line, 150, "Niveau");
			AddHtmlTexte(x + 125, y + space * line++, 100, m_From.Experience.Niveau.ToString());
			AddHtmlTexte(x + 10, y + space * line, 150, "Actuelle");
			AddHtmlTexte(x + 125, y + space * line++, 100, m_From.Experience.Exp.ToString());
			AddHtmlTexte(x + 10, y + space * line, 150, "Restante");
			AddHtmlTexte(x + 125, y + space * line++, 100, m_From.Experience.ExpToGainBank.ToString());
			AddHtmlTexte(x + 10, y + space * line, 150, "Heures jouées");
			AddHtmlTexte(x + 125, y + space * line++, 100, Math.Round(m_From.Account.TotalGameTime.TotalHours, 2).ToString());

			line++;

			AddSection(x - 10, y + space * line++, 250, space * 10 - 1, "Capacités");
			line++;
			foreach (Capacite cap in Enum.GetValues(typeof(Capacite)))
			{
				AddHtmlTexte(x + 10, y + space * line, 150, cap.ToString());
				AddHtmlTexte(x + 125, y + space * line++, 100, m_From.GetCapaciteValue(cap).ToString());
			}

			line++;

			AddSection(x - 10, y + space * line++, 250, space * 10 - 1, "Statistique");
			line++;

			AddHtmlTexte(x + 10, y + space * line, 150, "Force");

			if (m_From.CanDecreaseStat(StatType.Str))
				AddButton(x + 120, y + space * line + 2, 5603, 5607, 300, GumpButtonType.Reply, 0);

			if (m_From.CanIncreaseStat(StatType.Str))
				AddButton(x + 180, y + space * line + 2, 5601, 5605, 301, GumpButtonType.Reply, 0);

			AddLabel(x + 150, y + space * line++, 150, m_From.Str.ToString());

			AddHtmlTexte(x + 10, y + space * line, 150, "Dextérité");

			if (m_From.CanDecreaseStat(StatType.Dex))
				AddButton(x + 120, y + space * line + 2, 5603, 5607, 302, GumpButtonType.Reply, 0);

			if (m_From.CanIncreaseStat(StatType.Dex))
				AddButton(x + 180, y + space * line + 2, 5601, 5605, 303, GumpButtonType.Reply, 0);

			AddLabel(x + 150, y + space * line++, 150, m_From.Dex.ToString());

			AddHtmlTexte(x + 10, y + space * line, 150, "Intelligence");

			if (m_From.CanDecreaseStat(StatType.Int))
				AddButton(x + 120, y + space * line + 2, 5603, 5607, 304, GumpButtonType.Reply, 0);

			if (m_From.CanIncreaseStat(StatType.Int))
				AddButton(x + 180, y + space * line + 2, 5601, 5605, 305, GumpButtonType.Reply, 0);

			AddLabel(x + 150, y + space * line++, 150, m_From.Int.ToString());

			AddHtmlTexte(x + 10, y + space * line, 150, "Constitution");

			if (m_From.Attributs.CanDecreaseStat(Attribut.Constitution))
				AddButton(x + 120, y + space * line + 2, 5603, 5607, 306, GumpButtonType.Reply, 0);

			if (m_From.Attributs.CanIncreaseStat(Attribut.Constitution))
				AddButton(x + 180, y + space * line + 2, 5601, 5605, 307, GumpButtonType.Reply, 0);

			AddLabel(x + 150, y + space * line++, 150, m_From.Attributs.Constitution.ToString());

			AddHtmlTexte(x + 10, y + space * line, 150, "Endurance");

			if (m_From.Attributs.CanDecreaseStat(Attribut.Endurance))
				AddButton(x + 120, y + space * line + 2, 5603, 5607, 310, GumpButtonType.Reply, 0);

			if (m_From.Attributs.CanIncreaseStat(Attribut.Endurance))
				AddButton(x + 180, y + space * line + 2, 5601, 5605, 311, GumpButtonType.Reply, 0);

			AddLabel(x + 150, y + space * line++, 150, m_From.Attributs.Endurance.ToString());

			AddHtmlTexte(x + 10, y + space * line, 150, "Sagesse");

			if (m_From.Attributs.CanDecreaseStat(Attribut.Sagesse))
				AddButton(x + 120, y + space * line + 2, 5603, 5607, 308, GumpButtonType.Reply, 0);

			if (m_From.Attributs.CanIncreaseStat(Attribut.Sagesse))
				AddButton(x + 180, y + space * line + 2, 5601, 5605, 309, GumpButtonType.Reply, 0);

			AddLabel(x + 150, y + space * line++, 150, m_From.Attributs.Sagesse.ToString());

			AddHtmlTexte(x + 10, y + space * line, 150, "À placer");
			AddLabel(x + 150, y + space * line, 150, (525 - m_From.RawStr - m_From.RawDex - m_From.RawInt - m_From.Attributs.Constitution - m_From.Attributs.Sagesse - m_From.Attributs.Endurance).ToString());

			line = 0;
			AddSection(x + 241, y + space * line++, 359, space * 23 - 1, "Talents");
			line++;
			AddHtmlTexte(x + 261, y + space * line++, 300, "Disponible: " + Aptitudes.GetRemainingPA(m_From, m_From.Experience.Niveau) + " / Max: " + Aptitudes.GetMaxPA(m_From.Experience.Niveau));

			foreach (Aptitude apt in Enum.GetValues(typeof(Aptitude)))
			{
				AddHtmlTexte(x + 261, y + space * line, 150, apt.ToString());

				AddLabel(x + 525, y + space * line, 150, m_From.Aptitudes.GetValue(apt).ToString());

				if (Aptitudes.CanLower(m_From, apt))
					AddButton(x + 500, y + space * line + 2, 5603, 5607, 100 + (int)apt, GumpButtonType.Reply, 0);

				if (Aptitudes.CanRaise(m_From, apt))
					AddButton(x + 550, y + space * line + 2, 5601, 5605, 200 + (int)apt, GumpButtonType.Reply, 0);

				line++;
			}

			line++;
			line++;
			AddSection(x + 241, y + space * line++, 359, space * 12 - 1, "Classes");
			line++;
			AddHtmlTexte(x + 261, y + space * line, 150, "Classe");
			AddHtmlTexte(x + 525, y + space * line++, 100, m_From.Classe.ToString());
			var info = Classes.GetInfos(m_From.Classe);
			AddHtmlTexte(x + 261, y + space * line++, 150, "Aptitudes");
			if (info.Aptitudes.Length > 0)
			{
				foreach (var apt in info.Aptitudes)
				{
					AddHtmlTexte(x + 270, y + space * line, 150, apt.ToString());
					AddHtmlTexte(x + 525, y + space * line++, 100, apt.Value.ToString());
				}
			}
			else
				AddHtmlTexte(x + 261, y + space * line++, 100, "Aucune");

			AddHtmlTexte(x + 261, y + space * line++, 150, "Capacités");
			if (info.Capacites.Length > 0)
			{
				foreach (var cap in info.Capacites)
				{
					AddHtmlTexte(x + 270, y + space * line, 150, cap.ToString());
					AddHtmlTexte(x + 525, y + space * line++, 100, cap.Value.ToString());
				}
			}
			else
				AddHtmlTexte(x + 261, y + space * line++, 100, "Aucune");
		}

		public override void OnResponse(NetState sender, RelayInfo info)
        {
			if (info.ButtonID >= 100 && info.ButtonID < 200)
			{
				var apt = (Aptitude)(info.ButtonID - 100);
				if (Aptitudes.CanLower(m_From, apt))
				{
					m_From.Aptitudes[apt]--;
					Classes.SetBaseAndCapSkills(m_From, m_From.Experience.Niveau);
				}

				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID >= 200 && info.ButtonID < 300)
			{
				var apt = (Aptitude)(info.ButtonID - 200);
				if (Aptitudes.CanRaise(m_From, apt))
				{
					m_From.Aptitudes[apt]++;
					Classes.SetBaseAndCapSkills(m_From, m_From.Experience.Niveau);
				}

				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 300)
			{
				m_From.DecreaseStat(StatType.Str);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 301)
			{
				m_From.IncreaseStat(StatType.Str);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 302)
			{
				m_From.DecreaseStat(StatType.Dex);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 303)
			{
				m_From.IncreaseStat(StatType.Dex);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 304)
			{
				m_From.DecreaseStat(StatType.Int);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 305)
			{
				m_From.IncreaseStat(StatType.Int);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 306)
			{
				m_From.Attributs.DecreaseStat(Attribut.Constitution);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 307)
			{
				m_From.Attributs.IncreaseStat(Attribut.Constitution);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 308)
			{
				m_From.Attributs.DecreaseStat(Attribut.Sagesse);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 309)
			{
				m_From.Attributs.IncreaseStat(Attribut.Sagesse);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 310)
			{
				m_From.Attributs.DecreaseStat(Attribut.Endurance);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 311)
			{
				m_From.Attributs.IncreaseStat(Attribut.Endurance);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
		}
    }
}
