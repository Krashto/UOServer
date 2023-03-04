using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class BersekerClasse
    {
        private static Classe m_Classe = Classe.Berseker;
        private static int m_Level = 3;
        private static ClasseMode m_ClasseMode = ClasseMode.Guerriers;
        private static Classe m_ClasseAvant = Classe.Barbare;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Barbare;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(NAptitude.TueurDeMonstres, 8),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 6),
                new CCapacites(Capacite.Melee, 5),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Tactics, 100),
                new CSkills(SkillName.Swords, 85),
                new CSkills(SkillName.Wrestling, 85),
                new CSkills(SkillName.Macing, 80),
                new CSkills(SkillName.Fencing, 80),
                new CSkills(SkillName.MagicResist, 60),
                new CSkills(SkillName.ArmsLore, 60),
                new CSkills(SkillName.Anatomy, 40)
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
				"Berseker",
                m_ClasseBranche,
                m_Active
            );
    }
}
