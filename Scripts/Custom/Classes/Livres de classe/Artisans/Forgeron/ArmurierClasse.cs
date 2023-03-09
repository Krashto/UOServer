using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class ArmurierClasse
    {
		private static string m_Name = "Armurier";
        private static Classe m_Classe = Classe.Armurier;
        private static int m_Level = 1;
        private static ClasseMode m_ClasseMode = ClasseMode.Artisans;
        private static Classe m_ClasseAvant = Classe.Aucune;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Forgeron;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(Aptitude.Metallurgie, 3),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Expertise, 1),
                new CCapacites(Capacite.ArmesMelee, 1),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Blacksmith, 65),
                new CSkills(SkillName.Mining, 65),
                new CSkills(SkillName.ArmsLore, 60),
		        new CSkills(SkillName.ItemID, 20),
                new CSkills(SkillName.Tinkering, 15),
		        new CSkills(SkillName.Camping, 15),
                new CSkills(SkillName.Cooking, 15),
		        new CSkills(SkillName.Macing, 10),
		        new CSkills(SkillName.Fencing, 10),
		        new CSkills(SkillName.Swords, 10),
		        new CSkills(SkillName.Parry, 10),
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
