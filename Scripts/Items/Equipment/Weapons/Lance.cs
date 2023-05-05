using Server.Engines.Craft;

namespace Server.Items
{
    [Alterable(typeof(DefBlacksmithy), typeof(GargishLance))]
    [Flipable(0x26C0, 0x26CA)]
    public class Lance : BaseSpear
    {
        [Constructable]
        public Lance()
            : base(0x26C0)
        {
            Weight = 12.0;
			Layer = Layer.TwoHanded;
        }

        public Lance(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility => WeaponAbility.Dismount;
        public override WeaponAbility SecondaryAbility => WeaponAbility.ConcussionBlow;
        public override int StrengthReq => 0;
        public override int MinDamage => 18;
        public override int MaxDamage => 22;
        public override float Speed => 4.25f;

		public override int DefHitSound => 0x23C;
        public override int DefMissSound => 0x238;
        public override int InitMinHits => 31;
        public override int InitMaxHits => 110;
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