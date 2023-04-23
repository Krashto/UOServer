using Server.Custom.Aptitudes;
using Server.Custom.Capacites;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using System;
using System.Collections.Generic;

namespace Server.Engines.Craft
{
	public class CraftGump : Gump
    {
        private readonly Mobile m_From;
        private readonly CraftSystem m_CraftSystem;
        private readonly ITool m_Tool;

        private readonly CraftPage m_Page;

        private const int LabelHue = 0x480;
        private const int LabelColor = 0x7FFF;
        private const int FontColor = 0xFFFFFF;

        public bool Locked => AutoCraftTimer.HasTimer(m_From);

        private int maxItemPerPage = 30;
        
        private enum CraftPage
        {
            None,
            PickResource,
            PickResource2
        }

        public CraftGump(Mobile from, CraftSystem craftSystem, ITool tool, object notice)
            : this(from, craftSystem, tool, notice, CraftPage.None)
        {
        }

        private CraftGump(Mobile from, CraftSystem craftSystem, ITool tool, object notice, CraftPage page)
            : base(40, 40)
        {
            m_From = from;
            m_CraftSystem = craftSystem;
            m_Tool = tool;
            m_Page = page;

            CraftContext context = craftSystem.GetContext(from);

            from.CloseGump(typeof(CraftGump));
            from.CloseGump(typeof(CraftGumpItem));

            AddPage(0);

            AddBackground(0, 0, 830, 537, 5120); //5054
			AddImageTiled(10, 10, 810, 22, 2624);
            AddImageTiled(10, 37, 200, 350, 2624);
            AddImageTiled(215, 37, 605, 350, 2624);
            AddImageTiled(10, 392, 150, 45, 2624);
            AddImageTiled(165, 392, 655, 45, 2624);
            AddImageTiled(10, 442, 810, 85, 2624);
            AddAlphaRegion(10, 10, 810, 517);

            AddHtml(10, 12, 810, 20, "<h3><basefont color=#FFFFFF><center>" + craftSystem.GumpTitleString + "</center><basefont></h3>", false, false);
              
            AddHtml(13, 37, 200, 20, "<h3><basefont color=#FFFFFF>Catégories<basefont></h3>", false, false);
            AddHtml(218, 37, 200, 20, "<h3><basefont color=#FFFFFF>Sélections<basefont></h3>", false, false);
            AddHtml(13, 402, 200, 20, "<h3><basefont color=#FFFFFF>Message<basefont></h3>", false, false);

            AddButton(15, 502, 4017, 4019, 0, GumpButtonType.Reply, 0);
            AddHtml(50, 502, 200, 20, "<h3><basefont color=#FFFFFF>Quitter<basefont></h3>", false, false);

            AddButton(270, 442, 4017, 4019, GetButtonID(6, 11), GumpButtonType.Reply, 0);
            AddHtmlLocalized(305, 445, 150, 18, 1112698, LabelColor, false, false); // CANCEL MAKE

			AddButton(650, 485, 4005, 4007, GetButtonID(6, 2), GumpButtonType.Reply, 0);
			AddHtml(685, 485, 200, 20, "<h3><basefont color=#FFFFFF>Refaire<basefont></h3>", false, false);

            // Repair option
            if (m_CraftSystem.Repair)
            {
                AddButton(650, 442, 4005, 4007, GetButtonID(6, 5), GumpButtonType.Reply, 0);
                AddHtml(685, 445, 200, 20, "<h3><basefont color=#FFFFFF>Réparer<basefont></h3>", false, false);    
            }
            // ****************************************

            // Mark option
            if (m_CraftSystem.MarkOption)
            {
                AddButton(650, 462, 4005, 4007, GetButtonID(6, 6), GumpButtonType.Reply, 0);
               
                if (context.MarkOption == CraftMarkOption.DoNotMark)
                    AddHtml(685, 465, 200, 20, "<h3><basefont color=#FFFFFF>Marquer<basefont></h3>", false, false);
                else
                    AddHtml(685, 465, 200, 20, "<h3><basefont color=#FFFFFF>Ne Pas Marquer<basefont></h3>", false, false);
            }
            
            int total = 1;
            int made = 0;

            if (Locked && AutoCraftTimer.AutoCraftTable.ContainsKey(m_From))
            {
                AutoCraftTimer timer = AutoCraftTimer.AutoCraftTable[m_From];

                if (timer != null)
                {
                    total = timer.Amount;
                    made = timer.Attempts;
                }
                else
                {
                    if (context != null)
                        total = context.MakeTotal;
                }
            }

            string args = string.Format("{0}\t{1}", made.ToString(), total.ToString());

            AddHtmlLocalized(270, 468, 150, 18, 1079443, args, LabelColor, false, false); //~1_DONE~/~2_TOTAL~ COMPLETED

            // Resmelt option
            if (m_CraftSystem.Resmelt)
            {
                AddButton(415, 442, 4005, 4007, GetButtonID(6, 1), GumpButtonType.Reply, 0);
                AddHtml(450, 445, 150, 20, "<h3><basefont color=#FFFFFF>Détruire<basefont></h3>", false, false);
            }
            // ****************************************

            if (notice is int && (int)notice > 0)
                AddHtmlLocalized(170, 395, 810, 40, (int)notice, LabelColor, false, false);
            else if (notice is string)
                 AddHtml(170, 395, 810, 40, "<h3><basefont color=#FFFFFF>" + notice + "<basefont></h3>", false, false);

            // If the system has more than one resource
            if (craftSystem.CraftSubRes.Init)
            {
                string nameString = craftSystem.CraftSubRes.NameString;

                int resIndex = (context == null ? -1 : context.LastResourceIndex);

                Type resourceType = craftSystem.CraftSubRes.ResType;

                if (resIndex > -1)
                {
                    CraftSubRes subResource = craftSystem.CraftSubRes.GetAt(resIndex);

                    nameString = subResource.NameString;
                    resourceType = subResource.ItemType;
                }
				else
				{
					CraftSubRes subResource = craftSystem.CraftSubRes.GetAt(0);

					nameString = subResource.NameString;
					resourceType = subResource.ItemType;
				}

				Type resourceType2 = GetAltType(resourceType);
                int resourceCount = 0;

                if (from.Backpack != null)
                {
                    Item[] items = from.Backpack.FindItemsByType(resourceType, true);

                    for (int i = 0; i < items.Length; ++i)
                        resourceCount += items[i].Amount;

                    if (resourceType2 != null)
                    {
                        Item[] items2 = m_From.Backpack.FindItemsByType(resourceType2, true);

                        for (int i = 0; i < items2.Length; ++i)
                            resourceCount += items2[i].Amount;
                    }
                }

                AddButton(15, 442, 4005, 4007, GetButtonID(6, 0), GumpButtonType.Reply, 0);

                AddHtml(50, 445, 450, 40, "<h3><basefont color=#FFFFFF>" + nameString + " [" + resourceCount + "]<basefont></h3>", false, false);
            }
            // ****************************************

            // For dragon scales
            if (craftSystem.CraftSubRes2.Init)
            {
                string nameString = craftSystem.CraftSubRes2.NameString;

                int resIndex = (context == null ? -1 : context.LastResourceIndex2);

                Type resourceType = craftSystem.CraftSubRes2.ResType;

                if (resIndex > -1)
                {
                    CraftSubRes subResource = craftSystem.CraftSubRes2.GetAt(resIndex);

                    nameString = subResource.NameString;
                    resourceType = subResource.ItemType;
                }

                int resourceCount = 0;

                if (from.Backpack != null)
                {
                    Item[] items = from.Backpack.FindItemsByType(resourceType, true);

                    for (int i = 0; i < items.Length; ++i)
                        resourceCount += items[i].Amount;
                }

                AddButton(15, 470, 4005, 4007, GetButtonID(6, 7), GumpButtonType.Reply, 0);

                AddHtml(50, 470, 450, 40, "<h3><basefont color=#FFFFFF>" + nameString + " [" + resourceCount + "]<basefont></h3>", false, false);
            }
            // ****************************************

            CreateGroupList();

            if (page == CraftPage.PickResource)
                CreateResList(false, from);
            else if (page == CraftPage.PickResource2)
                CreateResList(true, from);
            else if (context != null && context.LastGroupIndex > -1)
                CreateItemList(context.LastGroupIndex);
        }

        private Type GetAltType(Type original)
        {
            for (int i = 0; i < m_TypesTable.Length; i++)
            {
                if (original == m_TypesTable[i][0] && m_TypesTable[i].Length > 1)
                    return m_TypesTable[i][1];

                if (m_TypesTable[i].Length > 1 && original == m_TypesTable[i][1])
                    return m_TypesTable[i][0];
            }

            return null;
        }

        private readonly Type[][] m_TypesTable = new Type[][]
        {
            new Type[]{ typeof( RegularLog ), typeof( RegularBoard ) },
            new Type[]{ typeof( HeartwoodLog ), typeof( HeartwoodBoard ) },
            new Type[]{ typeof( BloodwoodLog ), typeof( BloodwoodBoard ) },
            new Type[]{ typeof( FrostwoodLog ), typeof( FrostwoodBoard ) },
            new Type[]{ typeof( OakLog ), typeof( OakBoard ) },
            new Type[]{ typeof( AshLog ), typeof( AshBoard ) },
            new Type[]{ typeof( YewLog ), typeof( YewBoard ) },
            new Type[]{ typeof( PlainoisLeather ), typeof( PlainoisHides ) },
            new Type[]{ typeof( ForestierLeather ), typeof(ForestierHides) },
            new Type[]{ typeof(DesertiqueLeather), typeof(DesertiqueHides) },
            new Type[]{ typeof(CollinoisLeather), typeof(CollinoisHides) },
			new Type[]{ typeof(SavanoisLeather), typeof(SavanoisHides) },
			new Type[]{ typeof(ToundroisLeather), typeof(ToundroisHides) },
			new Type[]{ typeof(TropicauxLeather), typeof(TropicauxHides) },
			new Type[]{ typeof(MontagnardLeather), typeof(MontagnardHides) },
			new Type[]{ typeof(AncienLeather), typeof(AncienHides) }
		};

        public void CreateResList(bool opt, Mobile from)
        {
            CraftSubResCol res = (opt ? m_CraftSystem.CraftSubRes2 : m_CraftSystem.CraftSubRes);
			var column = -1;
			var columnSpace = 200;
			var resPerColumn = 10;
			var resPerPage = resPerColumn * 3;

			for (int i = 0; i < res.Count; ++i)
            {
				int index = i % resPerColumn;

				if (index == 0)
					column++;

				if (i != 0 && i % resPerPage == 0)
					column = 0;

                CraftSubRes subResource = res.GetAt(i);

                if (index == 0)
                {
                    if (i > 0 && res.Count > resPerPage)
                        AddButton(485, 360, 4005, 4007, 0, GumpButtonType.Page, (i / resPerPage) + 1);

                    AddPage((i / resPerPage) + 1);

                    if (i >= resPerPage)
                        AddButton(455, 360, 4014, 4015, 0, GumpButtonType.Page, i / resPerPage);

                    CraftContext context = m_CraftSystem.GetContext(m_From);

                    AddButton(220, 260, 4005, 4007, GetButtonID(6, 4), GumpButtonType.Reply, 0);
                    AddHtmlLocalized(255, 260, 200, 18, (context == null || !context.DoNotColor) ? 1061591 : 1061590, LabelColor, false, false);
                }

                int resourceCount = 0;

                if (from.Backpack != null)
                {
                    Item[] items = from.Backpack.FindItemsByType(subResource.ItemType, true);

                    for (int j = 0; j < items.Length; ++j)
                        resourceCount += items[j].Amount;

                    Type alt = GetAltType(subResource.ItemType);

                    if (alt != null)
                    {
                        Item[] items2 = m_From.Backpack.FindItemsByType(alt, true);

                        for (int j = 0; j < items2.Length; ++j)
                            resourceCount += items2[j].Amount;
                    }
                }

                AddButton(220 + column * columnSpace, 60 + (index * 20), 4005, 4007, GetButtonID(5, i), GumpButtonType.Reply, 0);
                AddHtml(255 + column * columnSpace, 60 + (index * 20), 200, 20, "<h3><basefont color=#FFFFFF>" + subResource.NameString + " [" + resourceCount + "]" + "<basefont></h3>", false, false);
            }
        }

        public void CreateMakeLastList()
        {
            CraftContext context = m_CraftSystem.GetContext(m_From);

            if (context == null)
                return;

            List<CraftItem> items = context.Items;

            if (items.Count > 0)
            {
                for (int i = 0; i < items.Count; ++i)
                {
                    int index = i % 10;

                    CraftItem craftItem = items[i];

                    if (index == 0)
                    {
                        if (i > 0)
                        {
                            AddButton(370, 360, 4005, 4007, 0, GumpButtonType.Page, (i / 10) + 1);
                            AddHtml(405, 263, 200, 20, "<h3><basefont color=#FFFFFF>Page Suivante<basefont></h3>", false, false);
                        }

                        AddPage((i / 10) + 1);

                        if (i > 0)
                        {
                            AddButton(220, 360, 4014, 4015, 0, GumpButtonType.Page, i / 10);
                            AddHtml(255, 363, 200, 20, "<h3><basefont color=#FFFFFF>Page Précédante<basefont></h3>", false, false);
                        }
                    }

                    AddButton(220, 60 + (index * 20), 4005, 4007, GetButtonID(3, i), GumpButtonType.Reply, 0);

                    AddHtml(255, 60 + (index * 20), 200, 20, "<h3><basefont color=#FFFFFF>" + craftItem.NameString + "<basefont></h3>", false, false);

                    AddButton(480, 60 + (index * 20), 4011, 4012, GetButtonID(4, i), GumpButtonType.Reply, 0);
                }
            }
            else
                AddHtml(230, 62, 400, 20, "<h3><basefont color=#FFFFFF>Vous n'avez encore rien fait.<basefont></h3>", false, false);
        }

        public void CreateItemList(int selectedGroup)
        {
            int numberOfPage = 0;

            if (selectedGroup == 501) // 501 : Last 10
            {
                CreateMakeLastList();
                return;
            }

            CraftGroupCol craftGroupCol = m_CraftSystem.CraftGroups;
            CraftGroup craftGroup = craftGroupCol.GetAt(selectedGroup);

            if (craftGroup == null)
                return;

            CraftItemCol craftItemCol = craftGroup.CraftItems;

            for (int i = 0; i < craftItemCol.Count; ++i)
            {
                int index = i % maxItemPerPage;

                CraftItem craftItem = craftItemCol.GetAt(i);

                if (index == 0)
                {
                    if (i > 0)
                    {
                        AddButton(780, 360, 4005, 4007, 0, GumpButtonType.Page, (i / maxItemPerPage) + 1);
                        AddHtml(655, 363, 200, 20, "<h3><basefont color=#FFFFFF>Page Suivante<basefont></h3>", false, false);
                    }

                    AddPage((i / maxItemPerPage) + 1);

                    numberOfPage++;

                    if (i > 0)
                    {
                        AddButton(220, 360, 4014, 4015, 0, GumpButtonType.Page, i / maxItemPerPage);
                        AddHtml(255, 363, 200, 20, "<h3><basefont color=#FFFFFF>Page Précédante<basefont></h3>", false, false);
                    }
                }

                if (i < (maxItemPerPage / 2 + ((numberOfPage - 1) * maxItemPerPage)))
                {
                    AddButton(220, 60 + (index * 20), 4005, 4007, GetButtonID(1, i), GumpButtonType.Reply, 0);
                    AddHtml(255, 60 + (index * 20), 200, 20, "<h3><basefont color=#FFFFFF>" + craftItem.NameString + "<basefont></h3>", false, false);
                    AddButton(480, 60 + (index * 20), 4011, 4012, GetButtonID(2, i), GumpButtonType.Reply, 0);
                }
                else
                {
                    AddButton(520, 60 + ((index - maxItemPerPage / 2) * 20), 4005, 4007, GetButtonID(1, i), GumpButtonType.Reply, 0);
                    AddHtml(555, 60 + ((index - maxItemPerPage / 2) * 20), 200, 20, "<h3><basefont color=#FFFFFF>" + craftItem.NameString + "<basefont></h3>", false, false);
                    AddButton(780, 60 + ((index - maxItemPerPage / 2) * 20), 4011, 4012, GetButtonID(2, i), GumpButtonType.Reply, 0);
                }
            }
        }

        public int CreateGroupList()
        {
            CraftGroupCol craftGroupCol = m_CraftSystem.CraftGroups;

            AddButton(15, 60, 4005, 4007, GetButtonID(6, 3), GumpButtonType.Reply, 0);
            AddHtmlLocalized(50, 63, 150, 18, 1044014, LabelColor, false, false); // LAST TEN

            for (int i = 0; i < craftGroupCol.Count; i++)
            {
                CraftGroup craftGroup = craftGroupCol.GetAt(i);

                AddButton(15, 80 + (i * 20), 4005, 4007, GetButtonID(0, i), GumpButtonType.Reply, 0);

                AddHtml(50, 80 + (i * 20), 200, 20, "<h3><basefont color=#FFFFFF>" + craftGroup.NameString + "<basefont></h3>", false, false);
            }

            return craftGroupCol.Count;
        }

        public static int GetButtonID(int type, int index)
        {
            return 1 + type + (index * 7);
        }

        public void CraftItem(CraftItem item)
        {
            if (item.TryCraft != null)
            {
                item.TryCraft(m_From, item, m_Tool);
                return;
            }

            int num = m_CraftSystem.CanCraft(m_From, m_Tool, item.ItemType);

            if (num > 0)
            {
                m_From.SendGump(new CraftGump(m_From, m_CraftSystem, m_Tool, num));
            }
            else
            {
                Type type = null;

                CraftContext context = m_CraftSystem.GetContext(m_From);

                if (context != null)
                {
                    CraftSubResCol res = (item.UseSubRes2 ? m_CraftSystem.CraftSubRes2 : m_CraftSystem.CraftSubRes);
                    int resIndex = (item.UseSubRes2 ? context.LastResourceIndex2 : context.LastResourceIndex);

                    if (resIndex >= 0 && resIndex < res.Count)
                        type = res.GetAt(resIndex).ItemType;
                }

                m_CraftSystem.CreateItem(m_From, item.ItemType, type, m_Tool, item);
            }
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            if (info.ButtonID <= 0)
                return; // Canceled

            int buttonID = info.ButtonID - 1;
            int type = buttonID % 7;
            int index = buttonID / 7;

            CraftSystem system = m_CraftSystem;
            CraftGroupCol groups = system.CraftGroups;
            CraftContext context = system.GetContext(m_From);

            if (Locked)
            {
                if (type == 6 && index == 11)
                {
                    // Cancel Make
                    AutoCraftTimer.EndTimer(m_From);
                }
                return;
            }

            switch (type)
            {
                case 0: // Show group
                    {
                        if (context == null)
                            break;

                        if (index >= 0 && index < groups.Count)
                        {
                            context.LastGroupIndex = index;
                            m_From.SendGump(new CraftGump(m_From, system, m_Tool, null));
                        }

                        break;
                    }
                case 1: // Create item
                    {
                        if (context == null)
                            break;

                        int groupIndex = context.LastGroupIndex;

                        if (groupIndex >= 0 && groupIndex < groups.Count)
                        {
                            CraftGroup group = groups.GetAt(groupIndex);

                            if (index >= 0 && index < group.CraftItems.Count)
                                CraftItem(group.CraftItems.GetAt(index));
                        }

                        break;
                    }
                case 2: // Item details
                    {
                        if (context == null)
                            break;

                        int groupIndex = context.LastGroupIndex;

                        if (groupIndex >= 0 && groupIndex < groups.Count)
                        {
                            CraftGroup group = groups.GetAt(groupIndex);

                            if (index >= 0 && index < group.CraftItems.Count)
                                m_From.SendGump(new CraftGumpItem(m_From, system, group.CraftItems.GetAt(index), m_Tool));
                        }

                        break;
                    }
                case 3: // Create item (last 10)
                    {
                        if (context == null)
                            break;

                        List<CraftItem> lastTen = context.Items;

                        if (index >= 0 && index < lastTen.Count)
                            CraftItem(lastTen[index]);

                        break;
                    }
                case 4: // Item details (last 10)
                    {
                        if (context == null)
                            break;

                        List<CraftItem> lastTen = context.Items;

                        if (index >= 0 && index < lastTen.Count)
                            m_From.SendGump(new CraftGumpItem(m_From, system, lastTen[index], m_Tool));

                        break;
                    }
                case 5: // Resource selected
                    {
                        if (m_Page == CraftPage.PickResource && index >= 0 && index < system.CraftSubRes.Count)
                        {
                            int groupIndex = (context == null ? -1 : context.LastGroupIndex);

                            CraftSubRes res = system.CraftSubRes.GetAt(index);

							var pm = m_From as CustomPlayerMobile;
							var resource = CraftResources.GetFromType(res.ItemType);
							var level = CraftResources.GetLevel(resource);

							if ((m_From.Skills[system.MainSkill].Base < res.RequiredSkill))
							{
								m_From.SendGump(new CraftGump(m_From, system, m_Tool, $"Niveau requis de compétence: {res.RequiredSkill}% de {system.MainSkill}"));
							}
							else if ((pm != null && pm.Capacites[Capacite.Expertise] < level))
                            {
                                m_From.SendGump(new CraftGump(m_From, system, m_Tool, $"Niveau requis d'expertise: {level}"));
                            }
                            else
                            {
                                if (context != null)
                                    context.LastResourceIndex = index;

                                m_From.SendGump(new CraftGump(m_From, system, m_Tool, null));
                            }
                        }
                        else if (m_Page == CraftPage.PickResource2 && index >= 0 && index < system.CraftSubRes2.Count)
                        {
                            int groupIndex = (context == null ? -1 : context.LastGroupIndex);

                            CraftSubRes res = system.CraftSubRes2.GetAt(index);
							var pm = m_From as CustomPlayerMobile;
							var resource = CraftResources.GetFromType(res.ItemType);
							var level = CraftResources.GetLevel(resource);

							if (m_From.Skills[system.MainSkill].Base < res.RequiredSkill || (pm != null && pm.Capacites[Capacite.Expertise] < level))
                            {
                                m_From.SendGump(new CraftGump(m_From, system, m_Tool, res.Message));
                            }
                            else
                            {
                                if (context != null)
                                    context.LastResourceIndex2 = index;

                                m_From.SendGump(new CraftGump(m_From, system, m_Tool, null));
                            }
                        }

                        break;
                    }
                case 6: // Misc. buttons
                    {
                        switch (index)
                        {
                            case 0: // Resource selection
                                {
                                    if (system.CraftSubRes.Init)
                                        m_From.SendGump(new CraftGump(m_From, system, m_Tool, null, CraftPage.PickResource));

                                    break;
                                }
                            case 1: // Smelt item
                                {
                                    if (system.Resmelt)
                                        Resmelt.Do(m_From, system, m_Tool);

                                    break;
                                }
                            case 2: // Make last
                                {
                                    if (context == null)
                                        break;

                                    CraftItem item = context.LastMade;

                                    if (item != null)
                                        CraftItem(item);
                                    else
                                        m_From.SendGump(new CraftGump(m_From, m_CraftSystem, m_Tool, 1044165, m_Page)); // You haven't made anything yet.

                                    break;
                                }
                            case 3: // Last 10
                                {
                                    if (context == null)
                                        break;

                                    context.LastGroupIndex = 501;
                                    m_From.SendGump(new CraftGump(m_From, system, m_Tool, null));

                                    break;
                                }
                            case 4: // Toggle use resource hue
                                {
                                    if (context == null)
                                        break;

                                    context.DoNotColor = !context.DoNotColor;

                                    m_From.SendGump(new CraftGump(m_From, m_CraftSystem, m_Tool, null, m_Page));

                                    break;
                                }
                            case 5: // Repair item
                                {
                                    if (system.Repair)
                                        Repair.Do(m_From, system, m_Tool);

                                    break;
                                }
                            case 6: // Toggle mark option
                                {
                                    if (context == null || !system.MarkOption)
                                        break;

                                    switch (context.MarkOption)
                                    {
                                        case CraftMarkOption.MarkItem:
                                            context.MarkOption = CraftMarkOption.DoNotMark;
                                            break;
                                        case CraftMarkOption.DoNotMark:
                                            context.MarkOption = CraftMarkOption.PromptForMark;
                                            break;
                                        case CraftMarkOption.PromptForMark:
                                            context.MarkOption = CraftMarkOption.MarkItem;
                                            break;
                                    }

                                    m_From.SendGump(new CraftGump(m_From, m_CraftSystem, m_Tool, null, m_Page));

                                    break;
                                }
                            case 7: // Resource selection 2
                                {
                                    if (system.CraftSubRes2.Init)
                                        m_From.SendGump(new CraftGump(m_From, system, m_Tool, null, CraftPage.PickResource2));

                                    break;
                                }
                            case 11: // Cancel Make
                                {
                                    AutoCraftTimer.EndTimer(m_From);
                                    break;
                                }
                        }
                        break;
                    }
            }
        }
    }
}
