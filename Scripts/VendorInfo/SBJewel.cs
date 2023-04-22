using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles
{
    public class SBJewel : SBInfo
    {
        private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

        public override IShopSellInfo SellInfo => m_SellInfo;
        public override List<GenericBuyInfo> BuyInfo => m_BuyInfo;

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
				Add(new GenericBuyInfo(typeof(Amber), 80, Utility.RandomMinMax(15, 25), 0xF25, 0));
				Add(new GenericBuyInfo(typeof(Bracelet1), 250, Utility.RandomMinMax(15, 25), 0x1F06, 0));
				Add(new GenericBuyInfo(typeof(Necklace), 250, Utility.RandomMinMax(15, 25), 0x1F08, 0));
				Add(new GenericBuyInfo(typeof(Earrings), 125, Utility.RandomMinMax(15, 25), 0x1F07, 0));
				Add(new GenericBuyInfo(typeof(Ring1), 125, Utility.RandomMinMax(15, 25), 0x1F09, 0));
			}
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {

				Add(typeof(Citrine), 5);
				Add(typeof(Amber), 8);
				Add(typeof(Tourmaline), 10);
				Add(typeof(Ruby), 12);
				Add(typeof(Amethyst), 15);
				Add(typeof(Sapphire), 28);
				Add(typeof(StarSapphire), 20);
				Add(typeof(Emerald), 22);
				Add(typeof(Diamond), 25);

				Add(typeof(GoldRing), 13);
                Add(typeof(SilverRing), 10);
                Add(typeof(Necklace), 13);
                Add(typeof(GoldNecklace), 13);
                Add(typeof(GoldBeadNecklace), 13);
                Add(typeof(SilverNecklace), 10);
                Add(typeof(SilverBeadNecklace), 10);
                Add(typeof(Beads), 13);
                Add(typeof(GoldBracelet), 13);
                Add(typeof(SilverBracelet), 10);
                Add(typeof(GoldEarrings), 13);
                Add(typeof(SilverEarrings), 10);
            }
        }
    }
}
