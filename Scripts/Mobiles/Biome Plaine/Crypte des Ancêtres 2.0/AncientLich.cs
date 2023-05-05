using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'une Liche Ancienne")]
    public class AncientLich : BaseCreature
    {
        [Constructable]
        public AncientLich()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
			Name = " Liche Ancienne";
            Body = 78;
            BaseSoundID = 412;

			SetStr(229, 408);
			SetDex(151, 253);
			SetInt(126, 203);

			SetHits(633, 963);

			SetDamage(40, 67);

			SetDamageType(ResistanceType.Poison, 50);
			SetDamageType(ResistanceType.Cold, 50);

			SetResistance(ResistanceType.Physical, 25, 25);
			SetResistance(ResistanceType.Fire, 25, 25);
			SetResistance(ResistanceType.Cold, 75, 75);
			SetResistance(ResistanceType.Poison, 75, 75);
			SetResistance(ResistanceType.Energy, 75, 75);

			SetSkill(SkillName.EvalInt, 50.1, 55.0);
			SetSkill(SkillName.Magery, 50.1, 55.0);
			SetSkill(SkillName.Meditation, 50.1, 55.0);


			SetSkill(SkillName.MagicResist, 35.1, 55.0);
			SetSkill(SkillName.Tactics, 50.1, 55.0);
			SetSkill(SkillName.Wrestling, 50.1, 55.0);


	//		Fame = 23000;
    //        Karma = -23000;
        }

        public AncientLich(Serial serial)
            : base(serial)
        {
        }


		public override int Level => 9;
		public override Biome Biome => Biome.Plaine;

		public override TribeType Tribe => TribeType.Undead;
		
        public override bool Unprovokable => true;
		
        public override bool BleedImmune => true;
		
        public override Poison PoisonImmune => Poison.Lethal;
		
        //public override int TreasureMapLevel => 5;

/*		public override int Bones => 12;
		public override BoneType BoneType => BoneType.;
*/
		public override int GetIdleSound()
        {
            return 0x19D;
        }

        public override int GetAngerSound()
        {
            return 0x175;
        }

        public override int GetDeathSound()
        {
            return 0x108;
        }

        public override int GetAttackSound()
        {
            return 0xE2;
        }

        public override int GetHurtSound()
        {
            return 0x28B;
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.FilthyRich, 3);
       //AddLoot(LootPack.MedScrolls, 2);
            AddLoot(LootPack.NecroRegs, 100, 200);
			AddLoot(LootPack.BodyPartsAndBones, Utility.RandomMinMax(3, 5));
			AddLoot(LootPack.Others, Utility.RandomMinMax(1, 2));
			AddLoot(LootPack.LootItem<CerveauLiche>());
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
