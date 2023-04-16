using System;
using Server.Network;
using Server.Mobiles;
using Server.Custom.Aptitudes;
using Server.Custom.Classes;
using Server.Custom.Capacites;
using Server.Custom;
using Server.Items;
using Server.Custom.Packaging.Packages;

namespace Server.Gumps
{
    public class FicheGump : BaseProjectMGump
	{
        private CustomPlayerMobile m_From;
        private CustomPlayerMobile m_GM;

        public FicheGump(CustomPlayerMobile from, CustomPlayerMobile gm) : base("Fiche de personnage", 700, 460, false)
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
			int lineSpace = 20;
			int column = 0;
			int columnSpace = 251;

			#region Informations
			AddSection(x - 10 + columnSpace * column, y + lineSpace * line++, 250, lineSpace * 10 - 1, "Informations");
			line++;
			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 100, "Nom");
			AddHtmlTexte(x + 150 + columnSpace * column, y + lineSpace * line++, 150, from.GetBaseName());

			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 100, "Race");
			AddHtmlTexte(x + 150 + columnSpace * column, y + lineSpace * line++, 150, from.Race.Name);

			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 100, "Apparence");
			AddHtmlTexte(x + 150 + columnSpace * column, y + lineSpace * line++, 150, from.Apparence());

			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 100, "Grandeur");
			AddHtmlTexte(x + 150 + columnSpace * column, y + lineSpace * line++, 150, from.GrandeurString());

			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 100, "Grosseur");
			AddHtmlTexte(x + 150 + columnSpace * column, y + lineSpace * line++, 150, from.CorpulenceString());

			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 100, "Pièces d'or");
			AddHtmlTexte(x + 150 + columnSpace * column, y + lineSpace * line++, 150, CustomUtility.GetItemAmountInBank(m_From, typeof(Gold)).ToString());

			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 100, "Matériaux");
			AddHtmlTexte(x + 150 + columnSpace * column, y + lineSpace * line++, 150, CustomUtility.GetItemAmountInBank(m_From, typeof(Materiaux)).ToString());
			#endregion

			#region Experience
			AddSection(x - 10 + columnSpace * column, y + lineSpace * line++, 250, lineSpace * 7 - 1, "Expérience");
			line++;
			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 150, "Niveau");
			AddHtmlTexte(x + 150 + columnSpace * column, y + lineSpace * line++, 100, m_From.Experience.Niveau.ToString());
			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 150, "Actuelle");
			AddButton(x + 140 + columnSpace * column, y + lineSpace * line + 2, 2117, 2118, 400, GumpButtonType.Reply, 0);
			AddHtmlTexte(x + 150 + columnSpace * column, y + lineSpace * line++, 100, m_From.Experience.Exp.ToString());
			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 150, "À gagner");
			AddHtmlTexte(x + 150 + columnSpace * column, y + lineSpace * line++, 100, m_From.Experience.ExpToGainBank.ToString());
			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 150, "Heures jouées");
			AddHtmlTexte(x + 150 + columnSpace * column, y + lineSpace * line++, 100, Math.Round(m_From.Account.TotalGameTime.TotalHours, 2).ToString());
			#endregion

			#region Classe
			AddSection(x - 10 + columnSpace * column, y + lineSpace * line++, 250, lineSpace * 10 - 1, "Classes");
			line++;
			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 150, "Classe");
			AddHtmlTexte(x + 150 + columnSpace * column, y + lineSpace * line++, 100, m_From.Classe.ToString());
			var info = Classes.GetInfos(m_From.Classe);
			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line++, 150, "Aptitudes");

			if (info.Aptitudes.Length > 0)
			{
				foreach (var apt in info.Aptitudes)
				{
					AddHtmlTexte(x + 20 + columnSpace * column, y + lineSpace * line, 150, apt.Aptitude.ToString());
					AddHtmlTexte(x + 150 + columnSpace * column, y + lineSpace * line++, 100, apt.Value.ToString());
				}
			}
			else
				AddHtmlTexte(x + 20 + columnSpace * column, y + lineSpace * line++, 100, "Aucune");

			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line++, 150, "Capacités");

			if (info.Capacites.Length > 0)
			{
				foreach (var cap in info.Capacites)
				{
					AddHtmlTexte(x + 20 + columnSpace * column, y + lineSpace * line, 150, cap.Capacite.ToString());
					AddHtmlTexte(x + 150 + columnSpace * column, y + lineSpace * line++, 100, cap.Value.ToString());
				}
			}
			else
				AddHtmlTexte(x + 20 + columnSpace * column, y + lineSpace * line++, 100, "Aucune");
			#endregion

			column++;
			line = 0;

			#region Capacités
			AddSection(x - 10 + columnSpace * column, y + lineSpace * line++, 250, lineSpace * 14 - 1, "Capacités");
			line++;
			for (int i = 0; i < Enum.GetValues(typeof(Capacite)).Length; i++)
			{
				var capacite = (Capacite)i;
				if (m_From.Capacites.CanDecreaseStat(capacite))
					AddButton(x + 120 + columnSpace * column, y + lineSpace * line + 2, 5603, 5607, 500 + i, GumpButtonType.Reply, 0);
				AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 150, capacite.ToString());
				AddLabel(x + 150 + columnSpace * column, y + lineSpace * line, 150, m_From.Capacites[capacite].ToString());
				if (m_From.Capacites.CanIncreaseStat(capacite))
					AddButton(x + 180 + columnSpace * column, y + lineSpace * line + 2, 5601, 5605, 550 + i, GumpButtonType.Reply, 0);
				line++;
			}

			line++;
			line++;

			AddSection(x - 10 + columnSpace * column, y + lineSpace * line++, 250, lineSpace * 11 - 1, "Statistique");
			line++;

			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 150, "Force");

			if (m_From.CanDecreaseStat(StatType.Str, 10))
				AddButton(x + 100 + columnSpace * column, y + lineSpace * line + 2, 5603, 5607, 350, GumpButtonType.Reply, 0);
			if (m_From.CanDecreaseStat(StatType.Str, 1))
				AddButton(x + 120 + columnSpace * column, y + lineSpace * line + 2, 5603, 5607, 300, GumpButtonType.Reply, 0);

			if (m_From.CanIncreaseStat(StatType.Str, 1))
				AddButton(x + 180 + columnSpace * column, y + lineSpace * line + 2, 5601, 5605, 301, GumpButtonType.Reply, 0);
			if (m_From.CanIncreaseStat(StatType.Str, 10))
				AddButton(x + 200 + columnSpace * column, y + lineSpace * line + 2, 5601, 5605, 351, GumpButtonType.Reply, 0);

			AddLabel(x + 150 + columnSpace * column, y + lineSpace * line++, 150, m_From.Str.ToString());

			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 150, "Dextérité");

			if (m_From.CanDecreaseStat(StatType.Dex, 10))
				AddButton(x + 100 + columnSpace * column, y + lineSpace * line + 2, 5603, 5607, 352, GumpButtonType.Reply, 0);
			if (m_From.CanDecreaseStat(StatType.Dex, 1))
				AddButton(x + 120 + columnSpace * column, y + lineSpace * line + 2, 5603, 5607, 302, GumpButtonType.Reply, 0);

			if (m_From.CanIncreaseStat(StatType.Dex, 1))
				AddButton(x + 180 + columnSpace * column, y + lineSpace * line + 2, 5601, 5605, 303, GumpButtonType.Reply, 0);
			if (m_From.CanIncreaseStat(StatType.Dex, 10))
				AddButton(x + 200 + columnSpace * column, y + lineSpace * line + 2, 5601, 5605, 353, GumpButtonType.Reply, 0);

			AddLabel(x + 150 + columnSpace * column, y + lineSpace * line++, 150, m_From.Dex.ToString());

			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 150, "Intelligence");

			if (m_From.CanDecreaseStat(StatType.Int, 10))
				AddButton(x + 100 + columnSpace * column, y + lineSpace * line + 2, 5603, 5607, 354, GumpButtonType.Reply, 0);
			if (m_From.CanDecreaseStat(StatType.Int, 1))
				AddButton(x + 120 + columnSpace * column, y + lineSpace * line + 2, 5603, 5607, 304, GumpButtonType.Reply, 0);

			if (m_From.CanIncreaseStat(StatType.Int, 1))
				AddButton(x + 180 + columnSpace * column, y + lineSpace * line + 2, 5601, 5605, 305, GumpButtonType.Reply, 0);
			if (m_From.CanIncreaseStat(StatType.Int, 10))
				AddButton(x + 200 + columnSpace * column, y + lineSpace * line + 2, 5601, 5605, 355, GumpButtonType.Reply, 0);

			AddLabel(x + 150 + columnSpace * column, y + lineSpace * line++, 150, m_From.Int.ToString());

			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 150, "Constitution");

			if (m_From.Attributs.CanDecreaseStat(Attribut.Constitution, 10))
				AddButton(x + 100 + columnSpace * column, y + lineSpace * line + 2, 5603, 5607, 356, GumpButtonType.Reply, 0);
			if (m_From.Attributs.CanDecreaseStat(Attribut.Constitution, 1))
				AddButton(x + 120 + columnSpace * column, y + lineSpace * line + 2, 5603, 5607, 306, GumpButtonType.Reply, 0);

			if (m_From.Attributs.CanIncreaseStat(Attribut.Constitution, 1))
				AddButton(x + 180 + columnSpace * column, y + lineSpace * line + 2, 5601, 5605, 307, GumpButtonType.Reply, 0);
			if (m_From.Attributs.CanIncreaseStat(Attribut.Constitution, 10))
				AddButton(x + 200 + columnSpace * column, y + lineSpace * line + 2, 5601, 5605, 357, GumpButtonType.Reply, 0);

			AddLabel(x + 150 + columnSpace * column, y + lineSpace * line++, 150, m_From.Attributs.Constitution.ToString());

			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 150, "Endurance");

			if (m_From.Attributs.CanDecreaseStat(Attribut.Endurance, 10))
				AddButton(x + 100 + columnSpace * column, y + lineSpace * line + 2, 5603, 5607, 358, GumpButtonType.Reply, 0);
			if (m_From.Attributs.CanDecreaseStat(Attribut.Endurance, 1))
				AddButton(x + 120 + columnSpace * column, y + lineSpace * line + 2, 5603, 5607, 308, GumpButtonType.Reply, 0);

			if (m_From.Attributs.CanIncreaseStat(Attribut.Endurance, 1))
				AddButton(x + 180 + columnSpace * column, y + lineSpace * line + 2, 5601, 5605, 309, GumpButtonType.Reply, 0);
			if (m_From.Attributs.CanIncreaseStat(Attribut.Endurance, 10))
				AddButton(x + 200 + columnSpace * column, y + lineSpace * line + 2, 5601, 5605, 359, GumpButtonType.Reply, 0);

			AddLabel(x + 150 + columnSpace * column, y + lineSpace * line++, 150, m_From.Attributs.Endurance.ToString());

			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 150, "Sagesse");

			if (m_From.Attributs.CanDecreaseStat(Attribut.Sagesse, 10))
				AddButton(x + 100 + columnSpace * column, y + lineSpace * line + 2, 5603, 5607, 360, GumpButtonType.Reply, 0);
			if (m_From.Attributs.CanDecreaseStat(Attribut.Sagesse, 1))
				AddButton(x + 120 + columnSpace * column, y + lineSpace * line + 2, 5603, 5607, 310, GumpButtonType.Reply, 0);

			if (m_From.Attributs.CanIncreaseStat(Attribut.Sagesse, 1))
				AddButton(x + 180 + columnSpace * column, y + lineSpace * line + 2, 5601, 5605, 311, GumpButtonType.Reply, 0);
			if (m_From.Attributs.CanIncreaseStat(Attribut.Sagesse, 10))
				AddButton(x + 200 + columnSpace * column, y + lineSpace * line + 2, 5601, 5605, 361, GumpButtonType.Reply, 0);

			AddLabel(x + 150 + columnSpace * column, y + lineSpace * line++, 150, m_From.Attributs.Sagesse.ToString());

			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 150, "Points restants");
			AddLabel(x + 150 + columnSpace * column, y + lineSpace * line, 150, (525 - m_From.RawStr - m_From.RawDex - m_From.RawInt - m_From.Attributs.Constitution - m_From.Attributs.Sagesse - m_From.Attributs.Endurance).ToString());
			#endregion

			column++;
			line = 0;

			#region Aptitudes
			AddSection(x - 10 + columnSpace * column, y + lineSpace * line++, 250, lineSpace * 23 - 1, "Aptitudes");
			line++;
			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 100, $"Disponible");
			AddHtmlTexte(x + 125 + columnSpace * column, y + lineSpace * line++, 100, $"{Aptitudes.GetRemainingPA(m_From, m_From.Experience.Niveau)} / {Aptitudes.GetMaxPA(m_From.Experience.Niveau)} (Max)");

			foreach (Aptitude apt in Enum.GetValues(typeof(Aptitude)))
			{
				AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 150, apt.ToString());

				AddLabel(x + 150 + columnSpace * column, y + lineSpace * line, 150, m_From.Aptitudes.GetValue(apt).ToString());

				if (Aptitudes.CanLower(m_From, apt))
					AddButton(x + 120 + columnSpace * column, y + lineSpace * line + 2, 5603, 5607, 100 + (int)apt, GumpButtonType.Reply, 0);

				if (Aptitudes.CanRaise(m_From, apt))
					AddButton(x + 175 + columnSpace * column, y + lineSpace * line + 2, 5601, 5605, 200 + (int)apt, GumpButtonType.Reply, 0);

				line++;
			}
			#endregion
		}

		public override void OnResponse(NetState sender, RelayInfo info)
        {
			if (info.ButtonID >= 100 && info.ButtonID < 200)
			{
				if (CustomUtility.ConsumeItemInBank(m_From, typeof(Gold), 1000))
				{
					var apt = (Aptitude)(info.ButtonID - 100);
					if (Aptitudes.CanLower(m_From, apt))
					{
						m_From.Aptitudes[apt]--;
						Classes.SetBaseAndCapSkills(m_From, m_From.Experience.Niveau);
					}
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
				if (CustomUtility.ConsumeItemInBank(m_From, typeof(Gold), 100))
					m_From.DecreaseStat(StatType.Str, 1);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 301)
			{
				m_From.IncreaseStat(StatType.Str, 1);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 302)
			{
				if (CustomUtility.ConsumeItemInBank(m_From, typeof(Gold), 100))
					m_From.DecreaseStat(StatType.Dex, 1);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 303)
			{
				m_From.IncreaseStat(StatType.Dex, 1);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 304)
			{
				if (CustomUtility.ConsumeItemInBank(m_From, typeof(Gold), 100))
					m_From.DecreaseStat(StatType.Int, 1);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 305)
			{
				m_From.IncreaseStat(StatType.Int, 1);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 306)
			{
				if (CustomUtility.ConsumeItemInBank(m_From, typeof(Gold), 100))
					m_From.Attributs.Decrease(Attribut.Constitution, 1);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 307)
			{
				m_From.Attributs.Increase(Attribut.Constitution, 1);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 308)
			{
				if (CustomUtility.ConsumeItemInBank(m_From, typeof(Gold), 100))
					m_From.Attributs.Decrease(Attribut.Endurance, 1);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 309)
			{
				m_From.Attributs.Increase(Attribut.Endurance, 1);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 310)
			{
				if (CustomUtility.ConsumeItemInBank(m_From, typeof(Gold), 100))
					m_From.Attributs.Decrease(Attribut.Sagesse, 1);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 311)
			{
				m_From.Attributs.Increase(Attribut.Sagesse, 1);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 350)
			{
				if (CustomUtility.ConsumeItemInBank(m_From, typeof(Gold), 100))
					m_From.DecreaseStat(StatType.Str, 10);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 351)
			{
				m_From.IncreaseStat(StatType.Str, 10);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 352)
			{
				if (CustomUtility.ConsumeItemInBank(m_From, typeof(Gold), 100))
					m_From.DecreaseStat(StatType.Dex, 10);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 353)
			{
				m_From.IncreaseStat(StatType.Dex, 10);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 354)
			{
				if (CustomUtility.ConsumeItemInBank(m_From, typeof(Gold), 100))
					m_From.DecreaseStat(StatType.Int, 10);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 355)
			{
				m_From.IncreaseStat(StatType.Int, 10);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 356)
			{
				if (CustomUtility.ConsumeItemInBank(m_From, typeof(Gold), 100))
					m_From.Attributs.Decrease(Attribut.Constitution, 10);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 357)
			{
				m_From.Attributs.Increase(Attribut.Constitution, 10);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 358)
			{
				if (CustomUtility.ConsumeItemInBank(m_From, typeof(Gold), 100))
					m_From.Attributs.Decrease(Attribut.Endurance, 10);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 359)
			{
				m_From.Attributs.Increase(Attribut.Endurance, 10);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 360)
			{
				if (CustomUtility.ConsumeItemInBank(m_From, typeof(Gold), 100))
					m_From.Attributs.Decrease(Attribut.Sagesse, 10);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 361)
			{
				m_From.Attributs.Increase(Attribut.Sagesse, 10);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 400)
			{
				m_From.SendGump(new PointsAncestrauxExchangeGump(m_From, m_GM));
			}
			else if (info.ButtonID >= 500 && info.ButtonID < 550)
			{
				if (CustomUtility.ConsumeItemInBank(m_From, typeof(Gold), 1000))
					m_From.Capacites.Decrease((Capacite)(info.ButtonID - 500));
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID >= 550 && info.ButtonID < 600)
			{
				m_From.Capacites.Increase((Capacite)(info.ButtonID - 550));
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
		}
    }
}
