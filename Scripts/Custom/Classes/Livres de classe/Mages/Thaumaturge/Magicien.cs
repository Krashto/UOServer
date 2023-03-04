using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class MagicienClasse
    {
        private static Classe m_Classe = Classe.Magicien;
        private static int m_Level = 2;
        private static ClasseMode m_ClasseMode = ClasseMode.Mages;
        private static Classe m_ClasseAvant = Classe.Mage;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Thaumaturge;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(NAptitude.Medecine, 4),
                new CAptitudes(NAptitude.Defense, 4),
                new CAptitudes(NAptitude.Arcanique, 2),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 1),
                new CCapacites(Capacite.Melee, 1),
                new CCapacites(Capacite.Magie, 5),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Magery, 65),
                new CSkills(SkillName.Meditation, 60),
                new CSkills(SkillName.MagicResist, 50),
                new CSkills(SkillName.Healing, 50),
                new CSkills(SkillName.Anatomy, 35),
                new CSkills(SkillName.Wrestling, 10),
                new CSkills(SkillName.Tracking, 10)
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
				"Magicien",
                m_ClasseBranche,
                m_Active
            );
    }
}
