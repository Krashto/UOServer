using Server.Custom.Classes;
using Server.Custom.Aptitudes;

namespace Server
{
	public class RepurgateurClasse
    {
        private static Classe m_Classe = Classe.Repurgateur;
        private static int m_Level = 1;
        private static ClasseMode m_ClasseMode = ClasseMode.Religion;
        private static Classe m_ClasseAvant = Classe.Aucune;
        private static ClasseBranche m_ClasseBranche = ClasseBranche.Paladin;
        private static bool m_Active = true;

        private static CAptitudes[] m_Aptitudes = new CAptitudes[]
            {
                new CAptitudes(NAptitude.MagieAncestrale, 4),
                new CAptitudes(NAptitude.BouclierGardien, 4),
            };

        private static CCapacites[] m_Capacites = new CCapacites[]
            {
                new CCapacites(Capacite.Armure, 4),
                new CCapacites(Capacite.Melee, 4),
            };

        private static CSkills[] m_Skills = new CSkills[]
            {
                new CSkills(SkillName.Tactics, 65),
                new CSkills(SkillName.Meditation, 65),
		        new CSkills(SkillName.Parry, 65),
                new CSkills(SkillName.SpiritSpeak, 40),
		        new CSkills(SkillName.ArmsLore, 20),
		        new CSkills(SkillName.Anatomy, 15),
		        new CSkills(SkillName.Veterinary, 15),
		        new CSkills(SkillName.Swords, 10),
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
				"Répurgateur",
                m_ClasseBranche,
                m_Active
            );
    }
}
