using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class SageClasse
    {
        private static Classe m_Classe = Classe.Sage;
        private static int m_Level = 3;
        private static ClasseMode m_ClasseMode = ClasseMode.Artisans;
        private static Classe m_ClasseAvant = Classe.Erudit;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Savant;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(NAptitude.Transcription, 9),
                new CAptitudes(NAptitude.Chimie, 8),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 1),
                new CCapacites(Capacite.Melee, 1),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Alchemy, 100),
                new CSkills(SkillName.Anatomy, 80),
                new CSkills(SkillName.ItemID, 60),
                new CSkills(SkillName.ArmsLore, 60),
                new CSkills(SkillName.EvalInt, 50),
                new CSkills(SkillName.Healing, 40),
                new CSkills(SkillName.Forensics, 35),
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
				"Sage",
                m_ClasseBranche,
                m_Active
            );
    }
}
