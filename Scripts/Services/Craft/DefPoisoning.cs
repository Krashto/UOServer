using Server.Items;
using System;

namespace Server.Engines.Craft
{
    public class DefPoisoning : CraftSystem
    {
        public override SkillName MainSkill => SkillName.Poisoning;

		// public override int GumpTitleNumber => 1044001;

		public override string GumpTitleString => "Alchemie";


		private static CraftSystem m_CraftSystem;

        public static CraftSystem CraftSystem
        {
            get
            {
                if (m_CraftSystem == null)
                    m_CraftSystem = new DefPoisoning();

                return m_CraftSystem;
            }
        }

        public override double GetChanceAtMin(CraftItem item)
        {
            return 0.0; // 0%
        }

        private DefPoisoning()
            : base(1, 1, 1.25)// base( 1, 1, 3.1 )
        {
        }

        public override int CanCraft(Mobile from, ITool tool, Type itemType)
        {
            int num = 0;

            if (tool == null || tool.Deleted || tool.UsesRemaining <= 0)
                return 1044038; // You have worn out your tool!
            else if (!tool.CheckAccessible(from, ref num))
                return num; // The tool must be on your person to use.

            return 0;
        }

        public override void PlayCraftEffect(Mobile from)
        {
            from.PlaySound(0x242);
        }

        private static readonly Type typeofPotion = typeof(BasePotion);

        public static bool IsPotion(Type type)
        {
            return typeofPotion.IsAssignableFrom(type);
        }

        public override int PlayEndingEffect(Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, bool makersMark, CraftItem item)
        {
            if (toolBroken)
                from.SendLocalizedMessage(1044038); // You have worn out your tool

            if (failed)
            {
                if (IsPotion(item.ItemType))
                {
                    from.AddToBackpack(new Bottle());
                    return 500287; // You fail to create a useful potion.
                }
                else
                {
                    return 1044043; // You failed to create the item, and some of your materials are lost.
                }
            }
            else
            {
                from.PlaySound(0x240); // Sound of a filling bottle

                if (IsPotion(item.ItemType))
                {
                    if (quality == -1)
                        return 1048136; // You create the potion and pour it into a keg.
                    else
                        return 500279; // You pour the potion into a bottle...
                }
                else
                {
                    return 1044154; // You create the item.
                }
            }
        }

        public override void InitCraftList()
        {
            int index = -1;

            // Curative
            index = AddCraft(typeof(LesserCurePotion), 1116348, 1044552, -10.0, 40.0, typeof(Garlic), 1044355, 1, 1044363);
            AddRes(index, typeof(Bottle), 1044529, 1, 500315);

            index = AddCraft(typeof(CurePotion), 1116348, 1044553, 25.0, 75.0, typeof(Garlic), 1044355, 3, 1044363);
            AddRes(index, typeof(Bottle), 1044529, 1, 500315);

            index = AddCraft(typeof(GreaterCurePotion), 1116348, 1044554, 65.0, 95.0, typeof(Garlic), 1044355, 6, 1044363);
            AddRes(index, typeof(Bottle), 1044529, 1, 500315);

			index = AddCraft(typeof(UltimeCurePotion), 1116348, "Antidote Ultime", 80.0, 105.0, typeof(PlumesSaliva), "Plume de Saliva", 1, "Vous n'avez pas assez de plume de Saliva");
			AddRes(index, typeof(Bottle), 1044529, 1, 500315);

            // Toxic
            index = AddCraft(typeof(LesserPoisonPotion), 1116350, 1044548, -5.0, 45.0, typeof(Nightshade), 1044358, 1, 1044366);
            AddRes(index, typeof(Bottle), 1044529, 1, 500315);

            index = AddCraft(typeof(PoisonPotion), 1116350, 1044549, 15.0, 65.0, typeof(Nightshade), 1044358, 2, 1044366);
            AddRes(index, typeof(Bottle), 1044529, 1, 500315);

            index = AddCraft(typeof(GreaterPoisonPotion), 1116350, 1044550, 55.0, 105.0, typeof(Nightshade), 1044358, 4, 1044366);
            AddRes(index, typeof(Bottle), 1044529, 1, 500315);

            index = AddCraft(typeof(DeadlyPoisonPotion), 1116350, 1044551, 90.0, 140.0, typeof(Nightshade), 1044358, 8, 1044366);
            AddRes(index, typeof(Bottle), 1044529, 1, 500315);

            index = AddCraft(typeof(ParasiticPotion), 1116350, 1072942, 65.0, 115.0, typeof(Bottle), 1044529, 1, 500315);
            AddRes(index, typeof(NoxCrystal), "Nox Crystal", 5, "Pas assez de Nox Crystal");
			AddRes(index, typeof(VeninAraigneeGeante), "Venin d'araignée géante", 1, "Vous n'avez pas suffisament de venin d'Araignée Géante");

			index = AddCraft(typeof(DarkglowPotion), 1116350, 1072943, 65.0, 115.0, typeof(Bottle), 1044529, 1, 500315);
            AddRes(index, typeof(NoxCrystal), "Nox Crystal", 5, "Pas assez de Nox Crystal");
			AddRes(index, typeof(VeninAraigneeNoire), "Venin d'araignée noire", 1, "Vous n'avez pas suffisament de venin d'Araignée Noire");

			index = AddCraft(typeof(ScouringToxin), 1116350, 1112292, 75.0, 100.0, typeof(NoxCrystal), "Nox Crystal", 1, "Pas assez de Nox Crystal");
            AddRes(index, typeof(Bottle), 1044529, 1, 500315);
			AddRes(index, typeof(VeninTarenlune), "Venin de Tarenlune", 5, "Vous n'avez pas suffisament de venin de Tarenlune");
		}
	}
}
