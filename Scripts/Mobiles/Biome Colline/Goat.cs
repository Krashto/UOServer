using System;
using System.Linq;

using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'une Chevre")]
    public class Goat : BaseCreature
    {
        [Constructable]
        public Goat()
            : base(AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = "Chevre";
            Body = 0xD1;
            BaseSoundID = 0x99;

			SetStr(63, 98);
			SetDex(42, 70);
			SetInt(35, 56);

			SetHits(70, 91);

			SetDamage(9, 14);

			SetDamageType(ResistanceType.Physical, 100);


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

	//		Fame = 150;
    //        Karma = 0;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 11.1;
        }

        public Goat(Serial serial)
            : base(serial)
        {
        }
		public override int Level => 2;
		public override Biome Biome => Biome.Colline;
		public override bool CanBeParagon => false;
		public override int Meat => 3;
        public override int Hides => 3;
        public override FoodType FavoriteFood => FoodType.GrainsAndHay | FoodType.FruitsAndVegies;

        private static readonly Type[] _FeedTypes = new[]
        {
            typeof(Backpack), typeof(BaseShoes), typeof(Bag)
        };

        public override bool CheckFoodPreference(Item f)
        {
            if (!base.CheckFoodPreference(f))
            {
                if (f is BaseArmor && (((BaseArmor)f).MaterialType == ArmorMaterialType.Leather || ((BaseArmor)f).MaterialType == ArmorMaterialType.Studded))
                {
                    return true;
                }

                var type = f.GetType();

                return _FeedTypes.Any(t => t == type || type.IsSubclassOf(t));
            }

            return true;
        }

		public override void GenerateLoot()
		{
			AddLoot(LootPack.LootItem<RawGoatRoast>(), Utility.RandomMinMax(0, 2));
			AddLoot(LootPack.LootItem<RawGoatSteak>(), Utility.RandomMinMax(0, 2));

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
