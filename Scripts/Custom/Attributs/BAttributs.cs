using System;
using Server;
using Server.Mobiles;

namespace Server
{
    public sealed class BAttributs : BaseAttributs
    {
        public BAttributs(CustomPlayerMobile owner) : base(owner)
        {
        }

        public BAttributs(CustomPlayerMobile owner, GenericReader reader) : base(owner, reader)
        {
        }

        public static int GetValue(CustomPlayerMobile m, Attribut attribut)
        {
            BAttributs attr = m.BaseAttributs;
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
}