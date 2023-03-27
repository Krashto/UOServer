using Server.Custom.Aptitudes;
using Server.Custom.Capacites;
using Server.Custom.Classes;

namespace Server
{
	public class StylisteClasse
	{
		private static string m_Name = "Styliste";
        private static Classe m_Classe = Classe.Styliste;
		private static int m_Level = 1;
        private static ClasseMode m_ClasseMode = ClasseMode.Artisans;
        private static Classe m_ClasseAvant = Classe.Aucune;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Couture;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(Aptitude.Couture, 3),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Expertise, 1),
                new CCapacites(Capacite.Magie, 1),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Tailoring, 50),
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
