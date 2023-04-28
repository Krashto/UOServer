using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'un Ophidien")]
    public class OphidianMage : BaseCreature
    {
        private static readonly string[] m_Names = new string[]
        {
            " Ophidien Mage",
            " Ophidien Shaman"
        };
        [Constructable]
        public OphidianMage()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = m_Names[Utility.Random(m_Names.Length)];
            Body = 85;
            BaseSoundID = 639;

			SetStr(124, 192);
			SetDex(83, 137);
			SetInt(69, 109);

			SetHits(118, 179);

			SetDamage(17, 28);

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

		//	Fame = 4000;
        //    Karma = -4000;
        }

        public OphidianMage(Serial serial)
            : base(serial)
        {
        }
		public override int Level => 4;
		public override Biome Biome => Biome.Foret;
		public override int Meat => 1;
        public override int TreasureMapLevel => 2;

		public override void GenerateLootParagon()
		{
			AddLoot(LootPack.LootItem<SangEnvoutePoison>(), Utility.RandomMinMax(2, 4));
		}


		public override TribeType Tribe => TribeType.Ophidian;

		public override int Hides => 6;
		public override HideType HideType => HideType.Ophidien;


		public override int Bones => 6;
		public override BoneType BoneType => BoneType.Ophidien;

		public override void GenerateLoot()
        {
            AddLoot(LootPack.Average);
         
           
            AddLoot(LootPack.MageryRegs, 10);
    //        AddLoot(LootPack.LootItem<PainSpikeScroll>(16.7));
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
