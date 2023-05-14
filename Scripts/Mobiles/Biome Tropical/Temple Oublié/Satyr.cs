using Server.Items;	

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'un Satyr")]
    public class Satyr : BaseCreature
    {
        [Constructable]
        public Satyr()
            : base(AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = " Satyr";
            Body = 271;
            BaseSoundID = 0x586;

            SetStr(177, 195);
            SetDex(251, 269);
            SetInt(153, 170);

            SetHits(350, 400);

            SetDamage(13, 24);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 55, 60);
            SetResistance(ResistanceType.Fire, 25, 35);
            SetResistance(ResistanceType.Cold, 30, 40);
            SetResistance(ResistanceType.Poison, 30, 40);
            SetResistance(ResistanceType.Energy, 30, 40);

            SetSkill(SkillName.MagicResist, 55.0, 65.0);
            SetSkill(SkillName.Tactics, 80.0, 100.0);
            SetSkill(SkillName.Wrestling, 80.0, 100.0);

            SetSkill(SkillName.Musicianship, 100);
            SetSkill(SkillName.Discordance, 100);
            SetSkill(SkillName.Provocation, 100);
            SetSkill(SkillName.Peacemaking, 100);

            Fame = 5000;
            Karma = 0;
        }

        public Satyr(Serial serial)
            : base(serial)
        {
        }
		public override int Level => 9;
		public override Biome Biome => Biome.Tropique;
		public override TribeType Tribe => TribeType.Fey;

		public override void GenerateLootParagon()
		{
			AddLoot(LootPack.LootItem<SangEnvouteSatyr>(), Utility.RandomMinMax(2, 4));
		}

		public override bool CanDiscord => true;
        public override bool CanPeace => true;
        public override bool CanProvoke => true;

        public override int Meat => 1;

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
