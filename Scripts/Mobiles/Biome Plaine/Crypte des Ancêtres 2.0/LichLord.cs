using System;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'un Seigneur Liche")]
    public class LichLord : BaseCreature
    {
        [Constructable]
        public LichLord()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = " Seigneur Liche";
            Body = 79;
            BaseSoundID = 412;

			SetStr(199, 355);
			SetDex(132, 220);
			SetInt(110, 177);

			SetHits(231, 351);

			SetDamage(26, 45);

			SetDamageType(ResistanceType.Poison, 50);
			SetDamageType(ResistanceType.Cold, 50);

			SetResistance(ResistanceType.Physical, 25, 25);
			SetResistance(ResistanceType.Fire, 25, 25);
			SetResistance(ResistanceType.Cold, 75, 75);
			SetResistance(ResistanceType.Poison, 75, 75);
			SetResistance(ResistanceType.Energy, 75, 75);

			SetSkill(SkillName.EvalInt, 50.1, 55.0);
			SetSkill(SkillName.Magery, 50.1, 55.0);
			SetSkill(SkillName.Meditation, 50.1, 55.0);


			SetSkill(SkillName.MagicResist, 35.1, 55.0);
			SetSkill(SkillName.Tactics, 50.1, 55.0);
			SetSkill(SkillName.Wrestling, 50.1, 55.0);

		//	Fame = 18000;
        //    Karma = -18000;
        }

        public LichLord(Serial serial)
            : base(serial)
        {
        }

		public override int Level => 6;
		public override Biome Biome => Biome.Plaine;

		public override TribeType Tribe => TribeType.Undead;


        public override bool CanRummageCorpses => true;
        public override bool BleedImmune => true;
        public override Poison PoisonImmune => Poison.Lethal;
        //public override int TreasureMapLevel => 4;
        public override void GenerateLoot()
        {
            AddLoot(LootPack.FilthyRich);
       //AddLoot(LootPack.MedScrolls, 2);
            AddLoot(LootPack.NecroRegs, 12, 40);
        }

		public override void OnDeath(Container c)
		{
			base.OnDeath(c);

			if (Utility.RandomDouble() < 0.06)
				c.DropItem(new AmeSeigneurLiche());
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
