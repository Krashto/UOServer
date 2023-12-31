using Server.Items;
using System;

namespace Server.Engines.Quests
{
    public class BrokenShaftQuest : BaseQuest
    {
        public BrokenShaftQuest()
            : base()
        {
            AddObjective(new ObtainObjective(typeof(Arrow), "arrows", 10, 0xF3F));

            AddReward(new BaseReward(typeof(FletcherCraftsmanSatchel), 1074282));
        }

        /* Broken Shaft */
        public override object Title => 1074018;
        /* What do humans know of archery? Humans can barely shoot straight. Why, your efforts are 
        absurd. In fact, I will make a wager - if these so called human arrows I've heard about are 
        really as effective and innovative as human braggarts would have me believe, then I'll trade 
        you something useful.  I might even teach you something of elven craftsmanship. */
        public override object Description => 1074112;
        /* Fine then, I'm shall find another to run my errands then. */
        public override object Refuse => 1074063;
        /* Hurry up! I don't have all day to wait for you to bring what I desire! */
        public override object Uncomplete => 1074064;
        /* These human made goods are laughable! It offends so -- I must show you what elven skill is capable of! */
        public override object Complete => 1074065;
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

    public class BendingTheBowQuest : BaseQuest
    {
        public BendingTheBowQuest()
            : base()
        {
            AddObjective(new ObtainObjective(typeof(Bow), "bows", 10, 0x13B2));

            AddReward(new BaseReward(typeof(FletcherCraftsmanSatchel), 1074282));
        }

        /* Bending the Bow */
        public override object Title => 1074019;
        /* Human craftsmanship! Ha! Why, take an elven bow. It will last for a lifetime, never break and 
        always shoot an arrow straight and true. Can't say the same for a human, can you? Bring me some 
        of these human made bows, and I will show you. */
        public override object Description => 1074113;
        /* Fine then, I'm shall find another to run my errands then. */
        public override object Refuse => 1074063;
        /* Hurry up! I don't have all day to wait for you to bring what I desire! */
        public override object Uncomplete => 1074064;
        /* These human made goods are laughable! It offends so -- I must show you what elven skill is capable of! */
        public override object Complete => 1074065;
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

    public class ArmsRaceQuest : BaseQuest
    {
        public ArmsRaceQuest()
            : base()
        {
            AddObjective(new ObtainObjective(typeof(Crossbow), "crossbows", 10, 0xF50));

            AddReward(new BaseReward(typeof(FletcherCraftsmanSatchel), 1074282));
        }

        /* Arms Race */
        public override object Title => 1074020;
        /* Leave it to a human to try and improve upon perfection. To take a bow and turn it into a mechanical 
        contraption like a crossbow. I wish to see more of this sort of "invention". Fetch for me a crossbow, 
        human. */
        public override object Description => 1074114;
        /* Fine then, I'm shall find another to run my errands then. */
        public override object Refuse => 1074063;
        /* Hurry up! I don't have all day to wait for you to bring what I desire! */
        public override object Uncomplete => 1074064;
        /* These human made goods are laughable! It offends so -- I must show you what elven skill is capable of! */
        public override object Complete => 1074065;
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

    public class ImprovedCrossbowsQuest : BaseQuest
    {
        public ImprovedCrossbowsQuest()
            : base()
        {
            AddObjective(new ObtainObjective(typeof(HeavyCrossbow), "heavy crossbows", 10, 0x13FD));

            AddReward(new BaseReward(typeof(FletcherCraftsmanSatchel), 1074282));
        }

        /* Improved Crossbows */
        public override object Title => 1074021;
        /* How lazy is man! You cannot even be bothered to pull your own drawstring and hold an arrow ready? You 
        must invent a device to do it for you? I cannot understand, but perhaps if I examine a heavy crossbow for 
        myself, I will see their appeal. Go and bring me such a device and I will repay your meager favor. */
        public override object Description => 1074115;
        /* Fine then, I'm shall find another to run my errands then. */
        public override object Refuse => 1074063;
        /* Hurry up! I don't have all day to wait for you to bring what I desire! */
        public override object Uncomplete => 1074064;
        /* These human made goods are laughable! It offends so -- I must show you what elven skill is capable of! */
        public override object Complete => 1074065;
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

    public class BuildingTheBetterCrossbowQuest : BaseQuest
    {
        public BuildingTheBetterCrossbowQuest()
            : base()
        {
            AddObjective(new ObtainObjective(typeof(RepeatingCrossbow), "repeating crossbow", 10, 0x26C3));

            AddReward(new BaseReward(typeof(FletcherCraftsmanSatchel), 1074282));
        }

        /* Building the Better Crossbow */
        public override object Title => 1074022;
        /* More is always better for a human, eh? Take these repeating crossbows. What sort of mind invents such a thing? 
        I must look at it more closely. Bring such a contraption to me and you'll receive a token for your efforts. */
        public override object Description => 1074116;
        /* Fine then, I'm shall find another to run my errands then. */
        public override object Refuse => 1074063;
        /* Hurry up! I don't have all day to wait for you to bring what I desire! */
        public override object Uncomplete => 1074064;
        /* These human made goods are laughable! It offends so -- I must show you what elven skill is capable of! */
        public override object Complete => 1074065;
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

    public class Beotham : MondainQuester
    {
        [Constructable]
        public Beotham()
            : base("Beotham", "the bowcrafter")
        {
        }

        public Beotham(Serial serial)
            : base(serial)
        {
        }

        public override Type[] Quests => new Type[]
                {
                    typeof(BrokenShaftQuest),
                    typeof(BendingTheBowQuest),
                    typeof(ArmsRaceQuest),
                    typeof(ImprovedCrossbowsQuest),
                    typeof(BuildingTheBetterCrossbowQuest)
                };
        public override void InitBody()
        {
            InitStats(100, 100, 25);

            Female = false;
            CantWalk = true;
            

            Hue = 0x876C;
            HairItemID = 0x2FC0;
            HairHue = 0x238;
        }

        public override void InitOutfit()
        {
            AddItem(new Sandals(0x901));
            AddItem(new LongPants(0x52C));
            AddItem(new FancyShirt(0x546));

            Item item;

            item = new LeafGloves
            {
                Hue = 0x901
            };
            AddItem(item);
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