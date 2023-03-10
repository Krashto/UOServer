using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class AeromancienClasse
    {
		private static string m_Name = "Aéromancien";
        private static Classe m_Classe = Classe.Aeromancien;
		private static int m_Level = 3;
        private static ClasseMode m_ClasseMode = ClasseMode.Mages;
        private static Classe m_ClasseAvant = Classe.Evocateur;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Aeromancien;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(Aptitude.Aeromancie, 10),
			};

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
				new CCapacites(Capacite.Magie, 3),
				new CCapacites(Capacite.Magie, 3),
			};

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Magery, 100),
                new CSkills(SkillName.Meditation, 100),
                new CSkills(SkillName.MagicResist, 100),
                new CSkills(SkillName.EvalInt, 75),
                new CSkills(SkillName.Anatomy, 75),
                new CSkills(SkillName.Wrestling, 50),
                new CSkills(SkillName.Tracking, 50),
                new CSkills(SkillName.DetectHidden, 40)
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
