using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class BarbareClasse
    {
        private static Classe m_Classe = Classe.Barbare;
        private static int m_Level = 2;
        private static ClasseMode m_ClasseMode = ClasseMode.Guerriers;
        private static Classe m_ClasseAvant = Classe.Brute;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Barbare;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(NAptitude.TueurDeMonstres, 6),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 6),
                new CCapacites(Capacite.Melee, 5),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Tactics, 80),
                new CSkills(SkillName.Swords, 80),
                new CSkills(SkillName.Wrestling, 70),
                new CSkills(SkillName.Macing, 65),
                new CSkills(SkillName.Fencing, 60),
                new CSkills(SkillName.MagicResist, 30),
                new CSkills(SkillName.ArmsLore, 30),
                new CSkills(SkillName.Anatomy, 20)
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
				"Barbare",
                m_ClasseBranche,
                m_Active
            );
    }
}
