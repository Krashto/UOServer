using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'une Harpie")]
    public class StoneHarpy : Harpy
	{
        [Constructable]
        public StoneHarpy()
            : base()
        {
            Name = " Harpie de Pierre";
            Body = 73;
            BaseSoundID = 402;

			SetStr(199, 355);
			SetDex(132, 220);
			SetInt(110, 177);

			SetHits(231, 351);

			SetDamage(26, 45);

			SetDamageType(ResistanceType.Physical, 100);


			SetResistance(ResistanceType.Physical, 75, 75);
			SetResistance(ResistanceType.Fire, 25, 25);
			SetResistance(ResistanceType.Cold, 25, 25);
			SetResistance(ResistanceType.Poison, 25, 25);
			SetResistance(ResistanceType.Energy, 25, 25);

			SetSkill(SkillName.EvalInt, 50.1, 55.0);
			SetSkill(SkillName.Magery, 50.1, 55.0);
			SetSkill(SkillName.Meditation, 50.1, 55.0);


			SetSkill(SkillName.MagicResist, 35.1, 55.0);
			SetSkill(SkillName.Tactics, 50.1, 55.0);
			SetSkill(SkillName.Wrestling, 50.1, 55.0);


		//	Fame = 4500;
        //    Karma = -4500;
        }

        public StoneHarpy(Serial serial)
            : base(serial)
        {
        }

		public override void GenerateLootParagon()
		{
			AddLoot(LootPack.LootItem<SangEnvouteEnergie>(), Utility.RandomMinMax(2, 4));
		}

		public override int Level => 6;
		public override Biome Biome => Biome.Foret;
		public override int Meat => 1;
        public override int Feathers => 50;
        public override bool CanFly => true;
        public override void GenerateLoot()
        {
            AddLoot(LootPack.Average, 2);
			AddLoot(LootPack.RandomLootItem(new System.Type[] { typeof(SilverRing), typeof(Necklace), typeof(SilverNecklace), typeof(Collier), typeof(Collier2) }, 5.0, 1, false, true));
			AddLoot(LootPack.LootItem<PlumesHarpie>());
			AddLoot(LootPack.LootItem<OeufPierre>());
			// AddLoot(LootPack.Gems, 2);
		}

        public override int GetAttackSound()
        {
            return 916;
        }

        public override int GetAngerSound()
        {
            return 916;
        }

        public override int GetDeathSound()
        {
            return 917;
        }

        public override int GetHurtSound()
        {
            return 919;
        }

        public override int GetIdleSound()
        {
            return 918;
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