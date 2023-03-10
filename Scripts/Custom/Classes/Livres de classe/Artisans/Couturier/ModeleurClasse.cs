using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class ModeleurClasse
    {
		private static string m_Name = "Modeleur";
        private static Classe m_Classe = Classe.Modeleur;
        private static int m_Level = 2;
        private static ClasseMode m_ClasseMode = ClasseMode.Artisans;
        private static Classe m_ClasseAvant = Classe.Styliste;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Couture;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(Aptitude.Couture, 6)
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
				new CCapacites(Capacite.Expertise, 2),
				new CCapacites(Capacite.Magie, 2),
			};

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Alchemy, 35),
                new CSkills(SkillName.TasteID, 30),
                new CSkills(SkillName.Tinkering, 15),
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
