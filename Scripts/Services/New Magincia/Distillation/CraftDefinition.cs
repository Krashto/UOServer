using Server.Items;
using System;

namespace Server.Engines.Distillation
{
    public class CraftDefinition
    {
        private readonly Group m_Group;
        private readonly Liquor m_Liquor;
        private readonly Type[] m_Ingredients;
        private readonly int[] m_Amounts;
        private readonly int[] m_Labels;
        private TimeSpan m_MaturationDuration;

        public Group Group => m_Group;
        public Liquor Liquor => m_Liquor;
        public Type[] Ingredients => m_Ingredients;
        public int[] Amounts => m_Amounts;
        public int[] Labels => m_Labels;
        public TimeSpan MaturationDuration => m_MaturationDuration;

        public CraftDefinition(Group group, Liquor liquor, Type[] ingredients, int[] amounts, TimeSpan matureperiod)
        {
            m_Group = group;
            m_Liquor = liquor;
            m_Ingredients = ingredients;
            m_Amounts = amounts;
            m_MaturationDuration = matureperiod;

            m_Labels = new int[m_Ingredients.Length];

            for (int i = 0; i < m_Ingredients.Length; i++)
            {
                Type type = m_Ingredients[i];

                if (type == typeof(Yeast))
                    m_Labels[i] = 1150453;
                else if (type == typeof(WheatWort))
                    m_Labels[i] = 1150275;
                else if (type == typeof(PewterBowlOfCorn))
                    m_Labels[i] = 1025631;
                else if (type == typeof(PewterBowlOfPotatos))
                    m_Labels[i] = 1025634;
                else if (type == typeof(Strawberry))
                    m_Labels[i] = 1040001;
                else if (type == typeof(HoneydewMelon))
                    m_Labels[i] = 1023189;
                else if (type == typeof(JarHoney))
                    m_Labels[i] = 1022540;
                else if (type == typeof(Pitcher))
                {
                    if (m_Liquor == Liquor.Brandy)
                        m_Labels[i] = 1028091;      // pitcher of wine
                    else
                        m_Labels[i] = 1024088;      // pitcher of water
                }
                else if (type == typeof(Dates))
                    m_Labels[i] = 1025927;
                else
                {
                    Item item = Loot.Construct(type);
                    if (item != null)
                    {
                        m_Labels[i] = item.LabelNumber;
                        item.Delete();
                    }
                }

            }
        }
    }
}