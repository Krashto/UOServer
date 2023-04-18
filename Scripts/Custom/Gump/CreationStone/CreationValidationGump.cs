using Server.Mobiles;
using Server.Network;
using Server.Accounting;
using Server.Custom.Classes;

namespace Server.Gumps
{
	public class CreationValidationGump : CreationBaseGump
    {
        public CreationValidationGump(CustomPlayerMobile from, CreationPerso creationPerso) : base(from, creationPerso, "Validation", true, false)
        {
            int x = XBase;
            int y = YBase;

            string info = "<h3><basefont color=#FFFFFFF>Nom: " + m_Creation.Name + "\n\nRace: " + m_Creation.Race + "\nSexe: " + (m_Creation.Female ? "Femme" : "Homme") + "\nApparence: " + m_Creation.GetApparence() + "\nGrandeur: " + m_Creation.GetGrandeur() + "\nGrosseur: " + m_Creation.GetGrosseur() + "\n\n<basefont></h3>";

			info = info + "Skills: \n";

			foreach (var skill in from.Skills)
			{
				if (skill.Value > 0)
					info = info + " -" + skill.Name + ": " + skill.Value + "\n";
			}

			info = info + "\n\nForce: " + creationPerso.Str;
			info = info + "\nDextérité: " + creationPerso.Dex;
			info = info + "\nIntelligence: " + creationPerso.Int;
			info = info + "\nConstitution: " + creationPerso.Const;
			info = info + "\nEndurance: " + creationPerso.Endur;
			info = info + "\nSagesse: " + creationPerso.Sag;

			if (m_Creation.Reroll != null)
				info = info + "\n\nTransfert: " + m_Creation.Reroll.Name + "\nExpériences: " + creationPerso.Reroll.Experience;

			AddSection(x - 10, y, 303, 508, "Information", info);

			string context = "Vous allez maintenant être envoyé dans le fortin de Colognan.";

			AddSection(x + 294, y, 304, 508, "Contexte", context);
			AddSection(x - 10, y + 509, 610, 99, "Validation");
			AddButton(x + 265, y + 550, 1, 1147, 1148);
        }
        public override void OnResponse(NetState sender, RelayInfo info)
        {
			CustomPlayerMobile pm = (CustomPlayerMobile)sender.Mobile;

            if (info.ButtonID == 1)
            {
                m_Creation.Validate();
				Classes.SetBaseAndCapSkills(pm, pm.Experience.Niveau);
			}
            else if (info.ButtonID == 1000 || info.ButtonID == 0)
            {
				Account acc = (Account)pm.Account;

				if (acc.Reroll.Count > 0)
					pm.SendGump(new CreationRerollGump(pm, m_Creation));
				else
					m_From.SendGump(new CreationSkills(m_From, m_Creation));
			}
        }
    }
}
