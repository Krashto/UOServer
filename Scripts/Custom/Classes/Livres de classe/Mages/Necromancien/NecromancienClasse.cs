using Server.Custom.Classes;
using Server.Custom.Aptitudes;
using Server.Custom.Capacites;

namespace Server
{
	public class NecromancienClasse
    {
        private static string m_Name = "Nécromancien";
        private static Classe m_Classe = Classe.Necromancien;
		private static int m_Level = 3;
        private static ClasseMode m_ClasseMode = ClasseMode.Mages;
        private static Classe m_ClasseAvant = Classe.Necromage;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Necromancien;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(Aptitude.Necromancie, 10),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
				new CCapacites(Capacite.Magie, 5),
				new CCapacites(Capacite.Compagnon, 5),
			};

		private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Necromancy, 100),
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
