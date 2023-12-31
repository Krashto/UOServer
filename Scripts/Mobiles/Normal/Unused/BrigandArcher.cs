using Server.Items;

namespace Server.Mobiles
{
  
    public class BrigandArcher : BaseCreature
    {
        [Constructable]
        public BrigandArcher()
            : base(AIType.AI_Archer, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
			Race = Race.Human;
			SpeechHue = Utility.RandomDyedHue();
            Title = " Brigand";
           	Race = BaseRace.GetRace(Utility.Random(4));
			ForceActiveSpeed = 0.20;
			ForcePassiveSpeed = 0.20;

			if (Female = Utility.RandomBool())
            {
                Body = 0x191;
                Name = NameList.RandomName("female");
                AddItem(new Skirt(Utility.RandomNeutralHue()));
            }
            else
            {
                Body = 0x190;
                Name = NameList.RandomName("male");
                AddItem(new ShortPants(Utility.RandomNeutralHue()));
            }

			AddItem(new Boots(Utility.RandomNeutralHue()));
			AddItem(new FancyShirt());
			AddItem(new Bandana());

			AddItem(new Bow());

			SetStr(86, 100);
            SetDex(81, 95);
            SetInt(61, 75);
			SetHits(58, 72);
			SetDamage(10, 23);

            SetSkill(SkillName.MagicResist, 25.0, 47.5);
            SetSkill(SkillName.Archery, 65.0, 87.5);
            SetSkill(SkillName.Tactics, 65.0, 87.5);
            SetSkill(SkillName.Wrestling, 15.0, 37.5);
			

			Utility.AssignRandomHair(this);
        }

        public BrigandArcher(Serial serial)
            : base(serial)
        {
        }

		
		public override int Level => 6;
		public override Biome Biome => Biome.Colline;
		public override TribeType Tribe => TribeType.Brigand;

		public override bool ClickTitle => false;
        public override bool AlwaysMurderer => true;

        public override bool ShowFameTitle => false;

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