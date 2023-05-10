using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'un Spectre")]
    public class DreamWraith : BaseCreature
    {
        [Constructable]
        public DreamWraith()
            : base(AIType.AI_NecroMage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = " Spectre Astral";
            Body = 740;
            BaseSoundID = 0x482;

			SetStr(173, 269);
			SetDex(115, 192);
			SetInt(96, 154);

			SetHits(165, 251);

			SetDamage(23, 39);

			SetDamageType(ResistanceType.Poison, 50);
			SetDamageType(ResistanceType.Cold, 50);

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


	//		Fame = 4000;
    //        Karma = -4000;
        }

        public DreamWraith(Serial serial)
            : base(serial)
        {
        }
		public override int Level => 5;
		public override Biome Biome => Biome.Plaine;
		public override bool BleedImmune => true;
        public override Poison PoisonImmune => Poison.Lethal;
		public override void GenerateLoot()
		{
			AddLoot(LootPack.LootItem<FluideAstral>(1, true));

		}

		//public override void OnDeath(Container c)
		//{
		//	base.OnDeath(c);

		//	if (Utility.RandomDouble() < 0.05)
		//		c.DropItem(new AmeSpectreAstral());
		//}

		public override int GetIdleSound()
        {
            return 0x5F4;
        }

        public override int GetAngerSound()
        {
            return 0x5F1;
        }

        public override int GetDeathSound()
        {
            return 0x5F2;
        }

        public override int GetHurtSound()
        {
            return 0x5F3;
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
