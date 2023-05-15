using Server.Items;

namespace Server.Mobiles
{
    [TypeAlias("Server.Mobiles.HumanBrigand")]
    public class BrigandMage : BaseCreature
    {
        [Constructable]
        public BrigandMage()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
		{

			Race = Race.Human;
            SpeechHue = Utility.RandomDyedHue();
            Title = " Brigand";
           	Race = BaseRace.GetRace(Utility.Random(4));

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
			AddItem(new Robe(Utility.RandomNeutralHue()));
			AddItem(new ChapeauMage());
			AddItem(new Backpack());

			SetStr(86, 100);
            SetDex(81, 95);
            SetInt(61, 75);
			SetHits(58, 72);
			SetDamage(10, 23);
			
            SetSkill(SkillName.Fencing, 66.0, 97.5);
            SetSkill(SkillName.Macing, 65.0, 87.5);
            SetSkill(SkillName.MagicResist, 25.0, 47.5);
            SetSkill(SkillName.Swords, 65.0, 87.5);
            SetSkill(SkillName.Tactics, 65.0, 87.5);
            SetSkill(SkillName.Wrestling, 15.0, 37.5);

            Utility.AssignRandomHair(this);
        }

        public BrigandMage(Serial serial)
            : base(serial)
        {
        }
		public override int Level => 6;
		public override Biome Biome => Biome.Colline;
		public override TribeType Tribe => TribeType.Brigand;

		public override bool ClickTitle => false;
        public override bool AlwaysMurderer => true;

        public override bool ShowFameTitle => false;

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

//            if (Utility.RandomDouble() < 0.75)
  //              c.DropItem(new SeveredHumanEars());
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Average);
			AddLoot(LootPack.Others, Utility.RandomMinMax(3, 4));
		}

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