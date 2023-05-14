using System;

namespace Server.Items
{
    [Flipable(0x13B2, 0x13B1)]
    public class Bow : BaseBow
    {
        [Constructable]
        public Bow()
            : base(0x13B2)
        {
            Weight = 6.0;
            Layer = Layer.TwoHanded;
			Name = "Arc simple";

		}

        public Bow(Serial serial)
            : base(serial)
        {
        }

        public override int EffectID => 0xF42;
        public override Type AmmoType => typeof(Arrow);
        public override Item Ammo => new Arrow();
        public override WeaponAbility PrimaryAbility => WeaponAbility.ParalyzingBlow;
        public override WeaponAbility SecondaryAbility => WeaponAbility.MortalStrike;
        public override int StrengthReq => 30;
        public override int MinDamage => 16;
        public override int MaxDamage => 20;
        public override float Speed => 4.00f;

        public override int InitMinHits => 31;
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
