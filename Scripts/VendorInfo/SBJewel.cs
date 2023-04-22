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

				Add(typeof(Citrine), 5);
				Add(typeof(Amber), 10);
				Add(typeof(Tourmaline), 15);
				Add(typeof(Ruby), 20);
				Add(typeof(Amethyst), 25);
				Add(typeof(Sapphire), 30);
				Add(typeof(StarSapphire), 35);
				Add(typeof(Emerald), 40);
				Add(typeof(Diamond), 50);

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
