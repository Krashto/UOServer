using Server.Custom.Aptitudes;
using Server.Custom.Capacites;
using Server.Custom.Classes;

namespace Server
{
	public class RoublardClasse
    {
        private static string m_Name = "Roublard";
        private static Classe m_Classe = Classe.Roublard;
		private static int m_Level = 3;
        private static ClasseMode m_ClasseMode = ClasseMode.Roublards;
        private static Classe m_ClasseAvant = Classe.Voleur;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Roublard;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
				new CAptitudes(Aptitude.Roublardise, 10),
            };

		private static CCapacites[] m_Capacites = new CCapacites[]
            {
				new CCapacites(Capacite.ArmesMelee, 5),
				new CCapacites(Capacite.Precision, 5)
			};

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Hiding, 100),
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
