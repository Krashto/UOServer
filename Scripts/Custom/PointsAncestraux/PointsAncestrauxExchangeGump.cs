using System;
using Server.Network;
using Server.Mobiles;
using Server.Custom.Aptitudes;
using Server.Custom.Classes;
using Server.Custom.Capacites;
using Server.Custom;
using Server.Targeting;
using Server.Items;
using Server.CustomScripts.Systems.Experience;

namespace Server.Gumps
{
	public class PointsAncestrauxExchangeGump : BaseProjectMGump
	{
		private CustomPlayerMobile m_From;
		private CustomPlayerMobile m_GM;
		private int m_ExpCost = 1000;

		public PointsAncestrauxExchangeGump(CustomPlayerMobile from, CustomPlayerMobile gm) : base("Échange des points ancestraux", 560, 660, false)
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

			AddSection(x - 10, y + space * line++, 305 - 1, space * 4 - 1, "Informations");
			line++;
			AddHtmlTexte(x + 10, y + space * line++, 100, 80, "Explications...");
			line += 4;

			line = 5;
			AddSection(x - 10, y + space * line++, 305 - 1, space * 4 - 1, "Expériences");
			line++;
			AddHtmlTexte(x + 10, y + space * line++, 300, 20, $"Vous pouvez échanger {m_ExpCost} contre 1 point ancestral à partir de {Experience.GetRequiredExpByLevel(50) + m_ExpCost} points d'expérience.");
			if (m_From.Experience.Exp >= Experience.GetRequiredExpByLevel(50) + m_ExpCost)
				AddButtonHtml(X + 10, y + space * line, 1, "Échanger", "#FFFFFFF");
			
			line = 5;
			AddSection(x + 295, y + space * line++, 305 - 1, space * 4 - 1, "Offrandes");
			line++;
			AddHtmlTexte(x + 10, y + space * line, 300, 20, $"Vous pouvez échanger une offrande en échange de points ancestraux.");
			AddButtonHtml(X + 10, y + space * line, 2, "Échanger", "#FFFFFFF");

			line += 4;

			AddSection(x - 10, y + space * line++, 610, space * 8 - 1, "Dépenser");
			line++;
			AddHtmlTexte(x + 10, y + space * line++, 610, 20, $"Vous pouvez dépenser des points ancestraux contre des objets.");
			AddButtonHtml(X + 10, y + space * line++, 100, "Couleur de vêtement ancestrale", "#FFFFFFF");
			AddButtonHtml(X + 10, y + space * line++, 101, "Couleur d'armure ancestrale", "#FFFFFFF");
			AddButtonHtml(X + 10, y + space * line++, 102, "Couleur d'arme ancestrale", "#FFFFFFF");
			AddButtonHtml(X + 10, y + space * line++, 120, "Parchemin de compétence supérieure", "#FFFFFFF");
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			if (info.ButtonID == 1)
			{
				if (m_From.Experience.Exp >= Experience.GetRequiredExpByLevel(50) + m_ExpCost)
				{
					m_From.Experience.Exp -= m_ExpCost;
					m_From.PointsAncestraux.AddPoints(1);
				}
			}
			else if (info.ButtonID == 2)
			{
				m_From.SendMessage("Quelle offrande voulez-vous donner ?");
				//m_From.Target = new OffrandeTarget(m_From, ); // Call our target
			}
			else if (info.ButtonID >= 100 && info.ButtonID < 200)
			{
				if (info.ButtonID == 100 && m_From.PointsAncestraux.RemovePoints(10))
				{
					//var item = (Item)Activator.CreateInstance();
					//m_From.AddToBackpack(item);
				}
				else if (info.ButtonID == 101 && m_From.PointsAncestraux.RemovePoints(10))
				{
					//var item = (Item)Activator.CreateInstance();
					//m_From.AddToBackpack(item);
				}
				else if (info.ButtonID == 102 && m_From.PointsAncestraux.RemovePoints(10))
				{
					//var item = (Item)Activator.CreateInstance();
					//m_From.AddToBackpack(item);
				}
				else if (info.ButtonID == 103 && m_From.PointsAncestraux.RemovePoints(10))
				{
					//var item = (Item)Activator.CreateInstance();
					//m_From.AddToBackpack(item);
				}
				else if (info.ButtonID == 104 && m_From.PointsAncestraux.RemovePoints(10))
				{
					//var item = (Item)Activator.CreateInstance();
					//m_From.AddToBackpack(item);
				}
				else if (info.ButtonID == 120 && m_From.PointsAncestraux.RemovePoints(15))
				{
					//var item = (Item)Activator.CreateInstance();
					//m_From.AddToBackpack(item);
				}

				m_From.SendGump(new PointsAncestrauxExchangeGump(m_From, m_GM));
			}
		}

		public class OffrandeTarget : Target
		{
			private int m_Cost;
			private Type m_ItemType;
			private Mobile m_From;

			public OffrandeTarget(Mobile from, int cost, Type itemType) : base(1, false, TargetFlags.None)
			{
				m_Cost = cost;
				m_ItemType = itemType;
				m_From = from;
			}

			protected override void OnTarget(Mobile from, object target)
			{
				if (target is CustomPlayerMobile pm)
				{
					
				}
				else
					from.SendMessage("Vous devez cibler un joueur.");
			}
		}
	}
}
