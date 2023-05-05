using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'un Dragonneau")]
    public class Drake : BaseCreature
    {
        [Constructable]
        public Drake()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = " Dragonneau";
            Body = Utility.RandomList(60, 61);
            BaseSoundID = 362;

			SetStr(263, 469);
			SetDex(174, 290);
			SetInt(144, 234);

			SetHits(452, 687);

			SetDamage(34, 58);

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


	//		Fame = 5500;
    //        Karma = -5500;

            Tamable = true;
            ControlSlots = 2;
            MinTameSkill = 84.3;

            SetSpecialAbility(SpecialAbility.DragonBreath);
        }

        public Drake(Serial serial)
            : base(serial)
        {
        }
		public override int Level => 12;
		public override Biome Biome => Biome.Volcan;
		public override bool ReacquireOnMovement => true;
        //public override int TreasureMapLevel => 2;
        public override int Meat => 10;
        public override int DragonBlood => 8;

		public override int Hides => 6;
		public override HideType HideType => HideType.Dragonique;


		public override int Bones => 6;
		public override BoneType BoneType => BoneType.Dragonique;



		public override void GenerateLootParagon()
		{
			AddLoot(LootPack.LootItem<SangEnvouteDrake>(), Utility.RandomMinMax(2, 4));
		}



		/*      public override int Hides => 20;
			  public override HideType HideType => HideType.Horned;
			  public override int Scales => 2;
			  public override ScaleType ScaleType => (Body == 60 ? ScaleType.Yellow : ScaleType.Red);*/
		public override FoodType FavoriteFood => FoodType.Meat | FoodType.Fish;
        public override bool CanFly => true;
        public override void GenerateLoot()
        {
            AddLoot(LootPack.Rich);
       //AddLoot(LootPack.MedScrolls, 2);
            AddLoot(LootPack.MageryRegs, 3);

			AddLoot(LootPack.LootItem<Items.GemmeFeu>(), (double)5);
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
