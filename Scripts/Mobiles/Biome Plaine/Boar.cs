using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'un Cochon")]
    public class Boar : BaseCreature
    {
        [Constructable]
        public Boar()
            : base(AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = " Cochon";
            Body = 0x122;
            BaseSoundID = 0xC4;

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

		//	Fame = 300;
        //    Karma = 0;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 29.1;
        }

        public Boar(Serial serial)
            : base(serial)
        {
        }
		public override int Level => 2;
		public override Biome Biome => Biome.Plaine;
		public override bool CanBeParagon => false;

		public override int Meat => 8;
        public override FoodType FavoriteFood => FoodType.FruitsAndVegies | FoodType.GrainsAndHay;

		public override void GenerateLoot()
		{
			AddLoot(LootPack.LootItem<PorkHock>(), Utility.RandomMinMax(0, 2));
			AddLoot(LootPack.LootItem<RawBacon>(), Utility.RandomMinMax(0, 2));
			AddLoot(LootPack.LootItem<RawBaconSlab>(), Utility.RandomMinMax(0, 2));
			AddLoot(LootPack.LootItem<RawGroundPork>(), Utility.RandomMinMax(0, 2));
			AddLoot(LootPack.LootItem<RawHam>(), Utility.RandomMinMax(0, 2));
			AddLoot(LootPack.LootItem<RawHamSlices>(), Utility.RandomMinMax(0, 2));
			AddLoot(LootPack.LootItem<RawPigHead>(), Utility.RandomMinMax(0, 2));
			AddLoot(LootPack.LootItem<RawPorkChop>(), Utility.RandomMinMax(0, 2));
			AddLoot(LootPack.LootItem<RawPorkRoast>(), Utility.RandomMinMax(0, 2));
			AddLoot(LootPack.LootItem<RawPorkSlice>(), Utility.RandomMinMax(0, 2));
			AddLoot(LootPack.LootItem<RawSpareRibs>(), Utility.RandomMinMax(0, 2));
			AddLoot(LootPack.LootItem<RawTrotters>(), Utility.RandomMinMax(0, 2));

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
