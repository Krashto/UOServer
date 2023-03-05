using System;
using Server.Mobiles;

namespace Server.Custom.Aptitudes
{
    public sealed class Aptitudes : BaseAptitudes
    {
        [CommandProperty(AccessLevel.GameMaster)]
        public int Chimie
        {
            get { return this[NAptitude.Chimie]; }
            set { this[NAptitude.Chimie] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Couture
        {
            get { return this[NAptitude.Couture]; }
            set { this[NAptitude.Couture] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Ebenisterie
        {
            get { return this[NAptitude.Ebenisterie]; }
            set { this[NAptitude.Ebenisterie] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Ingenierie
        {
            get { return this[NAptitude.Ingenierie]; }
            set { this[NAptitude.Ingenierie] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Metallurgie
        {
            get { return this[NAptitude.Metallurgie]; }
            set { this[NAptitude.Metallurgie] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Transcription
        {
            get { return this[NAptitude.Transcription]; }
            set { this[NAptitude.Transcription] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int BouclierGardien
        {
            get { return this[NAptitude.BouclierGardien]; }
            set { this[NAptitude.BouclierGardien] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int TueurDeMonstres
        {
            get { return this[NAptitude.TueurDeMonstres]; }
            set { this[NAptitude.TueurDeMonstres] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Penetration
        {
            get { return this[NAptitude.Penetration]; }
            set { this[NAptitude.Penetration] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Nature
        {
            get { return this[NAptitude.Nature]; }
            set { this[NAptitude.Nature] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Invocation
        {
            get { return this[NAptitude.Invocation]; }
            set { this[NAptitude.Invocation] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Necromancie
        {
            get { return this[NAptitude.Necromancie]; }
            set { this[NAptitude.Necromancie] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Arcanique
        {
            get { return this[NAptitude.Arcanique]; }
            set { this[NAptitude.Arcanique] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Medecine
        {
            get { return this[NAptitude.Medecine]; }
            set { this[NAptitude.Medecine] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Defense
        {
            get { return this[NAptitude.Defense]; }
            set { this[NAptitude.Defense] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Destruction
        {
            get { return this[NAptitude.Destruction]; }
            set { this[NAptitude.Destruction] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Musique
        {
            get { return this[NAptitude.Musique]; }
            set { this[NAptitude.Musique] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Familier
        {
            get { return this[NAptitude.Familier]; }
            set { this[NAptitude.Familier] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Piegeage
        {
            get { return this[NAptitude.Piegeage]; }
            set { this[NAptitude.Piegeage] = value; }
        }

        #region AptitudesEntry
        public class AptitudesEntry
        {
            private NAptitude m_Aptitude;
            private string m_Name;
            private int m_Max;
            private SkillName m_Skill;

            public NAptitude Aptitude { get { return m_Aptitude; } }
            public string Name { get { return m_Name; } }
            public int Max { get { return m_Max; } }
            public SkillName Skill { get { return m_Skill; } }

            public AptitudesEntry(NAptitude aptitude, string name, int max, SkillName skill)
            {
                m_Aptitude = aptitude;
                m_Name = name;
                m_Max = max;
                m_Skill = skill;
            }
        }

        public static AptitudesEntry[] m_AptitudeEntries = new AptitudesEntry[]
			{
				new AptitudesEntry( NAptitude.Chimie,                   "Chimie",                   10, SkillName.Alchemy),
				new AptitudesEntry( NAptitude.Couture,                  "Couture",                  10, SkillName.Tailoring),
				new AptitudesEntry( NAptitude.Ebenisterie,              "Ébénisterie",              10, SkillName.Carpentry),
				new AptitudesEntry( NAptitude.Ingenierie,               "Ingénierie",               10, SkillName.Tinkering),
				new AptitudesEntry( NAptitude.Metallurgie,              "Métallurgie",              10, SkillName.Blacksmith),
				new AptitudesEntry( NAptitude.Transcription,            "Transcription",            10, SkillName.Inscribe),

				new AptitudesEntry( NAptitude.BouclierGardien,          "Bouclier gardien",         10, SkillName.Parry),
				new AptitudesEntry( NAptitude.TueurDeMonstres,          "Tueur de monstres",        10, SkillName.Tactics),
				new AptitudesEntry( NAptitude.Penetration,              "Penetration",              10, SkillName.Tactics),
                
				new AptitudesEntry( NAptitude.Nature,                   "Nature",                   10, SkillName.Magery),
				new AptitudesEntry( NAptitude.Invocation,               "Invocation",               10, SkillName.Magery),
				new AptitudesEntry( NAptitude.Necromancie,              "Nécromancie",              10, SkillName.Necromancy),
				new AptitudesEntry( NAptitude.Arcanique,                "Arcanique",                10, SkillName.Magery),
				new AptitudesEntry( NAptitude.Medecine,                 "Médecine",                 10, SkillName.Magery),
				new AptitudesEntry( NAptitude.Defense,                  "Défense",                  10, SkillName.Magery),
				new AptitudesEntry( NAptitude.Destruction,              "Destruction",              10, SkillName.Magery),

                new AptitudesEntry( NAptitude.Musique,                  "Musique",                  10, SkillName.Musicianship),
				new AptitudesEntry( NAptitude.Familier,                 "Familier",                 10, SkillName.AnimalTaming),
				new AptitudesEntry( NAptitude.Piegeage,                 "Piègeage",                 10, SkillName.RemoveTrap),
			};
        #endregion

        public Aptitudes(CustomPlayerMobile owner) : base(owner)
        {
        }

        public Aptitudes(CustomPlayerMobile owner, GenericReader reader) : base(owner, reader)
        {
        }

        public static int GetValue(CustomPlayerMobile m, NAptitude aptitude)
        {
            Aptitudes apti = m.Aptitudes;
            int value = 0;

            if (apti != null)
                value = apti[aptitude];

            return value;
        }

        public static int GetDisponiblePA(CustomPlayerMobile from)
        {
            return from.PADispo;
        }

        public static int GetRemainingPA(CustomPlayerMobile from)
        {
            int pa = 30 + from.Niveau;
            int added = 0;

			for (int i = 0; i < m_AptitudeEntries.Length; i++)
			{
				AptitudesEntry entry = (AptitudesEntry)m_AptitudeEntries[i];
				NAptitude aptitude = entry.Aptitude;
				added = GetValue(from, aptitude) * 10;
			}

			return pa - added;
        }

        public static int GetRequiredPA(CustomPlayerMobile from, NAptitude aptitude)
        {
            return GetValue(from, aptitude) * 10;
        }

        public static int GetBaseValue(CustomPlayerMobile from, NAptitude aptitude)
        {
            return from.GetBaseAptitudeValue(aptitude);
        }

        public static bool CanRaise(CustomPlayerMobile from, NAptitude aptitude)
        {
            int requiredPA = GetRequiredPA(from, aptitude);
            int dispoPA = GetDisponiblePA(from);

            if (dispoPA >= requiredPA)
            {
                int index = (int)aptitude;

                if (index >= 0 && index < m_AptitudeEntries.Length)
                {
                    AptitudesEntry entry = m_AptitudeEntries[index];

                    int max = entry.Max;
                    int value = from.GetAptitudeValue(aptitude);

                    if (value >= max)
                        return false;

                    double skill = from.Skills[entry.Skill].Base;
                    int requiredSkill = GetValue(from, aptitude) * 7 + 30;

					if (skill > requiredSkill)
						return true;
                }
            }

            return false;
        }

        public static bool CanLower(CustomPlayerMobile from, NAptitude aptitude)
        {
            int value = GetValue(from, aptitude);

            if (value > 0)
                return true;

            return false;
        }

        public int this[NAptitude aptitude]
        {
            get { return GetValue(aptitude); }
            set { SetValue(aptitude, value); }
        }

        public override string ToString()
        {
            return "...";
        }
    }

    [PropertyObject]
    public abstract class BaseAptitudes
    {
        private CustomPlayerMobile m_Owner;
        public int[] m_Values;

        public CustomPlayerMobile Owner { get { return m_Owner; } }

        public BaseAptitudes(CustomPlayerMobile owner)
        {
            m_Owner = owner;
            m_Values = new int[Enum.GetNames(typeof(NAptitude)).Length + 1];
        }

        public BaseAptitudes(CustomPlayerMobile owner, GenericReader reader)
        {
            m_Owner = owner;

            int version = reader.ReadInt();

            int count = reader.ReadInt();

            m_Values = new int[Enum.GetNames(typeof(NAptitude)).Length + 1];

            for (int i = 0; i < count; ++i)
            {
                m_Values[i] = reader.ReadInt();
            }
        }

        public void Serialize(GenericWriter writer)
        {
            writer.Write((int)0); // version;

            writer.Write((int)m_Values.Length);

            for (int i = 0; i < m_Values.Length; ++i)
            {
                writer.Write((int)m_Values[i]);
            }
        }

        public int GetValue(NAptitude aptitude)
        {
            int index = GetIndex(aptitude);

            if (index >= 0 && index < m_Values.Length)
            {
                int value = m_Values[index];

                return value;
            }

            return 0;
        }

        public void SetValue(NAptitude aptitude, int value)
        {
            int index = GetIndex(aptitude);

            if (index >= 0 && index < m_Values.Length)
            {
                int oldvalue = m_Values[index];

                m_Values[index] = value;

                m_Owner.OnAptitudesChange(aptitude, oldvalue, value);
            }
        }

        private int GetIndex(NAptitude aptitude)
        {
            int index = (int)aptitude;

            return index;
        }

        public virtual void Reset()
        {
            for (int i = 0; i < m_Values.Length; i++)
            {
                m_Values[i] = 0;
                m_Owner.OnAptitudesChange((NAptitude)i, Owner.GetAptitudeValue((NAptitude)i) + 1, Owner.GetAptitudeValue((NAptitude)i));
            }

            Owner.PADispo = 30 + Owner.Niveau;
        }
    }
}
