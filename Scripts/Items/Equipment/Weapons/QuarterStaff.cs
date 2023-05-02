namespace Server.Items
{
    [Flipable(0xE89, 0xE8a)]
    public class QuarterStaff : BaseStaff
    {
        [Constructable]
        public QuarterStaff()
            : base(0xE89)
        {
            Weight = 4.0;
			Name = "B�ton";

		}

        public QuarterStaff(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility => WeaponAbility.DoubleStrike;
        public override WeaponAbility SecondaryAbility => WeaponAbility.ConcussionBlow;
        public override int StrengthReq => 30;
        public override int MinDamage => 8;
        public override int MaxDamage => 10;
        public override float Speed => 2.25f;

		public override int InitMinHits => 31;
        public override int InitMaxHits => 60;
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
