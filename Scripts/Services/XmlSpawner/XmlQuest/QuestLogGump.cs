using System;
using System.Collections.Generic;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Prompts;
using Server.Engines.XmlSpawner2;

//
// XmlLogGump
// modified from RC0 BOBGump.cs
//
namespace Server.Services.XmlSpawner.XmlQuest
{
	public class XMLQuestLogGump : Gump
	{
		private Mobile m_From;

		private List<object> m_List;

		private int m_Page;

		private const int LabelColor = 0x7FFF;

		public int GetIndexForPage(int page)
		{
			var index = 0;

			while (page-- > 0)
				index += GetCountForIndex(index);

			return index;
		}

		public int GetCountForIndex(int index)
		{
			var slots = 0;
			var count = 0;

			var list = m_List;

			for (var i = index; i >= 0 && i < list.Count; ++i)
			{
				var obj = list[i];

				int add;

				add = 1;

				if (slots + add > 10)
					break;

				slots += add;

				++count;
			}

			return count;
		}


		public XMLQuestLogGump(Mobile from) : this(from, 0, null)
		{
		}

		public override void OnResponse(Network.NetState sender, RelayInfo info)
		{
			if (info == null || m_From == null) return;

			switch (info.ButtonID)
			{
				case 0: // EXIT
					{
						break;
					}

				case 2: // Previous page
					{
						if (m_Page > 0)
							m_From.SendGump(new XMLQuestLogGump(m_From, m_Page - 1, m_List));

						return;
					}
				case 3: // Next page
					{
						if (GetIndexForPage(m_Page + 1) < m_List.Count)
							m_From.SendGump(new XMLQuestLogGump(m_From, m_Page + 1, m_List));

						break;
					}
				case 10: // Top players
					{
						// if this player has an XmlQuestPoints attachment, find it
						var p = (XmlQuestPoints)XmlAttach.FindAttachment(m_From, typeof(XmlQuestPoints));

						m_From.CloseGump(typeof(XmlQuestLeaders.TopQuestPlayersGump));
						m_From.SendGump(new XmlQuestLeaders.TopQuestPlayersGump(p));

						break;
					}


				default:
					{
						if (info.ButtonID >= 2000)
						{
							var index = info.ButtonID - 2000;

							if (index < 0 || index >= m_List.Count)
								break;

							if (m_List[index] is IXmlQuest)
							{
								var o = m_List[index] as IXmlQuest;

								if (o != null && !o.Deleted)
								{
									m_From.SendGump(new XMLQuestLogGump(m_From, m_Page, null));
									m_From.CloseGump(typeof(XmlQuestStatusGump));
									m_From.SendGump(new XmlQuestStatusGump(o, o.TitleString, 320, 0, true));
								}
							}
						}

						break;
					}
			}
		}


		public XMLQuestLogGump(Mobile from, int page, List<object> list) : base(12, 24)
		{
			if (from == null) return;

			from.CloseGump(typeof(XMLQuestLogGump));

			var p = (XmlQuestPoints)XmlAttach.FindAttachment(from, typeof(XmlQuestPoints));

			m_From = from;
			m_Page = page;

			if (list == null)
			{
				// make a new list based on the number of items in the book
				var nquests = 0;
				list = new List<object>();

				// find all quest items in the players pack
				if (from.Backpack != null)
				{
					var packquestitems = from.Backpack.FindItemsByType(typeof(IXmlQuest));

					if (packquestitems != null)
					{
						nquests += packquestitems.Length;
						for (var i = 0; i < packquestitems.Length; ++i)
							if (packquestitems[i] != null && !packquestitems[i].Deleted && !(packquestitems[i].Parent is XmlQuestBook))
								list.Add(packquestitems[i]);
					}

					// find any questbooks they might have
					var questbookitems = from.Backpack.FindItemsByType(typeof(XmlQuestBook));

					if (questbookitems != null)

						for (var j = 0; j < questbookitems.Length; ++j)
						{
							Item[] questitems = ((XmlQuestBook)questbookitems[j]).FindItemsByType(typeof(IXmlQuest));

							if (questitems != null)
							{
								nquests += questitems.Length;

								for (var i = 0; i < questitems.Length; ++i)
									list.Add(questitems[i]);
							}
						}

					// find any completed quests on the XmlQuestPoints attachment

					if (p != null && p.QuestList != null)
						// add all completed quests
						foreach (XmlQuestPoints.QuestEntry q in p.QuestList)
							list.Add(q);
				}

			}

			m_List = list;

			var index = GetIndexForPage(page);
			var count = GetCountForIndex(index);

			var tableIndex = 0;

			var width = 600;

			width = 766;

			X = (824 - width) / 2;

			var xoffset = 20;

			AddPage(0);

			AddBackground(10, 10, width, 439, 5054);
			AddImageTiled(18, 20, width - 17, 420, 2624);

			AddImageTiled(58 - xoffset, 64, 36, 352, 200); // open
			AddImageTiled(96 - xoffset, 64, 163, 352, 1416);  // name
			AddImageTiled(261 - xoffset, 64, 55, 352, 200); // type
			AddImageTiled(308 - xoffset, 64, 85, 352, 1416);  // status
			AddImageTiled(395 - xoffset, 64, 116, 352, 200);  // expires

			AddImageTiled(511 - xoffset, 64, 42, 352, 1416);  // points
			AddImageTiled(555 - xoffset, 64, 175, 352, 200);  // completed
			AddImageTiled(734 - xoffset, 64, 42, 352, 1416);  // repeated

			for (var i = index; i < index + count && i >= 0 && i < list.Count; ++i)
			{
				var obj = list[i];

				AddImageTiled(24, 94 + tableIndex * 32, 489, 2, 2624);

				++tableIndex;
			}

			AddAlphaRegion(18, 20, width - 17, 420);
			AddImage(5, 5, 10460);
			AddImage(width - 15, 5, 10460);
			AddImage(5, 424, 10460);
			AddImage(width - 15, 424, 10460);

			AddHtmlLocalized(375, 25, 200, 30, 1046026, LabelColor, false, false); // Quest Log

			AddHtmlLocalized(63 - xoffset, 45, 200, 32, 1072837, LabelColor, false, false); // Current Points: 

			AddHtml(243 - xoffset, 45, 200, 32, XmlSimpleGump.Color("Available Credits:", "FFFFFF"), false, false); // Your Reward Points: 

			AddHtml(453 - xoffset, 45, 200, 32, XmlSimpleGump.Color("Rank:", "FFFFFF"), false, false);  // Rank

			AddHtml(600 - xoffset, 45, 200, 32, XmlSimpleGump.Color("Quests Completed:", "FFFFFF"), false, false); // Quests completed

			if (p != null)
			{

				var pcolor = 53;
				AddLabel(170 - xoffset, 45, pcolor, p.Points.ToString());
				AddLabel(350 - xoffset, 45, pcolor, p.Credits.ToString());
				AddLabel(500 - xoffset, 45, pcolor, p.Rank.ToString());
				AddLabel(720 - xoffset, 45, pcolor, p.QuestsCompleted.ToString());
			}

			AddHtmlLocalized(63 - xoffset, 64, 200, 32, 3000362, LabelColor, false, false); // Open
			AddHtmlLocalized(147 - xoffset, 64, 200, 32, 3005104, LabelColor, false, false); // Name
			AddHtmlLocalized(270 - xoffset, 64, 200, 32, 1062213, LabelColor, false, false); // Type
			AddHtmlLocalized(326 - xoffset, 64, 200, 32, 3000132, LabelColor, false, false); // Status
			AddHtmlLocalized(429 - xoffset, 64, 200, 32, 1062465, LabelColor, false, false); // Expires

			AddHtml(514 - xoffset, 64, 200, 32, XmlSimpleGump.Color("Points", "FFFFFF"), false, false); // Points
			AddHtml(610 - xoffset, 64, 200, 32, XmlSimpleGump.Color("Next Available", "FFFFFF"), false, false); // Next Available
																												//AddHtmlLocalized( 610 - xoffset, 64, 200, 32,  1046033, LabelColor, false, false ); // Completed
			AddHtmlLocalized(738 - xoffset, 64, 200, 32, 3005020, LabelColor, false, false); // Repeat

			AddButton(675 - xoffset, 416, 4017, 4018, 0, GumpButtonType.Reply, 0);
			AddHtmlLocalized(710 - xoffset, 416, 120, 20, 1011441, LabelColor, false, false); // EXIT

			AddButton(113 - xoffset, 416, 0xFA8, 0xFAA, 10, GumpButtonType.Reply, 0);
			AddHtml(150 - xoffset, 416, 200, 32, XmlSimpleGump.Color("Top Players", "FFFFFF"), false, false); // Top players gump


			tableIndex = 0;

			if (page > 0)
			{
				AddButton(225, 416, 4014, 4016, 2, GumpButtonType.Reply, 0);
				AddHtmlLocalized(260, 416, 150, 20, 1011067, LabelColor, false, false); // Previous page
			}

			if (GetIndexForPage(page + 1) < list.Count)
			{
				AddButton(375, 416, 4005, 4007, 3, GumpButtonType.Reply, 0);
				AddHtmlLocalized(410, 416, 150, 20, 1011066, LabelColor, false, false); // Next page
			}

			for (var i = index; i < index + count && i >= 0 && i < list.Count; ++i)
			{
				var obj = list[i];


				if (obj is IXmlQuest)
				{
					var e = (IXmlQuest)obj;

					var y = 96 + tableIndex++ * 32;


					AddButton(60 - xoffset, y + 2, 0xFAB, 0xFAD, 2000 + i, GumpButtonType.Reply, 0); // open gump


					int color;

					if (!e.IsValid)
						color = 33;
					else
						if (e.IsCompleted)
						color = 67;
					else
						color = 5;


					AddLabel(100 - xoffset, y, color, e.Name);

					//AddHtmlLocalized( 315, y, 200, 32, e.IsCompleted ? 1049071 : 1049072, htmlcolor, false, false ); // Completed/Incomplete
					AddLabel(315 - xoffset, y, color, e.IsCompleted ? "Completed" : "In Progress");

					// indicate the expiration time
					if (e.IsValid)
					{

						// do a little parsing of the expiration string to fit it in the space
						var substring = e.ExpirationString;
						if (e.ExpirationString.IndexOf("Expires in") >= 0)
							substring = e.ExpirationString.Substring(11);
						AddLabel(400 - xoffset, y, color, substring);
					}
					else
						AddLabel(400 - xoffset, y, color, "No longer valid");

					if (e.PartyEnabled)

						AddLabel(270 - xoffset, y, color, "Party");
					else

						AddLabel(270 - xoffset, y, color, "Solo");

					AddLabel(515 - xoffset, y, color, e.Difficulty.ToString());

				}
				else
					if (obj is XmlQuestPoints.QuestEntry)
				{
					var e = (XmlQuestPoints.QuestEntry)obj;

					var y = 96 + tableIndex++ * 32;
					var color = 67;

					AddLabel(100 - xoffset, y, color, (string)e.Name);

					AddLabel(315 - xoffset, y, color, "Completed");

					if (e.PartyEnabled)

						AddLabel(270 - xoffset, y, color, "Party");
					else

						AddLabel(270 - xoffset, y, color, "Solo");

					AddLabel(515 - xoffset, y, color, e.Difficulty.ToString());

					//AddLabel( 560 - xoffset, y, color, e.WhenCompleted.ToString() );
					// determine when the quest can be done again by looking for an xmlquestattachment with the same name
					var qa = (XmlQuestAttachment)XmlAttach.FindAttachment(from, typeof(XmlQuestAttachment), e.Name);
					if (qa != null)
						if (qa.Expiration == TimeSpan.Zero)
							AddLabel(560 - xoffset, y, color, "Not Repeatable");
						else
						{
							DateTime nexttime = DateTime.Now + qa.Expiration;
							AddLabel(560 - xoffset, y, color, nexttime.ToString());
						}
					else
						// didnt find one so it can be done again
						AddLabel(560 - xoffset, y, color, "Available Now");

					AddLabel(741 - xoffset, y, color, e.TimesCompleted.ToString());
				}
			}
		}
	}
}
