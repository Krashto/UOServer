using System;
using Server.Network;
using Server.Mobiles;
using System.Collections.Generic;
using Server.Custom.Aptitudes;
using Server.Custom.Classes;
using Server.Items;

namespace Server.Gumps
{
    public class FicheGump : BaseProjectMGump
	{
        private CustomPlayerMobile m_From;
        private CustomPlayerMobile m_GM;

        public FicheGump(CustomPlayerMobile from, CustomPlayerMobile gm) : base("Fiche de personnage", 560, 622, false)
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

			AddSection(x - 10, y, 250, 180, "Informations");

			AddHtmlTexte(x +10, y + 40, 100, "Nom");
			AddHtmlTexte(x + 125, y + 40, 150, from.GetBaseName());

			AddHtmlTexte(x + 10, y + 60, 100, "Race");
			AddHtmlTexte(x + 125, y + 60, 150, from.Race.Name);

			AddHtmlTexte(x + 10, y + 80, 100, "Apparence:");
			AddHtmlTexte(x + 125, y + 80, 150, from.Apparence());

			AddHtmlTexte(x + 10, y + 100, 100, "Grandeur:");
			AddHtmlTexte(x + 125, y + 100, 150, from.GrandeurString());

			AddHtmlTexte(x + 10, y + 120, 100, "Grosseur:");
			AddHtmlTexte(x + 125, y + 120, 150, from.CorpulenceString());

			//201
			AddSection(x - 10, y+ 181, 250, 135, "Classes");

			AddHtmlTexte(x + 10, y + 220, 150, "Classe");
			AddHtmlTexte(x + 125, y + 220, 100,  m_From.Classe.ToString());
			var classeInfo = Classes.GetInfos(m_From.Classe);
			AddHtmlTexte(x + 10, y + 240, 150, "Branche");
			AddHtmlTexte(x + 125, y + 240, 100, classeInfo.ClasseMode.ToString());
			AddHtmlTexte(x + 10, y + 260, 150, "Niveau");
			AddHtmlTexte(x + 125, y + 260, 100, classeInfo.Level.ToString());

			// 402
			AddSection(x - 10, y + 317, 250, 135, "Expérience");

			AddHtmlTexte(x + 10, y + 355, 150, "Actuelle");
			AddHtmlTexte(x + 125, y + 355, 100, m_From.Experience.Exp.ToString());
			AddHtmlTexte(x + 10, y + 375, 150, "Restante");
			AddHtmlTexte(x + 125, y + 375, 100, m_From.Experience.ExpToGainBank.ToString());
			AddHtmlTexte(x + 10, y + 415, 150, "Heures jouées");
			AddHtmlTexte(x + 125, y + 415, 100, Math.Round(m_From.Account.TotalGameTime.TotalHours, 2).ToString());

			AddSection(x - 10, y + 453, 250, 210, "Statistique");

			AddHtmlTexte(x + 10, y + 490, 150, "Force");

			if (m_From.CanDecreaseStat(StatType.Str))
				AddButton(x + 100, y + 492, 5603, 5607, 300, GumpButtonType.Reply, 0);

			if (m_From.CanIncreaseStat(StatType.Str))
				AddButton(x + 160, y + 492, 5601, 5605, 301, GumpButtonType.Reply, 0);

			AddLabel(x + 130, y + 490, 150, m_From.Str.ToString());

			AddHtmlTexte(x + 10, y + 510, 150, "Dextérité");

			if (m_From.CanDecreaseStat(StatType.Dex))
				AddButton(x + 100, y + 512, 5603, 5607, 302, GumpButtonType.Reply, 0);

			if (m_From.CanIncreaseStat(StatType.Dex))
			  AddButton(x + 160, y + 512, 5601, 5605, 303, GumpButtonType.Reply, 0);
			
			AddLabel(x + 130, y + 510, 150, m_From.Dex.ToString());

			AddHtmlTexte(x + 10, y + 530, 150, "Intelligence");
		
			if (m_From.CanDecreaseStat(StatType.Int))
				AddButton(x + 100, y + 532, 5603, 5607, 304, GumpButtonType.Reply, 0);

			if (m_From.CanIncreaseStat(StatType.Int))
				AddButton(x + 160, y + 532, 5601, 5605, 305, GumpButtonType.Reply, 0);

			AddLabel(x + 130, y + 530, 150, m_From.Int.ToString());

			AddHtmlTexte(x + 10, y + 550, 150, "Constitution");

			if (m_From.Attributs.CanDecreaseStat(Attribut.Constitution))
				AddButton(x + 100, y + 552, 5603, 5607, 306, GumpButtonType.Reply, 0);

			if (m_From.Attributs.CanIncreaseStat(Attribut.Constitution))
				AddButton(x + 160, y + 552, 5601, 5605, 307, GumpButtonType.Reply, 0);

			AddLabel(x + 130, y + 550, 150, m_From.Attributs.Constitution.ToString());

			AddHtmlTexte(x + 10, y + 570, 150, "Sagesse");

			if (m_From.Attributs.CanDecreaseStat(Attribut.Sagesse))
				AddButton(x + 100, y + 572, 5603, 5607, 308, GumpButtonType.Reply, 0);

			if (m_From.Attributs.CanIncreaseStat(Attribut.Sagesse))
				AddButton(x + 160, y + 572, 5601, 5605, 309, GumpButtonType.Reply, 0);

			AddLabel(x + 130, y + 570, 150, m_From.Attributs.Sagesse.ToString());

			AddHtmlTexte(x + 10, y + 590, 150, "Endurance");

			if (m_From.Attributs.CanDecreaseStat(Attribut.Endurance))
				AddButton(x + 100, y + 592, 5603, 5607, 310, GumpButtonType.Reply, 0);

			if (m_From.Attributs.CanIncreaseStat(Attribut.Endurance))
				AddButton(x + 160, y + 592, 5601, 5605, 311, GumpButtonType.Reply, 0);

			AddLabel(x + 130, y + 590, 150, m_From.Attributs.Endurance.ToString());

			AddHtmlTexte(x + 10, y + 610, 150, "À placer");
			AddLabel(x + 130, y + 610, 150, (525 - m_From.RawStr - m_From.RawDex - m_From.RawInt - m_From.Attributs.Constitution - m_From.Attributs.Sagesse - m_From.Attributs.Endurance).ToString());

			AddSection(x + 241, y, 359, 452, "Talents");

			int line = 0;
			AddHtmlTexte(x + 261, y + 40 + line++ * 20, 300, "Disponible: " + Aptitudes.GetRemainingPA(m_From, m_From.Experience.Niveau) + " / Max: " + Aptitudes.GetMaxPA(m_From, m_From.Experience.Niveau));

			foreach (Aptitude apt in Enum.GetValues(typeof(Aptitude)))
			{
				AddHtmlTexte(x + 261, y + 40 + line * 20, 150, apt.ToString());

				AddLabel(x + 525, y + 40 + line * 20, 150, m_From.Aptitudes[apt].ToString());

				if (Aptitudes.CanLower(m_From, apt))
					AddButton(x + 500, y + 40 + line * 20, 5603, 5607, 100 + (int)apt, GumpButtonType.Reply, 0);

				if (Aptitudes.CanRaise(m_From, apt))
					AddButton(x + 550, y + 40 + line * 20, 5601, 5605, 200 + (int)apt, GumpButtonType.Reply, 0);

				line++;
			}
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
