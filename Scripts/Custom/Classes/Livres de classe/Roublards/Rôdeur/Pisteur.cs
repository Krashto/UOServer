using Server.Custom.Aptitudes;
using Server.Custom.Classes;

namespace Server
{
    public class PisteurClasse
    {
        private static Classe m_Classe = Classe.Pisteur;
        private static int m_Level = 1;
        private static ClasseMode m_ClasseMode = ClasseMode.Nature;
        private static Classe m_ClasseAvant = Classe.Aucune;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Rodeur;
        private static bool m_Active = false;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(NAptitude.Familier, 2),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 3),
                new CCapacites(Capacite.Melee, 2),
                new CCapacites(Capacite.ArmeDistance, 2),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Tracking, 65),
                new CSkills(SkillName.DetectHidden, 60),
                new CSkills(SkillName.Archery, 50),
		        new CSkills(SkillName.AnimalTaming, 50),
                new CSkills(SkillName.AnimalLore, 35),
                new CSkills(SkillName.Tactics, 10),
		        new CSkills(SkillName.Fletching, 10)
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
				"Pisteur",
                m_ClasseBranche,
                m_Active
            );
    }
}
