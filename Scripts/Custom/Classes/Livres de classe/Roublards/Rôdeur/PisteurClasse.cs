using Server.Custom.Aptitudes;
using Server.Custom.Capacites;
using Server.Custom.Classes;

namespace Server
{
	public class PisteurClasse
    {
        private static string m_Name = "Pisteur";
        private static Classe m_Classe = Classe.Pisteur;
		private static int m_Level = 2;
        private static ClasseMode m_ClasseMode = ClasseMode.Roublards;
        private static Classe m_ClasseAvant = Classe.Traqueur;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Rodeur;
        private static bool m_Active = false;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
				new CAptitudes(Aptitude.Chasseur, 6),
            };

		private static CCapacites[] m_Capacites = new CCapacites[]
            {
				new CCapacites(Capacite.ArmesDistance, 2),
				new CCapacites(Capacite.ArmesMelee, 2),
			};

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Tracking, 80),
                new CSkills(SkillName.DetectHidden, 80),
                new CSkills(SkillName.Archery, 65),
		        new CSkills(SkillName.AnimalTaming, 60),
                new CSkills(SkillName.Tactics, 30),
		        new CSkills(SkillName.Camping, 10),
		        new CSkills(SkillName.Cartography, 10),
		        new CSkills(SkillName.Healing, 10)
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
