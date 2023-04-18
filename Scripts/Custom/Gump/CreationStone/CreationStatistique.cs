using Server.Mobiles;
using Server.Network;

namespace Server.Gumps
{
  public class CreationStatistique : CreationBaseGump
    {
        public CreationStatistique (CustomPlayerMobile from, CreationPerso creationPerso) : base(from, creationPerso, "Statistique",true, creationPerso.CheckStats())
        {
            int x = XBase;
            int y = YBase;
            int line = 0;
            int lineSpace = 20;

            AddSection(x - 10, y + lineSpace * line++, 610, lineSpace * 10, "Sélection");
			line++;
			AddLabel(x + 185, y + lineSpace * line, 2101, "Force");
			AddLabel(x + 285, y + lineSpace * line, 2101, ":");
			AddButton(x + 290, y + lineSpace * line + 2, 5603, 5607, 238, GumpButtonType.Reply, 0);
			AddButton(x + 310, y + lineSpace * line + 2, 5603, 5607, 138, GumpButtonType.Reply, 0);
			AddLabel(x + 340, y + lineSpace * line, 2101, creationPerso.Str.ToString());
			AddButton(x + 370, y + lineSpace * line + 2, 5601, 5605, 139, GumpButtonType.Reply, 0);
			AddButton(x + 390, y + lineSpace * line++ + 2, 5601, 5605, 239, GumpButtonType.Reply, 0);

			AddLabel(x + 185, y + lineSpace * line, 2101, "Dextérité");
			AddLabel(x + 285, y + lineSpace * line, 2101, ":");
			AddButton(x + 290, y + lineSpace * line + 2, 5603, 5607, 240, GumpButtonType.Reply, 0);
			AddButton(x + 310, y + lineSpace * line + 2, 5603, 5607, 140, GumpButtonType.Reply, 0);
			AddLabel(x + 340, y + lineSpace * line, 2101, creationPerso.Dex.ToString());
			AddButton(x + 370, y + lineSpace * line + 2, 5601, 5605, 141, GumpButtonType.Reply, 0);
			AddButton(x + 390, y + lineSpace * line++ + 2, 5601, 5605, 241, GumpButtonType.Reply, 0);

			AddLabel(x + 185, y + lineSpace * line, 2101, "Intelligence");
			AddLabel(x + 285, y + lineSpace * line, 2101, ":");
			AddButton(x + 290, y + lineSpace * line + 2, 5603, 5607, 242, GumpButtonType.Reply, 0);
			AddButton(x + 310, y + lineSpace * line + 2, 5603, 5607, 142, GumpButtonType.Reply, 0);
			AddLabel(x + 340, y + lineSpace * line, 2101, creationPerso.Int.ToString());
			AddButton(x + 370, y + lineSpace * line + 2, 5601, 5605, 143, GumpButtonType.Reply, 0);
			AddButton(x + 390, y + lineSpace * line++ + 2, 5601, 5605, 243, GumpButtonType.Reply, 0);

			AddLabel(x + 185, y + lineSpace * line, 2101, "Constitution");
			AddLabel(x + 285, y + lineSpace * line, 2101, ":");
			AddButton(x + 290, y + lineSpace * line + 2, 5603, 5607, 244, GumpButtonType.Reply, 0);
			AddButton(x + 310, y + lineSpace * line + 2, 5603, 5607, 144, GumpButtonType.Reply, 0);
			AddLabel(x + 340, y + lineSpace * line, 2101, creationPerso.Const.ToString());
			AddButton(x + 370, y + lineSpace * line + 2, 5601, 5605, 145, GumpButtonType.Reply, 0);
			AddButton(x + 390, y + lineSpace * line++ + 2, 5601, 5605, 245, GumpButtonType.Reply, 0);

			AddLabel(x + 185, y + lineSpace * line, 2101, "Endurance");
			AddLabel(x + 285, y + lineSpace * line, 2101, ":");
			AddButton(x + 290, y + lineSpace * line + 2, 5603, 5607, 246, GumpButtonType.Reply, 0);
			AddButton(x + 310, y + lineSpace * line + 2, 5603, 5607, 146, GumpButtonType.Reply, 0);
			AddLabel(x + 340, y + lineSpace * line, 2101, creationPerso.Endur.ToString());
			AddButton(x + 370, y + lineSpace * line + 2, 5601, 5605, 147, GumpButtonType.Reply, 0);
			AddButton(x + 390, y + lineSpace * line++ + 2, 5601, 5605, 247, GumpButtonType.Reply, 0);

			AddLabel(x + 185, y + lineSpace * line, 2101, "Sagesse");
			AddLabel(x + 285, y + lineSpace * line, 2101, ":");
			AddButton(x + 290, y + lineSpace * line + 2, 5603, 5607, 248, GumpButtonType.Reply, 0);
			AddButton(x + 310, y + lineSpace * line + 2, 5603, 5607, 148, GumpButtonType.Reply, 0);
			AddLabel(x + 340, y + lineSpace * line, 2101, creationPerso.Sag.ToString());
			AddButton(x + 370, y + lineSpace * line + 2, 5601, 5605, 149, GumpButtonType.Reply, 0);
			AddButton(x + 390, y + lineSpace * line++ + 2, 5601, 5605, 249, GumpButtonType.Reply, 0);

			AddLabel(x + 185, y + lineSpace * line, 2101, "Points restants");
			AddLabel(x + 285, y + lineSpace * line, 2101, ":");
			var restants = creationPerso.GetPointsRestants();
			AddLabel(x + 342 + (restants > 100 ? -5 : 0) , y + lineSpace * line++, 2101, restants.ToString());

			string detail = "Force (Conseillée aux guerriers et récolteurs)\r\n-Permet de frapper plus fort avec une arme\r\n-Supporter plus de poids (Stone)\r\n\r\nDextérité (Conseillée aux guerriers)\r\n-Permet de frapper plus vite\r\n-Bonus de parade\r\n\r\nIntelligence (Conseillée aux magiciens)\r\n-Bonus sur les dégats magiques\r\n-Bonus sur la durée des buffs magiques\r\n-Bonus sur l'efficacité des buffs magiques\r\n\r\nConstitution (Conseillée à tous)\r\n-Augmente le nombre de points de vie\r\n-Meilleure regénération de points de vie\r\n\r\nEndurance (Conseillée à tous)\r\n-Augmente le nombre de points de stamina\r\n-Meilleure regénération de points de stamina\r\n\r\nSagesse (Conseillée à tous)\r\n-Augmente le nombre de points de mana\r\n-Meilleure regénération de points de mana";

			AddSection(x - 10, y + lineSpace * 10 + 1, 610, lineSpace * 20 + 8, "Détails", detail);
		}

		public override void OnResponse(NetState sender, RelayInfo info)
        {
			CustomPlayerMobile from = (CustomPlayerMobile)sender.Mobile;

			if (from.Deleted || !from.Alive)
				return;

			if (info.ButtonID == 138)
			{
				m_Creation.Str -= 1;
				from.SendGump(new CreationStatistique(from, m_Creation));
			}
			else if (info.ButtonID == 139)
			{
				m_Creation.Str += 1;
				from.SendGump(new CreationStatistique(from, m_Creation));
			}
			else if (info.ButtonID == 140)
			{
				m_Creation.Dex -= 1;
				from.SendGump(new CreationStatistique(from, m_Creation));
			}
			else if (info.ButtonID == 141)
			{
				m_Creation.Dex += 1;
				from.SendGump(new CreationStatistique(from, m_Creation));
			}
			else if (info.ButtonID == 142)
			{
				m_Creation.Int -= 1;
				from.SendGump(new CreationStatistique(from, m_Creation));
			}
			else if (info.ButtonID == 143)
			{
				m_Creation.Int += 1;
				from.SendGump(new CreationStatistique(from, m_Creation));
			}
			else if (info.ButtonID == 144)
			{
				m_Creation.Const -= 1;
				from.SendGump(new CreationStatistique(from, m_Creation));
			}
			else if (info.ButtonID == 145)
			{
				m_Creation.Const += 1;
				from.SendGump(new CreationStatistique(from, m_Creation));
			}
			else if (info.ButtonID == 146)
			{
				m_Creation.Endur -= 1;
				from.SendGump(new CreationStatistique(from, m_Creation));
			}
			else if (info.ButtonID == 147)
			{
				m_Creation.Endur += 1;
				from.SendGump(new CreationStatistique(from, m_Creation));
			}
			else if (info.ButtonID == 148)
			{
				m_Creation.Sag -= 1;
				from.SendGump(new CreationStatistique(from, m_Creation));
			}
			else if (info.ButtonID == 149)
			{
				m_Creation.Sag += 1;
				from.SendGump(new CreationStatistique(from, m_Creation));
			}
			else if (info.ButtonID == 238)
			{
				m_Creation.Str -= 10;
				from.SendGump(new CreationStatistique(from, m_Creation));
			}
			else if (info.ButtonID == 239)
			{
				m_Creation.Str += 10;
				from.SendGump(new CreationStatistique(from, m_Creation));
			}
			else if (info.ButtonID == 240)
			{
				m_Creation.Dex -= 10;
				from.SendGump(new CreationStatistique(from, m_Creation));
			}
			else if (info.ButtonID == 241)
			{
				m_Creation.Dex += 10;
				from.SendGump(new CreationStatistique(from, m_Creation));
			}
			else if (info.ButtonID == 242)
			{
				m_Creation.Int -= 10;
				from.SendGump(new CreationStatistique(from, m_Creation));
			}
			else if (info.ButtonID == 243)
			{
				m_Creation.Int += 10;
				from.SendGump(new CreationStatistique(from, m_Creation));
			}
			else if (info.ButtonID == 244)
			{
				m_Creation.Const -= 10;
				from.SendGump(new CreationStatistique(from, m_Creation));
			}
			else if (info.ButtonID == 245)
			{
				m_Creation.Const += 10;
				from.SendGump(new CreationStatistique(from, m_Creation));
			}
			else if (info.ButtonID == 246)
			{
				m_Creation.Endur -= 10;
				from.SendGump(new CreationStatistique(from, m_Creation));
			}
			else if (info.ButtonID == 247)
			{
				m_Creation.Endur += 10;
				from.SendGump(new CreationStatistique(from, m_Creation));
			}
			else if (info.ButtonID == 248)
			{
				m_Creation.Sag -= 10;
				from.SendGump(new CreationStatistique(from, m_Creation));
			}
			else if (info.ButtonID == 249)
			{
				m_Creation.Sag += 10;
				from.SendGump(new CreationStatistique(from, m_Creation));
			}
			else if (info.ButtonID == 1001) //Next
            {
				from.SendGump(new CreationSkills(m_From, m_Creation));
			}
            else if (info.ButtonID == 1000 || info.ButtonID == 0) //Previous
            {
				from.SendGump(new InfoGeneralGump(from, m_Creation));
			}
        }
    }
}
