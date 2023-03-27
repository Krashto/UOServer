using Server.Custom.Classes;
using Server.Custom.Aptitudes;
using Server.Custom.Capacites;

namespace Server
{
	public class MenestrelClasse
    {
        private static string m_Name = "Ménestrel";
        private static Classe m_Classe = Classe.Menestrel;
		private static int m_Level = 3;
        private static ClasseMode m_ClasseMode = ClasseMode.Mages;
        private static Classe m_ClasseAvant = Classe.Barde;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Menestrel;
        private static bool m_Active = false;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
				new CAptitudes(Aptitude.Musique, 10),
            };

		private static CCapacites[] m_Capacites = new CCapacites[]
            {
				new CCapacites(Capacite.Magie, 3),
				new CCapacites(Capacite.Bouclier, 3),
			};

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Musicianship, 100),
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
