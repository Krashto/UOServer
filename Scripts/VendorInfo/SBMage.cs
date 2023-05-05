using Server.Custom.Items.Spells;
using Server.Items;
using System;
using System.Collections.Generic;

namespace Server.Mobiles
{
    public class SBMage : SBInfo
    {
        private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

        public override IShopSellInfo SellInfo => m_SellInfo;
        public override List<GenericBuyInfo> BuyInfo => m_BuyInfo;

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(NewSpellbook), 500, 10, 0xEFA, 0));

                Add(new GenericBuyInfo(typeof(NecromancyTrainingWand), 100, 10, 0xDF2, 0));
                Add(new GenericBuyInfo(typeof(MageryTrainingWand), 100, 10, 0xDF2, 0));
                Add(new GenericBuyInfo(typeof(MagicResistTrainingWand), 100, 10, 0xDF2, 0));

                Add(new GenericBuyInfo(typeof(ScribesPen), 8, 10, 0xFBF, 0));

                Add(new GenericBuyInfo(typeof(BlankScroll), 5, 20, 0x0E34, 0));

				Add(new GenericBuyInfo(typeof(EssenceAeromancie), 5, 999, 0xF91, 2093));
				Add(new GenericBuyInfo(typeof(EssenceDefenseur), 5, 999, 0xF91, 2297));
				Add(new GenericBuyInfo(typeof(EssenceGeomancie), 5, 999, 0xF91, 2708));
				Add(new GenericBuyInfo(typeof(EssenceGuerison), 5, 999, 0xF91, 1999));
				Add(new GenericBuyInfo(typeof(EssenceMartial), 5, 999, 0xF91, 1935));
				Add(new GenericBuyInfo(typeof(EssenceMusique), 5, 999, 0xF91, 1486));
				Add(new GenericBuyInfo(typeof(EssenceNecromancie), 5, 999, 0xF91, 2174));
				Add(new GenericBuyInfo(typeof(EssenceChasseur), 5, 999, 0xF91, 2173));
				Add(new GenericBuyInfo(typeof(EssenceHydromancie), 5, 999, 0xF91, 2083));
				Add(new GenericBuyInfo(typeof(EssencePolymorphie), 5, 999, 0xF91, 2661));
				Add(new GenericBuyInfo(typeof(EssencePyromancie), 5, 999, 0xF91, 2737));
				Add(new GenericBuyInfo(typeof(EssenceRoublardise), 5, 999, 0xF91, 2818));
				Add(new GenericBuyInfo(typeof(EssenceTotemique), 5, 999, 0xF91, 2767));
			}
		}
    }
}





            
        
    

