using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class MultiformeClasse
    {
        private static string m_Name = "Multiforme";
        private static Classe m_Classe = Classe.Multiforme;
		private static int m_Level = 1;
        private static ClasseMode m_ClasseMode = ClasseMode.Mages;
        private static Classe m_ClasseAvant = Classe.Aucune;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Changeforme;
        private static bool m_Active = false;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
				new CAptitudes(Aptitude.Polymorphie, 3),
            };

		private static CCapacites[] m_Capacites = new CCapacites[]
            {
				new CCapacites(Capacite.Sorcellerie, 1),
				new CCapacites(Capacite.ArmesMelee, 1),
			};

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Musicianship, 65),
                new CSkills(SkillName.Peacemaking, 60),
                new CSkills(SkillName.Magery, 50),
                new CSkills(SkillName.Healing, 50),
                new CSkills(SkillName.Anatomy, 30),
                new CSkills(SkillName.Meditation, 15),
                new CSkills(SkillName.Provocation, 10)
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
