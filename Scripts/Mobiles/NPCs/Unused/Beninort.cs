using Server.Items;
using System;

namespace Server.Engines.Quests
{
    public class Beninort : MondainQuester
    {
        [Constructable]
        public Beninort()
            : base("Beninort", "the Artificer")
        {
            SetSkill(SkillName.ItemID, 60.0, 83.0);
            SetSkill(SkillName.Imbuing, 60.0, 83.0);
        }

        public Beninort(Serial serial)
            : base(serial)
        {
        }

        public override Type[] Quests => new Type[]
                {
                    typeof(SecretsoftheSoulforge)
                };
        public override void InitBody()
        {
            InitStats(100, 100, 25);

            CantWalk = true;
            

            Hue = 0x86E8;
            HairItemID = 0x4258;
            HairHue = 0x31D;
        }

        public override void InitOutfit()
        {
            AddItem(new SerpentStoneStaff());
            AddItem(new ClothChest(1609));
            AddItem(new ClothArms(1651));
            AddItem(new ClothKilt(1649));
        }

        public override void Advertise()
        {
            Say(1112521);  // Know the secrets. Learn of the soulforge.
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