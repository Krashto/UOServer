using System;
using Server.Network;
using Server.Mobiles;
using Server.Commands;
using Server.Gumps;

namespace Server.Custom.Classes
{

	public class InfoClasses
	{
		public static void Initialize()
		{
			CommandSystem.Register("InfoClasses", AccessLevel.Player, new CommandEventHandler(InfoClasses_OnCommand));
		}

		[Usage("InfoClasses")]
		[Description("Permet d'ouvrir le menu .InfoClasses")]
		public static void InfoClasses_OnCommand(CommandEventArgs e)
		{
			var from = e.Mobile;

			if (from is CustomPlayerMobile)
			{
				from.CloseGump(typeof(InfoClassesGump));
				from.SendGump(new InfoClassesGump((CustomPlayerMobile)from, ClasseBranche.Aucune, Classe.Aucune));
			}
		}
	}

	public class InfoClassesGump : Gump
	{
		private CustomPlayerMobile m_From;
		private ClasseBranche m_ClasseBranche;
		private Classe m_Classe;

		public InfoClassesGump(CustomPlayerMobile from, ClasseBranche ClasseBranche, Classe classe) : base(0, 20)
		{
			m_From = from;
			m_Classe = classe;
			m_ClasseBranche = ClasseBranche;

			Closable = true;
			Disposable = true;
			Dragable = true;
			Resizable = false;

			AddPage(0);

			AddBackground(61, 19, 686, 699, 9260); //Main

			AddImageTiled(78, 18, 644, 17, 10250); //Top

			//Dragon gauche
			AddImage(11, 6, 10440);

			//Dragon droite
			AddImage(715, 6, 10441);

			AddLabel(350, 40, 2101, "Info Classes");

			var index = 0;
			var xBase = 102;
			var xOffset = 20;

			var yBase = 78;
			var yOffset = 18;

			ClasseInfo ci;

			foreach (ClasseBranche branche in Enum.GetValues(typeof(ClasseBranche)))
			{
				AddButton(xBase, yBase + yOffset * index, 2224, 2224, (int)branche + 1000, GumpButtonType.Reply, 0);
				AddLabel(xBase + xOffset, -1 + yBase + yOffset * index++, 2101, branche.ToString());

				if (branche == m_ClasseBranche)
				{
					xBase = 112;

					foreach (Classe c in Enum.GetValues(typeof(Classe)))
					{
						ci = Classes.GetInfos(c);

						if (branche.ToString() == ci.ClasseBranche.ToString() && ci.Active && ci.Classe != Classe.Aucune)
						{
							AddButton(xBase, yBase + yOffset * index, 2224, 2224, (int)c, GumpButtonType.Reply, 0);
							AddLabel(xBase + xOffset, yBase + yOffset * index++ - 2, 2101, ci.Nom);
						}
					}

					xBase = 102;
				}
			}

			index = 0;
			xBase = 302;
			xOffset = 114;

			yBase = 78;
			yOffset = 18;

			if (m_Classe > 0 && (int)m_Classe < Enum.GetValues(typeof(Classe)).Length)
			{
				ci = Classes.GetInfos(m_Classe);

				AddLabel(xBase, yBase + yOffset * index, 2101, "Classe");
				AddLabel(xBase + xOffset, yBase + yOffset * index++, 2101, String.Format(": {0}", ci.Nom));

				AddLabel(xBase, yBase + yOffset * index, 2101, "Niveau");
				AddLabel(xBase + xOffset, yBase + yOffset * index++, 2101, String.Format(": {0}", ci.Level));

				AddLabel(xBase, yBase + yOffset * index, 2101, "Groupe");
				AddLabel(xBase + xOffset, yBase + yOffset * index++, 2101, String.Format(": {0}", ci.ClasseMode));

				index++;

				AddLabel(xBase, yBase + yOffset * index++, 2101, "Aptitudes");

				foreach (var apt in ci.Aptitudes)
				{
					AddLabel(xBase, yBase + yOffset * index, 2101, String.Format("{0}", apt.Aptitude));
					AddLabel(xBase + xOffset, yBase + yOffset * index++, 2101, String.Format(": {0}", apt.Value));
				}

				index++;

				AddLabel(xBase, yBase + yOffset * index++, 2101, "Capacités");

				foreach (var cap in ci.Capacites)
				{
					AddLabel(xBase, yBase + yOffset * index, 2101, String.Format("{0}", cap.Capacite));
					AddLabel(xBase + xOffset, yBase + yOffset * index++, 2101, String.Format(": {0}", cap.Value));
				}

				index++;

				AddLabel(xBase, yBase + yOffset * index++, 2101, "Compétences requises");

				foreach (var skl in ci.Skills)
				{
					AddLabel(xBase, yBase + yOffset * index, 2101, String.Format("{0}", skl.SkillName));
					AddLabel(xBase + xOffset, yBase + yOffset * index, 2101, String.Format(": {0}%", skl.Value));
					AddLabel(xBase + xOffset + 75, yBase + yOffset * index++, m_From.Skills[skl.SkillName].Value >= skl.Value ? 67 : 38, String.Format("(Actuel: {0}%)", m_From.Skills[skl.SkillName].Value));
				}
			}
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			var id = info.ButtonID;

			if (id < 1000)
			{
				if (id > 0 && info.ButtonID < Enum.GetValues(typeof(Classe)).Length)
					m_From.SendGump(new InfoClassesGump(m_From, m_ClasseBranche, (Classe)id));
			}
			else if (id < 2000)
			{
				var newId = id - 1000;
				if (newId > 0 && newId < Enum.GetValues(typeof(ClasseBranche)).Length)
					m_From.SendGump(new InfoClassesGump(m_From, (ClasseBranche)newId, Classe.Aucune));
			}
		}
	}
}
