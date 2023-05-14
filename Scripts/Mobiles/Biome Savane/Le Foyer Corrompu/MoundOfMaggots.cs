namespace Server.Mobiles
{
    [CorpseName("a maggoty corpse")] // TODO: Corpse name?
    public class MoundOfMaggots : BaseCreature
    {
        [Constructable]
        public MoundOfMaggots()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "a mound of maggots";
            Body = 319;
            BaseSoundID = 898;

            SetStr(61, 70);
            SetDex(61, 70);
            SetInt(10);

            SetMana(0);

            SetDamage(3, 9);

            SetDamageType(ResistanceType.Physical, 50);
            SetDamageType(ResistanceType.Poison, 50);

            SetResistance(ResistanceType.Physical, 90);
            SetResistance(ResistanceType.Poison, 100);

            SetSkill(SkillName.Tactics, 50.0);
            SetSkill(SkillName.Wrestling, 50.1, 60.0);
        }

        public MoundOfMaggots(Serial serial)
            : base(serial)
        {
        }
		public override int Level => 8;
		public override Biome Biome => Biome.Savane;
		public override Poison PoisonImmune => Poison.Lethal;
        
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