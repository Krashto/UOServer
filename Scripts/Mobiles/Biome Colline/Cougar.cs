namespace Server.Mobiles
{
    [CorpseName("Le Corps d'un Cougar")]
    public class Cougar : BaseCreature
    {
        [Constructable]
        public Cougar()
            : base(AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = "Un Cougar";
            Body = 63;
            BaseSoundID = 0x73;

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


		//	Fame = 450;
        //    Karma = 0;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 41.1;
        }

        public Cougar(Serial serial)
            : base(serial)
        {
        }

		public override bool CanBeParagon => false;

		public override int Meat => 3;
        public override int Hides => 5;
        public override FoodType FavoriteFood => FoodType.Fish | FoodType.Meat;
        public override PackInstinct PackInstinct => PackInstinct.Feline;
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
