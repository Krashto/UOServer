using System.Collections;
using Server.Custom.Aptitudes;
using Server.Custom.Capacites;
using Server.Mobiles;

namespace Server.Custom.Classes
{
	public class CAptitudes
    {
        private Aptitude m_Aptitude;
        private int m_Value;

        public Aptitude Aptitude { get { return m_Aptitude; } }
        public int Value { get { return m_Value; } }

        public CAptitudes(Aptitude aptitude, int value)
        {
            m_Aptitude = aptitude;
            m_Value = value;
        }
    }

    public class CCapacites
    {
        private Capacite m_Capacite;
        private int m_Value;

        public Capacite Capacite { get { return m_Capacite; } }
        public int Value { get { return m_Value; } }

        public CCapacites(Capacite capacite, int value)
        {
            m_Capacite = capacite;
            m_Value = value;
        }
    }

    public class CSkills
    {
        private SkillName m_SkillName;
        private double m_Value;

        public SkillName SkillName { get { return m_SkillName; } }
        public double Value { get { return m_Value; } }

        public CSkills(SkillName skillName, double value)
        {
            m_SkillName = skillName;
            m_Value = value;
        }
    }

    public class ClasseInfo
    {
        private Classe m_Classe;
        private int m_Level;
        private ClasseMode m_ClasseMode;
        private Classe m_ClasseAvant;
        private CAptitudes[] m_Aptitudes;
        private CCapacites[] m_Capacites;
        private CSkills[] m_Skills;
        private string m_Nom;
        private bool m_Prestige;
        private ClasseBranche m_ClasseBranche;
        private bool m_Active;

        public Classe Classe { get { return m_Classe; } }
        public int Level { get { return m_Level; } }
        public ClasseMode ClasseMode { get { return m_ClasseMode; } }
        public Classe ClasseAvant { get { return m_ClasseAvant; } }
        public CAptitudes[] Aptitudes { get { return m_Aptitudes; } }
        public CCapacites[] Capacites { get { return m_Capacites; } }
        public CSkills[] Skills { get { return m_Skills; } }
        public string Nom { get { return m_Nom; } }
        public bool Prestige { get { return m_Prestige; } }
        public ClasseBranche ClasseBranche { get { return m_ClasseBranche; } }
        public bool Active { get { return m_Active; } }

        public ClasseInfo(Classe classe, int level, ClasseMode classeMode, Classe classeAvant, CAptitudes[] aptitudes, CCapacites[] capacites, CSkills[] skills, string name, ClasseBranche branche, bool active)
        {
            m_Classe = classe;
            m_Level = level;
            m_ClasseMode = classeMode;
            m_ClasseAvant = classeAvant;
            m_Aptitudes = aptitudes;
            m_Capacites = capacites;
            m_Skills = skills;
            m_Nom = name;
            m_Prestige = false;
            m_ClasseBranche = branche;
            m_Active = active;
        }

        public ClasseInfo(Classe classe, int level, ClasseMode classeMode, Classe classeAvant, CAptitudes[] aptitudes, CCapacites[] capacites, CSkills[] skills, string name, bool prestige, ClasseBranche branche, bool active)
        {
            m_Classe = classe;
            m_Level = level;
            m_ClasseMode = classeMode;
            m_ClasseAvant = classeAvant;
            m_Aptitudes = aptitudes;
            m_Capacites = capacites;
            m_Skills = skills;
            m_Nom = name;
            m_Prestige = prestige;
            m_ClasseBranche = branche;
            m_Active = active;
        }
    }

    public sealed class Classes
    {
        public static bool IsValidChange(Classe oldClass, Classe newClass)
        {
            ClasseInfo oldinfo = GetInfos(oldClass);
            ClasseInfo info = GetInfos(newClass);

            if (info == null)
                return false;

            return (info.ClasseAvant == oldClass || (info != null && oldinfo != null && info.ClasseAvant == Classe.Aucune && oldinfo.ClasseAvant == Classe.Aucune && info.ClasseMode == oldinfo.ClasseMode));
        }

        public static Classe GetClassBefore(Classe classe)
        {
            ClasseInfo info = GetInfos(classe);

            if (info == null)
                return Classe.Aucune;

            return info.ClasseAvant;
        }

        public static int GetAptitudeValue(Classe classe, Aptitude aptitude)
        {
            ClasseInfo info = GetInfos(classe);

            if (info == null)
                return 0;

            if (info.Aptitudes != null)
            {
                for (int i = 0; i < info.Aptitudes.Length; ++i)
                {
                    CAptitudes aptitudes = info.Aptitudes[i];

                    if (aptitudes.Aptitude == aptitude)
                        return aptitudes.Value;
                }
            }

            return 0;
        }

        public static Hashtable GetAptitudes(Classe classe)
        {
            Hashtable table = new Hashtable();
            ClasseInfo info = GetInfos(classe);

            if (info == null)
                return table;

            if (info.Aptitudes != null)
            {
                for (int i = 0; i < info.Aptitudes.Length; ++i)
                {
                    CAptitudes aptitudes = info.Aptitudes[i];

                    if (!table.ContainsKey(aptitudes.Aptitude))
                        table.Add(aptitudes.Aptitude, aptitudes.Value);
                }
            }

            return table;
        }

        public static int GetLevel(Classe classe)
        {
            ClasseInfo info = GetInfos(classe);

            if (info == null)
                return 6;

            return info.Level;
        }

        public static ClasseMode GetClasseMode(Classe classe)
        {
            ClasseInfo info = GetInfos(classe);

            if (info == null)
                return ClasseMode.Aucun;

            return info.ClasseMode;
        }

		public static bool IsCraftingSkills(SkillName skill)
		{
			return skill == SkillName.Alchemy || skill == SkillName.Tailoring || skill == SkillName.Tinkering
				 || skill == SkillName.Blacksmith || skill == SkillName.Inscribe;
		}

		public static void SetBaseAndCapSkills(CustomPlayerMobile pm, int level)
		{
			if (pm is null)
				return;

			foreach (var skill in pm.Skills)
			{
				if (IsCraftingSkills(skill.SkillName))
					skill.Cap = 25 + level / 2;
				else
					skill.Cap = 50 + level;

				if (skill.Base > skill.Cap)
					skill.Base = skill.Cap;
			}
				
			pm.SkillMods.Clear();
			pm.SkillsCap = 4000 + level * 80;

			if (pm.Aptitudes.Chimie > 0)
			{
				var mod = new DefaultSkillMod(SkillName.Alchemy, true, pm.Aptitudes.Chimie * 5.0);
				pm.SkillMods.Add(mod);
			}
			if (pm.Aptitudes.Couture > 0)
			{
				var mod = new DefaultSkillMod(SkillName.Tailoring, true, pm.Aptitudes.Couture * 5.0);
				pm.SkillMods.Add(mod);
			}
			if (pm.Aptitudes.Ingenierie > 0)
			{
				var mod = new DefaultSkillMod(SkillName.Tinkering, true, pm.Aptitudes.Ingenierie * 5.0);
				pm.SkillMods.Add(mod);
			}
			if (pm.Aptitudes.Metallurgie > 0)
			{
				var mod = new DefaultSkillMod(SkillName.Blacksmith, true, pm.Aptitudes.Metallurgie * 5.0);
				pm.SkillMods.Add(mod);
			}
			if (pm.Aptitudes.Transcription > 0)
			{
				var mod = new DefaultSkillMod(SkillName.Inscribe, true, pm.Aptitudes.Transcription * 5.0);
				pm.SkillMods.Add(mod);
			}
		}

        public static int GetCapaciteValue(Capacite capacite, Classe classe)
        {
            ClasseInfo info = GetInfos(classe);

            if (info == null)
                return 0;

            for (int i = 0; i < info.Capacites.Length; ++i)
            {
                CCapacites cap = info.Capacites[i];

                if (cap.Capacite == capacite)
                    return cap.Value;
            }

            return 0;
        }

        public static bool IsValid(CustomPlayerMobile m, Classe classe)
        {
            ClasseInfo info = GetInfos(classe);

            if (m == null || info == null)
                return false;

            if (info.Skills != null)
            {
                for (int i = 0; i < info.Skills.Length; ++i)
                {
                    CSkills skills = info.Skills[i];

                    if (m.Skills[skills.SkillName].Base < skills.Value)
                        return false;
                }
            }

            return true;
        }

        public static ClasseInfo GetInfos(Classe classe)
        {
            ClasseInfo info = null;

            switch (classe)
            {
				case Classe.Embouteilleur: info = EmbouteilleurClasse.ClasseInfo; break;
				case Classe.Alchimiste: info = AlchimisteClasse.ClasseInfo; break;
				case Classe.Apothicaire: info = ApothicaireClasse.ClasseInfo; break;

				case Classe.Styliste: info = StylisteClasse.ClasseInfo; break;
				case Classe.Modeleur: info = ModeleurClasse.ClasseInfo; break;
				case Classe.Couturier: info = CouturierClasse.ClasseInfo; break;

				case Classe.Bricoleur: info = BricoleurClasse.ClasseInfo; break;
				case Classe.Ingenieur: info = IngenieurClasse.ClasseInfo; break;
				case Classe.Inventeur: info = InventeurClasse.ClasseInfo; break;

				case Classe.Armurier: info = ArmurierClasse.ClasseInfo; break;
				case Classe.Forgeron: info = ForgeronClasse.ClasseInfo; break;
				case Classe.Forgefer: info = ForgeferClasse.ClasseInfo; break;

				case Classe.Eleve: info = EleveClasse.ClasseInfo; break;
				case Classe.Erudit: info = EruditClasse.ClasseInfo; break;
				case Classe.Sage: info = SageClasse.ClasseInfo; break;

				case Classe.Combattant: info = CombattantClasse.ClasseInfo; break;
				case Classe.Mirmillon: info = MirmillonClasse.ClasseInfo; break;
				case Classe.Champion: info = ChampionClasse.ClasseInfo; break;

				case Classe.Archer: info = ArcherClasse.ClasseInfo; break;
				case Classe.FrancTireur: info = FrancTireurClasse.ClasseInfo; break;
				case Classe.MaitreArcher: info = MaitreArcherClasse.ClasseInfo; break;

				case Classe.Ecuyer: info = EcuyerClasse.ClasseInfo; break;
				case Classe.Jouteur: info = JouteurClasse.ClasseInfo; break;
				case Classe.Cavalier: info = CavalierClasse.ClasseInfo; break;

				case Classe.Defenseur: info = DefenseurClasse.ClasseInfo; break;
				case Classe.Gardien: info = GardienClasse.ClasseInfo; break;
				case Classe.Protecteur: info = ProtecteurClasse.ClasseInfo; break;

				case Classe.Pisteur: info = PisteurClasse.ClasseInfo; break;
				case Classe.Traqueur: info = TraqueurClasse.ClasseInfo; break;
				case Classe.Rodeur: info = RodeurClasse.ClasseInfo; break;

				case Classe.Multiforme: info = MultiformeClasse.ClasseInfo; break;
				case Classe.Diversiforme: info = DiversiformeClasse.ClasseInfo; break;
				case Classe.Changeforme: info = ChangeformeClasse.ClasseInfo; break;

				case Classe.Invocateur: info = InvocateurClasse.ClasseInfo; break;
				case Classe.Conjurateur: info = ConjurateurClasse.ClasseInfo; break;
				case Classe.Spiritualiste: info = SpiritualisteClasse.ClasseInfo; break;

				case Classe.Troubadour: info = TroubadourClasse.ClasseInfo; break;
				case Classe.Barde: info = BardeClasse.ClasseInfo; break;
				case Classe.Menestrel: info = MenestrelClasse.ClasseInfo; break;

				case Classe.Mage: info = MageClasse.ClasseInfo; break;
				case Classe.Magicien: info = MagicienClasse.ClasseInfo; break;
				case Classe.Hydromancien: info = HydromancienClasse.ClasseInfo; break;

				case Classe.Incantateur: info = IncantateurClasse.ClasseInfo; break;
				case Classe.Sorcier: info = SorcierClasse.ClasseInfo; break;
				case Classe.Pyromancien: info = PyromancienClasse.ClasseInfo; break;

				case Classe.Naturaliste: info = NaturalisteClasse.ClasseInfo; break;
				case Classe.Druide: info = DruideClasse.ClasseInfo; break;
				case Classe.Geomancien: info = GeomancienClasse.ClasseInfo; break;

				case Classe.Apprenti: info = ApprentiClasse.ClasseInfo; break;
				case Classe.Evocateur: info = EvocateurClasse.ClasseInfo; break;
				case Classe.Aeromancien: info = AeromancienClasse.ClasseInfo; break;

				case Classe.Thanathauste: info = ThanathausteClasse.ClasseInfo; break;
                case Classe.Necromage: info = NecromageClasse.ClasseInfo; break;
                case Classe.Necromancien: info = NecromancienClasse.ClasseInfo; break;

				case Classe.Vagabond: info = VagabondClasse.ClasseInfo; break;
				case Classe.Voleur: info = VoleurClasse.ClasseInfo; break;
				case Classe.Roublard: info = RoublardClasse.ClasseInfo; break;
				
				case Classe.Intervenant: info = IntervenantClasse.ClasseInfo; break;
				case Classe.Soigneur: info = SoigneurClasse.ClasseInfo; break;
				case Classe.Guerisseur: info = GuerisseurClasse.ClasseInfo; break;

                default: info = ClasseAucune.ClasseInfo; break;
            }

            return info;
        }
    }
}