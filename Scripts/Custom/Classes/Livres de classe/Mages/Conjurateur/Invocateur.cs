using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class InvocateurClasse
    {
        private static Classe m_Classe = Classe.Invocateur;
        private static int m_Level = 2;
        private static ClasseMode m_ClasseMode = ClasseMode.Mages;
        private static Classe m_ClasseAvant = Classe.Prestidigitateur;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Conjurateur;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
		        new CAptitudes(NAptitude.Familier, 4),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 2),
                new CCapacites(Capacite.Melee, 1),
                new CCapacites(Capacite.Magie, 6),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Magery, 65),
                new CSkills(SkillName.Meditation, 60),
                new CSkills(SkillName.Veterinary, 50),
		        new CSkills(SkillName.EvalInt, 50),
		        new CSkills(SkillName.AnimalLore, 35),
                new CSkills(SkillName.ItemID, 10),
		        new CSkills(SkillName.Wrestling, 10)
            };

        public static ClasseInfo ClasseInfo = new ClasseInfo(
                m_Classe,
                m_Level,
                m_ClasseMode,
                m_ClasseAvant,
                m_Aptitudes,
                m_Capacites,
                m_Skills,
				"Invocateur",
                m_ClasseBranche,
                m_Active
            );
    }
}
