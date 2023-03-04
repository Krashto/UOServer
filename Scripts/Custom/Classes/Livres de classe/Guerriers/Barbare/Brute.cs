using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class BruteClasse
    {
        private static Classe m_Classe = Classe.Brute;
        private static int m_Level = 1;
        private static ClasseMode m_ClasseMode = ClasseMode.Guerriers;
        private static Classe m_ClasseAvant = Classe.Aucune;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Barbare;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(NAptitude.TueurDeMonstres, 4),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 5),
                new CCapacites(Capacite.Melee, 4),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Tactics, 65),
                new CSkills(SkillName.Swords, 60),
                new CSkills(SkillName.Wrestling, 50),
                new CSkills(SkillName.Macing, 50),
                new CSkills(SkillName.Fencing, 35),
                new CSkills(SkillName.MagicResist, 10),
                new CSkills(SkillName.ArmsLore, 10)
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
				"Brute",
                m_ClasseBranche,
                m_Active
            );
    }
}
