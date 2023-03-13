using System;
using Server.Mobiles;
using Server.Network;
using System.Collections.Generic;
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
            int line = 0;
            int scale = 25;
            int space = 115;

            string info = "<h3><basefont color=#FFFFFFF>Nom: " + m_Creation.Name + "\n\nRace: " + m_Creation.Race + "\nDivinité: " + m_Creation.God.Name + "\nSexe: " + (m_Creation.Female ? "Femme" : "Homme") + "\nApparence: " + m_Creation.GetApparence() + "\nGrandeur: " + m_Creation.GetGrandeur() + "\nGrosseur: " + m_Creation.GetGrosseur() + "\n\n<basefont></h3>";

			Dictionary<SkillName, int> Skill = new Dictionary<SkillName, int>();

			info = info + "Skills: \n\n";

			foreach (KeyValuePair<SkillName,int> item in Skill)
				info = info +"  -" + item.Key + ": " + item.Value + "\n";

			info = info + "  -Mining: 30\n  -Fishing: 30\n  -Lumberjacking: 30\n  -MagicResist: 30\n";

			info = info + "\n\nForce: " + creationPerso.Str;
			info = info + "\nDextérité: " + creationPerso.Dex;
			info = info + "\nIntelligence: " + creationPerso.Int;

			if (m_Creation.Reroll != null)
			{
				info = info + "\n\nTransfert: " + m_Creation.Reroll.Name + "\nExpériences: " + Math.Round(creationPerso.Reroll.ExperienceNormal  + creationPerso.Reroll.ExperienceRP * 0.5 );
			}

			AddSection(x - 10, y, 303, 508, "Information", info);

			string context = "Vous allez maintenant être envoyé dans la cité de Boscula, pour une escale avant votre destination finale.\n\nDurant cette escale, profitez bien des marchands présents dans la cité pour regarnir votre garde-robe. \n\nPrenez garde, le bateau est rempli, vous ne pourrez que transporter ce que vous portez.";

			AddSection(x + 294, y, 304, 508, "Contexte", context);
			AddSection(x - 10, y + 509, 610, 99, "Validation");
			AddButton(x + 265, y + 550, 1, 1147, 1148);
        }
        public override void OnResponse(NetState sender, RelayInfo info)
        {
			CustomPlayerMobile pm = (CustomPlayerMobile)sender.Mobile;

            if (info.ButtonID == 1)
            {
                m_Creation.Valide();
				Classes.SetBaseAndCapSkills(pm);
			}
            else if (info.ButtonID == 1000 || info.ButtonID == 0)
            {
				Account acc = (Account)pm.Account;

				if (acc.Reroll.Count > 0)
					pm.SendGump(new CreationRerollGump(pm, m_Creation));
				else
					m_from.SendGump(new CreationGodGump(m_from, m_Creation));
			}
        }
    }
}
