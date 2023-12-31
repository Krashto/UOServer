using System;

namespace Server.Items
{
    [Flipable(0x27A5, 0x27F0)]
    public class Yumi : BaseLongbow
    {
        [Constructable]
        public Yumi()
            : base(0x27A5)
        {
            Weight = 6.0;
            Layer = Layer.TwoHanded;
			Name = "Arc long";

		}

        public Yumi(Serial serial)
            : base(serial)
        {
        }

        public override int EffectID => 0xF42;
        public override Type AmmoType => typeof(Arrow);
        public override Item Ammo => new Arrow();
        public override WeaponAbility PrimaryAbility => WeaponAbility.ArmorPierce;
        public override WeaponAbility SecondaryAbility => WeaponAbility.DoubleShot;
        public override int StrengthReq => 35;
        public override int MinDamage => 16;
        public override int MaxDamage => 20;
        public override float Speed => 3.25f;

        public override int InitMinHits => 55;
        public override int InitMaxHits => 60;
        public override WeaponAnimation DefAnimation => WeaponAnimation.ShootBow;
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
