using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class TemplierClasse
    {
        private static Classe m_Classe = Classe.Templier;
        private static int m_Level = 2;
        private static ClasseMode m_ClasseMode = ClasseMode.Religion;
        private static Classe m_ClasseAvant = Classe.Repurgateur;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Paladin;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(NAptitude.MagieAncestrale, 6),
                new CAptitudes(NAptitude.BouclierGardien, 6),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 5),
                new CCapacites(Capacite.Melee, 4),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Tactics, 80),
                new CSkills(SkillName.Meditation, 80),
		        new CSkills(SkillName.Parry, 80),
                new CSkills(SkillName.SpiritSpeak, 60),
		        new CSkills(SkillName.ArmsLore, 25),
		        new CSkills(SkillName.Anatomy, 25),
		        new CSkills(SkillName.Veterinary, 20),
		        new CSkills(SkillName.Swords, 20),
		        new CSkills(SkillName.EvalInt, 20)
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
				"Templier",
                m_ClasseBranche,
                m_Active
            );
    }
}
