using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'un Squelette")]
    public class Skeleton : BaseCreature
    {
        [Constructable]
        public Skeleton()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = " Squelette";
            Body = Utility.RandomList(50, 56);
            BaseSoundID = 0x48D;

			SetStr(45, 70);
			SetDex(30, 50);
			SetInt(25, 40);

			SetHits(50, 65);

			SetDamage(6, 10);

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


		//	Fame = 450;
        //    Karma = -450;
        }

        public Skeleton(Serial serial)
            : base(serial)
        {
        }
		public override int Level => 1;
		public override Biome Biome => Biome.Plaine;
		public override bool BleedImmune => true;
        public override Poison PoisonImmune => Poison.Lesser;
        public override TribeType Tribe => TribeType.Undead;

        public override bool IsEnemy(Mobile m)
        {
            if (Region.IsPartOf("Haven Island"))
            {
                return false;
            }

            return base.IsEnemy(m);
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Poor);
			AddLoot(LootPack.Bones, Utility.RandomMinMax(3, 5));
			AddLoot(LootPack.Others, Utility.RandomMinMax(1, 2));
		}



		//public override void OnDeath(Container c)
		//{
		//	base.OnDeath(c);

		//	if (Utility.RandomDouble() < 0.01)
		//		c.DropItem(new AmeSquelette());
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
