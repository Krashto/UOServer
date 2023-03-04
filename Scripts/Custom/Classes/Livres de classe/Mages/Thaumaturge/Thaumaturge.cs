using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class ThaumaturgeClasse
    {
        private static Classe m_Classe = Classe.Thaumaturge;
        private static int m_Level = 3;
        private static ClasseMode m_ClasseMode = ClasseMode.Mages;
        private static Classe m_ClasseAvant = Classe.Magicien;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Thaumaturge;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(NAptitude.Medecine, 6),
                new CAptitudes(NAptitude.Defense, 6),
                new CAptitudes(NAptitude.Arcanique, 3),
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
                new CSkills(SkillName.MagicResist, 70),
                new CSkills(SkillName.Healing, 65),
                new CSkills(SkillName.Anatomy, 60),
                new CSkills(SkillName.Wrestling, 30),
                new CSkills(SkillName.Tracking, 30),
                new CSkills(SkillName.DetectHidden, 20)
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
				"Thaumaturge",
                m_ClasseBranche,
                m_Active
            );
    }
}
