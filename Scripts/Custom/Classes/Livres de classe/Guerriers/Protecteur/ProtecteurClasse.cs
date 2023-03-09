using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class ProtecteurClasse
    {
		private static string m_Name = "Protecteur";
        private static Classe m_Classe = Classe.Protecteur;
		private static int m_Level = 3;
        private static ClasseMode m_ClasseMode = ClasseMode.Guerriers;
        private static Classe m_ClasseAvant = Classe.Gardien;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Protecteur;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
				new CAptitudes(Aptitude.Martial, 10),
            };

		private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 3),
                new CCapacites(Capacite.Bouclier, 3),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.MagicResist, 100),
                new CSkills(SkillName.Healing, 100),
                new CSkills(SkillName.Tactics, 100),
		        new CSkills(SkillName.Parry, 100),
                new CSkills(SkillName.Anatomy, 45),
                new CSkills(SkillName.ArmsLore, 45),
                new CSkills(SkillName.Tracking, 20),
		        new CSkills(SkillName.DetectHidden, 20)
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
