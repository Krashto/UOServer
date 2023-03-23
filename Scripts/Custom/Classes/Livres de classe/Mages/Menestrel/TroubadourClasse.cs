using Server.Custom.Classes;
using Server.Custom.Aptitudes;
using Server.Custom.Capacites;

namespace Server
{
	public class TroubadourClasse
    {
        private static string m_Name = "Troubadour";
        private static Classe m_Classe = Classe.Troubadour;
		private static int m_Level = 1;
        private static ClasseMode m_ClasseMode = ClasseMode.Mages;
        private static Classe m_ClasseAvant = Classe.Aucune;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Menestrel;
        private static bool m_Active = false;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
				new CAptitudes(Aptitude.Musique, 3),
            };

		private static CCapacites[] m_Capacites = new CCapacites[]
            {
               	new CCapacites(Capacite.Magie, 1),
                new CCapacites(Capacite.Bouclier, 1),
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
