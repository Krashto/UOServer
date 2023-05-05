namespace Server.Mobiles
{
    [CorpseName("Le Corps d'un Gazer Ancien")]
    public class ElderGazer : BaseCreature
    {
        [Constructable]
        public ElderGazer()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = " Gazer Ancien";
            Body = 22;
            BaseSoundID = 377;

			SetDamageType(ResistanceType.Energy, 50);
			SetDamageType(ResistanceType.Poison, 50);


			SetResistance(ResistanceType.Physical, 25, 25);
			SetResistance(ResistanceType.Fire, 25, 25);
			SetResistance(ResistanceType.Cold, 75, 75);
			SetResistance(ResistanceType.Poison, 75, 75);
			SetResistance(ResistanceType.Energy, 75, 75);

			SetSkill(SkillName.EvalInt, 35.1, 50.0);
			SetSkill(SkillName.Magery, 35.1, 50.0);
			SetSkill(SkillName.Meditation, 35.1, 50.0);

			SetSkill(SkillName.MagicResist, 35.1, 50.0);
			SetSkill(SkillName.Tactics, 35.1, 50.0);
			SetSkill(SkillName.Wrestling, 35.1, 50.0);

		//	Fame = 12500;
        //    Karma = -12500;
        }

        public ElderGazer(Serial serial)
            : base(serial)
        {
        }
		public override int Level => 5;
		public override Biome Biome => Biome.Foret;

		//public override int TreasureMapLevel => 4;
        public override void GenerateLoot()
        {
            AddLoot(LootPack.FilthyRich);
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