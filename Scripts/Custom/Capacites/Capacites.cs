using System;
using System.Linq;
using Server.Custom.Capacites;
using Server.Custom.Classes;
using Server.Mobiles;

namespace Server
{
    [PropertyObject]
    public sealed class Capacites
    {
		public CustomPlayerMobile Owner { get { return m_Owner; } }
		private CustomPlayerMobile m_Owner;
		private int[] m_Values = new int[Enum.GetValues(typeof(Capacite)).Length];

		public int Bank { get { return BankMax - m_Values.Sum(); } }
		public int BankMax { get { return m_Owner.Experience.Niveau / 5; } }

		#region Props
		[CommandProperty(AccessLevel.GameMaster)]
		public int BaseArmure
		{
			get { return GetValue(Capacite.Armure); }
			set { this[Capacite.Armure] = value; m_Owner.UpdateResistances(); }
		}
		[CommandProperty(AccessLevel.GameMaster)]
		public int Armure
		{
			get { return GetRealValue(Capacite.Armure); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int BaseArmesMelee
		{
			get { return GetValue(Capacite.ArmesMelee); }
			set { this[Capacite.ArmesMelee] = value; }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int ArmesMelee
		{
			get { return GetRealValue(Capacite.ArmesMelee); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int BaseArmesDistance
		{
			get { return GetValue(Capacite.ArmesDistance); }
			set { this[Capacite.ArmesDistance] = value; }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int ArmesDistance
		{
			get { return GetRealValue(Capacite.ArmesDistance); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int BaseMagie
		{
			get { return GetValue(Capacite.Magie); }
			set { this[Capacite.Magie] = value; }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int Magie
		{
			get { return GetRealValue(Capacite.Magie); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int BaseBouclier
		{
			get { return GetValue(Capacite.Bouclier); }
			set { this[Capacite.Bouclier] = value; }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int Bouclier
		{
			get { return GetRealValue(Capacite.Bouclier); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int BaseEquitation
		{
			get { return GetValue(Capacite.Equitation); }
			set { this[Capacite.Equitation] = value; }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int Equitation
		{
			get { return GetRealValue(Capacite.Equitation); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int BaseExpertise
		{
			get { return GetValue(Capacite.Expertise); }
			set { this[Capacite.Expertise] = value; }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int Expertise
		{
			get { return GetRealValue(Capacite.Expertise); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int BaseCompagnon
		{
			get { return GetValue(Capacite.Compagnon); }
			set { this[Capacite.Compagnon] = value; }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int Compagnon
		{
			get { return GetRealValue(Capacite.Compagnon); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int BaseConcentration
		{
			get { return GetValue(Capacite.Concentration); }
			set { this[Capacite.Concentration] = value; }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int Concentration
		{
			get { return GetRealValue(Capacite.Concentration); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int BasePrecision
		{
			get { return GetValue(Capacite.Precision); }
			set { this[Capacite.Precision] = value; }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int Precision
		{
			get { return GetRealValue(Capacite.Precision); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int BasePerfection
		{
			get { return GetValue(Capacite.Perfection); }
			set { this[Capacite.Perfection] = value; }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int Perfection
		{
			get { return GetRealValue(Capacite.Perfection); }
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
		public void Serialize(GenericWriter writer)
		{
			writer.Write((int)0); // version;

			writer.Write((int)m_Values.Length);

			for (int i = 0; i < m_Values.Length; ++i)
				writer.Write((int)m_Values[i]);
		}

		public int GetRealValue(Capacite capacite)
		{
			return m_Values[(int)capacite] + Classes.GetCapaciteValue(capacite, m_Owner.Classe);
		}

		private int GetValue(Capacite capacite)
		{
			return m_Values[(int)capacite];
		}

		public int this[Capacite Capacite]
        {
            get { return GetRealValue(Capacite); }
            set { SetValue(Capacite, value); }
        }

		public void SetValue(Capacite capacite, int value)
		{
			int index = GetIndex(capacite);

			if (m_Values[index] == value)
				return;

			if (index >= 0 && index < m_Values.Length)
			{
				m_Values[index] = value;
				Validate();
			}
		}

		public void Validate()
		{
			if (Owner == null)
				return;

			foreach (Capacite capacite in Enum.GetValues(typeof(Capacite)))
			{
				var value = GetRealValue(capacite);

				if (m_Values[(int)capacite] < 0)
					m_Values[(int)capacite] = 0;
				if (value > 5)
					m_Values[(int)capacite] = Math.Max(0, 5 - Classes.GetCapaciteValue(capacite, m_Owner.Classe));
			}
		}

		private int GetIndex(Capacite capacite)
		{
			return (int)capacite;
		}

		public bool CanLower(Capacite attr)
		{
			return GetValue(attr) > 0;
		}

		public bool CanRaise(Capacite attr)
		{
			if (Bank <= 0)
				return false;

			return GetRealValue(attr) < 5;
		}

		public void Raise(Capacite attr)
		{
			if (CanRaise(attr))
				m_Values[(int)attr]++;
		}

		public void Lower(Capacite attr)
		{
			if (CanLower(attr))
				m_Values[(int)attr]--;
		}

		public void Reset()
		{
			for (int i = 0; i < m_Values.Length; i++)
				m_Values[i] = 0;
		}
	}
}