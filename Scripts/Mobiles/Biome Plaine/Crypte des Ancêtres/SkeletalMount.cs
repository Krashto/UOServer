namespace Server.Mobiles
{
    [CorpseName("Le Corps d'un Cheval Squelettique")]
    public class SkeletalMount : BaseMount
    {
        [Constructable]
        public SkeletalMount()
            : this("Un Cheval Squelettique")
        {
        }

        [Constructable]
        public SkeletalMount(string name)
            : base(name, 793, 0x3EBB, AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
			SetStr(45, 70);
			SetDex(30, 50);
			SetInt(25, 40);

			SetHits(50, 65);

			SetDamage(6, 10);

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

			//      Fame = 0;
			//      Karma = 0;
		}

        public SkeletalMount(Serial serial)
            : base(serial)
        {
        }

        public override Poison PoisonImmune => Poison.Lethal;
        public override bool BleedImmune => true;
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(1); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 0:
                    {
                        Name = "Un Cheval Squelettique";
                        Tamable = false;
                        MinTameSkill = 0.0;
                        ControlSlots = 0;
                        break;
                    }
            }
        }
    }
}
