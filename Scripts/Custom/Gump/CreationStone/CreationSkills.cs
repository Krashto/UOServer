using System.Linq;
using Server.Mobiles;
using Server.Network;

namespace Server.Gumps
{
  public class CreationSkills : CreationBaseGump
    {
        public CreationSkills (CustomPlayerMobile from, CreationPerso creationPerso) : base(from, creationPerso, "Skills", true, creationPerso.CheckSkills())
        {
            int x = XBase;
            int y = YBase;
            int line = 0;
            int lineSpace = 20;
			int column = 0;
			int columnSpace = 275;

            AddSection(x - 10, y + lineSpace * line++, 610, lineSpace * 30 + 8, "Sélection");
			line++;
			AddLabel(x + 80, y + lineSpace * line++, 2101, "Choisissez un total de 150% de skills, maximum 50% dans un skill individuel");
			line++;

			var count = 0;

			var skills = from.Skills.OrderBy(f => f.Name).ToList();

			foreach(var skill in skills)
			{
				if (!Skills.IsActive(skill.SkillName))
					continue;

				if (count != 0 && count % 20 == 0)
				{
					column++;
					line = 4;
				}

				AddLabel(x + 30 + column * columnSpace, y + lineSpace * line, 2101, skill.Name);
				if (skill.Base >= 5)
					AddButton(x + 165 + column * columnSpace, y + lineSpace * line + 2, 5603, 5607, 300 + skill.SkillID, GumpButtonType.Reply, 0);
				if (skill.Base > 0)
					AddButton(x + 185 + column * columnSpace, y + lineSpace * line + 2, 5603, 5607, 100 + skill.SkillID, GumpButtonType.Reply, 0);
				AddLabel(x + 210 + column * columnSpace, y + lineSpace * line, 2101, skill.Base.ToString());
				if (skill.Base < 50 && m_From.SkillsTotal < 1500) //En dixième de pourcent
					AddButton(x + 235 + column * columnSpace, y + lineSpace * line + 2, 5601, 5605, 200 + skill.SkillID, GumpButtonType.Reply, 0);
				if (skill.Base <= 45 && m_From.SkillsTotal < 1500) //En dixième de pourcent
					AddButton(x + 260 + column * columnSpace, y + lineSpace * line + 2, 5601, 5605, 400 + skill.SkillID, GumpButtonType.Reply, 0);
				line++;
				count++;
			}
		}

		public override void OnResponse(NetState sender, RelayInfo info)
        {
			if (m_From.Deleted || !m_From.Alive)
				return;

			if (info.ButtonID >= 100 && info.ButtonID < 200)
			{
				if (m_From.Skills[info.ButtonID - 100].Base > 0)
					m_From.Skills[info.ButtonID - 100].Base -= 1;
				m_From.SendGump(new CreationSkills(m_From, m_Creation));
			}
			else if (info.ButtonID >= 200 && info.ButtonID < 300)
			{
				if (m_From.Skills[info.ButtonID - 200].Base < 50 && m_From.SkillsTotal < 1500) //En dixième de pourcent
					m_From.Skills[info.ButtonID - 200].Base += 1;
				m_From.SendGump(new CreationSkills(m_From, m_Creation));
			}
			else if (info.ButtonID >= 300 && info.ButtonID < 400)
			{
				if (m_From.Skills[info.ButtonID - 300].Base >= 5)
					m_From.Skills[info.ButtonID - 300].Base -= 5;
				m_From.SendGump(new CreationSkills(m_From, m_Creation));
			}
			else if (info.ButtonID >= 400 && info.ButtonID < 500)
			{
				if (m_From.Skills[info.ButtonID - 400].Base <= 45 && m_From.SkillsTotal < 1500) //En dixième de pourcent
					m_From.Skills[info.ButtonID - 400].Base += 5;
				m_From.SendGump(new CreationSkills(m_From, m_Creation));
			}
			else if (info.ButtonID == 1001) //Next
            {
				m_From.SendGump(new CreationValidationGump(m_From, m_Creation));
			}
            else if (info.ButtonID == 1000 || info.ButtonID == 0) //Previous
            {
				m_From.SendGump(new CreationStatistique(m_From, m_Creation));
			}
        }
    }
}
