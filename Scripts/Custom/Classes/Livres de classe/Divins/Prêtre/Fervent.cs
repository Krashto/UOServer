using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class FerventClasse
    {
        private static Classe m_Classe = Classe.Fervent;
        private static int m_Level = 1;
        private static ClasseMode m_ClasseMode = ClasseMode.Religion;
        private static Classe m_ClasseAvant = Classe.Aucune;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Pretre;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(NAptitude.MagieAncestrale, 2),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 2),
                new CCapacites(Capacite.Melee, 1),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Meditation, 50),
                new CSkills(SkillName.Healing, 40),
                new CSkills(SkillName.SpiritSpeak, 50),
		        new CSkills(SkillName.Anatomy, 30),
                new CSkills(SkillName.MagicResist, 10),
                new CSkills(SkillName.EvalInt, 10),
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
				"Fervent",
                m_ClasseBranche,
                m_Active
            );
    }
}
