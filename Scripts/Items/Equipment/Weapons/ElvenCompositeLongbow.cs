using System;

namespace Server.Items
{
    [Flipable(0x2D1E, 0x2D2A)]
    public class ElvenCompositeLongbow : BaseLongbow
    {
        [Constructable]
        public ElvenCompositeLongbow()
            : base(0x2D1E)
        {
            Weight = 6.0;
			Name = "Arc long composite";

		}

        public ElvenCompositeLongbow(Serial serial)
            : base(serial)
        {
        }

        public override int EffectID => 0xF42;
        public override Type AmmoType => typeof(Arrow);
        public override Item Ammo => new Arrow();
        public override WeaponAbility PrimaryAbility => WeaponAbility.ForceArrow;
        public override WeaponAbility SecondaryAbility => WeaponAbility.SerpentArrow;
        public override int StrengthReq => 45;
        public override int MinDamage => 16;
        public override int MaxDamage => 20;
        public override float Speed => 4.00f;

        public override int InitMinHits => 41;
        public override int InitMaxHits => 90;
        public override WeaponAnimation DefAnimation => WeaponAnimation.ShootBow;
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.WriteEncodedInt(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadEncodedInt();
        }
    }
}
