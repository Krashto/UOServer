using Server.Misc;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'un Homme Lezard")]
    public class Lizardman : BaseCreature
    {
        [Constructable]
        public Lizardman()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = " Homme Lezard";
            Body = Utility.RandomList(35, 36);
            BaseSoundID = 417;


			SetStr(89, 137);
			SetDex(59, 98);
			SetInt(59, 79);

			SetHits(84, 128);

			SetDamage(12, 20);

			SetDamageType(ResistanceType.Energy, 50);
			SetDamageType(ResistanceType.Poison, 50);


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

		//	Fame = 1500;
         //   Karma = -1500;
        }

        public Lizardman(Serial serial)
            : base(serial)
        {
        }

		public override void GenerateLootParagon()
		{
			AddLoot(LootPack.LootItem<SangEnvouteLezard>(), Utility.RandomMinMax(2, 4));
		}
		public override int Level => 3;
		public override Biome Biome => Biome.Foret;
		public override int TreasureMapLevel => 1;
        public override InhumanSpeech SpeechType => InhumanSpeech.Lizardman;
        public override bool CanRummageCorpses => true;
        public override int Meat => 1;


		public override int Hides => 4;
		public override HideType HideType => HideType.Reptilien;

		public override int Bones => 4;
		public override BoneType BoneType => BoneType.Reptilien;

		/*    public override int Hides => 12;
			public override HideType HideType => HideType.Spined;*/
		public override void GenerateLoot()
        {
            AddLoot(LootPack.Meager);
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