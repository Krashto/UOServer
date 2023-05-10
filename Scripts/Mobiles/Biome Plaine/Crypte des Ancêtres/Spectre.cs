using Server.Items;

namespace Server.Mobiles
	
{
    [CorpseName("Le Corps d'un Spectre")]
    public class Spectre : BaseCreature
    {
        [Constructable]
        public Spectre()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = " Spectre";
            Body = 26;
            Hue = 0x4001;
            BaseSoundID = 0x482;

			SetStr(63, 98);
			SetDex(42, 70);
			SetInt(35, 56);

			SetHits(70, 91);

			SetDamage(9, 14);

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


		//	Fame = 4000;
        //    Karma = -4000;
        }

        public Spectre(Serial serial)
            : base(serial)
        {
        }
		public override int Level => 2; 
		public override Biome Biome => Biome.Plaine;
		public override bool BleedImmune => true;

        public override TribeType Tribe => TribeType.Undead;

        public override Poison PoisonImmune => Poison.Lethal;
        public override void GenerateLoot()
        {
            AddLoot(LootPack.Meager);
            AddLoot(LootPack.MageryRegs, 10);
			AddLoot(LootPack.LootItem<CerveauSpectre>());
		}

		//public override void OnDeath(Container c)
		//{
		//	base.OnDeath(c);

		//	if (Utility.RandomDouble() < 0.02)
		//		c.DropItem(new AmeSpectre());
		//}

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
