using System;
using Server.Mobiles;

namespace Server.Custom.Aptitudes
{
    [PropertyObject]
    public sealed class Aptitudes
    {
		public CustomPlayerMobile Owner { get { return m_Owner; } }

		private CustomPlayerMobile m_Owner;
		private int[] m_Values = new int[Enum.GetValues(typeof(Aptitude)).Length];

		[CommandProperty(AccessLevel.GameMaster)]
		public int BaseChimie
		{
			get { return GetValue(Aptitude.Chimie); }
			set { this[Aptitude.Chimie] = value; }
		}
		[CommandProperty(AccessLevel.GameMaster)]
		public int Chimie
		{
			get { return GetRealValue(Aptitude.Chimie); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int BaseCouture
		{
			get { return GetValue(Aptitude.Couture); }
			set { this[Aptitude.Couture] = value; }
		}
		[CommandProperty(AccessLevel.GameMaster)]
		public int Couture
		{
			get { return GetRealValue(Aptitude.Couture); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int BaseIngenierie
		{
			get { return GetValue(Aptitude.Ingenierie); }
			set { this[Aptitude.Ingenierie] = value; }
		}
		[CommandProperty(AccessLevel.GameMaster)]
		public int Ingenierie
		{
			get { return GetRealValue(Aptitude.Ingenierie); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int BaseMetallurgie
		{
			get { return GetValue(Aptitude.Metallurgie); }
			set { this[Aptitude.Metallurgie] = value; }
		}
		[CommandProperty(AccessLevel.GameMaster)]
		public int Metallurgie
		{
			get { return GetRealValue(Aptitude.Metallurgie); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int BaseTranscription
		{
			get { return GetValue(Aptitude.Transcription); }
			set { this[Aptitude.Transcription] = value; }
		}
		[CommandProperty(AccessLevel.GameMaster)]
		public int Transcription
		{
			get { return GetRealValue(Aptitude.Transcription); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int BaseMartial
		{
			get { return GetValue(Aptitude.Martial); }
			set { this[Aptitude.Martial] = value; }
		}
		[CommandProperty(AccessLevel.GameMaster)]
		public int Martial
		{
			get { return GetRealValue(Aptitude.Martial); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int BaseChasseur
		{
			get { return GetValue(Aptitude.Chasseur); }
			set { this[Aptitude.Chasseur] = value; }
		}
		[CommandProperty(AccessLevel.GameMaster)]
		public int Chasseur
		{
			get { return GetRealValue(Aptitude.Chasseur); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int BaseRoublardise
		{
			get { return GetValue(Aptitude.Roublardise); }
			set { this[Aptitude.Roublardise] = value; }
		}
		[CommandProperty(AccessLevel.GameMaster)]
		public int Roublardise
		{
			get { return GetRealValue(Aptitude.Roublardise); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int BasePolymorphie
		{
			get { return GetValue(Aptitude.Polymorphie); }
			set { this[Aptitude.Polymorphie] = value; }
		}
		[CommandProperty(AccessLevel.GameMaster)]
		public int Polymorphie
		{
			get { return GetRealValue(Aptitude.Polymorphie); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int BaseTotemique
		{
			get { return GetValue(Aptitude.Totemique); }
			set { this[Aptitude.Totemique] = value; }
		}
		[CommandProperty(AccessLevel.GameMaster)]
		public int Totemique
		{
			get { return GetRealValue(Aptitude.Totemique); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int BaseMusique
		{
			get { return GetValue(Aptitude.Musique); }
			set { this[Aptitude.Musique] = value; }
		}
		[CommandProperty(AccessLevel.GameMaster)]
		public int Musique
		{
			get { return GetRealValue(Aptitude.Musique); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int BaseHydromancie
		{
			get { return GetValue(Aptitude.Hydromancie); }
			set { this[Aptitude.Hydromancie] = value; }
		}
		[CommandProperty(AccessLevel.GameMaster)]
		public int Hydromancie
		{
			get { return GetRealValue(Aptitude.Hydromancie); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int BasePyromancie
		{
			get { return GetValue(Aptitude.Pyromancie); }
			set { this[Aptitude.Pyromancie] = value; }
		}
		[CommandProperty(AccessLevel.GameMaster)]
		public int Pyromancie
		{
			get { return GetRealValue(Aptitude.Pyromancie); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int BaseGeomancie
		{
			get { return GetValue(Aptitude.Geomancie); }
			set { this[Aptitude.Geomancie] = value; }
		}
		[CommandProperty(AccessLevel.GameMaster)]
		public int Geomancie
		{
			get { return GetRealValue(Aptitude.Geomancie); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int BaseAeromancie
		{
			get { return GetValue(Aptitude.Aeromancie); }
			set { this[Aptitude.Aeromancie] = value; }
		}
		[CommandProperty(AccessLevel.GameMaster)]
		public int Aeromancie
		{
			get { return GetRealValue(Aptitude.Aeromancie); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int BaseNecromancie
		{
			get { return GetValue(Aptitude.Necromancie); }
			set { this[Aptitude.Necromancie] = value; }
		}
		[CommandProperty(AccessLevel.GameMaster)]
		public int Necromancie
		{
			get { return GetRealValue(Aptitude.Necromancie); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int BaseDefenseur
		{
			get { return GetValue(Aptitude.Defenseur); }
			set { this[Aptitude.Defenseur] = value; }
		}
		[CommandProperty(AccessLevel.GameMaster)]
		public int Defenseur
		{
			get { return GetRealValue(Aptitude.Defenseur); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int BaseGuerison
		{
			get { return GetValue(Aptitude.Guerison); }
			set { this[Aptitude.Guerison] = value; }
		}
		[CommandProperty(AccessLevel.GameMaster)]
		public int Guerison
		{
			get { return GetRealValue(Aptitude.Guerison); }
		}

		#region AptitudesEntry
		public class AptitudesEntry
        {
            public Aptitude Aptitude { get; private set; }
            public string Name { get; private set; }
			public int Max { get; private set; }
			public SkillName SkillName { get; private set; }

			public AptitudesEntry(Aptitude aptitude, string name, int max, SkillName skillName)
            {
                Aptitude = aptitude;
                Name = name;
                Max = max;
                SkillName = skillName;
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
			new AptitudesEntry( Aptitude.Hydromancie,   "Hydromancie",      10, SkillName.Meditation),
			new AptitudesEntry( Aptitude.Pyromancie,    "Pyromancie",       10, SkillName.Magery),
			new AptitudesEntry( Aptitude.Geomancie,     "Géomancie",        10, SkillName.MagicResist),
			new AptitudesEntry( Aptitude.Aeromancie,    "Aéromancie",       10, SkillName.SpiritSpeak),
			new AptitudesEntry( Aptitude.Necromancie,   "Nécromancie",      10, SkillName.Necromancy),
			new AptitudesEntry( Aptitude.Defenseur,     "Défenseur",		10, SkillName.Parry),
			new AptitudesEntry( Aptitude.Guerison,      "Guérison",			10, SkillName.Healing),
		};
        #endregion

        public Aptitudes(CustomPlayerMobile owner)
        {
			m_Owner = owner;
		}
		
		public Aptitudes(CustomPlayerMobile owner, GenericReader reader)
		{
			m_Owner = owner;

			int version = reader.ReadInt();

			m_Values = new int[Enum.GetValues(typeof(Aptitude)).Length];

			var count = reader.ReadInt();

			for (int i = 0; i < count; ++i)
			{
				var value = reader.ReadInt();
				if (i < m_Values.Length)
					m_Values[i] = value;
			}
		}

		public void Serialize(GenericWriter writer)
		{
			writer.Write((int)0); // version;

			writer.Write((int)m_Values.Length);

			for (int i = 0; i < m_Values.Length; ++i)
				writer.Write((int)m_Values[i]);
		}

		public int GetRealValue(Aptitude aptitude)
		{
			return m_Values[(int)aptitude] + Classes.Classes.GetAptitudeValue(Owner.Classe, aptitude);
		}

		private int GetValue(Aptitude aptitude)
		{
			return m_Values[(int)aptitude];
		}

		public static int GetMaxPA(int level)
		{
			return 50 + level * 4;
		}

		public static int GetRemainingPA(CustomPlayerMobile from, int level)
        {
            int pa = GetMaxPA(level);
            int added = 0;

			for (int i = 0; i < m_AptitudeEntries.Length; i++)
			{
				var entry = m_AptitudeEntries[i];
				var aptitude = entry.Aptitude;
				added += from.Aptitudes.GetValue(aptitude) * 10;
			}

			return pa - added;
        }

        public static int GetRequiredPA()
        {
            return 10;
        }

		public static double GetSkillRequirement(int level, Aptitude aptitude)
		{
			AptitudesEntry entry = m_AptitudeEntries[(int)aptitude];

			if (level == 0)
				return 50;

			return 50 + (level - 1) * 5;
		}

		public static SkillName GetSkillName(Aptitude aptitude)
		{
			AptitudesEntry entry = m_AptitudeEntries[(int)aptitude];

			return entry.SkillName;
		}

		public static Aptitude GetAptitudeNameBySkillName(SkillName skillName)
		{
			foreach(var entry in m_AptitudeEntries)
			{
				if (entry.SkillName == skillName)
					return entry.Aptitude;
			}

			return (Aptitude)(-1);
		}

		public void Validate()
		{
			if (Owner == null)
				return;

			foreach (Aptitude aptitude in Enum.GetValues(typeof(Aptitude)))
			{
				AptitudesEntry entry = m_AptitudeEntries[(int)aptitude];

				var value = GetRealValue(aptitude);

				if (m_Values[(int)aptitude] < 0)
					value = m_Values[(int)aptitude] = 0;
				if (value > entry.Max)
					value = m_Values[(int)aptitude] = Math.Max(0, entry.Max - Classes.Classes.GetAptitudeValue(m_Owner.Classe, aptitude));

				double skill = Owner.Skills[entry.SkillName].Value;

				double skillRequirement = GetSkillRequirement(value, entry.Aptitude);

				while (skillRequirement > skill && value > 0)
				{
					m_Values[(int)aptitude]--;
					value = GetRealValue(aptitude);
					skillRequirement = GetSkillRequirement(value, entry.Aptitude);
				}
			}
		}

		public bool CanRaise(Aptitude aptitude)
        {
            int requiredPA = GetRequiredPA();
            int dispoPA = GetRemainingPA(Owner, Owner.Experience.Niveau);

            if (dispoPA >= requiredPA)
            {
                int index = (int)aptitude;

                if (index >= 0 && index < m_AptitudeEntries.Length)
                {
					AptitudesEntry entry = m_AptitudeEntries[index];

					int max = entry.Max;
					int level = GetRealValue(aptitude);

					if (level >= max)
						return false;

					var skill = Owner.Skills[entry.SkillName].Base;

					var skillRequirement = GetSkillRequirement(level + 1, entry.Aptitude);

					return skill >= skillRequirement;
				}
            }

            return false;
        }

        public bool CanLower(Aptitude aptitude)
        {
            return GetValue(aptitude) > 0;
        }

		public void Raise(Aptitude aptitude)
		{
			if (CanRaise(aptitude))
				m_Values[(int)aptitude]++;
		}

		public void Lower(Aptitude aptitude)
		{
			if (CanLower(aptitude))
				m_Values[(int)aptitude]--;
		}

		public int this[Aptitude aptitude]
        {
            get { return GetValue(aptitude); }
            set { SetValue(aptitude, value); }
        }
		public void SetValue(Aptitude aptitude, int value)
		{
			int index = GetIndex(aptitude);

			if (m_Values[index] == value)
				return;

			if (index >= 0 && index < m_Values.Length)
			{
				m_Values[index] = value;
				Validate();
			}
		}

		private int GetIndex(Aptitude aptitude)
		{
			return (int)aptitude;
		}

		public override string ToString()
        {
            return "...";
        }

		public void Reset()
		{
			for (int i = 0; i < m_Values.Length; i++)
				m_Values[i] = 0;

			Classes.Classes.SetBaseAndCapSkills(Owner, Owner.Experience.Niveau);
		}
	}
}
