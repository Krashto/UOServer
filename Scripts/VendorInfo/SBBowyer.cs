using Server.Items;
using System.Collections.Generic;

namespace Server.Mobiles
{
    public class SBBowyer : SBInfo
    {
        private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

        public override IShopSellInfo SellInfo => m_SellInfo;
        public override List<GenericBuyInfo> BuyInfo => m_BuyInfo;

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
				Add(new GenericBuyInfo(typeof(TrainingBow), 50, 20, 0x13B2, 0));
				Add(new GenericBuyInfo(typeof(FletcherTools), 2, 20, 0x1022, 0));

				Add(new GenericBuyInfo(typeof(Arrow), 3, 999, 0xF3F, 0, true));
				Add(new GenericBuyInfo(typeof(Bolt), 3, 999, 0x1BFB, 0, true));
			}
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add(typeof(FletcherTools), 1);
				Add(typeof(Arrow), 1);
				Add(typeof(Bolt), 1);
			}
        }
    }
}
