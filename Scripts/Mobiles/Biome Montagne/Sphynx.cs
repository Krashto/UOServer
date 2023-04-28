using Server.ContextMenus;
using Server.Engines.SphynxFortune;
using Server.Gumps;
using Server.Network;
using System.Collections.Generic;

namespace Server.Mobiles
{
    public class Sphynx : BaseMount
	{
		public Sphynx() : this(" Loup Géant")
		{
		}

		[Constructable]
		public Sphynx(string name) : base(name, 788, 0x314, AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)

		{
			Body = 788;
            Name = " Loup Géant";

            SetStr(1001, 1200);
            SetDex(176, 195);
            SetInt(301, 400);

            SetHits(1001, 1200);
            SetStam(176, 195);
            SetMana(301, 400);

            SetDamage(10, 15);

            SetDamageType(ResistanceType.Physical, 85);
            SetDamageType(ResistanceType.Energy, 15);

            SetResistance(ResistanceType.Physical, 60, 80);
            SetResistance(ResistanceType.Fire, 30, 50);
            SetResistance(ResistanceType.Cold, 40, 60);
            SetResistance(ResistanceType.Poison, 40, 50);
            SetResistance(ResistanceType.Energy, 40, 50);

            SetSkill(SkillName.Wrestling, 90.1, 100.0);
            SetSkill(SkillName.Tactics, 90.1, 100.0);
            SetSkill(SkillName.MagicResist, 100.5, 150.0);
            SetSkill(SkillName.Magery, 95.5, 100.0);
            SetSkill(SkillName.Anatomy, 25.1, 50.0);
            SetSkill(SkillName.EvalInt, 90.1, 100.0);
            SetSkill(SkillName.Meditation, 95.1, 120.0);
            SetSkill(SkillName.Tracking, 100.0);

         //   Fame = 15000;
         //   Karma = 0;
        }
		public override int Level => 5;
		public override Biome Biome => Biome.Montagne;
		public override void GenerateLoot()
        {
            AddLoot(LootPack.Rich, 2);
            //AddLoot(LootPack.LootGold(1000, 1200));
    }


        public Sphynx(Serial serial)
            : base(serial)
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
        }

                }
            }

