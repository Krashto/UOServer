using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'un Cauchemar")]
    public class Nightmare : BaseMount
    {
        [Constructable]
        public Nightmare()
            : this("Un Cauchemar")
        {
        }

        [Constructable]
        public Nightmare(string name)
            : base(name, 0x74, 0x3EA7, AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            BaseSoundID = 0xA8;

			SetStr(199, 355);
			SetDex(132, 220);
			SetInt(110, 177);

			SetHits(231, 351);

			SetDamage(26, 45);

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


		//	Fame = 14000;
         //   Karma = -14000;

            Tamable = true;
            ControlSlots = 2;
            MinTameSkill = 95.1;

            switch (Utility.Random(4))
            {
                case 0:
                    {
                        BodyValue = 116;
                        ItemID = 16039;
                        break;
                    }
                case 1:
                    {
                        BodyValue = 177;
                        ItemID = 16053;
                        break;
                    }
                case 2:
                    {
                        BodyValue = 178;
                        ItemID = 16041;
                        break;
                    }
                case 3:
                    {
                        BodyValue = 179;
                        ItemID = 16055;
                        break;
                    }
            }

            if (Utility.RandomDouble() < 0.05)
                Hue = 1910;

            SetSpecialAbility(SpecialAbility.DragonBreath);
        }

        public Nightmare(Serial serial)
            : base(serial)
        {
        }

		public override int Level => 6;
		public override Biome Biome => Biome.Plaine;

		public override int Meat => 5;
      //  public override int Hides => 10;
		/*   public override HideType HideType => HideType.Barbed;
		   public override FoodType FavoriteFood => FoodType.Meat;*/

		public override int Hides => 12;
		public override HideType HideType => HideType.Demoniaque;


		public override int Bones => 12;
		public override BoneType BoneType => BoneType.Demoniaque;


		public override bool CanAngerOnTame => true;
        public override void GenerateLoot()
        {
            AddLoot(LootPack.Rich);
            AddLoot(LootPack.Average);
            AddLoot(LootPack.Potions);
            AddLoot(LootPack.LootItem<SulfurousAsh>(3, 5, true));
        }

        public override int GetAngerSound()
        {
            if (!Controlled)
                return 0x16A;

            return base.GetAngerSound();
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
