using Server.Mobiles;

namespace Server.Items
{
    public class GemMiningBook : Item
    {
        public override int LabelNumber => 1112240;  // Mining for Quality Gems

        [Constructable]
        public GemMiningBook()
            : base(0xFBE)
        {
            Weight = 5.0;
			Name = "Connaissance Gems";
        }

        public GemMiningBook(Serial serial)
            : base(serial)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
            PlayerMobile pm = from as PlayerMobile;

            if (pm == null)
            {
                return;
            }

            if (!IsChildOf(pm.Backpack))
            {
                pm.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
            }
            else if (pm.Skills[SkillName.Mining].Base < 50.0)
			{
				pm.SendMessage("Vous devez avoir 50.0 dans votre skill de Mining"); // Only a Grandmaster Miner can learn from this book.
			}
            else if (pm.GemMining)
            {
                pm.SendLocalizedMessage(1080064); // You have already learned this knowledge.
            }
            else
            {
                pm.GemMining = true;
                pm.SendLocalizedMessage(1112238); // You have learned to mine for gems.  Target mountains when mining to find gems.

                Delete();
            }
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
