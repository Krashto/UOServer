using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'un Ophidien")]
    public class OphidianKnight : BaseCreature
    {
        private static readonly string[] m_Names = new string[]
        {
            " Chevalier Ophidien",
            " Ophidien Vengeur"
        };
        [Constructable]
        public OphidianKnight()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = m_Names[Utility.Random(m_Names.Length)];
            Body = 86;
            BaseSoundID = 634;

			SetStr(199, 355);
			SetDex(132, 220);
			SetInt(110, 177);

			SetHits(231, 351);

			SetDamage(26, 45);

			SetDamageType(ResistanceType.Energy, 50);
			SetDamageType(ResistanceType.Poison, 50);


			SetResistance(ResistanceType.Physical, 25, 25);
			SetResistance(ResistanceType.Fire, 25, 25);
			SetResistance(ResistanceType.Cold, 75, 75);
			SetResistance(ResistanceType.Poison, 75, 75);
			SetResistance(ResistanceType.Energy, 75, 75);

			SetSkill(SkillName.EvalInt, 50.1, 55.0);
			SetSkill(SkillName.Magery, 50.1, 55.0);
			SetSkill(SkillName.Meditation, 50.1, 55.0);


			SetSkill(SkillName.MagicResist, 35.1, 55.0);
			SetSkill(SkillName.Tactics, 50.1, 55.0);
			SetSkill(SkillName.Wrestling, 50.1, 55.0);


		//	Fame = 10000;
        //    Karma = -10000;
        }

        public OphidianKnight(Serial serial)
            : base(serial)
        {
        }
		public override int Level => 6;
		public override Biome Biome => Biome.Foret;
		public override int Meat => 2;
        public override Poison PoisonImmune => Poison.Lethal;
        public override Poison HitPoison => Poison.Lethal;
        //public override int TreasureMapLevel => 3;

        public override TribeType Tribe => TribeType.Ophidian;

		public override int Hides => 6;
		public override HideType HideType => HideType.Ophidien;

		public override void GenerateLootParagon()
		{
			AddLoot(LootPack.LootItem<SangEnvoutePoison>(), Utility.RandomMinMax(2, 4));
		}


		public override int Bones => 6;
		public override BoneType BoneType => BoneType.Ophidien;

		public override void GenerateLoot()
        {
            AddLoot(LootPack.Rich, 2);
            AddLoot(LootPack.LootItem<LesserPoisonPotion>());
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
