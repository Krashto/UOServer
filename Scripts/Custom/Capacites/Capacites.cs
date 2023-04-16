using System;
using System.Linq;
using Server.Custom.Capacites;
using Server.Custom.Classes;
using Server.Mobiles;

namespace Server
{
    public sealed class Capacites
    {
		private CustomPlayerMobile m_Owner;
		private int[] m_Values = new int[Enum.GetValues(typeof(Capacite)).Length];

		public int Bank { get { return BankMax - m_Values.Sum(); } }
		public int BankMax { get { return m_Owner.Experience.Niveau / 10; } }

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

		[CommandProperty(AccessLevel.GameMaster)]
		public int Compagnon
		{
			get { return this[Capacite.Compagnon]; }
			set { this[Capacite.Compagnon] = value; }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int Concentration
		{
			get { return this[Capacite.Concentration]; }
			set { this[Capacite.Concentration] = value; }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int Precision
		{
			get { return this[Capacite.Precision]; }
			set { this[Capacite.Precision] = value; }
		}
		#endregion

		public Capacites(CustomPlayerMobile owner)
        {
			m_Owner = owner;
		}

		public Capacites(CustomPlayerMobile owner, GenericReader reader)
		{
			m_Owner = owner;

			int version = reader.ReadInt();

			m_Values = new int[Enum.GetValues(typeof(Capacite)).Length];

			var count = reader.ReadInt();

			for (int i = 0; i < count; ++i)
			{
				var value = reader.ReadInt();
				if (i < m_Values.Length)
					m_Values[i] = value;
			}
		}

        public static int GetValue(CustomPlayerMobile pm, Capacite capacite)
        {
			return pm.Capacites.GetValue(capacite);
		}

		public int GetValue(Capacite capacite)
		{
			return 2 + m_Values[(int)capacite] + Classes.GetCapaciteValue(capacite, m_Owner.Classe);
		}

		public int this[Capacite Capacite]
        {
            get { return GetValue(Capacite); }
            set { SetValue(Capacite, value); }
        }

		public void Serialize(GenericWriter writer)
		{
			writer.Write((int)0); // version;

			writer.Write((int)m_Values.Length);

			for (int i = 0; i < m_Values.Length; ++i)
				writer.Write((int)m_Values[i]);
		}

		public void SetValue(Capacite capacite, int value)
		{
			int index = GetIndex(capacite);

			if (index >= 0 && index < m_Values.Length)
			{
				int oldvalue = m_Values[index];

				m_Values[index] = value;

				if (m_Values[index] < 0)
					m_Values[index] = 0;
				else if (m_Values[index] > 3)
					m_Values[index] = 3;
			}
		}

		private int GetIndex(Capacite capacite)
		{
			return (int)capacite;
		}

		public bool CanDecreaseStat(Capacite attr)
		{
			return m_Values[(int)attr] > 0;
		}

		public bool CanIncreaseStat(Capacite attr)
		{
			if (Bank <= 0)
				return false;

			return m_Values[(int)attr] < 3;
		}

		public void Increase(Capacite attr)
		{
			if (CanIncreaseStat(attr))
				m_Values[(int)attr]++;
		}

		public void Decrease(Capacite attr)
		{
			if (CanDecreaseStat(attr))
				m_Values[(int)attr]--;
		}

		public void Reset()
		{
			for (int i = 0; i < m_Values.Length; i++)
				m_Values[i] = 0;
		}
	}
}