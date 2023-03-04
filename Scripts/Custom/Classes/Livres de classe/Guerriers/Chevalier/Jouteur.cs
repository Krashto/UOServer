using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class JouteurClasse
    {
        private static Classe m_Classe = Classe.Jouteur;
        private static int m_Level = 2;
        private static ClasseMode m_ClasseMode = ClasseMode.Guerriers;
        private static Classe m_ClasseAvant = Classe.Ecuyer;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Chevaucheur;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
				new CAptitudes(NAptitude.Penetration, 1),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 4),
                new CCapacites(Capacite.Melee, 3),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Tactics, 50),
                new CSkills(SkillName.MagicResist, 45),
                new CSkills(SkillName.Parry, 35),
                new CSkills(SkillName.Healing, 30),
                new CSkills(SkillName.ArmsLore, 20)
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
				"Jouteur",
                m_ClasseBranche,
                m_Active
            );
    }
}
