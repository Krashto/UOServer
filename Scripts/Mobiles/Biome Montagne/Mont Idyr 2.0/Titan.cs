using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'un Titan")]
    public class Titan : BaseCreature
    {
        [Constructable]
        public Titan()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = " Titan";
            Body = 76;
            BaseSoundID = 609;

            SetStr(536, 585);
            SetDex(126, 145);
            SetInt(281, 305);

            SetHits(322, 351);

            SetDamage(13, 16);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 35, 45);
            SetResistance(ResistanceType.Fire, 30, 40);
            SetResistance(ResistanceType.Cold, 25, 35);
            SetResistance(ResistanceType.Poison, 30, 40);
            SetResistance(ResistanceType.Energy, 30, 40);

            SetSkill(SkillName.EvalInt, 85.1, 100.0);
            SetSkill(SkillName.Magery, 85.1, 100.0);
            SetSkill(SkillName.MagicResist, 80.2, 110.0);
            SetSkill(SkillName.Tactics, 60.1, 80.0);
            SetSkill(SkillName.Wrestling, 40.1, 50.0);

        //    Fame = 11500;
        //    Karma = -11500;
        }

        public Titan(Serial serial)
            : base(serial)
        {
        }
		public override int Level => 13;
		public override Biome Biome => Biome.Montagne;
		public override int Meat => 4;
        public override Poison PoisonImmune => Poison.Regular;
		public override int Hides => 8;
		public override HideType HideType => HideType.Geant;


		public override int Bones => 8;
		public override BoneType BoneType => BoneType.Geant;

		public override void GenerateLoot()
        {
            AddLoot(LootPack.LootItem<Items.RoastPig>(10.0));
			AddLoot(LootPack.LootItem<CheveuxGeant>());
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
