using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class ChampionClasse
    {
        private static Classe m_Classe = Classe.Champion;
        private static int m_Level = 3;
        private static ClasseMode m_ClasseMode = ClasseMode.Guerriers;
        private static Classe m_ClasseAvant = Classe.Mirmillon;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Guerrier;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 6),
                new CCapacites(Capacite.Melee, 5),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Tactics, 80),
                new CSkills(SkillName.MagicResist, 80),
                new CSkills(SkillName.Parry, 70),
                new CSkills(SkillName.Anatomy, 65),
                new CSkills(SkillName.ArmsLore, 60),
                new CSkills(SkillName.Healing, 30),
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
				"Champion",
                m_ClasseBranche,
                m_Active
            );
    }
}
