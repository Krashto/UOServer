using Server.Custom.Aptitudes;
using Server.Custom.Classes;

namespace Server
{
    public class PillardClasse
    {
        private static Classe m_Classe = Classe.Pillard;
        private static int m_Level = 2;
        private static ClasseMode m_ClasseMode = ClasseMode.Roublards;
        private static Classe m_ClasseAvant = Classe.Maraudeur;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Voleur;
        private static bool m_Active = false;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 3),
                new CCapacites(Capacite.Melee, 1)
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Snooping, 80),
                new CSkills(SkillName.Stealing, 80),
                new CSkills(SkillName.Lockpicking, 75),
		        new CSkills(SkillName.RemoveTrap, 60),
                new CSkills(SkillName.Hiding, 55),
		        new CSkills(SkillName.DetectHidden, 30),
                new CSkills(SkillName.Tracking, 20)
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
        		"Pillard",
                m_ClasseBranche,
                m_Active
            );
    }
}
