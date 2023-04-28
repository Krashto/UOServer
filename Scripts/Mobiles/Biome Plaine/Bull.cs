using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'un Boeuf")]
    public class Bull : BaseCreature
    {
        [Constructable]
        public Bull()
            : base(AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = " Boeuf";
            Body = Utility.RandomList(0xE8, 0xE9);
            BaseSoundID = 0x64;

            if (0.5 >= Utility.RandomDouble())
                Hue = 0x901;

			SetStr(63, 98);
			SetDex(42, 70);
			SetInt(35, 56);

			SetHits(70, 91);

			SetDamage(9, 14);

			SetDamageType(ResistanceType.Physical, 100);


			SetResistance(ResistanceType.Physical, 45, 55);
			SetResistance(ResistanceType.Fire, 45, 55);
			SetResistance(ResistanceType.Cold, 45, 55);
			SetResistance(ResistanceType.Poison, 45, 55);
			SetResistance(ResistanceType.Energy, 45, 55);

			SetSkill(SkillName.EvalInt, 35.1, 50.0);
			SetSkill(SkillName.Magery, 35.1, 50.0);
			SetSkill(SkillName.Meditation, 35.1, 50.0);

			SetSkill(SkillName.MagicResist, 35.1, 50.0);
			SetSkill(SkillName.Tactics, 35.1, 50.0);
			SetSkill(SkillName.Wrestling, 35.1, 50.0);

		//	Fame = 600;
        //    Karma = 0;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 71.1;
        }

        public Bull(Serial serial)
            : base(serial)
        {
        }
		public override int Level => 2;
		public override Biome Biome => Biome.Plaine;
		public override bool CanBeParagon => false;
		public override int Meat => 8;
        public override int Hides => 10;
        public override FoodType FavoriteFood => FoodType.GrainsAndHay;
        public override PackInstinct PackInstinct => PackInstinct.Bull;

		public override void GenerateLoot()
		{
			AddLoot(LootPack.LootItem<RawBeefPorterhouse>(), Utility.RandomMinMax(0, 2));
			AddLoot(LootPack.LootItem<RawBeefPrimeRib>(), Utility.RandomMinMax(0, 2));
			AddLoot(LootPack.LootItem<RawBeefRibeye>(), Utility.RandomMinMax(0, 2));
			AddLoot(LootPack.LootItem<RawBeefRibs>(), Utility.RandomMinMax(0, 2));
			AddLoot(LootPack.LootItem<RawBeefRoast>(), Utility.RandomMinMax(0, 2));
			AddLoot(LootPack.LootItem<RawBeefSirloin>(), Utility.RandomMinMax(0, 2));
			AddLoot(LootPack.LootItem<RawBeefSlice>(), Utility.RandomMinMax(0, 2));
			AddLoot(LootPack.LootItem<RawBeefTBone>(), Utility.RandomMinMax(0, 2));
			AddLoot(LootPack.LootItem<RawBeefTenderloin>(), Utility.RandomMinMax(0, 2));
			AddLoot(LootPack.LootItem<RawGroundBeef>(), Utility.RandomMinMax(0, 2));

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
