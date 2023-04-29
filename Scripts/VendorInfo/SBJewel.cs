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
				Add(new GenericBuyInfo(typeof(GoldRing), 250, 20, 0x108A, 0));
				Add(new GenericBuyInfo(typeof(Necklace), 250, 20, 0x1085, 0));
				Add(new GenericBuyInfo(typeof(GoldNecklace), 250, 20, 0x1088, 0));
				Add(new GenericBuyInfo(typeof(GoldBeadNecklace), 250, 20, 0x1089, 0));
				Add(new GenericBuyInfo(typeof(Beads), 250, 20, 0x108B, 0, true));
				Add(new GenericBuyInfo(typeof(GoldBracelet), 250, 20, 0x1086, 0));
				Add(new GenericBuyInfo(typeof(GoldEarrings), 250, 20, 0x1087, 0));
			}
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {

				Add(typeof(Citrine), 1);
				Add(typeof(Amber), 2);
				Add(typeof(Tourmaline), 3);
				Add(typeof(Ruby), 4);
				Add(typeof(Amethyst), 5);
				Add(typeof(Sapphire), 6);
				Add(typeof(StarSapphire), 7);
				Add(typeof(Emerald), 8);
				Add(typeof(Diamond), 10);

				Add(typeof(GoldRing), 7);
                Add(typeof(SilverRing), 5);
                Add(typeof(Necklace), 5);
                Add(typeof(GoldNecklace), 7);
                Add(typeof(GoldBeadNecklace), 7);
                Add(typeof(SilverNecklace), 6);
                Add(typeof(SilverBeadNecklace), 6);
                Add(typeof(Beads), 5);
                Add(typeof(GoldBracelet), 7);
                Add(typeof(SilverBracelet), 6);
                Add(typeof(GoldEarrings), 7);
                Add(typeof(SilverEarrings), 6);
            }
        }
    }
}
