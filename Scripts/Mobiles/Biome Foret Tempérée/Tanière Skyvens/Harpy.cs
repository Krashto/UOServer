using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'une Harpie")]
    public class Harpy : BaseCreature
    {

        [Constructable]
        public Harpy()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = " Harpie";
            Body = 30;
            BaseSoundID = 402;


			SetStr(89, 137);
			SetDex(59, 98);
			SetInt(59, 79);

			SetHits(84, 128);

			SetDamage(12, 20);

			SetDamageType(ResistanceType.Physical, 100);
			

			SetResistance(ResistanceType.Physical, 75, 75);
			SetResistance(ResistanceType.Fire, 25, 25);
			SetResistance(ResistanceType.Cold, 25, 25);
			SetResistance(ResistanceType.Poison, 25, 25);
			SetResistance(ResistanceType.Energy, 25, 25);

			SetSkill(SkillName.EvalInt, 35.1, 50.0);
			SetSkill(SkillName.Magery, 35.1, 50.0);
			SetSkill(SkillName.Meditation, 35.1, 50.0);

			SetSkill(SkillName.MagicResist, 35.1, 50.0);
			SetSkill(SkillName.Tactics, 35.1, 50.0);
			SetSkill(SkillName.Wrestling, 35.1, 50.0);


		//	Fame = 2500;
         //   Karma = -2500;
        }

        public Harpy(Serial serial)
            : base(serial)
        {
        }
		public override int Level => 3;
		public override Biome Biome => Biome.Foret;
		public override void GenerateLootParagon()
		{
			AddLoot(LootPack.LootItem<SangEnvouteEnergie>(), Utility.RandomMinMax(2, 4));
		}

		public override bool CanRummageCorpses => true;
        public override int Meat => 4;
        public override MeatType MeatType => MeatType.Bird;
        public override int Feathers => 50;
        public override bool CanFly => true;
        public override void GenerateLoot()
        {
			AddLoot(LootPack.LootItem<PlumesHarpie>());
		}

        public override int GetAttackSound()
        {
            return 916;
        }

        public override int GetAngerSound()
        {
            return 916;
        }

        public override int GetDeathSound()
        {
            return 917;
        }

        public override int GetHurtSound()
        {
            return 919;
        }

        public override int GetIdleSound()
        {
            return 918;
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