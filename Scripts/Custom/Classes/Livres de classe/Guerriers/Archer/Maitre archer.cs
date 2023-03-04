using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class MaitreArcherClasse
    {
        private static Classe m_Classe = Classe.MaitreArcher;
        private static int m_Level = 3;
        private static ClasseMode m_ClasseMode = ClasseMode.Guerriers;
        private static Classe m_ClasseAvant = Classe.FrancTireur;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Archer;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 4),
                new CCapacites(Capacite.Melee, 2),
                //new CCapacites(Capacite.Jet, 3),
                new CCapacites(Capacite.ArmeDistance, 5),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Archery, 100),
                new CSkills(SkillName.Tactics, 100),
                new CSkills(SkillName.Anatomy, 65),
                new CSkills(SkillName.ArmsLore, 65),
                new CSkills(SkillName.Lumberjacking, 60),
                new CSkills(SkillName.Fencing, 60),
                new CSkills(SkillName.Fletching, 50),
                new CSkills(SkillName.Tracking, 40),
                new CSkills(SkillName.Hiding, 30),
                new CSkills(SkillName.MagicResist, 20)
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
                "Maitre Archer",
                m_ClasseBranche,
                m_Active
            );
    }
}
