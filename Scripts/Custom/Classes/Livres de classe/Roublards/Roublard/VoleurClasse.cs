using Server.Custom.Aptitudes;
using Server.Custom.Capacites;
using Server.Custom.Classes;

namespace Server
{
	public class VoleurClasse
    {
        private static string m_Name = "Voleur";
        private static Classe m_Classe = Classe.Voleur;
		private static int m_Level = 2;
        private static ClasseMode m_ClasseMode = ClasseMode.Roublards;
        private static Classe m_ClasseAvant = Classe.Vagabond;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Roublard;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
				new CAptitudes(Aptitude.Roublardise, 6),
            };

		private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.ArmesMelee, 3),
                new CCapacites(Capacite.Precision, 3)
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Hiding, 75),
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
