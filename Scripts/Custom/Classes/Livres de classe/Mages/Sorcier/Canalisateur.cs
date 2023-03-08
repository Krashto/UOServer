using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class CanalisateurClasse
    {
        private static Classe m_Classe = Classe.Canalisateur;
        private static int m_Level = 3;
        private static ClasseMode m_ClasseMode = ClasseMode.Mages;
        private static Classe m_ClasseAvant = Classe.Sorcier;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Sorcier;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(Aptitude.Aeromancie, 4),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 2),
                new CCapacites(Capacite.Melee, 1),
                new CCapacites(Capacite.Magie, 8),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Magery, 100),
                new CSkills(SkillName.Meditation, 100),
                new CSkills(SkillName.MagicResist, 100),
                new CSkills(SkillName.EvalInt, 75),
                new CSkills(SkillName.Anatomy, 75),
                new CSkills(SkillName.Wrestling, 50),
                new CSkills(SkillName.Tracking, 50),
                new CSkills(SkillName.DetectHidden, 40)
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
				"Canalisateur",
                m_ClasseBranche,
                m_Active
            );
    }
}
