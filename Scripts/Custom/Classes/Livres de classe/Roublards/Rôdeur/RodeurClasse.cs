using Server.Custom.Aptitudes;
using Server.Custom.Capacites;
using Server.Custom.Classes;

namespace Server
{
	public class RodeurClasse
    {
        private static string m_Name = "Rôdeur";
        private static Classe m_Classe = Classe.Rodeur;
		private static int m_Level = 3;
        private static ClasseMode m_ClasseMode = ClasseMode.Roublards;
        private static Classe m_ClasseAvant = Classe.Pisteur;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Rodeur;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
				new CAptitudes(Aptitude.Chasseur, 10),
            };

		private static CCapacites[] m_Capacites = new CCapacites[]
            {
				new CCapacites(Capacite.ArmesDistance, 5),
				new CCapacites(Capacite.Compagnon, 5),
			};

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Tracking, 100),
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
