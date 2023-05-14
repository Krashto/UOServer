using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'un Gazer")]
    public class GazerLarva : BaseCreature
    {
        [Constructable]
        public GazerLarva()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = " Gazer Brule";
            Body = 778;
            BaseSoundID = 377;

			SetStr(229, 408);
			SetDex(151, 253);
			SetInt(126, 203);

			SetHits(323, 491);

			SetDamage(30, 51);

			SetDamageType(ResistanceType.Energy, 50);
			SetDamageType(ResistanceType.Poison, 50);


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
        }

        public GazerLarva(Serial serial)
            : base(serial)
        {
        }
		public override int Level => 7;
		public override Biome Biome => Biome.Foret;
		public override int Meat => 1;
        public override void GenerateLoot()
        {
            AddLoot(LootPack.LootItem<Nightshade>(2, 3));
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
