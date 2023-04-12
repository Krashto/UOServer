using Server.Custom.Classes;
using Server.Custom.Aptitudes;
using Server.Custom.Capacites;

namespace Server
{
	public class EvocateurClasse
    {
        private static string m_Name = "Évocateur";
		private static Classe m_Classe = Classe.Evocateur;
        private static int m_Level = 2;
        private static ClasseMode m_ClasseMode = ClasseMode.Mages;
        private static Classe m_ClasseAvant = Classe.Apprenti;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Aeromancien;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(Aptitude.Aeromancie, 6),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
				new CCapacites(Capacite.Magie, 2),
			};

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.SpiritSpeak, 75),
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
				m_Name,
                m_ClasseBranche,
                m_Active
            );
    }
}
