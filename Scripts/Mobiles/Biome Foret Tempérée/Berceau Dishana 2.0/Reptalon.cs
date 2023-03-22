using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'un Reptalon")]
    public class Reptalon : BaseMount
    {
        [Constructable]
        public Reptalon()
            : base("Un Reptalon", 0x114, 0x3E90, AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.35)
        {
            BaseSoundID = 0x16A;

			SetStr(229, 408);
			SetDex(151, 253);
			SetInt(126, 203);

			SetHits(633, 963);

			SetDamage(40, 67);

			SetDamageType(ResistanceType.Energy, 50);
			SetDamageType(ResistanceType.Poison, 50);


			SetResistance(ResistanceType.Physical, 25, 25);
			SetResistance(ResistanceType.Fire, 25, 25);
			SetResistance(ResistanceType.Cold, 75, 75);
			SetResistance(ResistanceType.Poison, 75, 75);
			SetResistance(ResistanceType.Energy, 75, 75);

			SetSkill(SkillName.EvalInt, 50.1, 55.0);
			SetSkill(SkillName.Magery, 50.1, 55.0);
			SetSkill(SkillName.Meditation, 50.1, 55.0);


			SetSkill(SkillName.MagicResist, 35.1, 55.0);
			SetSkill(SkillName.Tactics, 50.1, 55.0);
			SetSkill(SkillName.Wrestling, 50.1, 55.0);


			Tamable = true;
            ControlSlots = 4;
            MinTameSkill = 80.0;

            SetWeaponAbility(WeaponAbility.ParalyzingBlow);
            SetSpecialAbility(SpecialAbility.DragonBreath);
        }

        public Reptalon(Serial serial)
            : base(serial)
        {
        }

        public override int TreasureMapLevel => 5;
        public override int Meat => 4;
        public override MeatType MeatType => MeatType.DinoRibs;
        public override int Hides => 10;
        public override bool CanAngerOnTame => true;
        public override bool StatLossAfterTame => true;
        public override FoodType FavoriteFood => FoodType.Meat;
        public override bool CanFly => true;
        public override void GenerateLoot()
        {
            AddLoot(LootPack.UltraRich, 3);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(1); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
