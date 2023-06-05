using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'une Poule")]
    public class Chicken : BaseCreature
    {
        [Constructable]
        public Chicken()
            : base(AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = " Poule";
            Body = 0xD0;
            BaseSoundID = 0x6E;

			SetStr(45, 70);
			SetDex(30, 50);
			SetInt(25, 40);

			SetHits(50, 65);

			SetDamage(6, 10);

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

		//	Fame = 150;
        //    Karma = 0;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = -0.9;
        }
		public override void GenerateLoot()
		{
			AddLoot(LootPack.LootItem<ChickenLeg>(), Utility.RandomMinMax(2, 2));
			
		}
		public Chicken(Serial serial)
            : base(serial)
        {
        }
		public override int Level => 1;
		public override Biome Biome => Biome.Plaine;
		public override bool CanBeParagon => false;

		public override int Meat => 1;
        public override MeatType MeatType => MeatType.Bird;
        public override FoodType FavoriteFood => FoodType.GrainsAndHay;
        public override bool CanFly => true;
        public override int Feathers => 25;
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
