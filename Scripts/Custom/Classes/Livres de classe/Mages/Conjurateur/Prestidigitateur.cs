using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class PrestidigitateurClasse
    {
        private static Classe m_Classe = Classe.Prestidigitateur;
        private static int m_Level = 1;
        private static ClasseMode m_ClasseMode = ClasseMode.Mages;
        private static Classe m_ClasseAvant = Classe.Aucune;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Conjurateur;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
		        new CAptitudes(NAptitude.Familier, 2),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 1),
                new CCapacites(Capacite.Melee, 1),
                new CCapacites(Capacite.Magie, 5),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Magery, 50),
                new CSkills(SkillName.Meditation, 45),
                new CSkills(SkillName.Veterinary, 35),
		        new CSkills(SkillName.EvalInt, 30),
		        new CSkills(SkillName.AnimalLore, 25)
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
				"Prestidigitateur",
                m_ClasseBranche,
                m_Active
            );
    }
}
