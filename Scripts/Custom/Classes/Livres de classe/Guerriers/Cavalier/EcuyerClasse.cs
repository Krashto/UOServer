using Server.Custom.Classes;
using Server.Custom.Aptitudes;
using Server.Custom.Capacites;

namespace Server
{
	public class EcuyerClasse
    {
		private static string m_Name = "Écuyer";
        private static Classe m_Classe = Classe.Ecuyer;
		private static int m_Level = 1;
        private static ClasseMode m_ClasseMode = ClasseMode.Guerriers;
        private static Classe m_ClasseAvant = Classe.Aucune;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Cavalier;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {                
				new CAptitudes(Aptitude.Martial, 3),
            };

		private static CCapacites[] m_Capacites = new CCapacites[]
            {
				new CCapacites(Capacite.Equitation, 3),
				new CCapacites(Capacite.ArmesMelee, 3),
			};

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Tactics, 35),
                new CSkills(SkillName.MagicResist, 35),
                new CSkills(SkillName.Parry, 10)
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
