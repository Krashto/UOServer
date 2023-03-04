using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class PaladinClasse
    {
        private static Classe m_Classe = Classe.Paladin;
        private static int m_Level = 3;
        private static ClasseMode m_ClasseMode = ClasseMode.Religion;
        private static Classe m_ClasseAvant = Classe.Templier;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Paladin;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(NAptitude.MagieAncestrale, 8),
		        new CAptitudes(NAptitude.BouclierGardien, 8),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 6),
                new CCapacites(Capacite.Melee, 5),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Tactics, 100),
                new CSkills(SkillName.Meditation, 100),
		        new CSkills(SkillName.Parry, 100),
                new CSkills(SkillName.SpiritSpeak, 75),
		        new CSkills(SkillName.ArmsLore, 55),
		        new CSkills(SkillName.Anatomy, 55),	
		        new CSkills(SkillName.Veterinary, 45),
		        new CSkills(SkillName.Swords, 30),
		        new CSkills(SkillName.EvalInt, 30)
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
				"Paladin",
                m_ClasseBranche,
                m_Active
            );
    }
}
