namespace Server.Mobiles
{
    [CorpseName("Le Corps d'un Ours Polaire")]
    public class PolarBear : BaseMount
	{
		[Constructable]
		public PolarBear() : this("Ours Polaire")
		{
		}

		[Constructable]
		public PolarBear(string name) : base(name, 213, 0xD5, AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
            Name = " Ours Polaire";
            Body = 213;
            BaseSoundID = 0xA3;

            SetStr(116, 140);
            SetDex(81, 105);
            SetInt(26, 50);

            SetHits(70, 84);
            SetMana(0);

            SetDamage(7, 12);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 25, 35);
            SetResistance(ResistanceType.Cold, 60, 80);
            SetResistance(ResistanceType.Poison, 15, 25);
            SetResistance(ResistanceType.Energy, 10, 15);

            SetSkill(SkillName.MagicResist, 45.1, 60.0);
            SetSkill(SkillName.Tactics, 60.1, 90.0);
            SetSkill(SkillName.Wrestling, 45.1, 70.0);

            Fame = 1500;
            Karma = 0;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 35.1;
        }

        public PolarBear(Serial serial)
            : base(serial)
        {
        }

		public override int Level => 5;
		public override Biome Biome => Biome.Toundra;
		public override bool CanBeParagon => false;
		public override int Meat => 2;
        public override int Hides => 8;
		public override FoodType FavoriteFood => FoodType.Fish | FoodType.FruitsAndVegies | FoodType.Meat;
        public override PackInstinct PackInstinct => PackInstinct.Bear;
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
