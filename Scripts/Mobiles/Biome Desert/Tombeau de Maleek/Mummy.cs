using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le corps d'une Momie")]
    public class Mummy : BaseCreature
    {
        [Constructable]
        public Mummy()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.4, 0.8)
        {
            Name = " Momie";
            Body = 154;
            BaseSoundID = 471;

			SetStr(124, 192);
			SetDex(83, 137);
			SetInt(69, 109);

			SetHits(118, 179);

			SetDamage(17, 28);

			SetDamageType(ResistanceType.Physical, 50);
			SetDamageType(ResistanceType.Cold, 50);

			SetResistance(ResistanceType.Physical, 45, 55);
			SetResistance(ResistanceType.Fire, 45, 55);
			SetResistance(ResistanceType.Cold, 45, 55);
			SetResistance(ResistanceType.Poison, 45, 55);
			SetResistance(ResistanceType.Energy, 45, 55);


			SetSkill(SkillName.EvalInt, 35.1, 50.0);

			SetSkill(SkillName.Magery, 35.1, 50.0);
			SetSkill(SkillName.Meditation, 35.1, 50.0); 


			SetSkill(SkillName.MagicResist, 35.1, 50.0);
			SetSkill(SkillName.Tactics, 35.1, 50.0);
			SetSkill(SkillName.Wrestling, 35.1, 50.0);


	//		Fame = 4000;
    //        Karma = -4000;
        }

        public Mummy(Serial serial)
            : base(serial)
        {
        }
		public override int Level => 5;
		public override Biome Biome => Biome.Desert;
		//public override int TreasureMapLevel => 1;
        public override bool BleedImmune => true;
        public override Poison PoisonImmune => Poison.Lesser;

        public override TribeType Tribe => TribeType.Undead;

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Rich);
            AddLoot(LootPack.Potions);
            AddLoot(LootPack.LootItem<Bandage>(100.0, 10, false, true));
            AddLoot(LootPack.LootItem<Garlic>(100.0, 5, false, true));
            AddLoot(LootPack.PeculiarSeed3);
			AddLoot(LootPack.BodyParts, Utility.RandomMinMax(3, 5));
			AddLoot(LootPack.Others, Utility.RandomMinMax(1, 2));
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
