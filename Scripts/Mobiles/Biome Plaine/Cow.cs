using System;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'une Vache")]
    public class Cow : BaseCreature
    {
        private DateTime m_MilkedOn;
        private int m_Milk;

        [Constructable]
        public Cow()
            : base(AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = "Une Vache";
            Body = Utility.RandomList(0xD8, 0xE7);
            BaseSoundID = 0x78;

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


		//	Fame = 300;
        //    Karma = 0;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 11.1;

            if (Utility.Random(1000) == 0) // 0.1% chance to have mad cows
                FightMode = FightMode.Closest;
        }
		public override int Level => 2;
		public override Biome Biome => Biome.Plaine;
		public override bool CanBeParagon => false;
		public Cow(Serial serial)
            : base(serial)
        {
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public DateTime MilkedOn
        {
            get
            {
                return m_MilkedOn;
            }
            set
            {
                m_MilkedOn = value;
            }
        }
        [CommandProperty(AccessLevel.GameMaster)]
        public int Milk
        {
            get
            {
                return m_Milk;
            }
            set
            {
                m_Milk = value;
            }
        }
        public override int Meat => 8;
        public override int Hides => 12;
        public override FoodType FavoriteFood => FoodType.FruitsAndVegies | FoodType.GrainsAndHay;
        public override void OnDoubleClick(Mobile from)
        {
            base.OnDoubleClick(from);

            int random = Utility.Random(100);

            if (random < 5)
                Tip();
            else if (random < 20)
                PlaySound(120);
            else if (random < 40)
                PlaySound(121);
        }

        public void Tip()
        {
            PlaySound(121);
            Animate(8, 0, 3, true, false, 0);
        }

        public bool TryMilk(Mobile from)
        {
            if (!from.InLOS(this) || !from.InRange(Location, 2))
                from.SendLocalizedMessage(1080400); // You can not milk the cow from this location.
            if (Controlled && ControlMaster != from)
                from.SendLocalizedMessage(1071182); // The cow nimbly escapes your attempts to milk it.
            if (m_Milk == 0 && m_MilkedOn + TimeSpan.FromDays(1) > DateTime.UtcNow)
                from.SendLocalizedMessage(1080198); // This cow can not be milked now. Please wait for some time.
            else
            {
                if (m_Milk == 0)
                    m_Milk = 4;

                m_MilkedOn = DateTime.UtcNow;
                m_Milk--;

                return true;
            }

            return false;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);

            writer.Write(m_MilkedOn);
            writer.Write(m_Milk);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            m_MilkedOn = reader.ReadDateTime();
            m_Milk = reader.ReadInt();
        }
    }
}
