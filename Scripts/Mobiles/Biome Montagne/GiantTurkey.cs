using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'une Dinde")]
    public class GiantTurkey : BaseCreature
    {
        [Constructable]
        public GiantTurkey()
            : base(AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = " Dinde G�ante";
            Body = 1026;
            BaseSoundID = 0x66A;

            SetStr(1200, 1400);
            SetDex(170, 260);
            SetInt(430, 560);

            SetHits(25000);
            SetMana(1000);

            SetDamage(20, 30);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 55, 70);
            SetResistance(ResistanceType.Fire, 70, 90);
            SetResistance(ResistanceType.Cold, 35, 45);
            SetResistance(ResistanceType.Poison, 45, 55);
            SetResistance(ResistanceType.Energy, 45, 55);

            SetSkill(SkillName.MagicResist, 85.0, 100.0);
            SetSkill(SkillName.Tactics, 100.0, 110.0);
            SetSkill(SkillName.Wrestling, 100.0, 120.0);
            SetSkill(SkillName.Anatomy, 75.0, 80.0);

            SetWeaponAbility(WeaponAbility.ParalyzingBlow);
            SetWeaponAbility(WeaponAbility.BleedAttack);
            SetAreaEffect(AreaEffect.EssenceOfDisease);
            SetSpecialAbility(SpecialAbility.HowlOfCacophony);
            SetWeaponAbility(WeaponAbility.Dismount);
        }
		public override int Level => 4;
		public override Biome Biome => Biome.Montagne;
		public override int Meat => 5;
        public override MeatType MeatType => MeatType.Bird;
        public override FoodType FavoriteFood => FoodType.GrainsAndHay;
        public override int Feathers => 35;

        public override int GetIdleSound()
        {
            return 0x66A;
        }

        public override int GetAngerSound()
        {
            return 0x66A;
        }

        public override int GetHurtSound()
        {
            return 0x66B;
        }

        public override int GetDeathSound()
        {
            return 0x66B;
        }

		public override void GenerateLoot()
		{
			AddLoot(LootPack.LootItem<RawTurkey>(), Utility.RandomMinMax(2, 4));
			AddLoot(LootPack.LootItem<RawTurkeyLeg>(), Utility.RandomMinMax(2, 4));
			AddLoot(LootPack.LootItem<TurkeyHock>(), Utility.RandomMinMax(2, 4));

		}

		public GiantTurkey(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
