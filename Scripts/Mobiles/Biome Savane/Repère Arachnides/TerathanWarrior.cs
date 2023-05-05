namespace Server.Mobiles
{
    [CorpseName("le corps d'une therathan")]
    public class TerathanWarrior : BaseCreature
    {
        [Constructable]
        public TerathanWarrior()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = " Guerriere Therathan";
            Body = 70;
            BaseSoundID = 589;

            SetStr(166, 215);
            SetDex(96, 145);
            SetInt(41, 65);

            SetHits(100, 129);
            SetMana(0);

            SetDamage(7, 17);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 30, 35);
            SetResistance(ResistanceType.Fire, 20, 30);
            SetResistance(ResistanceType.Cold, 25, 35);
            SetResistance(ResistanceType.Poison, 30, 40);
            SetResistance(ResistanceType.Energy, 25, 35);

            SetSkill(SkillName.Poisoning, 60.1, 80.0);
            SetSkill(SkillName.MagicResist, 60.1, 75.0);
            SetSkill(SkillName.Tactics, 80.1, 100.0);
            SetSkill(SkillName.Wrestling, 80.1, 90.0);

            Fame = 4000;
            Karma = -4000;
        }

        public TerathanWarrior(Serial serial)
            : base(serial)
        {
        }
		public override int Level => 5;
		public override Biome Biome => Biome.Savane;
		//public override int TreasureMapLevel => 1;
        public override int Meat => 4;
		public override int Hides => 5;
		public override HideType HideType => HideType.Arachnide;


		public override int Bones => 5;
		public override BoneType BoneType => BoneType.Arachnide;


		public override TribeType Tribe => TribeType.Terathan;

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Average);
      ;
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
