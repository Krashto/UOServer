using Server.Items;
using Server.Misc;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'un Sky-Vens Archer")]
    public class RatmanArcher : BaseCreature
    {
        [Constructable]
        public RatmanArcher()
            : base(AIType.AI_Archer, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = " Sky-vens Archer";
            Body = 0x8E;
            BaseSoundID = 437;

			SetStr(173, 269);
			SetDex(115, 192);
			SetInt(96, 154);

			SetHits(165, 251);

			SetDamage(23, 39);

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


		//	Fame = 6500;
        //    Karma = -6500;

            AddItem(new Bow());
        }

        public RatmanArcher(Serial serial)
            : base(serial)
        {
        }
		public override int Level => 5;
		public override Biome Biome => Biome.Foret;
		public override InhumanSpeech SpeechType => InhumanSpeech.Ratman;
        public override bool CanRummageCorpses => true;
		public override int Hides => 8;
		public override HideType HideType => HideType.Regular;

		public override int Bones => 8;
		public override BoneType BoneType => BoneType.Regular;
		public override void GenerateLoot()
        {
            AddLoot(LootPack.Average);
            AddLoot(LootPack.LootItem<Arrow>(10, 25, true));
			AddLoot(LootPack.RandomLootItem(new System.Type[] { typeof(CheeseWedge), typeof(CheeseSlice), typeof(CheeseWheel) }, 25.0, 2, false, true));
			AddLoot(LootPack.Others, Utility.RandomMinMax(1, 2));
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
