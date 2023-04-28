using Server.Gumps;
using Server.Items;
using System;

namespace Server.Mobiles
{
    public class TritonStatue : Item, ICreatureStatuette
    {
        public override int LabelNumber => 1158929;  // Triton

        public Type CreatureType => typeof(Triton);

        [Constructable]
        public TritonStatue()
            : base(0xA2D8)
        {
            Hue = 2713;
        }

        public TritonStatue(Serial serial)
            : base(serial)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (IsChildOf(from.Backpack))
            {
                if (from.Skills[SkillName.AnimalTaming].Value >= 100)
                {
                    from.SendGump(new ConfirmMountStatuetteGump(this));
                }
                else
                {
                    from.SendLocalizedMessage(1158959, "100"); // ~1_SKILL~ Animal Taming skill is required to redeem this pet.
                }
            }
            else
            {
                SendLocalizedMessageTo(from, 1010095); // This must be on your person to use.
            }
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            list.Add(1158954); // *Redeemable for a pet*<br>*Requires Grandmaster Taming to Claim Pet*
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

    [CorpseName(" Triton")]
    public class Triton : BaseCreature
    {
        [Constructable]
        public Triton()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = " Triton";
            Body = 0x2D0;
            Hue = 2713;
            BaseSoundID = 0x5A;

			SetStr(229, 408);
			SetDex(151, 253);
			SetInt(126, 203);

			SetHits(323, 491);

			SetDamage(30, 51);

			SetDamageType(ResistanceType.Energy, 50);
			SetDamageType(ResistanceType.Poison, 50);


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

		//	Fame = 300;
        //    Karma = 300;

            Tamable = true;
            ControlSlots = 2;
            MinTameSkill = 56.0;

            SetSpecialAbility(SpecialAbility.Heal);
        }
		public override int Level => 7;
		public override Biome Biome => Biome.Foret;
		public override void GenerateLoot()
        {
            AddLoot(LootPack.LootItem<Bandage>(11, true));
        }

        public Triton(Serial serial)
            : base(serial)
        {
        }

        public override bool DeleteOnRelease => true;
        public override int Meat => 3;
		public override int Hides => 7;
		public override HideType HideType => HideType.Reptilien;


		public override int Bones => 7;
		public override BoneType BoneType => BoneType.Reptilien;
		public override FoodType FavoriteFood => FoodType.Meat;

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
