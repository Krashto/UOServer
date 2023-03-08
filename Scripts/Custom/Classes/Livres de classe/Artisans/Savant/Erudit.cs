using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class EruditClasse
    {
        private static Classe m_Classe = Classe.Erudit;
        private static int m_Level = 2;
        private static ClasseMode m_ClasseMode = ClasseMode.Artisans;
        private static Classe m_ClasseAvant = Classe.Eleve;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Savant;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(Aptitude.Transcription, 7),
                new CAptitudes(Aptitude.Chimie, 6),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 1),
                new CCapacites(Capacite.Melee, 1),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Alchemy, 80),
                new CSkills(SkillName.Anatomy, 70),
                new CSkills(SkillName.ItemID, 50),
                new CSkills(SkillName.ArmsLore, 50),
                new CSkills(SkillName.EvalInt, 50),
                new CSkills(SkillName.Healing, 30),
                new CSkills(SkillName.Forensics, 25),
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
				"Erudit",
                m_ClasseBranche,
                m_Active
            );
    }
}
