using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'une Liche Squelettique")]
    public class SkeletalLich : BaseCreature
    {
        [Constructable]
        public SkeletalLich() : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Une Liche Squelettique";
            Body = 309;
            Hue = 1345;
            BaseSoundID = 0x48D;

			SetStr(199, 355);
			SetDex(132, 220);
			SetInt(110, 177);

			SetHits(1241, 1887);

			SetDamage(26, 45);

			SetDamageType(ResistanceType.Poison, 50);
			SetDamageType(ResistanceType.Cold, 50);

			SetResistance(ResistanceType.Physical, 25, 25);
			SetResistance(ResistanceType.Fire, 25, 25);
			SetResistance(ResistanceType.Cold, 75, 75);
			SetResistance(ResistanceType.Poison, 75, 75);
			SetResistance(ResistanceType.Energy, 75, 75);

			SetSkill(SkillName.EvalInt, 55.1, 65.0);
			SetSkill(SkillName.Magery, 55.1, 65.0);
			SetSkill(SkillName.Meditation, 55.1, 65.0);


			SetSkill(SkillName.MagicResist, 45.1, 60.0);
			SetSkill(SkillName.Tactics, 55.1, 65.0);
			SetSkill(SkillName.Wrestling, 55.1, 65.0);

		//	Fame = 6000;
        //    Karma = -6000;

            SetWeaponAbility(WeaponAbility.Dismount);
        }

        public SkeletalLich(Serial serial) : base(serial)
        {
        }
		
        public override bool BleedImmune => true;
		
        public override Poison PoisonImmune => Poison.Lethal;
		
        public override int TreasureMapLevel => 1;



        public override void GenerateLoot()
        {
            AddLoot(LootPack.FilthyRich, 2);

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
