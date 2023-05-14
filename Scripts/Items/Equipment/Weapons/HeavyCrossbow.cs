using System;

namespace Server.Items
{
    [Flipable(0x13FD, 0x13FC)]
    public class HeavyCrossbow : BaseHeavyCrossbow
    {
        [Constructable]
        public HeavyCrossbow()
            : base(0x13FD)
        {
            Weight = 7.0;
            Layer = Layer.TwoHanded;
			Name = "Arbalète lourde";

		}

        public HeavyCrossbow(Serial serial)
            : base(serial)
        {
        }

        public override int EffectID => 0x1BFE;
        public override Type AmmoType => typeof(Bolt);
        public override Item Ammo => new Bolt();
        public override WeaponAbility PrimaryAbility => WeaponAbility.MovingShot;
        public override WeaponAbility SecondaryAbility => WeaponAbility.Dismount;
        public override int StrengthReq => 80;
        public override int MinDamage => 20;
        public override int MaxDamage => 24;
        public override float Speed => 5.00f;

        public override int InitMinHits => 31;
        public override int InitMaxHits => 100;
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
