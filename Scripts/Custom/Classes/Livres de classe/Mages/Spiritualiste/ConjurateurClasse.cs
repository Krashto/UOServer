using Server.Custom.Classes;
using Server.Custom.Aptitudes;
using Server.Custom.Capacites;

namespace Server
{
	public class ConjurateurClasse
    {
        private static string m_Name = "Conjurateur";
        private static Classe m_Classe = Classe.Conjurateur;
		private static int m_Level = 2;
        private static ClasseMode m_ClasseMode = ClasseMode.Mages;
        private static Classe m_ClasseAvant = Classe.Invocateur;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Spiritualiste;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
				new CAptitudes(Aptitude.Totemique, 6),
            };

		private static CCapacites[] m_Capacites = new CCapacites[]
            {
				new CCapacites(Capacite.Magie, 2),
				new CCapacites(Capacite.ArmesDistance, 2),
			};

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.AnimalTaming, 75),
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
