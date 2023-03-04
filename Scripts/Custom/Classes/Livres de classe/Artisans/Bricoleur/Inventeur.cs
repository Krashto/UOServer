using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class InventeurClasse
    {
        private static Classe m_Classe = Classe.Inventeur;
        private static int m_Level = 3;
        private static ClasseMode m_ClasseMode = ClasseMode.Artisans;
        private static Classe m_ClasseAvant = Classe.Ingenieur;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Bricoleur;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(NAptitude.Couture, 8),
                new CAptitudes(NAptitude.Ingenierie, 8),
                new CAptitudes(NAptitude.Ebenisterie, 8),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 2),
                new CCapacites(Capacite.Melee, 1),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Tailoring, 100),
                new CSkills(SkillName.Carpentry, 100),
                new CSkills(SkillName.Tinkering, 100),
                new CSkills(SkillName.Lumberjacking, 75),
                new CSkills(SkillName.Mining, 75),
                new CSkills(SkillName.ArmsLore, 40),
                new CSkills(SkillName.Cooking, 40),
                new CSkills(SkillName.Blacksmith, 40),
                new CSkills(SkillName.ItemID, 30),
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
                "Inventeur",
                m_ClasseBranche,
                m_Active
            );
    }
}
