using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("un corps d'Aigle")]
    public class Eagle : BaseCreature
    {
        [Constructable]
        public Eagle()
            : base(AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = " Aigle";
            Body = 5;
            BaseSoundID = 0x2EE;

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


	//		Fame = 300;
     //       Karma = 0;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 17.1;
        }

        public Eagle(Serial serial)
            : base(serial)
        {
        }
		public override int Level => 2;
		public override Biome Biome => Biome.Colline;
		public override bool CanBeParagon => false;

		public override int Meat => 1;
        public override MeatType MeatType => MeatType.Bird;
        public override int Feathers => 36;
        public override FoodType FavoriteFood => FoodType.Meat | FoodType.Fish;
        public override bool CanFly => true;

		public override void GenerateLoot()
		{
		AddLoot(LootPack.LootItem<PlumesAigle>());
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
