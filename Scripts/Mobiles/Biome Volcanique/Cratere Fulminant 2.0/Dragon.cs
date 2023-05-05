using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'un Dragon")]
    public class Dragon : BaseCreature
    {
        [Constructable]
        public Dragon()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = " Dragon";
            Body = Utility.RandomList(12, 59);
            BaseSoundID = 362;

			SetStr(348, 621);
			SetDex(230, 384);
			SetInt(191, 309);

			SetHits(887, 1348);

			SetDamage(45, 77);

			SetDamageType(ResistanceType.Physical, 50);
			SetDamageType(ResistanceType.Energy, 50);

			SetResistance(ResistanceType.Physical, 50, 60);
			SetResistance(ResistanceType.Fire, 50, 60);
			SetResistance(ResistanceType.Cold, 50, 60);
			SetResistance(ResistanceType.Poison, 50, 60);
			SetResistance(ResistanceType.Energy, 50, 60);


			SetSkill(SkillName.EvalInt, 45.1, 50.0);

			SetSkill(SkillName.Magery, 45.1, 50.0);
			SetSkill(SkillName.Meditation, 45.1, 50.0); 


			SetSkill(SkillName.MagicResist, 25.1, 50.0);
			SetSkill(SkillName.Tactics, 45.1, 50.0);
			SetSkill(SkillName.Wrestling, 45.1, 50.0);


		//	Fame = 15000;
        //    Karma = -15000;

            Tamable = true;
            ControlSlots = 3;
            MinTameSkill = 93.9;

            SetSpecialAbility(SpecialAbility.DragonBreath);
        }

        public Dragon(Serial serial)
            : base(serial)
        {
        }
		public override int Level => 14;
		public override Biome Biome => Biome.Volcan;
		public override bool ReacquireOnMovement => !Controlled;
        public override bool AutoDispel => !Controlled;
        //public override int TreasureMapLevel => 4;
        public override int Meat => 19;
        public override int DragonBlood => 8;
        public override int Hides => 10;
        public override HideType HideType => HideType.Dragonique;
		public override int Bones => 10;
		public override BoneType BoneType => BoneType.Dragonique;


		public override FoodType FavoriteFood => FoodType.Meat;
        public override bool CanAngerOnTame => true;
        public override bool CanFly => true;
        public override void GenerateLoot()
        {
            AddLoot(LootPack.FilthyRich, 2);
			AddLoot(LootPack.LootItem<Items.GemmeFeu>(), (double)10);
			//     AddLoot(LootPack.Gems, 8);
		}


		public override void GenerateLootParagon()
		{
			AddLoot(LootPack.LootItem<SangEnvouteDragon>(), Utility.RandomMinMax(2, 4));
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
