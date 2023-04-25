using System;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'une Liche")]
    public class SummonedLich : BaseCreature
    {
        [Constructable]
        public SummonedLich()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Une Liche";
            Body = 24;
            BaseSoundID = 0x3E9;

			SetStr(89, 137);
			SetDex(59, 98);
			SetInt(59, 79);

			SetHits(84, 128);

			SetDamage(12, 20);

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
        }

		public SummonedLich(Serial serial)
            : base(serial)
        {
        }


		public override int Level => 4;
        public override bool BleedImmune => true;
        public override Poison PoisonImmune => Poison.Lethal;
        
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
