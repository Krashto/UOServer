using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class BardeClasse
    {
        private static Classe m_Classe = Classe.Barde;
        private static int m_Level = 2;
        private static ClasseMode m_ClasseMode = ClasseMode.AmuseursPublics;
        private static Classe m_ClasseAvant = Classe.Troubadour;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Barde;
        private static bool m_Active = false;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 3),
                new CCapacites(Capacite.Melee, 2),
                new CCapacites(Capacite.ArmeDistance, 2),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Musicianship, 80),
                new CSkills(SkillName.Peacemaking, 80),
                new CSkills(SkillName.Magery, 65),
                new CSkills(SkillName.Healing, 60),
                new CSkills(SkillName.Anatomy, 40),
                new CSkills(SkillName.Meditation, 30),
                new CSkills(SkillName.Provocation, 20),
                new CSkills(SkillName.AnimalTaming, 20),
                new CSkills(SkillName.Discordance, 10),
                new CSkills(SkillName.Tactics, 10)
            };


        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
				"Barde",
                m_ClasseBranche,
                m_Active
            );
    }
}
