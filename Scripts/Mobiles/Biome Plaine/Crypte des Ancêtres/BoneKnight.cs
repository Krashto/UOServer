using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'un Chevalier d'Os")]
    public class BoneKnight : BaseCreature
    {
        [Constructable]
        public BoneKnight()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = " Chevalier d'Os";
            Body = 57;
            BaseSoundID = 451;

			SetStr(63, 98);
			SetDex(42, 70);
			SetInt(35, 56);

			SetHits(70, 91);

			SetDamage(9, 14);


			SetDamageType(ResistanceType.Poison, 50);
			SetDamageType(ResistanceType.Cold, 50);

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

		//	Fame = 3000;
        //    Karma = -3000;
        }

        public BoneKnight(Serial serial)
            : base(serial)
        {
        }
		public override int Level => 4;
		public override Biome Biome => Biome.Plaine;
		public override bool BleedImmune => true;

        public override TribeType Tribe => TribeType.Undead;

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
