using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class ArchiDruideClasse
    {
        private static Classe m_Classe = Classe.ArchiDruide;
        private static int m_Level = 3;
        private static ClasseMode m_ClasseMode = ClasseMode.Nature;
        private static Classe m_ClasseAvant = Classe.Druide;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Druide;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(NAptitude.Nature, 8),
                new CAptitudes(NAptitude.Invocation, 8),
                new CAptitudes(NAptitude.Familier, 4),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 2),
                new CCapacites(Capacite.Melee, 2),
                new CCapacites(Capacite.Magie, 8),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.AnimalTaming, 100),
                new CSkills(SkillName.Magery, 100),
                new CSkills(SkillName.AnimalLore, 80),
                new CSkills(SkillName.Herding, 70),
                new CSkills(SkillName.Veterinary, 70),
                new CSkills(SkillName.Meditation, 50),
                new CSkills(SkillName.EvalInt, 50),
                new CSkills(SkillName.SpiritSpeak, 40),
                new CSkills(SkillName.Anatomy, 30),
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
				"Archidruide",
                m_ClasseBranche,
                m_Active
            );
    }
}
