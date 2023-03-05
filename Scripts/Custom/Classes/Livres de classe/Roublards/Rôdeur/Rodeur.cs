using Server.Custom.Aptitudes;
using Server.Custom.Classes;

namespace Server
{
    public class RodeurClasse
    {
        private static Classe m_Classe = Classe.Rodeur;
        private static int m_Level = 3;
        private static ClasseMode m_ClasseMode = ClasseMode.Nature;
        private static Classe m_ClasseAvant = Classe.Eclaireur;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Rodeur;
        private static bool m_Active = false;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(NAptitude.Familier, 4),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 4),
                new CCapacites(Capacite.Melee, 3),
                new CCapacites(Capacite.ArmeDistance, 4),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Tracking, 100),
                new CSkills(SkillName.DetectHidden, 100),
                new CSkills(SkillName.Archery, 100),
		        new CSkills(SkillName.AnimalTaming, 70),
                new CSkills(SkillName.Tactics, 50),
		        new CSkills(SkillName.Carpentry, 40),
		        new CSkills(SkillName.Camping, 20),
		        new CSkills(SkillName.Cartography, 20),
		        new CSkills(SkillName.Healing, 20)
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
				"Rôdeur",
                m_ClasseBranche,
                m_Active
            );
    }
}
