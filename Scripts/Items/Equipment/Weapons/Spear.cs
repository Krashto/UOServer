using Server.Engines.Craft;

namespace Server.Items
{
    [Alterable(typeof(DefBlacksmithy), typeof(JupeOndulee))]
    [Flipable(0xF62, 0xF63)]
    public class Spear : BaseSpear
    {
        [Constructable]
        public Spear()
            : base(0xF62)
        {
            Weight = 7.0;
			Name = "Lance de guerre";

		}

        public Spear(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility => WeaponAbility.ArmorIgnore;
        public override WeaponAbility SecondaryAbility => WeaponAbility.ParalyzingBlow;
        public override int StrengthReq => 50;
        public override int MinDamage => 9;
        public override int MaxDamage => 11;
        public override float Speed => 2.75f;

		public override int InitMinHits => 31;
        public override int InitMaxHits => 80;
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
