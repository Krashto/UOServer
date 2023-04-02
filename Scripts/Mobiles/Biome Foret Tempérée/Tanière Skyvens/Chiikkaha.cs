namespace Server.Mobiles
{
    [CorpseName("Le Corps de Chiikkaha l'edente")]
    public class Chiikkaha : RatmanMage
    {
        [Constructable]
        public Chiikkaha()
        {
            Name = "Chiikkaha l'edente";

			SetStr(229, 408);
			SetDex(151, 253);
			SetInt(126, 203);

			SetHits(887, 1348);

			SetDamage(45, 77);

			SetDamageType(ResistanceType.Physical, 100);


			SetResistance(ResistanceType.Physical, 75, 75);
			SetResistance(ResistanceType.Fire, 25, 25);
			SetResistance(ResistanceType.Cold, 25, 25);
			SetResistance(ResistanceType.Poison, 25, 25);
			SetResistance(ResistanceType.Energy, 25, 25);

			SetSkill(SkillName.EvalInt, 50.1, 55.0);
			SetSkill(SkillName.Magery, 50.1, 55.0);
			SetSkill(SkillName.Meditation, 50.1, 55.0);


			SetSkill(SkillName.MagicResist, 35.1, 55.0);
			SetSkill(SkillName.Tactics, 50.1, 55.0);
			SetSkill(SkillName.Wrestling, 50.1, 55.0);


		//	Fame = 7500;
        //    Karma = -7500;
        }

        public Chiikkaha(Serial serial)
            : base(serial)
        {
        }
		
		public override void GenerateLoot()
		{
			AddLoot(LootPack.Rich);
			AddLoot(LootPack.LootItem<Items.Gold>(50, 100));
			base.GenerateLoot();
		}
		public override int Level => 10;
		public override Biome Biome => Biome.Foret;
		public override bool CanBeParagon => false;
		
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}