using Server.Custom;
using Server.Custom.Items.SouvenirsAncestraux.Souvenirs;

namespace Server.Items
{
	public class TreasureLevel1 : BaseDungeonChest
    {
        public override int DefaultGumpID => 0x49;

		public override int Level => 1;

		[Constructable]
        public TreasureLevel1() : base(Utility.RandomList(0xE3C, 0xE3E, 0x9a9)) // Large, Medium and Small Crate
        {
            RequiredSkill = 20;
            LockLevel = RequiredSkill - Utility.Random(1, 10);
            MaxLockLevel = RequiredSkill;
            TrapType = TrapType.ExplosionTrap;
            TrapPower = 1 * Utility.Random(35, 45);

			//var item = CustomUtility.GetRandomItemByBaseType(typeof(BaseSouvenir));
			//if (item != null)
			//{
			//	item.Amount = Level;
			//	DropItem(item);
			//}
		}

        public TreasureLevel1(Serial serial) : base(serial)
        {
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

    public class TreasureLevel2 : BaseDungeonChest
    {
		public override int Level => 2;

		[Constructable]
        public TreasureLevel2() : base(Utility.RandomList(0xe3c, 0xE3E, 0x9a9, 0xe42, 0x9ab, 0xe40, 0xe7f, 0xe77)) // various container IDs
        {
            RequiredSkill = 40;
            LockLevel = RequiredSkill - Utility.Random(1, 10);
            MaxLockLevel = RequiredSkill;
            TrapType = TrapType.ExplosionTrap;
            TrapPower = 2 * Utility.Random(30, 50);

			//var item = CustomUtility.GetRandomItemByBaseType(typeof(BaseSouvenir));
			//if (item != null)
			//{
			//	item.Amount = Level;
			//	DropItem(item);
			//}
		}

        public TreasureLevel2(Serial serial) : base(serial)
        {
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

    public class TreasureLevel3 : BaseDungeonChest
    {
		public override int Level => 3;
		public override int DefaultGumpID => 0x4A;

        [Constructable]
        public TreasureLevel3() : base(Utility.RandomList(0x9ab, 0xe40, 0xe42)) // Wooden, Metal and Metal Golden Chest
        {
            RequiredSkill = 60;
            LockLevel = RequiredSkill - Utility.Random(1, 10);
            MaxLockLevel = RequiredSkill;
            TrapType = TrapType.ExplosionTrap;
            TrapPower = 3 * Utility.Random(30, 40);

			//var item = CustomUtility.GetRandomItemByBaseType(typeof(BaseSouvenir));
			//if (item != null)
			//{
			//	item.Amount = Level;
			//	DropItem(item);
			//}
		}

        public TreasureLevel3(Serial serial) : base(serial)
        {
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

    public class TreasureLevel4 : BaseDungeonChest
    {
		public override int Level => 4;

		[Constructable]
        public TreasureLevel4() : base(Utility.RandomList(0xe40, 0xe42, 0x9ab)) // Wooden, Metal and Metal Golden Chest
        {
            RequiredSkill = 80;
            LockLevel = RequiredSkill - Utility.Random(1, 10);
            MaxLockLevel = RequiredSkill;
            TrapType = TrapType.ExplosionTrap;
            TrapPower = 4 * Utility.Random(25, 35);

			//var item = CustomUtility.GetRandomItemByBaseType(typeof(BaseSouvenir));
			//if (item != null)	
			//{
			//	item.Amount = Level;
			//	DropItem(item);
			//}
		}

        public TreasureLevel4(Serial serial) : base(serial)
        {
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
