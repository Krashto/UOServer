using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class IntermediaireDivinClasse
    {
        private static Classe m_Classe = Classe.IntermediaireDivin;
        private static int m_Level = 3;
        private static ClasseMode m_ClasseMode = ClasseMode.Religion;
        private static Classe m_ClasseAvant = Classe.MaitreDeCeremonie;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Pretre;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(NAptitude.MagieAncestrale, 8),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 2),
                new CCapacites(Capacite.Melee, 2),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Meditation, 100),
		        new CSkills(SkillName.SpiritSpeak, 100),
                new CSkills(SkillName.Healing, 90),
		        new CSkills(SkillName.Anatomy, 75),
		        new CSkills(SkillName.MagicResist, 65),
		        new CSkills(SkillName.EvalInt, 45),         
		        new CSkills(SkillName.AnimalLore, 45),
		        new CSkills(SkillName.Forensics, 40),
		        new CSkills(SkillName.Camping, 30),   
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
				"Intermédiaire Divin",
                m_ClasseBranche,
                m_Active
            );
    }
}
