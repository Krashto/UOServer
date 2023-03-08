using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class EleveClasse
    {
        private static Classe m_Classe = Classe.Eleve;
        private static int m_Level = 1;
        private static ClasseMode m_ClasseMode = ClasseMode.Artisans;
        private static Classe m_ClasseAvant = Classe.Aucune;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Savant;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(Aptitude.Transcription, 1),
                new CAptitudes(Aptitude.Chimie, 1),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 1),
                new CCapacites(Capacite.Melee, 1),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Alchemy, 35),
                new CSkills(SkillName.Anatomy, 15),
                new CSkills(SkillName.ItemID, 10),
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
				"Eleve",
                m_ClasseBranche,
                m_Active
            );
    }
}
