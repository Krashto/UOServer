using Server.Custom.Classes;
using Server.Custom.Aptitudes;
using Server.Custom.Capacites;

namespace Server
{
	public class ApothicaireClasse
    {
		private static string m_Name = "Apothicaire";
        private static Classe m_Classe = Classe.Apothicaire;
        private static int m_Level = 3;
        private static ClasseMode m_ClasseMode = ClasseMode.Artisans;
        private static Classe m_ClasseAvant = Classe.Alchimiste;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Apothicaire;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(Aptitude.Chimie, 10),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
				new CCapacites(Capacite.Expertise, 5),
				new CCapacites(Capacite.Perfection, 5),
			};

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Alchemy, 100),
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
