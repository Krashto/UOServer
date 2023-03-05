using Server.Custom.Aptitudes;
using Server.Custom.Classes;

namespace Server
{
    public class EclaireurClasse
    {
        private static Classe m_Classe = Classe.Eclaireur;
        private static int m_Level = 2;
        private static ClasseMode m_ClasseMode = ClasseMode.Nature;
        private static Classe m_ClasseAvant = Classe.Pisteur;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Rodeur;
        private static bool m_Active = false;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(NAptitude.Familier, 3),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 4),
                new CCapacites(Capacite.Melee, 2),
                new CCapacites(Capacite.ArmeDistance, 3),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Tracking, 80),
                new CSkills(SkillName.DetectHidden, 80),
                new CSkills(SkillName.Archery, 65),
		        new CSkills(SkillName.AnimalTaming, 60),
                new CSkills(SkillName.Tactics, 30),
		        new CSkills(SkillName.Carpentry, 30),
		        new CSkills(SkillName.Camping, 10),
		        new CSkills(SkillName.Cartography, 10),
		        new CSkills(SkillName.Healing, 10)
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
				"Éclaireur",
                m_ClasseBranche,
                m_Active
            );
    }
}
