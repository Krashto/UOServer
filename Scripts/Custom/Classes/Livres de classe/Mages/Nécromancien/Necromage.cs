using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class NecromageClasse
    {
        private static Classe m_Classe = Classe.Necromage;
        private static int m_Level = 2;
        private static ClasseMode m_ClasseMode = ClasseMode.Mages;
        private static Classe m_ClasseAvant = Classe.Thanathauste;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Necromancien;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(Aptitude.Necromancie, 6),
                new CAptitudes(Aptitude.Geomancie, 6),
                new CAptitudes(Aptitude.Aeromancie, 3),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 2),
                new CCapacites(Capacite.Melee, 1),
                new CCapacites(Capacite.Magie, 7),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Magery, 80),
                new CSkills(SkillName.Meditation, 80),
                new CSkills(SkillName.Poisoning, 70),
                new CSkills(SkillName.Forensics, 65),
                new CSkills(SkillName.EvalInt, 60),
                new CSkills(SkillName.SpiritSpeak, 30),
                new CSkills(SkillName.Wrestling, 30),
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
				"N�cromage",
                m_ClasseBranche,
                m_Active
            );
    }
}
