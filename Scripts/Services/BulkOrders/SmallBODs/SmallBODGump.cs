using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Server.Engines.BulkOrders
{
    public class SmallBODGump : BaseProjectMGump
	{
        private readonly SmallBOD m_Deed;
        private readonly Mobile m_From;

        public SmallBODGump(Mobile from, SmallBOD deed) : base("Contrat de fabrication", 525, 425, false)
		{
            m_From = from;
            m_Deed = deed;

            m_From.CloseGump(typeof(LargeBODGump));
            m_From.CloseGump(typeof(SmallBODGump));

            AddPage(0);

            int y = 100;
			int line = 0;
			int lineSpace = 25;

			AddSection(100, y + lineSpace * line++, 500, 400, "Contrat");
			line++;
			AddHtmlTexte(150, y + lineSpace * line, 400, 20, "Quantité à fabriquer"); // Amount to make:
			AddHtmlTexte(375, y + lineSpace * line++, 400, 20, deed.AmountMax.ToString());

			AddHtmlTexte(150, y + lineSpace * line, 400, 20, "Quantité complétée:"); // Amount finished:
			AddHtmlTexte(375, y + lineSpace * line++, 400, 20, deed.AmountCur.ToString());
			
			AddHtmlTexte(150, y + lineSpace * line, 400, 20, "Item demandée"); // Item requested:
			var item = (Item)Activator.CreateInstance(deed.Type);
			if (item != null)
			{
				var name = item.Name;
				if (string.IsNullOrEmpty(item.Name))
					name = System.Text.RegularExpressions.Regex.Replace(deed.Type.Name, "[A-Z]", " $0").Trim();
				AddHtmlTexte(375, y + lineSpace * line, 400, 20, name);
			}
			item.Delete();
			line++;

			AddItem(510, 125, deed.Graphic, deed.GraphicHue);

            if (deed.RequireExceptional || deed.Material != BulkMaterialType.None)
                AddHtmlTexte(150, y + lineSpace * line++, 400, 20, "Particularités:"); // Special requirements to meet:

            if (deed.RequireExceptional)
				AddHtmlTexte(150, y + lineSpace * line++, 400, 20, "Tous les items doivent être de qualité exceptionelle."); // All items must be exceptional.

            if (deed.Material != BulkMaterialType.None)
                AddHtmlLocalized(150, y + lineSpace * line++, 400, 20, GetMaterialNumberFor(deed.Material), 0x7FFF, false, false); // All items must be made with x material.

            if (from is PlayerMobile && BulkOrderSystem.NewSystemEnabled)
            {
                AddButton(150, y + lineSpace * line, 4005, 4007, 2, GumpButtonType.Reply, 0);
				AddHtmlTexte(190, y + lineSpace * line++, 400, 20, "Ajouter un item au contrat de fabrication."); // Combine this deed with the item requested.

                AddButton(150, y + lineSpace * line, 4005, 4007, 4, GumpButtonType.Reply, 0);
				AddHtmlTexte(190, y + lineSpace * line++, 400, 20, "Ajouter les item d'un sac au contrat de fabrication."); // Combine this deed with contained items.
            }
            else
            {
                AddButton(150, y + lineSpace * line, 4005, 4007, 2, GumpButtonType.Reply, 0);
				AddHtmlTexte(190, y + lineSpace * line++, 400, 20, "Ajouter un item au contrat de fabrication."); // Combine this deed with the item requested.
            }

            AddButton(150, y + lineSpace * line, 4005, 4007, 1, GumpButtonType.Reply, 0);
			AddHtmlTexte(190, y + lineSpace * line++, 400, 20, "Quitter"); // EXIT
        }

        public static int GetMaterialNumberFor(BulkMaterialType material)
        {
            if (material >= BulkMaterialType.DullCopper && material <= BulkMaterialType.Valorite)
                return 1045142 + (material - BulkMaterialType.DullCopper);
            else if (material >= BulkMaterialType.Spined && material <= BulkMaterialType.Barbed)
                return 1049348 + (material - BulkMaterialType.Spined);
            else if (material >= BulkMaterialType.OakWood && material <= BulkMaterialType.Frostwood)
            {
                switch (material)
                {
                    case BulkMaterialType.OakWood: return 1071428;
                    case BulkMaterialType.AshWood: return 1071429;
                    case BulkMaterialType.YewWood: return 1071430;
                    case BulkMaterialType.Heartwood: return 1071432;
                    case BulkMaterialType.Bloodwood: return 1071431;
                    case BulkMaterialType.Frostwood: return 1071433;
                }
            }
            return 0;
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            if (m_Deed.Deleted || !m_Deed.IsChildOf(m_From.Backpack))
                return;

            switch (info.ButtonID)
            {
                case 2: // Combine
                    {
                        m_From.SendGump(new SmallBODGump(m_From, m_Deed));
                        m_Deed.BeginCombine(m_From);
                        break;
                    }
                case 3: // points mode
                    {
                        BODContext c = BulkOrderSystem.GetContext(m_From);

                        if (c != null)
                        {
                            switch (c.PointsMode)
                            {
                                case PointsMode.Enabled: c.PointsMode = PointsMode.Disabled; break;
                                case PointsMode.Disabled: c.PointsMode = PointsMode.Automatic; break;
                                case PointsMode.Automatic: c.PointsMode = PointsMode.Enabled; break;
                            }
                        }

                        m_From.SendGump(new SmallBODGump(m_From, m_Deed));
                        break;
                    }
                case 4: // combine from container
                    {
                        m_From.BeginTarget(-1, false, Targeting.TargetFlags.None, (m, targeted) =>
                            {
                                if (!m_Deed.Deleted && targeted is Container)
                                {
                                    List<Item> list = new List<Item>(((Container)targeted).Items);

                                    foreach (Item item in list)
                                    {
                                        m_Deed.EndCombine(m_From, item);
                                    }
                                }
                            });
                        break;
                    }
            }
        }
    }
}