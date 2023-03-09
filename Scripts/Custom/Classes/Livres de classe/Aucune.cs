using Server.Custom.Classes;

namespace Server
{
    public class AucuneClasse
    {
        private static string m_Name = "Aucune";
        private static Classe m_Classe = Classe.Aucune;
		private static int m_Level = 0;
        private static ClasseMode m_ClasseMode = ClasseMode.Aucun;
        private static Classe m_ClasseAvant = Classe.Aucune;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Aucune;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
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
