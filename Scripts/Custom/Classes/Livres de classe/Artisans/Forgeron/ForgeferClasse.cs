using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class ForgeferClasse
    {
		private static string m_Name = "Forgefer";
        private static Classe m_Classe = Classe.Forgefer;
        private static int m_Level = 3;
        private static ClasseMode m_ClasseMode = ClasseMode.Artisans;
        private static Classe m_ClasseAvant = Classe.Forgeron;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Forgeron;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(Aptitude.Metallurgie, 10),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
				new CCapacites(Capacite.Expertise, 3),
				new CCapacites(Capacite.ArmesMelee, 3),
			};

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Blacksmith, 100),
                new CSkills(SkillName.Mining, 100),
                new CSkills(SkillName.ArmsLore, 80),
                new CSkills(SkillName.ItemID, 60),
                new CSkills(SkillName.Tinkering, 50),
                new CSkills(SkillName.Camping, 40),
                new CSkills(SkillName.Cooking, 40),
                new CSkills(SkillName.Macing, 30),
                new CSkills(SkillName.Fencing, 30),
                new CSkills(SkillName.Swords, 30),
                new CSkills(SkillName.Parry, 30),
            };

		public static ClasseInfo ClasseInfo = new ClasseInfo(
				m_Classe,
				m_Level,
				m_ClasseMode,
				m_ClasseAvant,
				m_Aptitudes,
				m_Capacites,
				m_Skills,
				m_Name,
				m_ClasseBranche,
				m_Active
			);
	}
}
