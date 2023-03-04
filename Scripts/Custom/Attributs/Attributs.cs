using System;
using Server;
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
        public int Intuition
        {
            get { return this[Attribut.Intuition]; }
            set { this[Attribut.Intuition] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Pouvoir
        {
            get { return this[Attribut.Pouvoir]; }
            set { this[Attribut.Pouvoir] = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Resistance
        {
            get { return this[Attribut.Resistance]; }
            set { this[Attribut.Resistance] = value; }
        }
        #endregion
    }

    [PropertyObject]
    public abstract class BaseAttributs
    {
        private CustomPlayerMobile m_Owner;
        public int[] m_Values;
        private int[] m_Base = new int[4];

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

        public virtual void Reset()
        {
            for (int i = 0; i < m_Values.Length; i++)
            {
                m_Values[i] = 0;
            }

            Owner.PUDispo = Owner.Niveau * 3;
        }
    }
}


/*

    1- Constitution :

      x Bonus sur le Maximum de Point de Vie.
      x Offre une plus grande regénération de Point de Vie.
      x Réduction de l'essouflement à la course.

    2- Intuition :

      x Réduction de la perte de matériaux lorsque la tentative de fabrication d'un objet a échoué.
      x La durabilité des outils diminue moins rapidement.
      x Réduction du temps entre chaque création d'objet.

    3- Pouvoir :

      x Réduit vos chances de vous faire assassiner.
      x Bonus sur le Maximum de Point de Mana.
      x Offre une plus grande regénération de Mana.

    4- Résistances :

      x Offre un bonus de résistance à la Magie.
      x Offre un bonus de résistance aux Coups Critiques.
      x Offre un bonus de résistance au Poison. 
*/