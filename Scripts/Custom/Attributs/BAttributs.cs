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
}