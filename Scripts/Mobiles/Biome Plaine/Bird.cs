namespace Server.Mobiles
{
    [CorpseName("Le corps d'un Oiseau")]
    public class Bird : BaseCreature
    {
        [Constructable]
        public Bird()
            : base(AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            if (Utility.RandomBool())
            {
                Hue = 0x901;

                switch (Utility.Random(3))
                {
                    case 0:
                        Name = " Corbeau";
                        break;
                    case 2:
                        Name = " Corneille";
                        break;
                    case 1:
                        Name = " Pie";
                        break;
                }
            }
            else
            {
                Hue = Utility.RandomBirdHue();
                Name = NameList.RandomName("Bird");
            }

            Body = 6;
            BaseSoundID = 0x1B;

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

			//    Fame = 150;
			//    Karma = 0;

			Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 0;
        }

        public Bird(Serial serial)
            : base(serial)
        {
        }
		public override int Level => 1;
		public override Biome Biome => Biome.Plaine;
		public override bool CanBeParagon => false;
		public override MeatType MeatType => MeatType.Bird;
        public override int Meat => 1;
        public override int Feathers => 25;
        public override FoodType FavoriteFood => FoodType.FruitsAndVegies | FoodType.GrainsAndHay;
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

    [CorpseName("a bird corpse")]
    public class TropicalBird : BaseCreature
    {
        [Constructable]
        public TropicalBird()
            : base(AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Hue = Utility.RandomBirdHue();
            Name = "a tropical bird";

            Body = 6;
            BaseSoundID = 0xBF;

            SetStr(10);
            SetDex(25, 35);
            SetInt(10);

            SetDamage(0);

            SetDamageType(ResistanceType.Physical, 100);

            SetSkill(SkillName.Wrestling, 4.2, 6.4);
            SetSkill(SkillName.Tactics, 4.0, 6.0);
            SetSkill(SkillName.MagicResist, 4.0, 5.0);

            Fame = 150;
            Karma = 0;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = -6.9;
        }

        public TropicalBird(Serial serial)
            : base(serial)
        {
        }

        public override MeatType MeatType => MeatType.Bird;
        public override int Meat => 1;
        public override int Feathers => 15;
        public override FoodType FavoriteFood => FoodType.FruitsAndVegies | FoodType.GrainsAndHay;
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
