using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class ChevalierClasse
    {
        private static Classe m_Classe = Classe.Chevalier;
        private static int m_Level = 3;
        private static ClasseMode m_ClasseMode = ClasseMode.Guerriers;
        private static Classe m_ClasseAvant = Classe.Jouteur;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Chevaucheur;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
				new CAptitudes(NAptitude.Penetration, 4),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 6),
                new CCapacites(Capacite.Melee, 5),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Tactics, 100),
                new CSkills(SkillName.MagicResist, 100),
                new CSkills(SkillName.Parry, 100),
                new CSkills(SkillName.Healing, 70),
                new CSkills(SkillName.ArmsLore, 70),
                new CSkills(SkillName.AnimalLore, 50),
                new CSkills(SkillName.Veterinary, 40)
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
				"Chevalier",
                m_ClasseBranche,
                m_Active
            );
    }
}
