using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a clan scratch tinkerer corpse")]
    public class ClanCT : BaseCreature
    {
        [Constructable]
        public ClanCT()
            : base(AIType.AI_Archer, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Clan Scratch Tinkerer";
            Body = 0x8E;
            BaseSoundID = 437;

			AddItem(new Bow());

			SetStr(300, 330);
            SetDex(220, 240);
            SetInt(240, 275);

            SetHits(2025, 2068);

            SetDamage(4, 10);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 20, 30);
            SetResistance(ResistanceType.Fire, 20, 30);
            SetResistance(ResistanceType.Cold, 35, 50);
            SetResistance(ResistanceType.Poison, 10, 20);
            SetResistance(ResistanceType.Energy, 10, 20);

            SetSkill(SkillName.Anatomy, 62.5, 82.6);
            SetSkill(SkillName.Archery, 80.1, 90.0);
            SetSkill(SkillName.MagicResist, 76.8, 99.3);
            SetSkill(SkillName.Tactics, 64.2, 84.4);
            SetSkill(SkillName.Wrestling, 62.8, 85.0);
        }

        public ClanCT(Serial serial)
            : base(serial)
        {
        }

        public override bool CanRummageCorpses => true;
		public override int Hides => 8;
		public override HideType HideType => HideType.Regular;

		public override int Bones => 12;
		public override BoneType BoneType => BoneType.Regular;
		
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
