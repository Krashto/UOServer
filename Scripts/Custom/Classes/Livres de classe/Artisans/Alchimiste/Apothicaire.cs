using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class ApothicaireClasse
    {
        private static Classe m_Classe = Classe.Apothicaire;
        private static int m_Level = 3;
        private static ClasseMode m_ClasseMode = ClasseMode.Artisans;
        private static Classe m_ClasseAvant = Classe.Alchimiste;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Alchimiste;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(NAptitude.Chimie, 8),
                new CAptitudes(NAptitude.Ingenierie, 4),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 2),
                new CCapacites(Capacite.Melee, 1),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Alchemy, 100),
                new CSkills(SkillName.TasteID, 80),
                new CSkills(SkillName.Cooking, 80),
                new CSkills(SkillName.ItemID, 75),
                new CSkills(SkillName.Camping, 60),
                new CSkills(SkillName.Tinkering, 50),
                new CSkills(SkillName.Mining, 50),
                new CSkills(SkillName.Healing, 40),
                new CSkills(SkillName.Anatomy, 35),
                new CSkills(SkillName.EvalInt, 20),
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
				"Apothicaire",
                m_ClasseBranche,
                m_Active
            );
    }
}
