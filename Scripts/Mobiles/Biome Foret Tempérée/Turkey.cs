using System;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'une Dinde")]
    public class Turkey : BaseCreature
    {
        [Constructable]
        public Turkey() : this(false)
        {
        }

        [Constructable]
        public Turkey(bool tamable) : base(AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = "Une Dinde";
            Body = 95;
            BaseSoundID = 0x66A;

			SetStr(63, 98);
			SetDex(42, 70);
			SetInt(35, 56);

			SetHits(70, 91);

			SetDamage(9, 14);

			SetDamageType(ResistanceType.Physical, 100);
		

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

	//		Fame = 150;
   //         Karma = 0;

            Tamable = tamable;
            ControlSlots = 1;
            MinTameSkill = -0.9;

            m_NextGobble = DateTime.UtcNow;
        }

        public override int Meat => 5;
        public override MeatType MeatType => MeatType.Bird;
        public override FoodType FavoriteFood => FoodType.GrainsAndHay;
        public override int Feathers => 25;

        public override int GetIdleSound()
        {
            return 0x66A;
        }

        public override int GetAngerSound()
        {
            return 0x66A;
        }

        public override int GetHurtSound()
        {
            return 0x66B;
        }

        public override int GetDeathSound()
        {
            return 0x66B;
        }

        private DateTime m_NextGobble;

        public override void OnThink()
        {
            base.OnThink();

            if (Tamable && !Controlled && m_NextGobble < DateTime.UtcNow)
            {
                Say(1153511); //*gobble* *gobble*
                PlaySound(GetIdleSound());

                m_NextGobble = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(20, 240));
            }
        }

        public Turkey(Serial serial) : base(serial)
        {
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

            m_NextGobble = DateTime.UtcNow;
        }
    }
}
