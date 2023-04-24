using Server.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Mobiles
{
    public class GenericSellInfo : IShopSellInfo
    {
        private readonly Dictionary<Type, int> m_Table = new Dictionary<Type, int>();
        private Type[] m_Types;

        public Type[] Types
        {
            get
            {
                if (m_Types == null)
                {
                    m_Types = new Type[m_Table.Keys.Count];
                    m_Table.Keys.CopyTo(m_Types, 0);
                }

                return m_Types;
            }
        }
        public void Add(Type type, int price)
        {
            m_Table[type] = price;
            m_Types = null;
        }

		public static double GetSellingScalar(Mobile from)
		{
			return 1 + (from.Skills[SkillName.Snooping].Value * 0.002);
		}

		public int GetSellPriceFor(Mobile from, Item item)
        {
            return GetSellPriceFor(from, item, null);
        }

        public int GetSellPriceFor(Mobile from, Item item, BaseVendor vendor)
        {
            int price = 0;
            m_Table.TryGetValue(item.GetType(), out price);

			if (from != null)
			{
				price = (int)(price * GetSellingScalar(from));
			}

            if (vendor != null && BaseVendor.UseVendorEconomy)
            {
                IBuyItemInfo buyInfo = vendor.GetBuyInfo().OfType<GenericBuyInfo>().FirstOrDefault(info => info.EconomyItem && info.Type == item.GetType());
                return Math.Max(1, price);
            }

            if (item is BaseArmor)
            {
                BaseArmor armor = (BaseArmor)item;

                if (armor.Quality == ItemQuality.Low)
                    price = (int)(price * 0.60);
                else if (armor.Quality == ItemQuality.Exceptional)
                    price = (int)(price * 1.25);

                if (price < 1)
                    price = 1;
            }
            else if (item is BaseWeapon)
            {
                BaseWeapon weapon = (BaseWeapon)item;

                if (weapon.Quality == ItemQuality.Low)
                    price = (int)(price * 0.60);
                else if (weapon.Quality == ItemQuality.Exceptional)
                    price = (int)(price * 1.25);

                if (price < 1)
                    price = 1;
            }
            else if (item is BaseBeverage)
            {
                int price1 = price, price2 = price;

                if (item is Pitcher)
                {
                    price1 = 3;
                    price2 = 5;
                }
                else if (item is BeverageBottle)
                {
                    price1 = 3;
                    price2 = 3;
                }
                else if (item is Jug)
                {
                    price1 = 6;
                    price2 = 6;
                }

                BaseBeverage bev = (BaseBeverage)item;

                if (bev.IsEmpty || bev.Content == BeverageType.Milk)
                    price = price1;
                else
                    price = price2;
            }

            return price;
        }

        public int GetBuyPriceFor(Mobile from, Item item)
        {
            return GetBuyPriceFor(from, item, null);
        }

        public int GetBuyPriceFor(Mobile from, Item item, BaseVendor vendor)
        {
            return (int)(1.90 * GetSellPriceFor(from, item, vendor) * GenericBuyInfo.GetBuyingScalar(from));
        }

        public string GetNameFor(Item item)
        {
            if (item.Name != null)
                return item.Name;
            else
                return item.LabelNumber.ToString();
        }

        public bool IsSellable(Item item)
        {
            if (item.QuestItem)
                return false;

            //if ( item.Hue != 0 )
            //return false;

            return IsInList(item.GetType());
        }

        public bool IsResellable(Item item)
        {
            if (item.QuestItem)
                return false;

            //if ( item.Hue != 0 )
            //return false;

            return IsInList(item.GetType());
        }

        public bool IsInList(Type type)
        {
            return m_Table.ContainsKey(type);
        }
    }
}
