using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'une Gargouille")]
    public class StoneGargoyle : BaseCreature
    {
        [Constructable]
        public StoneGargoyle()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = " Gargouille de Pierre";
            Body = 67;
            BaseSoundID = 0x174;

            SetStr(246, 275);
            SetDex(76, 95);
            SetInt(81, 105);

            SetHits(148, 165);

            SetDamage(11, 17);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 45, 55);
            SetResistance(ResistanceType.Fire, 20, 30);
            SetResistance(ResistanceType.Cold, 10, 20);
            SetResistance(ResistanceType.Poison, 30, 40);
            SetResistance(ResistanceType.Energy, 30, 40);

            SetSkill(SkillName.MagicResist, 85.1, 100.0);
            SetSkill(SkillName.Tactics, 80.1, 100.0);
            SetSkill(SkillName.Wrestling, 60.1, 100.0);

         //   Fame = 4000;
         //   Karma = -4000;
        }

        public StoneGargoyle(Serial serial)
            : base(serial)
        {
        }
		public override int Level => 8;
		public override Biome Biome => Biome.Volcan;
		//public override int TreasureMapLevel => 2;
        public override void GenerateLoot()
        {
            AddLoot(LootPack.Average, 2);           
            AddLoot(LootPack.Potions);
           
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
