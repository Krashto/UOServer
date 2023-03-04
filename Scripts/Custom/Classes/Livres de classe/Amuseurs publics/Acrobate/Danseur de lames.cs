using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class DanseurDeLameClasse
    {
        private static Classe m_Classe = Classe.DanseurDeLames;
        private static int m_Level = 3;
        private static ClasseMode m_ClasseMode = ClasseMode.AmuseursPublics;
        private static Classe m_ClasseAvant = Classe.LanceurDeCouteaux;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Acrobate;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(NAptitude.TueurDeMonstres, 4)
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 4),
                new CCapacites(Capacite.Melee, 5),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Archery, 100),
                new CSkills(SkillName.Tactics, 85),
                new CSkills(SkillName.Musicianship, 80),
                new CSkills(SkillName.Peacemaking, 75),
                new CSkills(SkillName.MagicResist, 70),
                new CSkills(SkillName.Provocation, 50),
                new CSkills(SkillName.Discordance, 50),
                new CSkills(SkillName.Anatomy, 50),
                new CSkills(SkillName.Healing, 30)
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
                "Danseur de lames",
                m_ClasseBranche,
                m_Active
            );
    }
}
