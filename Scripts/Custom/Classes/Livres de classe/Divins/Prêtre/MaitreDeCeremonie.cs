using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class MaitreDeCeremonieClasse
    {
        private static Classe m_Classe = Classe.MaitreDeCeremonie;
        private static int m_Level = 2;
        private static ClasseMode m_ClasseMode = ClasseMode.Religion;
        private static Classe m_ClasseAvant = Classe.Fervent;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Pretre;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(NAptitude.MagieAncestrale, 6),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 2),
                new CCapacites(Capacite.Melee, 2),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Meditation, 80),
		        new CSkills(SkillName.SpiritSpeak, 70),
                new CSkills(SkillName.Healing, 50),
		        new CSkills(SkillName.Anatomy, 40),
		        new CSkills(SkillName.MagicResist, 35),
		        new CSkills(SkillName.EvalInt, 35),
		        new CSkills(SkillName.AnimalLore, 30),
		        new CSkills(SkillName.Forensics, 30),
		        new CSkills(SkillName.Camping, 25),
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
				"Maître de cérémonie",
                m_ClasseBranche,
                m_Active
            );
    }
}
