using Server.Custom.Aptitudes;
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
                new CCapacites(Capacite.Academique, 1),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Alchemy, 80),
                new CSkills(SkillName.TasteID, 70),
                new CSkills(SkillName.Cooking, 55),
                new CSkills(SkillName.ItemID, 50),
                new CSkills(SkillName.Tinkering, 40),
                new CSkills(SkillName.Mining, 40),
                new CSkills(SkillName.Camping, 30),
                new CSkills(SkillName.Healing, 30),
                new CSkills(SkillName.Anatomy, 25),
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
