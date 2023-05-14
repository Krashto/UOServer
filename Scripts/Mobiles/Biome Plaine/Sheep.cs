using Server.Engines.Quests;
using Server.Items;
using Server.Network;
using System;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'un Mouton")]
    public class Sheep : BaseCreature, ICarvable
    {
        private DateTime m_NextWoolTime;
        [Constructable]
        public Sheep()
            : base(AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = " Mouton";
            Body = 0xCF;
            BaseSoundID = 0xD6;


			SetStr(45, 70);
			SetDex(30, 50);
			SetInt(25, 40);

			SetHits(50, 65);

			SetDamage(6, 10);

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
         //   Karma = 0;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 11.1;
        }

		public override int Level => 1;
		public override Biome Biome => Biome.Plaine;

		public override bool CanBeParagon => false;
		public Sheep(Serial serial)
            : base(serial)
        {
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public DateTime NextWoolTime
        {
            get
            {
                return m_NextWoolTime;
            }
            set
            {
                m_NextWoolTime = value;
                Body = (DateTime.UtcNow >= m_NextWoolTime) ? 0xCF : 0xDF;
            }
        }
        public override int Meat => 3;
		public override int Hides => 4;
		public override HideType HideType => HideType.Regular;


		public override int Bones => 4;
		public override BoneType BoneType => BoneType.Regular;
		public override MeatType MeatType => MeatType.LambLeg;
        public override FoodType FavoriteFood => FoodType.FruitsAndVegies | FoodType.GrainsAndHay;
        public override int Wool => (Body == 0xCF ? 3 : 0);
        public bool Carve(Mobile from, Item item)
        {
            if (DateTime.UtcNow < m_NextWoolTime)
            {
                // This sheep is not yet ready to be shorn.
                PrivateOverheadMessage(MessageType.Regular, 0x3B2, 500449, from.NetState);
                return false;
            }

            from.SendLocalizedMessage(500452); // You place the gathered wool into your backpack.
            from.AddToBackpack(new Wool(Map == Map.Felucca ? 2 : 1));

            if (from is PlayerMobile)
            {
                PlayerMobile player = (PlayerMobile)from;
                foreach (BaseQuest quest in player.Quests)
                {
                    if (quest is ShearingKnowledgeQuest)
                    {
                        if (!quest.Completed &&
                            (from.Map == Map.Trammel || from.Map == Map.Felucca))
                        {
                            from.AddToBackpack(new BritannianWool(1));
                        }
                        break;
                    }
                }
            }

            NextWoolTime = DateTime.UtcNow + TimeSpan.FromHours(2.0); // TODO: Proper time delay

            return true;
        }

        public override void OnThink()
        {
            base.OnThink();
            Body = (DateTime.UtcNow >= m_NextWoolTime) ? 0xCF : 0xDF;
        }

		public override void GenerateLoot()
		{
			AddLoot(LootPack.LootItem<RawLambLegExp>(), Utility.RandomMinMax(0, 2));
			AddLoot(LootPack.LootItem<RawMuttonRoast>(), Utility.RandomMinMax(0, 2));
			AddLoot(LootPack.LootItem<RawMuttonSteak>(), Utility.RandomMinMax(0, 2));
		}

		public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(1);

            writer.WriteDeltaTime(m_NextWoolTime);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 1:
                    {
                        NextWoolTime = reader.ReadDeltaTime();
                        break;
                    }
            }
        }
    }
}
