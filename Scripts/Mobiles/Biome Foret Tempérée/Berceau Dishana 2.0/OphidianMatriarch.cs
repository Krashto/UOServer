using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le corps d'une Ophidienne")]
    public class OphidianMatriarch : BaseCreature
    {
        [Constructable]
        public OphidianMatriarch()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = " Ophidienne Matriarche";
            Body = 87;
            BaseSoundID = 644;

			SetStr(199, 355);
			SetDex(132, 220);
			SetInt(110, 177);

			SetHits(1738, 2642);

			SetDamage(26, 45);

			SetDamageType(ResistanceType.Energy, 50);
			SetDamageType(ResistanceType.Poison, 50);


			SetResistance(ResistanceType.Physical, 25, 25);
			SetResistance(ResistanceType.Fire, 25, 25);
			SetResistance(ResistanceType.Cold, 75, 75);
			SetResistance(ResistanceType.Poison, 75, 75);
			SetResistance(ResistanceType.Energy, 75, 75);

			SetSkill(SkillName.EvalInt, 55.1, 65.0);
			SetSkill(SkillName.Magery, 55.1, 65.0);
			SetSkill(SkillName.Meditation, 55.1, 65.0);


			SetSkill(SkillName.MagicResist, 45.1, 60.0);
			SetSkill(SkillName.Tactics, 55.1, 65.0);
			SetSkill(SkillName.Wrestling, 55.1, 65.0);

		//	Fame = 16000;
        //    Karma = -16000;
        }

        public OphidianMatriarch(Serial serial)
            : base(serial)
        {
        }

		public override void GenerateLootParagon()
		{
			AddLoot(LootPack.LootItem<SangEnvoutePoison>(), Utility.RandomMinMax(2, 4));
		}

		public override int Level => 12;
		public override Biome Biome => Biome.Foret;
		public override Poison PoisonImmune => Poison.Greater;
        public override int TreasureMapLevel => 4;

        public override TribeType Tribe => TribeType.Ophidian;

		public override int Hides => 6;
		public override HideType HideType => HideType.Ophidien;


		public override int Bones => 6;
		public override BoneType BoneType => BoneType.Ophidien;

		public override void GenerateLoot()
        {
            AddLoot(LootPack.Rich);
            AddLoot(LootPack.Average, 2);
          
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
