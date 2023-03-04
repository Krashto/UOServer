using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class AcrobateClasse
    {
        private static Classe m_Classe = Classe.Acrobate;
        private static int m_Level = 1;
        private static ClasseMode m_ClasseMode = ClasseMode.AmuseursPublics;
        private static Classe m_ClasseAvant = Classe.Aucune;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Acrobate;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(NAptitude.TueurDeMonstres, 2)
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 3),
                new CCapacites(Capacite.Melee, 3),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Archery, 65),
                new CSkills(SkillName.Tactics, 65),
                new CSkills(SkillName.Musicianship, 65),
                new CSkills(SkillName.Peacemaking, 40),
                new CSkills(SkillName.MagicResist, 20),
                new CSkills(SkillName.Provocation, 15),
                new CSkills(SkillName.Discordance, 15),
                new CSkills(SkillName.Anatomy, 10),
                new CSkills(SkillName.Healing, 10)
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
				"Acrobate",
                m_ClasseBranche,
                m_Active
            );
    }
}
