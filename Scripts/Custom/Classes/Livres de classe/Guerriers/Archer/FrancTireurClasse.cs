using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class FrancTireurClasse
    {
		private static string m_Name = "Franc-Tireur";
        private static Classe m_Classe = Classe.FrancTireur;
        private static int m_Level = 2;
        private static ClasseMode m_ClasseMode = ClasseMode.Guerriers;
        private static Classe m_ClasseAvant = Classe.Archer;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Archer;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
				new CAptitudes(Aptitude.Martial, 6),
			};

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
				new CCapacites(Capacite.ArmesDistance, 2),
				new CCapacites(Capacite.Armure, 2),
			};

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Archery, 80),
                new CSkills(SkillName.Tactics, 80),
                new CSkills(SkillName.Anatomy, 60),
                new CSkills(SkillName.ArmsLore, 60),
                new CSkills(SkillName.Lumberjacking, 40),
                new CSkills(SkillName.Fencing, 30),
                new CSkills(SkillName.Tracking, 20),
                new CSkills(SkillName.Hiding, 10),
                new CSkills(SkillName.MagicResist, 10)
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
