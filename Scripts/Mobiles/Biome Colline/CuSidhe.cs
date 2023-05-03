using Server.Items;
using System;

namespace Server.Mobiles
{
    [CorpseName("le corps d'un Cu Sidhe")]
    public class CuSidhe : BaseMount
    {
        public override double HealChance => 1.0;

        [Constructable]
        public CuSidhe()
            : this(" cu sidhe")
        {
        }

        [Constructable]
        public CuSidhe(string name)
            : base(name, 277, 0x3E91, AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            double chance = Utility.RandomDouble() * 23301;

            if (chance <= 1)
                Hue = 0x489;
            else if (chance <= 301)
                Hue = Utility.RandomList(0x657, 0x515, 0x4B1, 0x481, 0x482, 0x455);
            else if (chance <= 3301)
                Hue = Utility.RandomList(0x97A, 0x978, 0x901, 0x8AC, 0x5A7, 0x527);

			SetStr(173, 269);
			SetDex(115, 192);
			SetInt(96, 154);

			SetHits(165, 251);

			SetDamage(23, 39);

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


		//	Fame = 5000;  //Guessing here
        //    Karma = 5000;  //Guessing here

            Tamable = true;
            ControlSlots = 3;
            MinTameSkill = 85.0;

            SetWeaponAbility(WeaponAbility.BleedAttack);
        }

        public CuSidhe(Serial serial)
            : base(serial)
        {
        }
		public override int Level => 5;
		public override Biome Biome => Biome.Colline;
		////public override int TreasureMapLevel => 5;

        public override FoodType FavoriteFood => FoodType.FruitsAndVegies;
        public override bool CanAngerOnTame => true;
        public override bool StatLossAfterTame => true;
        public override int Hides => 10;
        public override int Meat => 3;

        public override void GenerateLoot()
        {
            AddLoot(LootPack.FilthyRich, 5);
        }

        public override void OnAfterTame(Mobile tamer)
        {
            if (Owners.Count == 0)
            {
                if (RawStr > 0)
                    RawStr = (int)Math.Max(1, RawStr * 0.5);

                if (RawDex > 0)
                    RawDex = (int)Math.Max(1, RawDex * 0.5);

                if (HitsMaxSeed > 0)
                    HitsMaxSeed = (int)Math.Max(1, HitsMaxSeed * 0.5);

                Hits = Math.Min(HitsMaxSeed, Hits);
                Stam = Math.Min(RawDex, Stam);
            }
            else
            {
                base.OnAfterTame(tamer);
            }
        }

        public override void OnDoubleClick(Mobile from)
        {
            base.OnDoubleClick(from);
        }

        public override int GetIdleSound()
        {
            return 0x577;
        }

        public override int GetAttackSound()
        {
            return 0x576;
        }

        public override int GetAngerSound()
        {
            return 0x578;
        }

        public override int GetHurtSound()
        {
            return 0x576;
        }

        public override int GetDeathSound()
        {
            return 0x579;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(3); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            if (version < 3 && Controlled && RawStr >= 1200 && ControlSlots == ControlSlotsMin)
            {
                SkillHandlers.AnimalTaming.ScaleStats(this, 0.5);
            }

            if (version < 1 && Name == "a Cu Sidhe")
                Name = "a cu sidhe";

            if (version == 1)
            {
                SetWeaponAbility(WeaponAbility.BleedAttack);
            }
        }
    }
}
