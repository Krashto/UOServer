namespace Server.Mobiles
{
    [CorpseName("Le Corps d'un Ours Noir")]
    public class BlackBear : BaseMount
	{

		[Constructable]
		public BlackBear() : this("Ours Noir")
		{
		}

		[Constructable]
		public BlackBear(string name) : base(name, 211, 211, AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
            Name = "Un Ours Noir";
            Body = 211;
            BaseSoundID = 0xA3;

			SetStr(124, 192);
			SetDex(83, 137);
			SetInt(69, 109);

			SetHits(118, 179);

			SetDamage(17, 28);

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

			//Fame = 450;
            //Karma = 0;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 35.1;
        }

        public BlackBear(Serial serial)
            : base(serial)
        {
        }
		public override int Level => 4;
		public override Biome Biome => Biome.Foret;
		public override bool CanBeParagon => false;
		public override int Meat => 5;
        public override int Hides => 8;
        public override FoodType FavoriteFood => FoodType.Fish | FoodType.Meat | FoodType.FruitsAndVegies;
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
