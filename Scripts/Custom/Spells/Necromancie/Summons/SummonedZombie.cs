using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'un Zombie")]
    public class SummonedZombie : BaseCreature
    {
        [Constructable]
        public SummonedZombie() : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Un Zombie";
            Body = 3;
            BaseSoundID = 471;

			SetStr(63, 98);
			SetDex(42, 70);
			SetInt(35, 56);

			SetHits(70, 91);

			SetDamage(9, 14);

			SetDamageType(ResistanceType.Physical, 50);
			SetDamageType(ResistanceType.Cold, 50);

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
		}

		public SummonedZombie(Serial serial)
            : base(serial)
        {
        }
		public override int Level => 1;
		public override bool BleedImmune => true;
        public override Poison PoisonImmune => Poison.Regular;
		public override bool DeleteOnRelease => true;
		public override bool DeleteCorpseOnDeath => true;

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
