using Server.Custom.Classes;
using Server.Custom.Aptitudes;
using Server.Custom.Capacites;

namespace Server
{
	public class GardienClasse
    {
		private static string m_Name = "Gardien";
        private static Classe m_Classe = Classe.Gardien;
		private static int m_Level = 2;
        private static ClasseMode m_ClasseMode = ClasseMode.Guerriers;
        private static Classe m_ClasseAvant = Classe.Defenseur;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Protecteur;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
				new CAptitudes(Aptitude.Defenseur, 6),
            };

		private static CCapacites[] m_Capacites = new CCapacites[]
            {
				new CCapacites(Capacite.Armure, 3),
				new CCapacites(Capacite.Bouclier, 3),
			};

        private static CSkills[] m_Skills = new CSkills[]
            {
		        new CSkills(SkillName.Parry, 75)
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
