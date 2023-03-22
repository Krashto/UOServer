using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a wyvern corpse")]
    public class Wyvern : BaseCreature
    {
        [Constructable]
        public Wyvern()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "a wyvern";
            Body = 62;
            BaseSoundID = 362;

			SetStr(199, 355);
			SetDex(132, 220);
			SetInt(110, 177);

			SetHits(231, 351);

			SetDamage(26, 45);

			SetDamageType(ResistanceType.Physical, 50);
			SetDamageType(ResistanceType.Energy, 50);

			SetResistance(ResistanceType.Physical, 50, 60);
			SetResistance(ResistanceType.Fire, 50, 60);
			SetResistance(ResistanceType.Cold, 50, 60);
			SetResistance(ResistanceType.Poison, 50, 60);
			SetResistance(ResistanceType.Energy, 50, 60);


			SetSkill(SkillName.EvalInt, 45.1, 50.0);

			SetSkill(SkillName.Magery, 45.1, 50.0);
			SetSkill(SkillName.Meditation, 45.1, 50.0); 


			SetSkill(SkillName.MagicResist, 25.1, 50.0);
			SetSkill(SkillName.Tactics, 45.1, 50.0);
			SetSkill(SkillName.Wrestling, 45.1, 50.0);

		}

		public Wyvern(Serial serial)
            : base(serial)
        {
        }

        public override bool ReacquireOnMovement => true;
        public override Poison PoisonImmune => Poison.Deadly;
        public override Poison HitPoison => Poison.Deadly;
        public override int TreasureMapLevel => 2;
        public override int Meat => 10;
        public override int Hides => 12;
        public override HideType HideType => HideType.Dragonique;

		public override int Bones => 12;
		public override BoneType BoneType => BoneType.Dragonique;

		public override bool CanFly => true;
        public override void GenerateLoot()
        {
            AddLoot(LootPack.Average);
            AddLoot(LootPack.Meager);
            AddLoot(LootPack.MedScrolls);
            AddLoot(LootPack.LootItem<LesserPoisonPotion>(true));
			AddLoot(LootPack.LootItem<Items.GemmePoison>(), (double)5);
		}

		public override void GenerateLootParagon()
		{
			AddLoot(LootPack.LootItem<SangEnvouteWyvern>(), Utility.RandomMinMax(2, 4));
		}

		public override int GetAttackSound()
        {
            return 713;
        }

        public override int GetAngerSound()
        {
            return 718;
        }

        public override int GetDeathSound()
        {
            return 716;
        }

        public override int GetHurtSound()
        {
            return 721;
        }

        public override int GetIdleSound()
        {
            return 725;
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
