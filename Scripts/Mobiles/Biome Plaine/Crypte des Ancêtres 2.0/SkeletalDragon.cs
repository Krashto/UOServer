using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'un Dragon Squelette")]
    public class SkeletalDragon : BaseCreature
    {
        [Constructable]
        public SkeletalDragon()
            : base(AIType.AI_NecroMage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = " Dragon Squelette";
            Body = 104;
            BaseSoundID = 0x488;

			SetStr(229, 408);
			SetDex(151, 253);
			SetInt(126, 203);

			SetHits(452, 687);

			SetDamage(34, 58);

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


		//	Fame = 22500;
        //    Karma = -22500;

            SetSpecialAbility(SpecialAbility.DragonBreath);
        }

        public SkeletalDragon(Serial serial)
            : base(serial)
        {
        }

		public override int Level => 8;
		public override Biome Biome => Biome.Plaine;
		public override bool AutoDispel => !Controlled;
        public override bool BleedImmune => true;
        public override bool ReacquireOnMovement => !Controlled;
        public override double BonusPetDamageScalar => 3.0;
  //      public override int Hides => 20;
        public override int Meat => 19;  // where's it hiding these? :)
										 //     public override HideType HideType => HideType.Barbed;

		public override int Bones => 12;
		public override BoneType BoneType => BoneType.Dragonique;
		public override Poison PoisonImmune => Poison.Lethal;
        public override TribeType Tribe => TribeType.Undead;

        public override void GenerateLoot()
        {
            AddLoot(LootPack.FilthyRich, 4);
            AddLoot(LootPack.Gems, 5);
        }

		//public override void OnDeath(Container c)
		//{
		//	base.OnDeath(c);

		//	if (Utility.RandomDouble() < 0.08)
		//		c.DropItem(new AmeDragonSquel());
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
