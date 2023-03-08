using Server.Custom.Aptitudes;
using Server.Custom.Classes;

namespace Server
{
    public class MaraudeurClasse
    {
        private static Classe m_Classe = Classe.Maraudeur;
        private static int m_Level = 1;
        private static ClasseMode m_ClasseMode = ClasseMode.Roublards;
        private static Classe m_ClasseAvant = Classe.Aucune;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Voleur;
        private static bool m_Active = false;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {		        
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 1),
                new CCapacites(Capacite.Melee, 1)
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Snooping, 35),
                new CSkills(SkillName.Stealing, 35),
                new CSkills(SkillName.Lockpicking, 10),
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
				"Maraudeur",
                m_ClasseBranche,
                m_Active
            );
    }
}
