using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class DruideClasse
    {
        private static Classe m_Classe = Classe.Druide;
        private static int m_Level = 2;
        private static ClasseMode m_ClasseMode = ClasseMode.Nature;
        private static Classe m_ClasseAvant = Classe.Herboriste;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Druide;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(NAptitude.Nature, 6),
                new CAptitudes(NAptitude.Invocation, 6),
                new CAptitudes(NAptitude.Familier, 3),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 2),
                new CCapacites(Capacite.Melee, 2),
                new CCapacites(Capacite.Magie, 6),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.AnimalTaming, 80),
                new CSkills(SkillName.Magery, 80),
                new CSkills(SkillName.AnimalLore, 65),
                new CSkills(SkillName.Herding, 60),
                new CSkills(SkillName.Veterinary, 60),
                new CSkills(SkillName.Meditation, 30),
                new CSkills(SkillName.EvalInt, 30),
                new CSkills(SkillName.SpiritSpeak, 20),
                new CSkills(SkillName.Anatomy, 10),
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
				"Druide",
                m_ClasseBranche,
                m_Active
            );
    }
}
