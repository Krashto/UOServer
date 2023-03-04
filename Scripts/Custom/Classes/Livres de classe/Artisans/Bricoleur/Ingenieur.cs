using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class IngenieurClasse
    {
        private static Classe m_Classe = Classe.Ingenieur;
        private static int m_Level = 2;
        private static ClasseMode m_ClasseMode = ClasseMode.Artisans;
        private static Classe m_ClasseAvant = Classe.Bricoleur;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Bricoleur;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(NAptitude.Couture, 6),
                new CAptitudes(NAptitude.Ingenierie, 6),
                new CAptitudes(NAptitude.Ebenisterie, 6),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 2),
                new CCapacites(Capacite.Melee, 1),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Tailoring, 80),
                new CSkills(SkillName.Carpentry, 80),
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
				"Ingenieur",
                m_ClasseBranche,
                m_Active
            );
    }
}
