using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'une Hydre")]
    public class Hydra : BaseCreature
    {
        [Constructable]
        public Hydra()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Une Hydre";
            Body = 0x109;
            BaseSoundID = 0x16A;

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


		//	Fame = 22000;
        //    Karma = -22000;

            SetSpecialAbility(SpecialAbility.DragonBreath);
        }

        public Hydra(Serial serial)
            : base(serial)
        {
        }
		public override int Level => 12;
		public override Biome Biome => Biome.Foret;
		public override int Hides => 12;
		public override HideType HideType => HideType.Reptilien;


		public override int Bones => 12;
		public override BoneType BoneType => BoneType.Reptilien;

		public override int Meat => 19;
        public override int TreasureMapLevel => 5;
        public override void GenerateLoot()
        {
            AddLoot(LootPack.UltraRich, 3);
        }

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
