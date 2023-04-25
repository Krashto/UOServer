using System;
using Server.Items;
using Server.Mobiles;

namespace Server
{
    [PropertyObject]
    public sealed class Attributs
	{
		private CustomPlayerMobile m_Owner;
		public int[] Values = new int[Enum.GetValues(typeof(Attribut)).Length];

		public static int MaxStats = 500;
		public static int MinStat = 25;
		public static int MaxStat = 125;

		#region Props
		[CommandProperty(AccessLevel.GameMaster)]
		public int BaseConstitution
		{
			get { return GetBaseValue(Attribut.Constitution); }
			set { this[Attribut.Constitution] = value; }
		}
		[CommandProperty(AccessLevel.GameMaster)]
		public int Constitution
		{
			get { return GetRealValue(Attribut.Constitution); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int BaseSagesse
		{
			get { return GetBaseValue(Attribut.Sagesse); }
			set { this[Attribut.Sagesse] = value; }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int Sagesse
		{
			get { return GetRealValue(Attribut.Sagesse); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int BaseEndurance
		{
			get { return GetBaseValue(Attribut.Endurance); }
			set { this[Attribut.Endurance] = value; }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int Endurance
		{
			get { return GetRealValue(Attribut.Endurance); }
		}

		#endregion

		public int GetRealValue(Attribut attr)
		{
			var value = GetBaseValue(attr);

			switch(attr)
			{
				case Attribut.Constitution: value += BaseHitsMaxBuffFood.GetValue(m_Owner); break;
				case Attribut.Endurance: value += BaseStamMaxBuffFood.GetValue(m_Owner); break;
				case Attribut.Sagesse: value += BaseManaMaxBuffFood.GetValue(m_Owner); break;
			}

			return value;
		}
		public int GetBaseValue(Attribut attr)
		{
			return Values[(int)attr];
		}

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

		public void SetValue(Attribut attr, int value)
		{
			int oldvalue = GetBaseValue(attr);
			Values[(int)attr] = value;
			m_Owner.OnAttributsChange(attr, oldvalue, value);
		}

		private int GetIndex(Attribut attribut)
		{
			int index = (int)attribut;

			return index;
		}

		public bool CanDecreaseStat(Attribut attr, int value)
		{
			var baseValue = GetBaseValue(attr);
			return baseValue - value >= MinStat;
		}

		public bool CanIncreaseStat(Attribut attr, int value)
		{
			if (m_Owner.RawDex + m_Owner.RawStr + m_Owner.RawInt + m_Owner.Attributs.BaseConstitution + m_Owner.Attributs.BaseEndurance + m_Owner.Attributs.BaseSagesse + value > MaxStats)
				return false;

			return GetBaseValue(attr) + value <= MaxStat;
		}

		public void Increase(Attribut attr, int value)
		{
			if (CanIncreaseStat(attr, value))
				m_Owner.Attributs[attr] = GetBaseValue(attr) + value;
		}

		public void Decrease(Attribut attr, int value)
		{
			if (CanDecreaseStat(attr, value))
				m_Owner.Attributs[attr] = GetBaseValue(attr) - value;
		}

		public void Reset()
		{
			for (int i = 0; i < Values.Length; i++)
				Values[i] = 0;
		}

		public int this[Attribut attribut]
        {
            get { return GetRealValue(attribut); }
            set { SetValue(attribut, value); }
        }
    }
}