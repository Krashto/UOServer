using Server.Custom.Classes;
using Server.Custom.Aptitudes;
using Server.Custom.Capacites;

namespace Server
{
	public class IngenieurClasse
    {
		private static string m_Name = "Ingénieur";
        private static Classe m_Classe = Classe.Ingenieur;
        private static int m_Level = 2;
        private static ClasseMode m_ClasseMode = ClasseMode.Artisans;
        private static Classe m_ClasseAvant = Classe.Bricoleur;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Inventeur;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(Aptitude.Ingenierie, 6),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Expertise, 2),
                new CCapacites(Capacite.ArmesDistance, 1),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Tailoring, 80),
                new CSkills(SkillName.Tinkering, 80),
                new CSkills(SkillName.Lumberjacking, 65),
                new CSkills(SkillName.Mining, 65),
                new CSkills(SkillName.ArmsLore, 15),
                new CSkills(SkillName.Cooking, 15),
                new CSkills(SkillName.Blacksmith, 15),
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
