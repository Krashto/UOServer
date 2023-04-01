using System;
using Server.Mobiles;

namespace Server
{
    public sealed class Attributs
    {
		private CustomPlayerMobile m_Owner;
		public int[] m_Values = new int[Enum.GetValues(typeof(Attribut)).Length];

		#region Props
		[CommandProperty(AccessLevel.GameMaster)]
		public int Constitution
		{
			get { return this[Attribut.Constitution]; }
			set { this[Attribut.Constitution] = value; }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int Sagesse
		{
			get { return this[Attribut.Sagesse]; }
			set { this[Attribut.Sagesse] = value; }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int Endurance
		{
			get { return this[Attribut.Endurance]; }
			set { this[Attribut.Endurance] = value; }
		}
		#endregion

		public Attributs(CustomPlayerMobile owner)
        {
			m_Owner = owner;
		}

		public Attributs(CustomPlayerMobile owner, GenericReader reader)
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

		public int GetValue(Attribut attribut)
		{
			int index = GetIndex(attribut);

			if (index >= 0 && index < m_Values.Length)
			{
				int value = m_Values[index];
				return value;
			}

			return 0;
		}

		public void SetValue(Attribut attribut, int value)
		{
			int index = GetIndex(attribut);

			if (index >= 0 && index < m_Values.Length)
			{
				int oldvalue = m_Values[index];
				m_Values[index] = value;
				m_Owner.OnAttributsChange(attribut, oldvalue, value);
			}
		}

		private int GetIndex(Attribut attribut)
		{
			int index = (int)attribut;

			return index;
		}


		public bool CanDecreaseStat(Attribut attr)
		{
			return m_Owner.Attributs[attr] > 25;
		}

		public bool CanIncreaseStat(Attribut attr)
		{
			if (m_Owner.RawDex + m_Owner.RawStr + m_Owner.RawInt + m_Owner.Attributs[Attribut.Constitution] + m_Owner.Attributs[Attribut.Sagesse] + m_Owner.Attributs[Attribut.Endurance] >= 525)
				return false;

			return m_Owner.Attributs[attr] < 125;
		}

		public void IncreaseStat(Attribut attr)
		{
			if (CanIncreaseStat(attr))
				m_Owner.Attributs[attr]++;
		}

		public void DecreaseStat(Attribut attr)
		{
			if (CanDecreaseStat(attr))
				m_Owner.Attributs[attr]--;
		}

		public void Reset()
		{
			for (int i = 0; i < m_Values.Length; i++)
				m_Values[i] = 0;

			m_Owner.PUDispo = m_Owner.Experience.Niveau * 3;
		}

		public int this[Attribut attribut]
        {
            get { return GetValue(attribut); }
            set { SetValue(attribut, value); }
        }
    }
}