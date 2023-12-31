using Server.Misc;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'un Sky-vens Rat")]
    public class Ratman : BaseCreature
    {
        [Constructable]
        public Ratman()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = " Sky-vens";
            Body = 42;
            BaseSoundID = 437;
			SetStr(124, 192);
			SetDex(83, 137);
			SetInt(69, 109);

			SetHits(118, 179);

			SetDamage(17, 28);

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


	//		Fame = 1500;
    //        Karma = -1500;
        }

        public Ratman(Serial serial)
            : base(serial)
        {
        }
		public override int Level => 4;
		public override Biome Biome => Biome.Foret;
		public override InhumanSpeech SpeechType => InhumanSpeech.Ratman;
        public override bool CanRummageCorpses => true;
		public override int Hides => 8;
		public override HideType HideType => HideType.Regular;

		public override int Bones => 8;
		public override BoneType BoneType => BoneType.Regular;
		public override void GenerateLoot()
        {
			AddLoot(LootPack.RandomLootItem(new System.Type[] { typeof(CheeseWedge), typeof(CheeseSlice), typeof(CheeseWheel) }, 25.0, 2, false, true));
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