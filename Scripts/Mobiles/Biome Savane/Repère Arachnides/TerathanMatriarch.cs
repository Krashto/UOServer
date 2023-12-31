using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'une Therathan")]
    public class TerathanMatriarch : BaseCreature
    {
        [Constructable]
        public TerathanMatriarch()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = " Therathan Matriarche";
            Body = 72;
            BaseSoundID = 599;

            SetStr(316, 405);
            SetDex(96, 115);
            SetInt(366, 455);

            SetHits(190, 243);

            SetDamage(11, 14);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 45, 55);
            SetResistance(ResistanceType.Fire, 30, 40);
            SetResistance(ResistanceType.Cold, 35, 45);
            SetResistance(ResistanceType.Poison, 40, 50);
            SetResistance(ResistanceType.Energy, 35, 45);

            SetSkill(SkillName.EvalInt, 90.1, 100.0);
            SetSkill(SkillName.Magery, 90.1, 100.0);
            SetSkill(SkillName.MagicResist, 90.1, 100.0);
            SetSkill(SkillName.Tactics, 50.1, 70.0);
            SetSkill(SkillName.Wrestling, 60.1, 80.0);

            Fame = 10000;
            Karma = -10000;
        }

        public TerathanMatriarch(Serial serial)
            : base(serial)
        {
        }
		public override int Level => 10;
		public override Biome Biome => Biome.Savane;
		//public override int TreasureMapLevel => 4;

		public override int Hides => 10;
		public override HideType HideType => HideType.Arachnide;


		public override int Bones => 10;
		public override BoneType BoneType => BoneType.Arachnide;

		public override TribeType Tribe => TribeType.Terathan;

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
