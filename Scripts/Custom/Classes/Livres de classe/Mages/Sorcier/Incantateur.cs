using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class IncantateurClasse
    {
        private static Classe m_Classe = Classe.Incantateur;
        private static int m_Level = 1;
        private static ClasseMode m_ClasseMode = ClasseMode.Mages;
        private static Classe m_ClasseAvant = Classe.Aucune;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Sorcier;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(NAptitude.Destruction, 1)
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 1),
                new CCapacites(Capacite.Melee, 1),
                new CCapacites(Capacite.Magie, 1),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Magery, 35),
                new CSkills(SkillName.MagicResist, 35),
                new CSkills(SkillName.Meditation, 10)
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
				"Incantateur",
                m_ClasseBranche,
                m_Active
            );
    }
}
