using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'un Centaur")]
    public class Centaur : BaseCreature
    {
        [Constructable]
        public Centaur()
            : base(AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = " Centaur";
            Body = 101;
            BaseSoundID = 679;

			AddItem(new Bow());

			SetStr(202, 300);
            SetDex(104, 260);
            SetInt(91, 100);

            SetHits(130, 172);

            SetDamage(13, 24);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 45, 55);
            SetResistance(ResistanceType.Fire, 35, 45);
            SetResistance(ResistanceType.Cold, 25, 35);
            SetResistance(ResistanceType.Poison, 45, 55);
            SetResistance(ResistanceType.Energy, 35, 45);

            SetSkill(SkillName.Anatomy, 95.1, 115.0);
            SetSkill(SkillName.Archery, 95.1, 100.0);
            SetSkill(SkillName.MagicResist, 50.3, 80.0);
            SetSkill(SkillName.Tactics, 90.1, 100.0);
            SetSkill(SkillName.Wrestling, 95.1, 100.0);
        }

        public Centaur(Serial serial)
            : base(serial)
        {
        }

		public override int Level => 8;
		public override Biome Biome => Biome.Tropique;

		public override void GenerateLootParagon()
		{
			AddLoot(LootPack.LootItem<SangEnvouteWyvern>(), Utility.RandomMinMax(2, 4));
		}



		public override TribeType Tribe => TribeType.Fey;

        public override int Meat => 1;
        public override int Hides => 8;
        public override HideType HideType => HideType.Regular;

		public override int Bones => 12;
		public override BoneType BoneType => BoneType.Regular;
		
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
