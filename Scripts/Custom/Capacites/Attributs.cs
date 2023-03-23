using System.Linq;
using Server.Custom.Capacites;
using Server.Custom.Classes;
using Server.Mobiles;

namespace Server
{
    public sealed class Capacites : BaseCapacites
    {
        public Capacites(CustomPlayerMobile owner)
            : base(owner)
        {
        }

        public Capacites(CustomPlayerMobile owner, GenericReader reader)
            : base(owner, reader)
        {
        }

        public static int GetValue(CustomPlayerMobile pm, Capacite Capacite)
        {
			//Capacites attr = pm.Capacites;
			//int value = 0;

			//if (attr != null)
			//    value = attr[Capacite];

			//return value;

			return 2;
        }

        public int this[Capacite Capacite]
        {
            get { return GetValue(Capacite); }
            set { SetValue(Capacite, value); }
        }

        public override string ToString()
        {
            return "...";
        }
		
		#region Props
		[CommandProperty(AccessLevel.GameMaster)]
        public int Armure
		{
            get { return this[Capacite.Armure]; }
            set { this[Capacite.Armure] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int ArmesMelee
		{
            get { return this[Capacite.ArmesMelee]; }
            set { this[Capacite.ArmesMelee] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int ArmesDistance
		{
            get { return this[Capacite.ArmesDistance]; }
            set { this[Capacite.ArmesDistance] = value; }
        }

		[CommandProperty(AccessLevel.GameMaster)]
		public int Magie
		{
			get { return this[Capacite.Magie]; }
			set { this[Capacite.Magie] = value; }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int Bouclier
		{
			get { return this[Capacite.Bouclier]; }
			set { this[Capacite.Bouclier] = value; }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int Equitation
		{
			get { return this[Capacite.Equitation]; }
			set { this[Capacite.Equitation] = value; }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int Expertise
		{
			get { return this[Capacite.Expertise]; }
			set { this[Capacite.Expertise] = value; }
		}
		#endregion
	}

    [PropertyObject]
    public abstract class BaseCapacites
    {
        private CustomPlayerMobile m_Owner;
        public int[] m_Values;
        private int[] m_Base = new int[3];

        public CustomPlayerMobile Owner { get { return m_Owner; } }

        public BaseCapacites(CustomPlayerMobile owner)
        {
            m_Owner = owner;
            m_Values = m_Base;
        }

        public BaseCapacites(CustomPlayerMobile owner, GenericReader reader)
        {
            m_Owner = owner;

            int version = reader.ReadInt();

            m_Values = new int[reader.ReadInt()];

            for (int i = 0; i < m_Values.Length; ++i)
                m_Values[i] = reader.ReadInt();
        }

        public void Serialize(GenericWriter writer)
        {
            writer.Write((int)0); // version;

            writer.Write((int)m_Values.Length);

            for (int i = 0; i < m_Values.Length; ++i)
                writer.Write((int)m_Values[i]);
        }

        public int GetValue(Capacite Capacite)
        {
            int index = GetIndex(Capacite);

            if (index >= 0 && index < m_Values.Length)
            {
                int value = m_Values[index];
                return value;
            }

            return 0;
        }

        public void SetValue(Capacite Capacite, int value)
        {
            int index = GetIndex(Capacite);

            if (index >= 0 && index < m_Values.Length)
            {
                int oldvalue = m_Values[index];

                m_Values[index] = value;

                m_Owner.OnCapacitesChange(Capacite, oldvalue, value);
            }
        }

        private int GetIndex(Capacite Capacite)
        {
            int index = (int)Capacite;

            return index;
        }

		public bool CanDecreaseStat(Capacite attr)
		{
			return m_Values[(int)attr] > 0;
		}

		public bool CanIncreaseStat(Capacite attr)
		{
			if (Owner.PUDispo <= 0)
				return false;

			return m_Values[(int)attr] < 5;
		}

		public void IncreaseStat(Capacite attr)
		{
			if (CanIncreaseStat(attr))
				m_Values[(int)attr]++;
		}

		public void DecreaseStat(Capacite attr)
		{
			if (CanDecreaseStat(attr))
				m_Values[(int)attr]--;
		}

		public virtual void Reset()
        {
            for (int i = 0; i < m_Values.Length; i++)
            {
                m_Values[i] = 0;
            }

			var info = Classes.GetInfos(Owner.Classe);
            Owner.PUDispo = info.Level;
        }
    }
}