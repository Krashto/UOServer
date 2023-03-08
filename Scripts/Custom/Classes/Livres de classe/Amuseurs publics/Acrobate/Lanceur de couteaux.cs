using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class LanceurDeCouteauxClasse
    {
        private static Classe m_Classe = Classe.LanceurDeCouteaux;
        private static int m_Level = 2;
        private static ClasseMode m_ClasseMode = ClasseMode.AmuseursPublics;
        private static Classe m_ClasseAvant = Classe.Acrobate;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Acrobate;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 4),
                new CCapacites(Capacite.Melee, 5),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Archery, 80),
                new CSkills(SkillName.Tactics, 80),
                new CSkills(SkillName.Musicianship, 80),
                new CSkills(SkillName.Peacemaking, 60),
                new CSkills(SkillName.MagicResist, 30),
                new CSkills(SkillName.Provocation, 25),
                new CSkills(SkillName.Discordance, 25),
                new CSkills(SkillName.Anatomy, 20),
                new CSkills(SkillName.Healing, 20)
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
                "Lanceur de Couteaux",
                m_ClasseBranche,
                m_Active
            );
    }
}
