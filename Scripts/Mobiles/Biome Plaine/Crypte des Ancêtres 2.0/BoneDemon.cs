using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'un Demon D'Os")]
    public class BoneDemon : BaseCreature
    {
        [Constructable]
        public BoneDemon()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = " Demon D'Os";
            Body = 308;
            BaseSoundID = 0x48D;

			SetStr(199, 355);
			SetDex(132, 220);
			SetInt(110, 177);

			SetHits(1241, 1887);

			SetDamage(26, 45);

			SetDamageType(ResistanceType.Poison, 50);
			SetDamageType(ResistanceType.Cold, 50);

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


		//	Fame = 20000;
        //  Karma = -20000;
        }

        public BoneDemon(Serial serial)
            : base(serial)
        {
        }
		public override int Level => 11;
		public override Biome Biome => Biome.Plaine;
		public override int Bones => 12;
		public override BoneType BoneType => BoneType.Demoniaque;
		public override bool Unprovokable => true;
        public override bool AreaPeaceImmune => true;
        public override Poison PoisonImmune => Poison.Lethal;
        public override void GenerateLoot()
        {
			AddLoot(LootPack.LootItem<Items.GemmeGlace>(), (double)5);
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
