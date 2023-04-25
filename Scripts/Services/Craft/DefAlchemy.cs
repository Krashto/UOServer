using Server.Custom.Items.SouvenirsAncestraux.Souvenirs;
using Server.Engines.Quests.Hag;
using Server.Items;
using System;
using System.Security.Policy;

namespace Server.Engines.Craft
{
	public enum AlchemyRecipes
    {
        BarrabHemolymphConcentrate = 900,
        JukariBurnPoiltice = 901,
        KurakAmbushersEssence = 902,
        BarakoDraftOfMight = 903,
        UraliTranceTonic = 904,
        SakkhraProphylaxisPotion = 905,
    }

    public class DefAlchemy : CraftSystem
    {
        public override SkillName MainSkill => SkillName.Alchemy;

		// public override int GumpTitleNumber => 1044001;

		public override string GumpTitleString => "Alchemie";


		private static CraftSystem m_CraftSystem;

        public static CraftSystem CraftSystem
        {
            get
            {
                if (m_CraftSystem == null)
                    m_CraftSystem = new DefAlchemy();

                return m_CraftSystem;
            }
        }

        public override double GetChanceAtMin(CraftItem item)
        {
            return 0.0; // 0%
        }

        private DefAlchemy()
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

			index = AddCraft(typeof(LesserRefreshPotion), "Rafraichissement", "Potion de rafrai. mineure", 0.0, 25.0, typeof(BlackPearl), 1044353, 1, 1044361);
			AddRes(index, typeof(Bottle), 1044529, 1, 500315);

			index = AddCraft(typeof(RefreshPotion), "Rafraichissement", "Potion de rafraichissement", 25.0, 50.0, typeof(BlackPearl), 1044353, 3, 1044361);
            AddRes(index, typeof(Bottle), 1044529, 1, 500315);

			index = AddCraft(typeof(GreaterRefreshPotion), "Rafraichissement", "Potion de rafrai. majeure", 50.0, 75.0, typeof(BlackPearl), 1044353, 5, 1044361);
			AddRes(index, typeof(Bottle), 1044529, 1, 500315);

			index = AddCraft(typeof(SuperiorRefreshPotion), "Rafraichissement", "Potion de rafrai. supérieure", 75.0, 100.0, typeof(BlackPearl), 1044353, 7, 1044361);
            AddRes(index, typeof(Bottle), 1044529, 1, 500315);

            index = AddCraft(typeof(LesserHealPotion), "Soin", "Potion de soin mineure", 0.0, 25.0, typeof(Ginseng), 1044356, 1, 1044364);
            AddRes(index, typeof(Bottle), 1044529, 1, 500315);

            index = AddCraft(typeof(HealPotion), "Soin", "Potion de soin", 25.0, 50.0, typeof(Ginseng), 1044356, 3, 1044364);
            AddRes(index, typeof(Bottle), 1044529, 1, 500315);

            index = AddCraft(typeof(GreaterHealPotion), "Soin", "Potion de soin majeure", 50.0, 75.0, typeof(Ginseng), 1044356, 5, 1044364);
            AddRes(index, typeof(Bottle), 1044529, 1, 500315);

			index = AddCraft(typeof(SuperiorHealPotion), "Soin", "Potion de soin supérieure", 75.0, 100.0, typeof(Ginseng), 1044356, 7, 1044364);
			AddRes(index, typeof(Bottle), 1044529, 1, 500315);

			index = AddCraft(typeof(LesserCurePotion), "Antidote", "Potion d'antidote mineure", 0.0, 25.0, typeof(Garlic), 1044355, 1, 1044363);
            AddRes(index, typeof(Bottle), 1044529, 1, 500315);

            index = AddCraft(typeof(CurePotion), "Antidote", "Potion d'antidote", 25.0, 50.0, typeof(Garlic), 1044355, 3, 1044363);
            AddRes(index, typeof(Bottle), 1044529, 1, 500315);

            index = AddCraft(typeof(GreaterCurePotion), "Antidote", "Potion d'antidote majeure", 50.0, 75.0, typeof(Garlic), 1044355, 5, 1044363);
            AddRes(index, typeof(Bottle), 1044529, 1, 500315);

			index = AddCraft(typeof(SuperiorCurePotion), "Antidote", "Potion d'antidote supérieure", 75.0, 100.0, typeof(Garlic), 1044355, 7, 1044363);
			AddRes(index, typeof(Bottle), 1044529, 1, 500315);

			index = AddCraft(typeof(LesserAgilityPotion), "Dextérité", "Potion de dextérité mineure", 0.0, 25.0, typeof(Bloodmoss), 1044354, 1, 1044362);
			AddRes(index, typeof(Bottle), 1044529, 1, 500315);

			index = AddCraft(typeof(AgilityPotion), "Dextérité", "Potion de dextérité", 25.0, 50.0, typeof(Bloodmoss), 1044354, 3, 1044362);
            AddRes(index, typeof(Bottle), 1044529, 1, 500315);

            index = AddCraft(typeof(GreaterAgilityPotion), "Dextérité", "Potion de dextérité majeure", 50.0, 75.0, typeof(Bloodmoss), 1044354, 5, 1044362);
            AddRes(index, typeof(Bottle), 1044529, 1, 500315);

			index = AddCraft(typeof(SuperiorAgilityPotion), "Dextérité", "Potion de dextérité supérieure", 75.0, 100.0, typeof(Bloodmoss), 1044354, 7, 1044362);
			AddRes(index, typeof(Bottle), 1044529, 1, 500315);

			index = AddCraft(typeof(LesserStrengthPotion), "Force", "Potion de force mineure", 0.0, 25.0, typeof(MandrakeRoot), 1044357, 1, 1044365);
			AddRes(index, typeof(Bottle), 1044529, 1, 500315);

			index = AddCraft(typeof(StrengthPotion), "Force", "Potion de force", 25.0, 50.0, typeof(MandrakeRoot), 1044357, 3, 1044365);
            AddRes(index, typeof(Bottle), 1044529, 1, 500315);

            index = AddCraft(typeof(GreaterStrengthPotion), "Force", "Potion de force majeure", 50.0, 75.0, typeof(MandrakeRoot), 1044357, 5, 1044365);
            AddRes(index, typeof(Bottle), 1044529, 1, 500315);

			index = AddCraft(typeof(SuperiorStrengthPotion), "Force", "Potion de force supérieure", 75.0, 100.0, typeof(MandrakeRoot), 1044357, 7, 1044365);
			AddRes(index, typeof(Bottle), 1044529, 1, 500315);

			// Explosive
			index = AddCraft(typeof(LesserExplosionPotion), "Explosion", "Potion explosive mineure", 5.0, 55.0, typeof(SulfurousAsh), 1044359, 3, 1044367);
            AddRes(index, typeof(Bottle), 1044529, 1, 500315);

            index = AddCraft(typeof(ExplosionPotion), "Explosion", "Potion explosive", 35.0, 85.0, typeof(SulfurousAsh), 1044359, 5, 1044367);
            AddRes(index, typeof(Bottle), 1044529, 1, 500315);

            index = AddCraft(typeof(GreaterExplosionPotion), "Explosion", "Potion explosive majeure", 65.0, 115.0, typeof(SulfurousAsh), 1044359, 10, 1044367);
            AddRes(index, typeof(Bottle), 1044529, 1, 500315);

            index = AddCraft(typeof(ConflagrationPotion), "Explosion", "Potion incendière", 55.0, 105.0, typeof(Bottle), 1044529, 1, 500315);
            AddRes(index, typeof(GraveDust), 1023983, 5, 1044253);

            index = AddCraft(typeof(GreaterConflagrationPotion), "Explosion", "Potion incendière majeure", 70.0, 120.0, typeof(Bottle), 1044529, 1, 500315);
            AddRes(index, typeof(GraveDust), 1023983, 10, 1044253);

            index = AddCraft(typeof(SmokeBomb), "Autres", "Smoke bomb", 90.0, 120.0, typeof(Eggs), 1044477, 1, 1044253);
            AddRes(index, typeof(Ginseng), 1044356, 3, 1044364);

			index = AddCraft(typeof(InvisibilityPotion), "Autres", "Potion d'invisibilité", 65.0, 115.0, typeof(Bottle), 1044529, 1, 500315);
			AddRes(index, typeof(Bloodmoss), 1044354, 4, 1044362);
			AddRes(index, typeof(Nightshade), 1044358, 3, 1044366);

			index = AddCraft(typeof(NightSightPotion), "Autres", "Potion de vision de nuit", -25.0, 25.0, typeof(SpidersSilk), 1044360, 1, 1044368);
			AddRes(index, typeof(Bottle), 1044529, 1, 500315);
			//Potions de souvenir
			index = AddCraft(typeof(SouvenirAeromanciePotion), "Potion de souvenir", "Potion de souvenir aéromancien", 50.0, 100.0, typeof(SouvenirAeromancie), "Souvenir Ancestral: Aéromancie", 1, "Vous n'avez pas suffisamment de souvenir pour concocter ceci.");
			AddRes(index, typeof(Bottle), 1044529, 1, 500315);

			index = AddCraft(typeof(HairDye), "Teinture pour cheveux", "Teinture à Cheveux", 75.0, 100.0, typeof(BacVide), "Bac à teinture", 1, "Il vous faut un bac à teinture");
			AddRes(index, typeof(Charcoal), "Charbon", 5, "Vous n'avez pas suffisament de charbon");

			#region Teintures

			#region Teintures OR
			index = AddCraft(typeof(OrSombreDyeTub), "Teintures", "Or Sombre", 25.0, 50.0, typeof(BacVide), "Bac de Teinture", 1, "Il vous faut un bac de teinture");
			AddRes(index, typeof(PoudreCoquillages), "Poudre de Coquillages", 5, "Vous n'avez pas suffisament de Poudre de Coquillages");
			AddRes(index, typeof(GoldIngot), "Lingot d'or", 2, "Vous n'avez pas suffisament de Lingot d'or");

			index = AddCraft(typeof(CitronAbrasifDyeTub), "Teintures", "Citron Abrasif", 50.0, 75.0, typeof(BacVide), "Bac de Teinture", 1, "Il vous faut un bac de teinture");
			AddRes(index, typeof(PoudreCoquillages), "Poudre de Coquillages", 5, "Vous n'avez pas suffisament de Poudre de Coquillages");
			AddRes(index, typeof(GoldIngot), "Lingot d'or", 2, "Vous n'avez pas suffisament de Lingot d'or");

			index = AddCraft(typeof(OrDouxDyeTub), "Teintures", "Or Doux", 65.0, 85.0, typeof(BacVide), "Bac de Teinture", 1, "Il vous faut un bac de teinture");
			AddRes(index, typeof(PoudreCoquillages), "Poudre de Coquillages", 5, "Vous n'avez pas suffisament de Poudre de Coquillages");
			AddRes(index, typeof(GoldIngot), "Lingot d'or", 2, "Vous n'avez pas suffisament de Lingot d'or");

			index = AddCraft(typeof(BeurreDouxDyeTub), "Teintures", "Beurre Doux", 80, 100.0, typeof(BacVide), "Bac de Teinture", 1, "Il vous faut un bac de teinture");
			AddRes(index, typeof(PoudreCoquillages), "Poudre de Coquillages", 5, "Vous n'avez pas suffisament de Poudre de Coquillages");
			AddRes(index, typeof(GoldIngot), "Lingot d'or", 2, "Vous n'avez pas suffisament de Lingot d'or");
			#endregion

			#region Teintures BRUNE
			index = AddCraft(typeof(CafeBruleDyeTub), "Teintures", "Cafe Brûlé", 25.0, 50.0, typeof(BacVide), "Bac de Teinture", 1, "Il vous faut un bac de teinture");
			AddRes(index, typeof(PoudreCoquillages), "Poudre de Coquillages", 5, "Vous n'avez pas suffisament de Poudre de Coquillages");
			AddRes(index, typeof(CoffeeBean), "Grain de Café", 10, "Vous n'avez pas suffisament de Grains de Café");

			index = AddCraft(typeof(RouilleDyeTub), "Teintures", "Rouille", 50.0, 75.0, typeof(BacVide), "Bac de Teinture", 1, "Il vous faut un bac de teinture");
			AddRes(index, typeof(PoudreCoquillages), "Poudre de Coquillages", 5, "Vous n'avez pas suffisament de Poudre de Coquillages");
			AddRes(index, typeof(CheveuxTroll), "Cheveux de Troll", 5, "Vous n'avez pas suffisament de Cheveux de Troll");

			index = AddCraft(typeof(BronzeDyeTub), "Teintures", "Bronze", 65.0, 85.0, typeof(BacVide), "Bac de Teinture", 1, "Il vous faut un bac de teinture");
			AddRes(index, typeof(PoudreCoquillages), "Poudre de Coquillages", 5, "Vous n'avez pas suffisament de Poudre de Coquillages");
			AddRes(index, typeof(BronzeIngot), "Lingot de Bronze", 2, "Vous n'avez pas suffisament de Lingot de Bronze");

			index = AddCraft(typeof(CuivreDyeTub), "Teintures", "Cuivre", 80, 100.0, typeof(BacVide), "Bac de Teinture", 1, "Il vous faut un bac de teinture");
			AddRes(index, typeof(PoudreCoquillages), "Poudre de Coquillages", 5, "Vous n'avez pas suffisament de Poudre de Coquillages");
			AddRes(index, typeof(CopperIngot), "Lingot de Cuivre", 2, "Vous n'avez pas suffisament de Lingot de Cuivre");
			#endregion

			#region Teintures Rouge
			index = AddCraft(typeof(RougeSanguinDyeTub), "Teintures", "Rouge Sanguin", 25.0, 50.0, typeof(BacVide), "Bac de Teinture", 1, "Il vous faut un bac de teinture");
			AddRes(index, typeof(PoudreCoquillages), "Poudre de Coquillages", 5, "Vous n'avez pas suffisament de Poudre de Coquillages");
			AddRes(index, typeof(PattesLapin), "Patte de Lapins", 5, "Vous n'avez pas suffisament de Pattes de Lapin");

			index = AddCraft(typeof(BordeauDyeTub), "Teintures", "Bordeau", 50.0, 75.0, typeof(BacVide), "Bac de Teinture", 1, "Il vous faut un bac de teinture");
			AddRes(index, typeof(PoudreCoquillages), "Poudre de Coquillages", 5, "Vous n'avez pas suffisament de Poudre de Coquillages");
			AddRes(index, typeof(BaseBeverage), 1022503, 1, 1044253);
		    SetBeverageType(index, BeverageType.Wine);

			index = AddCraft(typeof(CorailDyeTub), "Teintures", "Corail", 65.0, 85.0, typeof(BacVide), "Bac de Teinture", 1, "Il vous faut un bac de teinture");
			AddRes(index, typeof(PoudreCoquillages), "Poudre de Coquillages", 5, "Vous n'avez pas suffisament de Poudre de Coquillages");
			AddRes(index, typeof(DentRequin), "Dent de Requin", 2, "Vous n'avez pas suffisament de Dent de Requin");

			index = AddCraft(typeof(RougeObscureDyeTub), "Teintures", "Rouge Obscure", 80, 100.0, typeof(BacVide), "Bac de Teinture", 1, "Il vous faut un bac de teinture");
			AddRes(index, typeof(PoudreCoquillages), "Poudre de Coquillages", 5, "Vous n'avez pas suffisament de Poudre de Coquillages");
			AddRes(index, typeof(CerveauSpectre), "Cerveau de Spectre", 2, "Vous n'avez pas suffisament de Cerveau de Spectre");
			#endregion

			#region Teintures Bleu
			index = AddCraft(typeof(BleuGlacierDyeTub), "Teintures", "Bleu Glacier", 25.0, 50.0, typeof(BacVide), "Bac de Teinture", 1, "Il vous faut un bac de teinture");
			AddRes(index, typeof(PoudreCoquillages), "Poudre de Coquillages", 5, "Vous n'avez pas suffisament de Poudre de Coquillages");
			AddRes(index, typeof(CheveuxGeant), "Cheveux de Géant", 5, "Vous n'avez pas suffisament de Cheveux de Géant");

			index = AddCraft(typeof(BleuProfondDyeTub), "Teintures", "Bleu Profond", 50.0, 75.0, typeof(BacVide), "Bac de Teinture", 1, "Il vous faut un bac de teinture");
			AddRes(index, typeof(PoudreCoquillages), "Poudre de Coquillages", 5, "Vous n'avez pas suffisament de Poudre de Coquillages");
			AddRes(index, typeof(Blueberry), "Bleuets", 10, "Vous n'avez pas suffisament de Bleuets");
			

			index = AddCraft(typeof(BleuCielDyeTub), "Teintures", "Bleu Ciel", 65.0, 85.0, typeof(BacVide), "Bac de Teinture", 1, "Il vous faut un bac de teinture");
			AddRes(index, typeof(PoudreCoquillages), "Poudre de Coquillages", 5, "Vous n'avez pas suffisament de Poudre de Coquillages");
			AddRes(index, typeof(CerveauLiche), "Cerveau de Liche", 2, "Vous n'avez pas suffisament de Cerveaux de Liche");

			index = AddCraft(typeof(BleuSombreDyeTub), "Teintures", "Bleu Sombre", 80, 100.0, typeof(BacVide), "Bac de Teinture", 1, "Il vous faut un bac de teinture");
			AddRes(index, typeof(PoudreCoquillages), "Poudre de Coquillages", 5, "Vous n'avez pas suffisament de Poudre de Coquillages");
			AddRes(index, typeof(MytherilIngot), "Lingot de Mytheril", 2, "Vous n'avez pas suffisament de Lingot de Mytheril");
			#endregion

			#region Teintures Verte
			index = AddCraft(typeof(VertSombreDyeTub), "Teintures", "Vert Sombre", 25.0, 50.0, typeof(BacVide), "Bac de Teinture", 1, "Il vous faut un bac de teinture");
			AddRes(index, typeof(PoudreCoquillages), "Poudre de Coquillages", 5, "Vous n'avez pas suffisament de Poudre de Coquillages");
			AddRes(index, typeof(EcorceArbreGeant), "Ecorce d'arbre maudit", 5, "Vous n'avez pas suffisament d'écorce d'arbre maudit");

			index = AddCraft(typeof(VertOliveDyeTub), "Teintures", "Vert Olive", 50.0, 75.0, typeof(BacVide), "Bac de Teinture", 1, "Il vous faut un bac de teinture");
			AddRes(index, typeof(PoudreCoquillages), "Poudre de Coquillages", 5, "Vous n'avez pas suffisament de Poudre de Coquillages");
			AddRes(index, typeof(Peas), "Pois", 10, "Vous n'avez pas suffisament de Pois");


			index = AddCraft(typeof(VertPrintanierDyeTub), "Teintures", "Vert Printanier", 65.0, 85.0, typeof(BacVide), "Bac de Teinture", 1, "Il vous faut un bac de teinture");
			AddRes(index, typeof(PoudreCoquillages), "Poudre de Coquillages", 5, "Vous n'avez pas suffisament de Poudre de Coquillages");
			AddRes(index, typeof(VeriteIngot), "Lingot de Vérite", 2, "Vous n'avez pas suffisament de Lingot de Vérite");

			index = AddCraft(typeof(VertIridescentDyeTub), "Teintures", "Vert Iridescent", 80, 100.0, typeof(BacVide), "Bac de Teinture", 1, "Il vous faut un bac de teinture");
			AddRes(index, typeof(PoudreCoquillages), "Poudre de Coquillages", 5, "Vous n'avez pas suffisament de Poudre de Coquillages");
			AddRes(index, typeof(VeninTarenlune), "Venin de Tarenlune", 2, "Vous n'avez pas suffisament de Venin de Tarenlune");
			#endregion

			#region Teintures TURQUOISE 
			index = AddCraft(typeof(TurquoisePlumePaon), "Teintures", "Plume de Paon", 25.0, 50.0, typeof(BacVide), "Bac de Teinture", 1, "Il vous faut un bac de teinture");
			AddRes(index, typeof(PoudreCoquillages), "Poudre de Coquillages", 5, "Vous n'avez pas suffisament de Poudre de Coquillages");
			AddRes(index, typeof(EcorceArbreGeant), "Ecorce d'arbre Géant", 5, "Vous n'avez pas suffisament d'écorce d'arbre Géant");

			index = AddCraft(typeof(TurquoiseDyeTub), "Teintures", "Turquoise", 50.0, 75.0, typeof(BacVide), "Bac de Teinture", 1, "Il vous faut un bac de teinture");
			AddRes(index, typeof(PoudreCoquillages), "Poudre de Coquillages", 5, "Vous n'avez pas suffisament de Poudre de Coquillages");
			AddRes(index, typeof(VeninAraigneeGeante), "Venin d'araignée Géante", 5, "Vous n'avez pas suffisament de Venin d'araignée géante");


			index = AddCraft(typeof(EcaillePoissonDyeTub), "Teintures", "Ecaille de Poisson", 65.0, 85.0, typeof(BacVide), "Bac de Teinture", 1, "Il vous faut un bac de teinture");
			AddRes(index, typeof(PoudreCoquillages), "Poudre de Coquillages", 5, "Vous n'avez pas suffisament de Poudre de Coquillages");
			AddRes(index, typeof(RawFishSteak), "Morceaux de Poisson cru", 2, "Vous n'avez pas suffisament de Poisson cru");

			index = AddCraft(typeof(AquaMarineDyeTub), "Teintures", "Aqua Marine", 80, 100.0, typeof(BacVide), "Bac de Teinture", 1, "Il vous faut un bac de teinture");
			AddRes(index, typeof(PoudreCoquillages), "Poudre de Coquillages", 5, "Vous n'avez pas suffisament de Poudre de Coquillages");
			AddRes(index, typeof(Sapphire), "Un Saphir", 2, "Vous n'avez pas suffisament de Saphir");
			#endregion

			#region Teintures Mauve 
			index = AddCraft(typeof(MauveIndigoDyeTub), "Teintures", "Mauve Indigo", 25.0, 50.0, typeof(BacVide), "Bac de Teinture", 1, "Il vous faut un bac de teinture");
			AddRes(index, typeof(PoudreCoquillages), "Poudre de Coquillages", 5, "Vous n'avez pas suffisament de Poudre de Coquillages");
			AddRes(index, typeof(PoilsLoup), "Poils de Loup", 5, "Vous n'avez pas suffisament de poils de Loup");

			index = AddCraft(typeof(RosePerleDyeTub), "Teintures", "Rose Perle", 50.0, 75.0, typeof(BacVide), "Bac de Teinture", 1, "Il vous faut un bac de teinture");
			AddRes(index, typeof(PoudreCoquillages), "Poudre de Coquillages", 5, "Vous n'avez pas suffisament de Poudre de Coquillages");
			AddRes(index, typeof(RedRose), "Rose Rouge", 5, "Vous n'avez pas suffisament de Roses Rouge");


			index = AddCraft(typeof(PruneDyeTub), "Teintures", "Prune", 65.0, 85.0, typeof(BacVide), "Bac de Teinture", 1, "Il vous faut un bac de teinture");
			AddRes(index, typeof(PoudreCoquillages), "Poudre de Coquillages", 5, "Vous n'avez pas suffisament de Poudre de Coquillages");
			AddRes(index, typeof(PattesPanthere), "Pattes de Panthère", 2, "Vous n'avez pas suffisament de Patte de Panthère");

			index = AddCraft(typeof(MauveVelourDyeTub), "Teintures", "Mauve Velour", 80, 100.0, typeof(BacVide), "Bac de Teinture", 1, "Il vous faut un bac de teinture");
			AddRes(index, typeof(PoudreCoquillages), "Poudre de Coquillages", 5, "Vous n'avez pas suffisament de Poudre de Coquillages");
			AddRes(index, typeof(Amethyst), "Une Améthyste", 2, "Vous n'avez pas suffisament d'améthyste");
			#endregion

			#region Teintures NEUTRE
			index = AddCraft(typeof(GrisAntraciteDyeTub), "Teintures", "Gris Antracite", 25.0, 50.0, typeof(BacVide), "Bac de Teinture", 1, "Il vous faut un bac de teinture");
			AddRes(index, typeof(PoudreCoquillages), "Poudre de Coquillages", 5, "Vous n'avez pas suffisament de Poudre de Coquillages");
			AddRes(index, typeof(PlumesHarpie), "Plumes de Harpie", 5, "Vous n'avez pas suffisament de Plumes de Harpie");

			index = AddCraft(typeof(GrisArgenteDyeTub), "Teintures", "Gris Argenté", 50.0, 75.0, typeof(BacVide), "Bac de Teinture", 1, "Il vous faut un bac de teinture");
			AddRes(index, typeof(PoudreCoquillages), "Poudre de Coquillages", 5, "Vous n'avez pas suffisament de Poudre de Coquillages");
			AddRes(index, typeof(OeufPierre), "Oeuf de Pierre", 2, "Vous n'avez pas suffisament d'oeuf de Pierre");


			index = AddCraft(typeof(NoirDyeTub), "Teintures", "Noir", 65.0, 85.0, typeof(BacVide), "Bac de Teinture", 1, "Il vous faut un bac de teinture");
			AddRes(index, typeof(PoudreCoquillages), "Poudre de Coquillages", 5, "Vous n'avez pas suffisament de Poudre de Coquillages");
			AddRes(index, typeof(Charcoal), "Charbon", 5, "Vous n'avez pas suffisament de Charbon");

			index = AddCraft(typeof(BlancDyeTub), "Teintures", "Blanc", 80, 100.0, typeof(BacVide), "Bac de Teinture", 1, "Il vous faut un bac de teinture");
			AddRes(index, typeof(PoudreCoquillages), "Poudre de Coquillages", 5, "Vous n'avez pas suffisament de Poudre de Coquillages");
			AddRes(index, typeof(PlumesAigle), "Plumes d'aigles", 10, "Vous n'avez pas suffisament de plumes d'aigle");
			#endregion
			#endregion
		}
	}
}
