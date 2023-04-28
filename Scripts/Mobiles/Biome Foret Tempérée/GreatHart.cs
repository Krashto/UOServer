using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'un Cerf")]
    public class GreatHart : BaseCreature
    {
        [Constructable]
        public GreatHart()
            : base(AIType.AI_Melee, FightMode.Weakest, 10, 1, 0.2, 0.4)
        {
            Name = " Cerf";
            Body = 0xEA;

			SetStr(89, 137);
			SetDex(59, 98);
			SetInt(59, 79);

			SetHits(84, 128);

			SetDamage(12, 20);

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


			//     Fame = 300;
			//     Karma = 0;

			Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 59.1;
        }

        public GreatHart(Serial serial)
            : base(serial)
        {
        }
		public override int Level => 3;
		public override Biome Biome => Biome.Foret;
		public override int Meat => 5;
        public override int Hides => 8;
        public override FoodType FavoriteFood => FoodType.FruitsAndVegies | FoodType.GrainsAndHay;
        public override int GetAttackSound()
        {
            return 0x82;
        }

        public override int GetHurtSound()
        {
            return 0x83;
        }

        public override int GetDeathSound()
        {
            return 0x84;
        }
		public override void GenerateLoot()
		{
			AddLoot(LootPack.LootItem<RawGroundVenison>(), Utility.RandomMinMax(1, 3));
			AddLoot(LootPack.LootItem<RawVenisonRoast>(), Utility.RandomMinMax(1, 3));
			AddLoot(LootPack.LootItem<RawVenisonSlice>(), Utility.RandomMinMax(1, 3));
			AddLoot(LootPack.LootItem<RawVenisonSteak>(), Utility.RandomMinMax(1, 3));

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
