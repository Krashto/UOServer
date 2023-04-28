using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'un Loup")]
    [TypeAlias("Server.Mobiles.Direwolf")]
    public class DireWolf : BaseCreature
    {
        [Constructable]
        public DireWolf()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = " Loup Sauvage";
            Body = 23;
            BaseSoundID = 0xE5;

			SetStr(124, 192);
			SetDex(83, 137);
			SetInt(69, 109);

			SetHits(118, 179);

			SetDamage(17, 28);

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



			//	Fame = 2500;
			//    Karma = -2500;

			Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 83.1;
        }
		public override int Level => 4;
		public override Biome Biome => Biome.Foret;
		public override bool CanBeParagon => false;
		public DireWolf(Serial serial)
            : base(serial)
        {
        }

        public override bool IsEnemy(Mobile m)
        {
            if (m is BaseCreature && ((BaseCreature)m).IsMonster && m.Karma > 0)
            {
                return true;
            }

            return base.IsEnemy(m);
        }

        public override int Meat => 1;
        public override int Hides => 5;
        public override HideType HideType => HideType.Lupus;

		public override int Bones => 5;
		public override BoneType BoneType => BoneType.Lupus;


		public override void GenerateLoot()
		{
			AddLoot(LootPack.LootItem<PoilsLoup>());
		}
		




		public override FoodType FavoriteFood => FoodType.Meat;
        public override PackInstinct PackInstinct => PackInstinct.Canine;
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