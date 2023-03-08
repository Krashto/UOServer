using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class BricoleurClasse
    {
        private static Classe m_Classe = Classe.Bricoleur;
        private static int m_Level = 1;
        private static ClasseMode m_ClasseMode = ClasseMode.Artisans;
        private static Classe m_ClasseAvant = Classe.Aucune;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Bricoleur;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(Aptitude.Couture, 4),
                new CAptitudes(Aptitude.Ingenierie, 4),
                new CAptitudes(Aptitude.Ebenisterie, 4),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 1),
                new CCapacites(Capacite.Melee, 1),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Tailoring, 65),
                new CSkills(SkillName.Carpentry, 60),
                new CSkills(SkillName.Tinkering, 60),
		        new CSkills(SkillName.Lumberjacking, 50),
                new CSkills(SkillName.Mining, 50),
		        new CSkills(SkillName.ArmsLore, 10),
                new CSkills(SkillName.Cooking, 10),
		        new CSkills(SkillName.Blacksmith, 10),
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
				"Bricoleur",
                m_ClasseBranche,
                m_Active
            );
    }
}
