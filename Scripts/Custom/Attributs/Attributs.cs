using Server.Mobiles;

namespace Server
{
    public sealed class Attributs : BaseAttributs
    {
        public Attributs(CustomPlayerMobile owner)
            : base(owner)
        {
        }

        public Attributs(CustomPlayerMobile owner, GenericReader reader)
            : base(owner, reader)
        {
        }

        public static int GetValue(CustomPlayerMobile m, Attribut attribut)
        {
            Attributs attr = m.Attributs;
            int value = 0;

            if (attr != null)
                value = attr[attribut];

            return value;
        }

        public int this[Attribut attribut]
        {
            get { return GetValue(attribut); }
            set { SetValue(attribut, value); }
        }

        public override string ToString()
        {
            return "...";
        }

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
    }

    [PropertyObject]
    public abstract class BaseAttributs
    {
        private CustomPlayerMobile m_Owner;
        public int[] m_Values;
        private int[] m_Base = new int[3];

        public CustomPlayerMobile Owner { get { return m_Owner; } }

        public BaseAttributs(CustomPlayerMobile owner)
        {
            m_Owner = owner;
            m_Values = m_Base;
        }

        public BaseAttributs(CustomPlayerMobile owner, GenericReader reader)
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
			switch (attr)
			{
				case Attribut.Constitution: return Owner.Attributs[Attribut.Constitution] > 25;
				case Attribut.Sagesse: return Owner.Attributs[Attribut.Sagesse] > 25;
				case Attribut.Endurance: return Owner.Attributs[Attribut.Endurance] > 25;
				default: return false;
			}
		}


		public bool CanIncreaseStat(Attribut attr)
		{
			if (Owner.RawDex + Owner.RawStr + Owner.RawInt + Owner.Attributs[Attribut.Constitution] + Owner.Attributs[Attribut.Sagesse] + Owner.Attributs[Attribut.Endurance] >= 525)
				return false;

			switch (attr)
			{
				case Attribut.Constitution: return Owner.Attributs[Attribut.Constitution] < 125;
				case Attribut.Sagesse: return Owner.Attributs[Attribut.Sagesse] < 125;
				case Attribut.Endurance: return Owner.Attributs[Attribut.Endurance] < 125;
				default: return false;
			}
		}

		public void IncreaseStat(Attribut attr)
		{
			if (CanIncreaseStat(attr))
			{
				switch (attr)
				{
					case Attribut.Constitution: Owner.Attributs[Attribut.Constitution]++; break;
					case Attribut.Sagesse: Owner.Attributs[Attribut.Sagesse]++; break;
					case Attribut.Endurance: Owner.Attributs[Attribut.Endurance]++; break;
				}
			}
		}

		public void DecreaseStat(Attribut attr)
		{
			if (CanDecreaseStat(attr))
			{
				switch (attr)
				{
					case Attribut.Constitution: Owner.Attributs[Attribut.Constitution]--; break;
					case Attribut.Sagesse: Owner.Attributs[Attribut.Sagesse]--; break;
					case Attribut.Endurance: Owner.Attributs[Attribut.Endurance]--; break;
				}
			}
		}

		public virtual void Reset()
        {
            for (int i = 0; i < m_Values.Length; i++)
            {
                m_Values[i] = 0;
            }

            Owner.PUDispo = Owner.Experience.Niveau * 3;
        }
    }
}

/*
Force 
- Permet de frapper plus fort (Arme de corps à corps et distance)
- Supporter plus de poid (Stone)

Dextérité 
- Permet de frapper plus vite
- Bonus Esquive
- Bonus Parry

Intelligence
- Bonus sur les dégats magique
- Bonus sur la durée des buffs magique
- Bonus sur l'efficacité des buff magique

Sagesse
- Augmente la Mana
- Meilleur Regen de Mana

Constitution
- Augmente HP
- Meilleur regen HP

Endurance
- Augmente la Stamina
- Meilleur regen de Stamina

*/