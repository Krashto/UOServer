using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class CavalierClasse
    {
		private static string m_Name = "Cavalier";
        private static Classe m_Classe = Classe.Cavalier;
		private static int m_Level = 3;
        private static ClasseMode m_ClasseMode = ClasseMode.Guerriers;
        private static Classe m_ClasseAvant = Classe.Jouteur;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Cavalier;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
				new CAptitudes(Aptitude.Martial, 10),
            };

		private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Equitation, 3),
                new CCapacites(Capacite.ArmesMelee, 3),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Tactics, 100),
                new CSkills(SkillName.MagicResist, 100),
                new CSkills(SkillName.Parry, 100),
                new CSkills(SkillName.Healing, 70),
                new CSkills(SkillName.ArmsLore, 70),
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
