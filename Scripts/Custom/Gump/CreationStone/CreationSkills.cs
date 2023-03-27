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
			int columnSpace = 300;

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
				AddLabel(x + 200 + column * columnSpace, y + lineSpace * line, 2101, ":");
				if (skill.Base > 0)
					AddButton(x + 220 + column * columnSpace, y + lineSpace * line + 2, 5603, 5607, 100 + skill.SkillID, GumpButtonType.Reply, 0);
				AddLabel(x + 245 + column * columnSpace, y + lineSpace * line, 2101, skill.Base.ToString());
				if (skill.Base < 50 && m_from.SkillsTotal < 1500) //En dixième de pourcent
					AddButton(x + 270 + column * columnSpace, y + lineSpace * line + 2, 5601, 5605, 200 + skill.SkillID, GumpButtonType.Reply, 0);
				line++;
				count++;
			}
		}

		public override void OnResponse(NetState sender, RelayInfo info)
        {
			CustomPlayerMobile from = (CustomPlayerMobile)sender.Mobile;

			if (from.Deleted || !from.Alive)
				return;

			if (info.ButtonID >= 100 && info.ButtonID < 200)
			{
				if (from.Skills[info.ButtonID - 100].Base > 0)
					from.Skills[info.ButtonID - 100].Base--;
				from.SendGump(new CreationSkills(from, m_Creation));
			}
			else if (info.ButtonID >= 200 && info.ButtonID < 300)
			{
				if (from.Skills[info.ButtonID - 200].Base < 50 && m_from.SkillsTotal < 1500) //En dixième de pourcent
					from.Skills[info.ButtonID - 200].Base++;
				from.SendGump(new CreationSkills(from, m_Creation));
			}
			else if (info.ButtonID == 1001) //Next
            {
				from.SendGump(new CreationValidationGump(m_from, m_Creation));
			}
            else if (info.ButtonID == 1000 || info.ButtonID == 0) //Previous
            {
				from.SendGump(new CreationStatistique(from, m_Creation));
			}
        }
    }
}
