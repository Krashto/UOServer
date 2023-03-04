using Server.Custom.Aptitudes;
using Server.Custom.Classes;

namespace Server
{
    public class VoleurClasse
    {
        private static Classe m_Classe = Classe.Voleur;
        private static int m_Level = 3;
        private static ClasseMode m_ClasseMode = ClasseMode.Roublards;
        private static Classe m_ClasseAvant = Classe.Pillard;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Voleur;
        private static bool m_Active = false;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
		        new CAptitudes(NAptitude.Piegeage, 8),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 3),
                new CCapacites(Capacite.Melee, 2)
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Snooping, 100),
                new CSkills(SkillName.Stealing, 100),
                new CSkills(SkillName.Lockpicking, 100),
		        new CSkills(SkillName.RemoveTrap, 90),
                new CSkills(SkillName.Hiding, 70),
		        new CSkills(SkillName.DetectHidden, 40),
                new CSkills(SkillName.Tracking, 40)
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
				"Voleur",
                m_ClasseBranche,
                m_Active
            );
    }
}
