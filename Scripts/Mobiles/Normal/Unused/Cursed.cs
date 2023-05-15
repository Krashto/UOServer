using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("an inhuman corpse")]
    public class Cursed : BaseCreature
    {
        [Constructable]
        public Cursed()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
          

        
            Body = 0x190;
			Female = Utility.RandomBool();
			Race = Race.DefaultRace;

			if (Female)
			{
				Name = NameList.RandomName("female");
				Title = "La Maudite";
			}
			else
			{
				Name = NameList.RandomName("male");
				Title = "Le Maudit";
			}
          
            BaseSoundID = 471;		

			Hue = Utility.RandomMinMax(0x8596, 0x8599);

			if (FindItemOnLayer(Layer.Shirt) != null && FindItemOnLayer(Layer.Shirt)  is BaseRaceGumps bg)
			{
				bg.Hue = Hue;
			}

			AddItem(new ShortPants(Utility.RandomNeutralHue()));
            AddItem(new Shirt(Utility.RandomNeutralHue()));

			BaseWeapon weapon = Loot.RandomWeapon();
			weapon.Movable = false;
			AddItem(weapon);

			SetStr(91, 100);
            SetDex(86, 95);
            SetInt(61, 70);

            SetHits(91, 120);

            SetDamage(5, 13);

            SetResistance(ResistanceType.Physical, 15, 25);
            SetResistance(ResistanceType.Fire, 5, 10);
            SetResistance(ResistanceType.Cold, 25, 35);
            SetResistance(ResistanceType.Poison, 5, 10);
            SetResistance(ResistanceType.Energy, 5, 10);

            SetSkill(SkillName.Fencing, 46.0, 77.5);
            SetSkill(SkillName.Macing, 35.0, 57.5);
            SetSkill(SkillName.MagicResist, 53.5, 62.5);
            SetSkill(SkillName.Swords, 55.0, 77.5);
            SetSkill(SkillName.Tactics, 60.0, 82.5);
            SetSkill(SkillName.Poisoning, 60.0, 82.5);
        }

        public Cursed(Serial serial)
            : base(serial)
        {
        }

        public override bool ClickTitle => false;
        public override bool ShowFameTitle => false;
        public override bool AlwaysMurderer => true;
        public override int GetAttackSound()
        {
            return -1;
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