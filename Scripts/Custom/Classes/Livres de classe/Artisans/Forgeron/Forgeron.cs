using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class ForgeronClasse
    {
        private static Classe m_Classe = Classe.Forgeron;
        private static int m_Level = 2;
        private static ClasseMode m_ClasseMode = ClasseMode.Artisans;
        private static Classe m_ClasseAvant = Classe.Armurier;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Forgeron;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(Aptitude.Metallurgie, 6),
                new CAptitudes(Aptitude.Ingenierie, 3),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 2),
                new CCapacites(Capacite.Melee, 2),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Blacksmith, 80),
                new CSkills(SkillName.Mining, 80),
                new CSkills(SkillName.ArmsLore, 70),
                new CSkills(SkillName.ItemID, 45),
                new CSkills(SkillName.Tinkering, 30),
                new CSkills(SkillName.Camping, 30),
                new CSkills(SkillName.Cooking, 30),
                new CSkills(SkillName.Macing, 15),
                new CSkills(SkillName.Fencing, 15),
                new CSkills(SkillName.Swords, 15),
                new CSkills(SkillName.Parry, 15),
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
				"Forgeron",
                m_ClasseBranche,
                m_Active
            );
    }
}
