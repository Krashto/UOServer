using System;
using Server.Gumps;
using Server.Network;

namespace Server.Engines.BulkOrders
{
    public class SmallBODAcceptGump : BaseProjectMGump
	{
        private readonly SmallBOD m_Deed;
        private readonly Mobile m_From;
        public SmallBODAcceptGump(Mobile from, SmallBOD deed) : base("Contrat de fabrication", 450, 300, false)
		{
            m_From = from;
            m_Deed = deed;

            m_From.CloseGump(typeof(LargeBODAcceptGump));
            m_From.CloseGump(typeof(SmallBODAcceptGump));

            AddPage(0);

			int y = 100;
			int line = 0;
			int lineSpace = 25;

			AddSection(100, y + lineSpace * line++, 425, 275, "Contrat");
			line++;

			AddHtmlTexte(150, y + lineSpace * line++, 400, 20, "Voulez-vous m'aider ?");

			AddHtmlTexte(150, y + lineSpace * line, 400, 20, "Item demandée:"); // Item requested:
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

			AddHtmlTexte(150, y + lineSpace * line, 400, 20, "Quantité à fabriquer:"); // Amount to make:
			AddHtmlTexte(375, y + lineSpace * line++, 400, 20, deed.AmountMax.ToString());
			
            AddItem(400, 125, deed.Graphic, deed.GraphicHue);

            if (deed.RequireExceptional || deed.Material != BulkMaterialType.None)
            {
                AddHtmlTexte(150, y + lineSpace * line++, 400, 20, "Particularités:"); // Special requirements to meet:

                if (deed.RequireExceptional)
					AddHtmlTexte(150, y + lineSpace * line++, 400, 20, "Tous les items doivent être de qualité exceptionelle."); // All items must be exceptional.

                if (deed.Material != BulkMaterialType.None)
					AddHtmlLocalized(150, y + lineSpace * line++, 400, 20, SmallBODGump.GetMaterialNumberFor(deed.Material), 0x7FFF, false, false); // All items must be made with x material.
            }

			AddHtmlTexte(150, y + lineSpace * line++, 350, 20, "Voulez-vous accepter cette commande ?"); // Do you want to accept this order?

            AddButton(150, y + lineSpace * line, 4005, 4007, 1, GumpButtonType.Reply, 0);
			AddHtmlTexte(185, y + lineSpace * line, 400, 20, "Accepter");

            AddButton(350, y + lineSpace * line, 4005, 4007, 0, GumpButtonType.Reply, 0);
			AddHtmlTexte(385, y + lineSpace * line, 400, 20, "Refuser");
		}

        public override void OnServerClose(NetState owner)
        {
            Timer.DelayCall(() =>
            {
                if (m_Deed.Map == null || m_Deed.Map == Map.Internal)
                {
                    m_Deed.Delete();
                }
            });
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            if (info.ButtonID == 1) // Ok
            {
                if (m_From.PlaceInBackpack(m_Deed))
                {
                    m_From.SendLocalizedMessage(1045152); // The bulk order deed has been placed in your backpack.
                }
                else
                {
                    m_From.SendLocalizedMessage(1045150); // There is not enough room in your backpack for the deed.
                    m_Deed.Delete();
                }
            }
            else
            {
                m_Deed.Delete();
            }
        }
    }
}