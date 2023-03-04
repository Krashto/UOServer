using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class DefenseurClasse
    {
        private static Classe m_Classe = Classe.Defenseur;
        private static int m_Level = 1;
        private static ClasseMode m_ClasseMode = ClasseMode.Guerriers;
        private static Classe m_ClasseAvant = Classe.Aucune;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Protecteur;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(NAptitude.BouclierGardien, 2),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 4),
                new CCapacites(Capacite.Melee, 3),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.MagicResist, 50),
                new CSkills(SkillName.Healing, 45),
                new CSkills(SkillName.Tactics, 35),
		        new CSkills(SkillName.Parry, 35)
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
				"Defenseur",
                m_ClasseBranche,
                m_Active
            );
    }
}
