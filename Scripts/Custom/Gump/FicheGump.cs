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

		private int m_CapaciteDecreasingCost = 1000;
		private int m_StatsDecreasingCost = 100;
		private int m_AptitudesDecreasingCost = 1000;

		public FicheGump(CustomPlayerMobile from, CustomPlayerMobile gm) : base("Fiche de personnage", 730, 540, false)
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
			int columnSpace = 261;

			#region Informations
			AddSection(x - 10 + columnSpace * column, y + lineSpace * line++, columnSpace - 1, lineSpace * 10 - 1, "Informations");
			line++;
			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 100, "Nom");
			AddHtmlTexte(x + 115 + columnSpace * column, y + lineSpace * line++, 150, from.GetBaseName());

			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 100, "Race");
			AddHtmlTexte(x + 115 + columnSpace * column, y + lineSpace * line++, 150, from.Race.Name);

			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 100, "Apparence");
			AddHtmlTexte(x + 115 + columnSpace * column, y + lineSpace * line++, 150, from.Apparence());

			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 100, "Grandeur");
			AddHtmlTexte(x + 115 + columnSpace * column, y + lineSpace * line++, 150, from.GrandeurString());

			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 100, "Grosseur");
			AddHtmlTexte(x + 115 + columnSpace * column, y + lineSpace * line++, 150, from.CorpulenceString());

			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 100, "Pièces d'or");
			AddHtmlTexte(x + 115 + columnSpace * column, y + lineSpace * line++, 150, CustomUtility.GetItemAmountInBank(m_From, typeof(Gold)).ToString());

			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 100, "Matériaux");
			AddHtmlTexte(x + 115 + columnSpace * column, y + lineSpace * line++, 150, CustomUtility.GetItemAmountInBank(m_From, typeof(Materiaux)).ToString());
			#endregion

			line++;

			#region Experience
			AddSection(x - 10 + columnSpace * column, y + lineSpace * line++, columnSpace - 1, lineSpace * 7 - 1, "Expérience");
			line++;
			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 150, "Niveau");
			AddHtmlTexte(x + 115 + columnSpace * column, y + lineSpace * line++, 100, m_From.Experience.Niveau.ToString());
			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 150, "Actuelle");
			AddButton(x + 95 + columnSpace * column, y + lineSpace * line + 2, 2117, 2118, 400, GumpButtonType.Reply, 0);
			AddHtmlTexte(x + 115 + columnSpace * column, y + lineSpace * line++, 100, m_From.Experience.Exp.ToString());
			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 150, "À gagner");
			AddHtmlTexte(x + 115 + columnSpace * column, y + lineSpace * line++, 100, m_From.Experience.ExpToGainBank.ToString());
			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 150, "Heures jouées");
			AddHtmlTexte(x + 115 + columnSpace * column, y + lineSpace * line++, 100, Math.Round(m_From.Account.TotalGameTime.TotalHours, 2).ToString());
			#endregion

			line++;

			#region Classe
			AddSection(x - 10 + columnSpace * column, y + lineSpace * line++, columnSpace - 1, lineSpace * 12 - 1, "Classes");
			line++;
			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 150, "Classe");
			AddHtmlTexte(x + 115 + columnSpace * column, y + lineSpace * line++, 100, m_From.Classe.ToString());
			var info = Classes.GetInfos(m_From.Classe);
			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line++, 150, "Aptitudes");

			if (info.Aptitudes.Length > 0)
			{
				foreach (var apt in info.Aptitudes)
				{
					AddHtmlTexte(x + 12 + columnSpace * column, y + lineSpace * line, 150, apt.Aptitude.ToString());
					AddHtmlTexte(x + 115 + columnSpace * column, y + lineSpace * line++, 100, apt.Value.ToString());
				}
			}
			else
				AddHtmlTexte(x + 12 + columnSpace * column, y + lineSpace * line++, 100, "Aucune");

			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line++, 150, "Capacités");

			if (info.Capacites.Length > 0)
			{
				foreach (var cap in info.Capacites)
				{
					AddHtmlTexte(x + 12 + columnSpace * column, y + lineSpace * line, 150, CustomUtility.GetDescription(cap.Capacite));
					AddHtmlTexte(x + 115 + columnSpace * column, y + lineSpace * line++, 100, cap.Value.ToString());
				}
			}
			else
				AddHtmlTexte(x + 12 + columnSpace * column, y + lineSpace * line++, 100, "Aucune");
			#endregion

			column++;
			line = 0;

			#region Capacités
			AddSection(x - 10 + columnSpace * column, y + lineSpace * line++, columnSpace - 1, lineSpace * 17 - 1, "Capacités");
			line++;
			for (int i = 0; i < Enum.GetValues(typeof(Capacite)).Length; i++)
			{
				var capacite = (Capacite)i;
				if (m_From.Capacites.CanLower(capacite))
					AddButton(x + 157 + columnSpace * column, y + lineSpace * line + 2, 5603, 5607, 500 + i, GumpButtonType.Reply, 0);
				AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 140, CustomUtility.GetDescription(capacite));
				AddHtmlTexte(x + 174 + columnSpace * column, y + lineSpace * line, 32, Center(m_From.Capacites.GetRealValue(capacite).ToString()));
				if (m_From.Capacites.CanRaise(capacite))
					AddButton(x + 206 + columnSpace * column, y + lineSpace * line + 2, 5601, 5605, 550 + i, GumpButtonType.Reply, 0);
				line++;
			}
			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 140, "Points restants");
			AddHtmlTexte(x + 174 + columnSpace * column, y + lineSpace * line++, 32, Center(m_From.Capacites.Bank.ToString()));
			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 200, 40, $"Note: Diminuer un point coûte {m_CapaciteDecreasingCost} po.");

			line += 3;

			AddSection(x - 10 + columnSpace * column, y + lineSpace * line++, columnSpace - 1, lineSpace * 12 - 1, "Statistiques");
			line++;

			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 150, "Force");

			if (m_From.CanDecreaseStat(StatType.Str, 5))
				AddButton(x + 140 + columnSpace * column, y + lineSpace * line + 2, 5603, 5607, 350, GumpButtonType.Reply, 0);
			if (m_From.CanDecreaseStat(StatType.Str, 1))
				AddButton(x + 157 + columnSpace * column, y + lineSpace * line + 2, 5603, 5607, 300, GumpButtonType.Reply, 0);

			if (m_From.CanIncreaseStat(StatType.Str, 1))
				AddButton(x + 206 + columnSpace * column, y + lineSpace * line + 2, 5601, 5605, 301, GumpButtonType.Reply, 0);
			if (m_From.CanIncreaseStat(StatType.Str, 5))
				AddButton(x + 223 + columnSpace * column, y + lineSpace * line + 2, 5601, 5605, 351, GumpButtonType.Reply, 0);

			AddHtmlTexte(x + 174 + columnSpace * column, y + lineSpace * line, 32, Center(m_From.RawStr.ToString()));
			if (m_From.Str > m_From.RawStr)
				AddHtmlTexte(x + 85 + columnSpace * column, y + lineSpace * line, 55, Center($"+{m_From.Str - m_From.RawStr}"));
			else if (m_From.Str < m_From.RawStr)
				AddHtmlTexte(x + 85 + columnSpace * column, y + lineSpace * line, 55, Center($"-{m_From.RawStr - m_From.Str}"));
			line++;

			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 120, "Dextérité");

			if (m_From.CanDecreaseStat(StatType.Dex, 5))
				AddButton(x + 140 + columnSpace * column, y + lineSpace * line + 2, 5603, 5607, 352, GumpButtonType.Reply, 0);
			if (m_From.CanDecreaseStat(StatType.Dex, 1))
				AddButton(x + 157 + columnSpace * column, y + lineSpace * line + 2, 5603, 5607, 302, GumpButtonType.Reply, 0);

			if (m_From.CanIncreaseStat(StatType.Dex, 1))
				AddButton(x + 206 + columnSpace * column, y + lineSpace * line + 2, 5601, 5605, 303, GumpButtonType.Reply, 0);
			if (m_From.CanIncreaseStat(StatType.Dex, 5))
				AddButton(x + 223 + columnSpace * column, y + lineSpace * line + 2, 5601, 5605, 353, GumpButtonType.Reply, 0);

			AddHtmlTexte(x + 174 + columnSpace * column, y + lineSpace * line, 32, Center(m_From.RawDex.ToString()));
			if (m_From.Dex > m_From.RawDex)
				AddHtmlTexte(x + 85 + columnSpace * column, y + lineSpace * line, 55, Center($"+{m_From.Dex - m_From.RawDex}"));
			else if (m_From.Dex < m_From.RawDex)
				AddHtmlTexte(x + 85 + columnSpace * column, y + lineSpace * line, 55, Center($"-{m_From.RawDex - m_From.Dex}"));
			line++;

			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 120, "Intelligence");

			if (m_From.CanDecreaseStat(StatType.Int, 5))
				AddButton(x + 140 + columnSpace * column, y + lineSpace * line + 2, 5603, 5607, 354, GumpButtonType.Reply, 0);
			if (m_From.CanDecreaseStat(StatType.Int, 1))
				AddButton(x + 157 + columnSpace * column, y + lineSpace * line + 2, 5603, 5607, 304, GumpButtonType.Reply, 0);

			if (m_From.CanIncreaseStat(StatType.Int, 1))
				AddButton(x + 206 + columnSpace * column, y + lineSpace * line + 2, 5601, 5605, 305, GumpButtonType.Reply, 0);
			if (m_From.CanIncreaseStat(StatType.Int, 5))
				AddButton(x + 223 + columnSpace * column, y + lineSpace * line + 2, 5601, 5605, 355, GumpButtonType.Reply, 0);

			AddHtmlTexte(x + 174 + columnSpace * column, y + lineSpace * line, 32, Center(m_From.RawInt.ToString()));
			if (m_From.Int > m_From.RawInt)
				AddHtmlTexte(x + 85 + columnSpace * column, y + lineSpace * line, 55, Center($"+{m_From.Int - m_From.RawInt}"));
			else if (m_From.Int < m_From.RawInt)
				AddHtmlTexte(x + 85 + columnSpace * column, y + lineSpace * line, 55, Center($"-{m_From.RawInt - m_From.Int}"));
			line++;

			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 120, "Constitution");

			if (m_From.Attributs.CanDecreaseStat(Attribut.Constitution, 5))
				AddButton(x + 140 + columnSpace * column, y + lineSpace * line + 2, 5603, 5607, 356, GumpButtonType.Reply, 0);
			if (m_From.Attributs.CanDecreaseStat(Attribut.Constitution, 1))
				AddButton(x + 157 + columnSpace * column, y + lineSpace * line + 2, 5603, 5607, 306, GumpButtonType.Reply, 0);

			if (m_From.Attributs.CanIncreaseStat(Attribut.Constitution, 1))
				AddButton(x + 206 + columnSpace * column, y + lineSpace * line + 2, 5601, 5605, 307, GumpButtonType.Reply, 0);
			if (m_From.Attributs.CanIncreaseStat(Attribut.Constitution, 5))
				AddButton(x + 223 + columnSpace * column, y + lineSpace * line + 2, 5601, 5605, 357, GumpButtonType.Reply, 0);

			AddHtmlTexte(x + 174 + columnSpace * column, y + lineSpace * line, 32, Center(m_From.Attributs.BaseConstitution.ToString()));
			if (m_From.Attributs.Constitution > m_From.Attributs.BaseConstitution)
				AddHtmlTexte(x + 85 + columnSpace * column, y + lineSpace * line, 55, Center($"+{m_From.Attributs.Constitution - m_From.Attributs.BaseConstitution}"));
			else if (m_From.Dex < m_From.RawDex)
				AddHtmlTexte(x + 85 + columnSpace * column, y + lineSpace * line, 55, Center($"-{m_From.Attributs.BaseConstitution - m_From.Attributs.Constitution}"));
			line++;

			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 120, "Endurance");

			if (m_From.Attributs.CanDecreaseStat(Attribut.Endurance, 5))
				AddButton(x + 140 + columnSpace * column, y + lineSpace * line + 2, 5603, 5607, 358, GumpButtonType.Reply, 0);
			if (m_From.Attributs.CanDecreaseStat(Attribut.Endurance, 1))
				AddButton(x + 157 + columnSpace * column, y + lineSpace * line + 2, 5603, 5607, 308, GumpButtonType.Reply, 0);

			if (m_From.Attributs.CanIncreaseStat(Attribut.Endurance, 1))
				AddButton(x + 206 + columnSpace * column, y + lineSpace * line + 2, 5601, 5605, 309, GumpButtonType.Reply, 0);
			if (m_From.Attributs.CanIncreaseStat(Attribut.Endurance, 5))
				AddButton(x + 223 + columnSpace * column, y + lineSpace * line + 2, 5601, 5605, 359, GumpButtonType.Reply, 0);

			AddHtmlTexte(x + 174 + columnSpace * column, y + lineSpace * line, 32, Center(m_From.Attributs.BaseEndurance.ToString()));
			if (m_From.Attributs.Endurance > m_From.Attributs.BaseEndurance)
				AddHtmlTexte(x + 85 + columnSpace * column, y + lineSpace * line, 55, Center($"+{m_From.Attributs.Endurance - m_From.Attributs.BaseEndurance}"));
			else if (m_From.Dex < m_From.RawDex)
				AddHtmlTexte(x + 85 + columnSpace * column, y + lineSpace * line, 55, Center($"-{m_From.Attributs.BaseEndurance - m_From.Attributs.Endurance}"));
			line++;

			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 120, "Sagesse");

			if (m_From.Attributs.CanDecreaseStat(Attribut.Sagesse, 5))
				AddButton(x + 140 + columnSpace * column, y + lineSpace * line + 2, 5603, 5607, 360, GumpButtonType.Reply, 0);
			if (m_From.Attributs.CanDecreaseStat(Attribut.Sagesse, 1))
				AddButton(x + 157 + columnSpace * column, y + lineSpace * line + 2, 5603, 5607, 310, GumpButtonType.Reply, 0);

			if (m_From.Attributs.CanIncreaseStat(Attribut.Sagesse, 1))
				AddButton(x + 206 + columnSpace * column, y + lineSpace * line + 2, 5601, 5605, 311, GumpButtonType.Reply, 0);
			if (m_From.Attributs.CanIncreaseStat(Attribut.Sagesse, 5))
				AddButton(x + 223 + columnSpace * column, y + lineSpace * line + 2, 5601, 5605, 361, GumpButtonType.Reply, 0);

			AddHtmlTexte(x + 174 + columnSpace * column, y + lineSpace * line, 32, Center(m_From.Attributs.BaseSagesse.ToString()));
			if (m_From.Attributs.Sagesse > m_From.Attributs.BaseSagesse)
				AddHtmlTexte(x + 85 + columnSpace * column, y + lineSpace * line, 55, Center($"+{m_From.Attributs.Sagesse - m_From.Attributs.BaseSagesse}"));
			else if (m_From.Dex < m_From.RawDex)
				AddHtmlTexte(x + 85 + columnSpace * column, y + lineSpace * line, 55, Center($"-{m_From.Attributs.BaseSagesse - m_From.Attributs.Sagesse}"));
			line++;

			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 120, "Points restants");
			AddHtmlTexte(x + 175 + columnSpace * column, y + lineSpace * line++, 35, Center((Attributs.MaxStats - m_From.RawStr - m_From.RawDex - m_From.RawInt - m_From.Attributs.BaseConstitution - m_From.Attributs.BaseSagesse - m_From.Attributs.BaseEndurance).ToString()));
			
			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 200, 40, $"Note: Diminuer un point coûte {m_StatsDecreasingCost} po.");
			#endregion

			column++;
			line = 0;

			#region Aptitudes
			AddSection(x - 10 + columnSpace * column, y + lineSpace * line++, columnSpace - 1, lineSpace * 29 - 1, "Aptitudes");
			line++;
			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 100, $"Disponible");
			AddHtmlTexte(x + 145 + columnSpace * column, y + lineSpace * line++, 100, Center($"{Aptitudes.GetRemainingPA(m_From, m_From.Experience.Niveau)} / {Aptitudes.GetMaxPA(m_From.Experience.Niveau)} (Max)"));

			foreach (Aptitude apt in Enum.GetValues(typeof(Aptitude)))
			{
				AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 150, apt.ToString());

				AddHtmlTexte(x + 174 + columnSpace * column, y + lineSpace * line, 32, Center(m_From.Aptitudes.GetRealValue(apt).ToString()));

				if (m_From.Aptitudes.CanLower(apt))
					AddButton(x + 157 + columnSpace * column, y + lineSpace * line + 2, 5603, 5607, 100 + (int)apt, GumpButtonType.Reply, 0);

				if (m_From.Aptitudes.CanRaise(apt))
					AddButton(x + 206 + columnSpace * column, y + lineSpace * line + 2, 5601, 5605, 200 + (int)apt, GumpButtonType.Reply, 0);

				line++;
			}
			line += 5;
			AddHtmlTexte(x + 10 + columnSpace * column, y + lineSpace * line, 200, 40, $"Note: Diminuer un point coûte {m_AptitudesDecreasingCost} po.");
			#endregion
		}

		public override void OnResponse(NetState sender, RelayInfo info)
        {
			if (info.ButtonID >= 100 && info.ButtonID < 200)
			{
				if (CustomUtility.ConsumeItemInBank(m_From, typeof(Gold), m_AptitudesDecreasingCost))
				{
					var apt = (Aptitude)(info.ButtonID - 100);
					if (m_From.Aptitudes.CanLower(apt))
					{
						m_From.Aptitudes.Lower(apt);
						Classes.SetBaseAndCapSkills(m_From, m_From.Experience.Niveau);
						m_From.InvalidateProperties();
					}
				}

				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID >= 200 && info.ButtonID < 300)
			{
				var apt = (Aptitude)(info.ButtonID - 200);
				if (m_From.Aptitudes.CanRaise(apt))
				{
					m_From.Aptitudes.Raise(apt);
					Classes.SetBaseAndCapSkills(m_From, m_From.Experience.Niveau);
					m_From.InvalidateProperties();
				}

				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 300)
			{
				if (CustomUtility.ConsumeItemInBank(m_From, typeof(Gold), m_StatsDecreasingCost))
				{
					m_From.DecreaseStat(StatType.Str, 1);
					m_From.Delta(MobileDelta.Stat);
				}
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 301)
			{
				m_From.IncreaseStat(StatType.Str, 1);
				m_From.Delta(MobileDelta.Stat);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 302)
			{
				if (CustomUtility.ConsumeItemInBank(m_From, typeof(Gold), m_StatsDecreasingCost))
				{
					m_From.DecreaseStat(StatType.Dex, 1);
					m_From.Delta(MobileDelta.Stat);
				}
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 303)
			{
				m_From.IncreaseStat(StatType.Dex, 1);
				m_From.Delta(MobileDelta.Stat);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 304)
			{
				if (CustomUtility.ConsumeItemInBank(m_From, typeof(Gold), m_StatsDecreasingCost))
				{
					m_From.DecreaseStat(StatType.Int, 1);
					m_From.Delta(MobileDelta.Stat);
				}
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 305)
			{
				m_From.IncreaseStat(StatType.Int, 1);
				m_From.Delta(MobileDelta.Stat);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 306)
			{
				if (CustomUtility.ConsumeItemInBank(m_From, typeof(Gold), m_StatsDecreasingCost))
				{
					m_From.Attributs.Decrease(Attribut.Constitution, 1);
					m_From.Delta(MobileDelta.Hits);
				}
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 307)
			{
				m_From.Attributs.Increase(Attribut.Constitution, 1);
				m_From.Delta(MobileDelta.Hits);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 308)
			{
				if (CustomUtility.ConsumeItemInBank(m_From, typeof(Gold), m_StatsDecreasingCost))
				{
					m_From.Attributs.Decrease(Attribut.Endurance, 1);
					m_From.Delta(MobileDelta.Stam);
				}
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 309)
			{
				m_From.Attributs.Increase(Attribut.Endurance, 1);
				m_From.Delta(MobileDelta.Stam);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 310)
			{
				if (CustomUtility.ConsumeItemInBank(m_From, typeof(Gold), m_StatsDecreasingCost))
				{
					m_From.Attributs.Decrease(Attribut.Sagesse, 1);
					m_From.Delta(MobileDelta.Mana);
				}
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 311)
			{
				m_From.Attributs.Increase(Attribut.Sagesse, 1);
				m_From.Delta(MobileDelta.Mana);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 350)
			{
				if (CustomUtility.ConsumeItemInBank(m_From, typeof(Gold), m_StatsDecreasingCost * 5))
				{
					m_From.DecreaseStat(StatType.Str, 5);
					m_From.Delta(MobileDelta.Stat);
				}
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 351)
			{
				m_From.IncreaseStat(StatType.Str, 5);
				m_From.Delta(MobileDelta.Stat);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 352)
			{
				if (CustomUtility.ConsumeItemInBank(m_From, typeof(Gold), m_StatsDecreasingCost * 5))
				{
					m_From.DecreaseStat(StatType.Dex, 5);
					m_From.Delta(MobileDelta.Stat);
				}
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 353)
			{
				m_From.IncreaseStat(StatType.Dex, 5);
				m_From.Delta(MobileDelta.Stat);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 354)
			{
				if (CustomUtility.ConsumeItemInBank(m_From, typeof(Gold), m_StatsDecreasingCost * 5))
				{
					m_From.DecreaseStat(StatType.Int, 5);
					m_From.Delta(MobileDelta.Stat);
				}
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 355)
			{
				m_From.IncreaseStat(StatType.Int, 5);
				m_From.Delta(MobileDelta.Stat);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 356)
			{
				if (CustomUtility.ConsumeItemInBank(m_From, typeof(Gold), m_StatsDecreasingCost * 5))
				{
					m_From.Attributs.Decrease(Attribut.Constitution, 5);
					m_From.Delta(MobileDelta.Hits);
				}
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 357)
			{
				m_From.Attributs.Increase(Attribut.Constitution, 5);
				m_From.Delta(MobileDelta.Hits);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 358)
			{
				if (CustomUtility.ConsumeItemInBank(m_From, typeof(Gold), m_StatsDecreasingCost * 5))
				{
					m_From.Attributs.Decrease(Attribut.Endurance, 5);
					m_From.Delta(MobileDelta.Stam);
				}
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 359)
			{
				m_From.Attributs.Increase(Attribut.Endurance, 5);
				m_From.Delta(MobileDelta.Stam);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 360)
			{
				if (CustomUtility.ConsumeItemInBank(m_From, typeof(Gold), m_StatsDecreasingCost * 5))
				{
					m_From.Attributs.Decrease(Attribut.Sagesse, 5);
					m_From.Delta(MobileDelta.Mana);
				}
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 361)
			{
				m_From.Attributs.Increase(Attribut.Sagesse, 5);
				m_From.Delta(MobileDelta.Mana);
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID == 400)
			{
				m_From.SendGump(new PointsAncestrauxExchangeGump(m_From, m_GM));
			}
			else if (info.ButtonID >= 500 && info.ButtonID < 550)
			{
				if (CustomUtility.ConsumeItemInBank(m_From, typeof(Gold), m_CapaciteDecreasingCost))
				{
					m_From.Capacites.Lower((Capacite)(info.ButtonID - 500));
					m_From.InvalidateProperties();
				}
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
			else if (info.ButtonID >= 550 && info.ButtonID < 600)
			{
				m_From.Capacites.Raise((Capacite)(info.ButtonID - 550));
				m_From.SendGump(new FicheGump(m_From, m_GM));
			}
		}
    }
}
