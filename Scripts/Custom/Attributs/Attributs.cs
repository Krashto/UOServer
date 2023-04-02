using System;
using System.Linq;
using Server.Mobiles;

namespace Server
{
    public sealed class Attributs
    {
		private CustomPlayerMobile m_Owner;
		public int[] Values = new int[Enum.GetValues(typeof(Attribut)).Length];

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

			Values = new int[reader.ReadInt()];

			for (int i = 0; i < Values.Length; ++i)
				Values[i] = reader.ReadInt();
		}

		public void Serialize(GenericWriter writer)
		{
			writer.Write((int)0); // version;

			writer.Write((int)Values.Length);

			for (int i = 0; i < Values.Length; ++i)
				writer.Write((int)Values[i]);
		}

		public static int GetAttributMaxPoints(CustomPlayerMobile pm)
		{
			return pm.Experience.Niveau / 15;
		}

		public static int GetAttributPoints(CustomPlayerMobile pm)
		{
			return GetAttributMaxPoints(pm) - pm.Attributs.Values.Sum();
		}

		public int GetValue(Attribut attribut)
		{
			int index = GetIndex(attribut);

			if (index >= 0 && index < Values.Length)
			{
				int value = Values[index];
				return value;
			}

			return 0;
		}

		public void SetValue(Attribut attribut, int value)
		{
			int index = GetIndex(attribut);

			if (index >= 0 && index < Values.Length)
			{
				int oldvalue = Values[index];
				Values[index] = value;
				m_Owner.OnAttributsChange(attribut, oldvalue, value);
			}
		}

		private int GetIndex(Attribut attribut)
		{
			int index = (int)attribut;

			return index;
		}


		public bool CanDecreaseStat(Attribut attr, int value)
		{
			return m_Owner.Attributs[attr] - value > 25;
		}

		public bool CanIncreaseStat(Attribut attr, int value)
		{
			if (m_Owner.RawDex + m_Owner.RawStr + m_Owner.RawInt + m_Owner.Attributs[Attribut.Constitution] + m_Owner.Attributs[Attribut.Sagesse] + m_Owner.Attributs[Attribut.Endurance] + value >= 525)
				return false;

			return m_Owner.Attributs[attr] + value < 125;
		}

		public void Increase(Attribut attr, int value)
		{
			if (CanIncreaseStat(attr, value))
				m_Owner.Attributs[attr] += value;
		}

		public void Decrease(Attribut attr, int value)
		{
			if (CanDecreaseStat(attr, value))
				m_Owner.Attributs[attr] -= value;
		}

		public void Reset()
		{
			for (int i = 0; i < Values.Length; i++)
				Values[i] = 0;

			m_Owner.PUDispo = m_Owner.Experience.Niveau * 3;
		}

		public int this[Attribut attribut]
        {
            get { return GetValue(attribut); }
            set { SetValue(attribut, value); }
        }
    }
}