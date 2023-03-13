using System;
using Server.Mobiles;

namespace Server.Custom.Aptitudes
{
    public sealed class Aptitudes : BaseAptitudes
    {
        [CommandProperty(AccessLevel.GameMaster)]
        public int Chimie
        {
            get { return this[Aptitude.Chimie]; }
            set { this[Aptitude.Chimie] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Couture
        {
            get { return this[Aptitude.Couture]; }
            set { this[Aptitude.Couture] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Ingenierie
        {
            get { return this[Aptitude.Ingenierie]; }
            set { this[Aptitude.Ingenierie] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Metallurgie
        {
            get { return this[Aptitude.Metallurgie]; }
            set { this[Aptitude.Metallurgie] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Transcription
        {
            get { return this[Aptitude.Transcription]; }
            set { this[Aptitude.Transcription] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Martial
		{
            get { return this[Aptitude.Martial]; }
            set { this[Aptitude.Martial] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Chasseur
		{
            get { return this[Aptitude.Chasseur]; }
            set { this[Aptitude.Chasseur] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Roublardise
		{
            get { return this[Aptitude.Roublardise]; }
            set { this[Aptitude.Roublardise] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Polymorphie
		{
            get { return this[Aptitude.Polymorphie]; }
            set { this[Aptitude.Polymorphie] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Totemique
		{
            get { return this[Aptitude.Totemique]; }
            set { this[Aptitude.Totemique] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Musique
		{
            get { return this[Aptitude.Musique]; }
            set { this[Aptitude.Musique] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Hydromancie
		{
            get { return this[Aptitude.Hydromancie]; }
            set { this[Aptitude.Hydromancie] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Pyromancie
		{
            get { return this[Aptitude.Pyromancie]; }
            set { this[Aptitude.Pyromancie] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Geomancie
		{
            get { return this[Aptitude.Geomancie]; }
            set { this[Aptitude.Geomancie] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Aeromancie
		{
            get { return this[Aptitude.Aeromancie]; }
            set { this[Aptitude.Aeromancie] = value; }
        }

		[CommandProperty(AccessLevel.GameMaster)]
		public int Necromancie
		{
			get { return this[Aptitude.Necromancie]; }
			set { this[Aptitude.Necromancie] = value; }
		}

		#region AptitudesEntry
		public class AptitudesEntry
        {
            private Aptitude m_Aptitude;
            private string m_Name;
            private int m_Max;
            private SkillName m_Skill;

            public Aptitude Aptitude { get { return m_Aptitude; } }
            public string Name { get { return m_Name; } }
            public int Max { get { return m_Max; } }
            public SkillName Skill { get { return m_Skill; } }

            public AptitudesEntry(Aptitude aptitude, string name, int max, SkillName skill)
            {
                m_Aptitude = aptitude;
                m_Name = name;
                m_Max = max;
                m_Skill = skill;
            }
        }

        public static AptitudesEntry[] m_AptitudeEntries = new AptitudesEntry[]
			{
				new AptitudesEntry( Aptitude.Chimie,		"Chimie",           10, SkillName.Alchemy),
				new AptitudesEntry( Aptitude.Couture,		"Couture",          10, SkillName.Tailoring),
				new AptitudesEntry( Aptitude.Ingenierie,	"Ingénierie",       10, SkillName.Tinkering),
				new AptitudesEntry( Aptitude.Metallurgie,	"Métallurgie",      10, SkillName.Blacksmith),
				new AptitudesEntry( Aptitude.Transcription,	"Transcription",    10, SkillName.Inscribe),

				new AptitudesEntry( Aptitude.Martial,		"Martial",          10, SkillName.Tactics),
				new AptitudesEntry( Aptitude.Chasseur,      "Chasseur",         10, SkillName.Tracking),
				new AptitudesEntry( Aptitude.Roublardise,   "Roublardise",		10, SkillName.Hiding),
				new AptitudesEntry( Aptitude.Polymorphie,   "Polymorphie",      10, SkillName.Anatomy),
				new AptitudesEntry( Aptitude.Totemique,     "Totémique",        10, SkillName.AnimalTaming),
				new AptitudesEntry( Aptitude.Musique,       "Musique",          10, SkillName.Musicianship),
				new AptitudesEntry( Aptitude.Hydromancie,   "Hydromancie",      10, SkillName.Healing),
				new AptitudesEntry( Aptitude.Pyromancie,    "Pyromancie",       10, SkillName.Magery),
				new AptitudesEntry( Aptitude.Geomancie,     "Géomancie",        10, SkillName.MagicResist),
				new AptitudesEntry( Aptitude.Aeromancie,    "Aéromancie",       10, SkillName.SpiritSpeak),
				new AptitudesEntry( Aptitude.Necromancie,   "Nécromancie",      10, SkillName.Necromancy),
			};
        #endregion

        public Aptitudes(CustomPlayerMobile owner) : base(owner)
        {
        }

        public Aptitudes(CustomPlayerMobile owner, GenericReader reader) : base(owner, reader)
        {
        }

        public static int GetValue(CustomPlayerMobile m, Aptitude aptitude)
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
				Aptitude aptitude = entry.Aptitude;
				added = GetValue(from, aptitude) * 10;
			}

			return pa - added;
        }

        public static int GetRequiredPA(CustomPlayerMobile from, Aptitude aptitude)
        {
            return GetValue(from, aptitude) * 10;
        }

        public static int GetBaseValue(CustomPlayerMobile from, Aptitude aptitude)
        {
            return from.GetBaseAptitudeValue(aptitude);
        }

		public static int GetSkillRequirement(int level)
		{
			return 30 + level * 7;
		}

		public static bool IsValid(CustomPlayerMobile from, Aptitude aptitude)
		{
			int index = (int)aptitude;

			if (index >= 0 && index < m_AptitudeEntries.Length)
			{
				AptitudesEntry entry = m_AptitudeEntries[index];

				int max = entry.Max;
				int value = from.GetTotalAptitudeValue(aptitude);

				if (value > max)
					return false;

				double skill = from.Skills[entry.Skill].Base;
				int addedvalue = GetValue(from, aptitude);
				double skillRequirement = GetSkillRequirement(addedvalue);

				if (addedvalue == 0)
					return true;

				return skill > skillRequirement;
			}

			return false;
		}

		public static bool CanRaise(CustomPlayerMobile from, Aptitude aptitude)
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
                    int value = from.GetTotalAptitudeValue(aptitude);

                    if (value >= max)
                        return false;

                    double skill = from.Skills[entry.Skill].Base;
                    int requiredSkill = GetSkillRequirement(GetValue(from, aptitude));

					if (skill > requiredSkill)
						return true;
                }
            }

            return false;
        }

        public static bool CanLower(CustomPlayerMobile from, Aptitude aptitude)
        {
            int value = GetValue(from, aptitude);

            if (value > 0)
                return true;

            return false;
        }

        public int this[Aptitude aptitude]
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
            m_Values = new int[Enum.GetNames(typeof(Aptitude)).Length + 1];
        }

        public BaseAptitudes(CustomPlayerMobile owner, GenericReader reader)
        {
            m_Owner = owner;

            int version = reader.ReadInt();

            int count = reader.ReadInt();

            m_Values = new int[Enum.GetNames(typeof(Aptitude)).Length + 1];

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

        public int GetValue(Aptitude aptitude)
        {
            int index = GetIndex(aptitude);

            if (index >= 0 && index < m_Values.Length)
            {
                int value = m_Values[index];

                return value;
            }

            return 0;
        }

        public void SetValue(Aptitude aptitude, int value)
        {
            int index = GetIndex(aptitude);

            if (index >= 0 && index < m_Values.Length)
            {
                int oldvalue = m_Values[index];

                m_Values[index] = value;

                m_Owner.OnAptitudesChange(aptitude, oldvalue, value);
            }
        }

        private int GetIndex(Aptitude aptitude)
        {
            int index = (int)aptitude;

            return index;
        }

        public virtual void Reset()
        {
            for (int i = 0; i < m_Values.Length; i++)
            {
                m_Values[i] = 0;
                m_Owner.OnAptitudesChange((Aptitude)i, Owner.GetTotalAptitudeValue((Aptitude)i) + 1, Owner.GetTotalAptitudeValue((Aptitude)i));
            }

            Owner.PADispo = 30 + Owner.Niveau;

			Classes.Classes.SetBaseAndCapSkills(Owner);
		}
    }
}
