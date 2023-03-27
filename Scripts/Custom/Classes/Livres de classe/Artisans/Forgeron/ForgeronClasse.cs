using Server.Custom.Classes;
using Server.Custom.Aptitudes;
using Server.Custom.Capacites;

namespace Server
{
	public class ForgeronClasse
    {
		private static string m_Name = "Forgeron";
        private static Classe m_Classe = Classe.Forgeron;
		private static int m_Level = 2;
        private static ClasseMode m_ClasseMode = ClasseMode.Artisans;
        private static Classe m_ClasseAvant = Classe.Armurier;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Forgeron;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(Aptitude.Metallurgie, 6),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
				new CCapacites(Capacite.Expertise, 2),
				new CCapacites(Capacite.ArmesMelee, 2),
			};

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Blacksmith, 75),
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
