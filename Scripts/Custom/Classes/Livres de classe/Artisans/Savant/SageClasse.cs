using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class SageClasse
    {
		private static string m_Name = "Sage";
        private static Classe m_Classe = Classe.Sage;
		private static int m_Level = 3;
        private static ClasseMode m_ClasseMode = ClasseMode.Artisans;
        private static Classe m_ClasseAvant = Classe.Erudit;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Sage;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(Aptitude.Transcription, 10),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
				new CCapacites(Capacite.Expertise, 3),
				new CCapacites(Capacite.Magie, 3),
			};

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Alchemy, 100),
                new CSkills(SkillName.Anatomy, 80),
                new CSkills(SkillName.ItemID, 60),
                new CSkills(SkillName.ArmsLore, 60),
                new CSkills(SkillName.EvalInt, 50),
                new CSkills(SkillName.Healing, 40),
                new CSkills(SkillName.Forensics, 35),
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
