﻿using Server.Items;
using Server.Mobiles;
using Server.Targeting;
using System;
using Server.Services.BasketWeaving.Baskets;
using Xanthos.ShrinkSystem;

namespace Server.Engines.Craft
{
	public enum TinkerRecipes
	{
		InvisibilityPotion = 400,
		DarkglowPotion = 401,
		ParasiticPotion = 402,

		EssenceOfBattle = 450,
		PendantOfTheMagi = 451,
		ResilientBracer = 452,
		ScrappersCompendium = 453,
		HoveringWisp = 454, // Removed at OSI Publish 103

		KotlPowerCore = 455,

		// doom
		BraceletOfPrimalConsumption = 456,
		DrSpectorLenses = 457,
		KotlAutomatonHead = 458,

		WeatheredBronzeArcherSculpture = 459,
		WeatheredBronzeFairySculpture = 460,
		WeatheredBronzeGlobeSculpture = 461,
		WeatheredBronzeManOnABench = 462,

		KrampusMinionEarrings = 463,
		EnchantedPicnicBasket = 464,

		Telescope = 465,

		BarbedWhip = 466,
		SpikedWhip = 467,
		BladedWhip = 468,
	}

	public class DefTinkering : CraftSystem
	{
		#region Mondain's Legacy
		public override CraftECA ECA => CraftECA.ChanceMinusSixtyToFourtyFive;
		#endregion

		public override SkillName MainSkill => SkillName.Tinkering;

		//   public override int GumpTitleNumber => 1044007;

		public override string GumpTitleString => "Bricolage";

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if (m_CraftSystem == null)
					m_CraftSystem = new DefTinkering();

				return m_CraftSystem;
			}
		}

		private DefTinkering()
			: base(3, 4, 1.50)// base( 1, 1, 3.0 )
		{
		}

		public override double GetChanceAtMin(CraftItem item)
		{
			if (item.NameNumber == 1044258 || item.NameNumber == 1046445) // potion keg 
				return 0.5; // 50%

			return 0.0; // 0%
		}

		public override int CanCraft(Mobile from, ITool tool, Type itemType)
		{
			int num = 0;

			if (tool == null || tool.Deleted || tool.UsesRemaining <= 0)
				return 1044038; // You have worn out your tool!
			else if (!tool.CheckAccessible(from, ref num))
				return num; // The tool must be on your person to use.
			else if (itemType == typeof(ModifiedClockworkAssembly) && !(from is PlayerMobile && ((PlayerMobile)from).MechanicalLife))
				return 1113034; // You haven't read the Mechanical Life Manual. Talking to Sutek might help!

			return 0;
		}

		private static readonly Type[] m_TinkerColorables = new Type[]
		{
			typeof(ForkLeft), typeof(ForkRight),
			typeof(SpoonLeft), typeof(SpoonRight),
			typeof(KnifeLeft), typeof(KnifeRight),
			typeof(Plate), typeof(Eventail),
			typeof(Goblet), typeof(PewterMug),
			typeof(KeyRing),
			typeof(Candelabra), typeof(Scales),
			typeof(Key), typeof(Globe), typeof(Eventail),
			typeof(Spyglass), typeof(Lantern),
			typeof(HeatingStand), typeof(BroadcastCrystal), typeof(TerMurStyleCandelabra),
			typeof(GorgonLense), typeof(MedusaLightScales), typeof(MedusaDarkScales), typeof(RedScales),
			typeof(BlueScales), typeof(BlackScales), typeof(GreenScales), typeof(YellowScales), typeof(WhiteScales),
			typeof(PlantPigment), typeof(Kindling), typeof(DryReeds), typeof(PlantClippings), typeof(Bracelet1), typeof(Earrings1), typeof(Ring1), typeof(Necklace1),

			typeof(KotlAutomatonHead)
		};

		public override bool RetainsColorFrom(CraftItem item, Type type)
		{
			if (type == typeof(CrystalDust))
				return false;

			return true;

			//bool contains = false;
			//type = item.ItemType;

			//for (int i = 0; !contains && i < m_TinkerColorables.Length; ++i)
			//	contains = (m_TinkerColorables[i] == type);

			//if (!contains && !type.IsSubclassOf(typeof(BaseIngot)))
			//	return false;

			//if (type.IsSubclassOf(typeof(BaseBoard)))
			//	return true;

			//return contains;
		}

		public override void PlayCraftEffect(Mobile from)
		{
			from.PlaySound(0x23B);
		}

		public override int PlayEndingEffect(Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, bool makersMark, CraftItem item)
		{
			if (toolBroken)
				from.SendMessage("Vous avez brisé votre outil."); ; // You have worn out your tool

			if (failed)
			{
				if (lostMaterial)
					return 1044043; // You failed to create the item, and some of your materials are lost.
				else
					return 1044157; // You failed to create the item, but no materials were lost.
			}
			else
			{
				if (quality == 0)
					return 502785; // You were barely able to make this item.  It's quality is below average.
				else if (makersMark && quality == 2)
					return 1044156; // You create an exceptional quality item and affix your maker's mark.
				else if (quality == 2)
					return 1044155; // You create an exceptional quality item.
				else
					return 1044154; // You create the item.
			}
		}

		public override void InitCraftList()
		{
			int index = -1;

			#region Outils
			index = AddCraft(typeof(Scissors), "Outils", "Ciseaux", 10.0, 30.0, typeof(IronIngot), 1044036, 5, 1044037);
			index = AddCraft(typeof(EmptyAleBottle), "Outils", "Bouteille de Bière Vide", 10.0, 30.0, typeof(IronIngot), 1044036, 5, 1044037);
			index = AddCraft(typeof(SewingKit), "Outils", "Kit de couture (Tissus)", 10.0, 30.0, typeof(IronIngot), 1044036, 5, 1044037);
			index = AddCraft(typeof(BoneSewingKit), "Outils", "Kit de couture (Os)", 10.0, 30.0, typeof(IronIngot), 1044036, 5, 1044037);
			index = AddCraft(typeof(LeatherSewingKit), "Outils", "Kit de couture (Cuir)", 10.0, 30.0, typeof(IronIngot), 1044036, 5, 1044037);
			index = AddCraft(typeof(Hatchet), "Outils", "Hachette", 20.0, 40.0, typeof(IronIngot), 1044036, 4, 1044037);
			index = AddCraft(typeof(Shovel), "Outils", "Pelle", 20.0, 40.0, typeof(IronIngot), 1044036, 4, 1044037);
			index = AddCraft(typeof(Pickaxe), "Outils", "Pioche", 20.0, 40.0, typeof(IronIngot), 1044036, 4, 1044037);
			index = AddCraft(typeof(TinkerTools), "Outils", "Trousse de Bricolage", 15.0, 30.0, typeof(IronIngot), 1044036, 5, 1044037);
			index = AddCraft(typeof(SmithyHammer), "Outils", "Marteau de forgeron", 15.0, 30.0, typeof(IronIngot), 1044036, 4, 1044037);
			index = AddCraft(typeof(Saw), "Outils", "Scie", 15.0, 30.0, typeof(IronIngot), 1044036, 4, 1044037);
			index = AddCraft(typeof(RollingPin), "Outils", "Rouleau à pâte", 15.0, 35.0, typeof(RegularBoard), 1044041, 5, 1044351);
			index = AddCraft(typeof(Skillet), "Outils", "Poêlon", 15.0, 30.0, typeof(IronIngot), 1044036, 4, 1044037);
			index = AddCraft(typeof(FlourSifter), "Outils", "Tamis à farine", 15.0, 35.0, typeof(IronIngot), 1044036, 3, 1044037);
			index = AddCraft(typeof(MortarPestle), "Outils", "Mortier et pilon", 15.0, 35.0, typeof(IronIngot), 1044036, 3, 1044037);
			index = AddCraft(typeof(MortarPestlePoisoning), "Outils", "Mortier et pilon (Poison)", 15.0, 35.0, typeof(IronIngot), 1044036, 3, 1044037);
			index = AddCraft(typeof(FletcherTools), "Outils", "Outil fabrication d'arc", 15.0, 35.0, typeof(IronIngot), 1044036, 3, 1044037);
			index = AddCraft(typeof(ScribesPen), "Outils", "Plume d'écriture", 15.0, 35.0, typeof(IronIngot), 1044036, 3, 1044037);
			index = AddCraft(typeof(SpellsPen), "Outils", "Cristal de compétences", 15.0, 35.0, typeof(IronIngot), 1044036, 3, 1044037);
			index = AddCraft(typeof(SoulsPen), "Outils", "Plume de reviviscence", 50.0, 75.0, typeof(IronIngot), 1044036, 3, 1044037);
			index = AddCraft(typeof(Lockpick), "Outils", "Crochets", 10.0, 30.0, typeof(IronIngot), 1044036, 3, 1044037);
			index = AddCraft(typeof(BarberScissors), "Outils", "Ciseaux de Barbier", 10.0, 70.0, typeof(IronIngot), 1044036, 5, 1044037);
			index = AddCraft(typeof(Ecraseur), "Outils", "Écraseur", 15.0, 30.0, typeof(IronIngot), 1044036, 5, 1044037);
			index = AddCraft(typeof(BeerBreweringTools), "Outils", "Outil fabrication de bière", 35.0, 55.0, typeof(IronIngot), 1044036, 5, 1044037);
			index = AddCraft(typeof(Recycleur), "Outils", "Recycleur", 35.0, 55.0, typeof(IronIngot), 1044036, 8, 1044037);
			index = AddCraft(typeof(BrewersTools), "Outils", "Outil Brasseur", 30.0, 55.0, typeof(IronIngot), 1044036, 5, 1044037);
			index = AddCraft(typeof(BreweryLabelMaker), "Outils", "Marqueur de bière", 30.0, 55.0, typeof(IronIngot), 1044036, 5, 1044037);
			index = AddCraft(typeof(GrapevinePlacementTool), "Outils", "Outil placement de vignes", 30.0, 55.0, typeof(IronIngot), 1044036, 5, 1044037);
			index = AddCraft(typeof(GrinderExp), "Outils", "Broyeur à café", 05.0, 55.0, typeof(IronIngot), 1044036, 5, 1044037);
			index = AddCraft(typeof(JuicersTools), "Outils", "Fabrication de Jus", 30.0, 55.0, typeof(IronIngot), 1044036, 5, 1044037);
			index = AddCraft(typeof(VinyardLabelMaker), "Outils", "Marqueur de vin", 30.0, 55.0, typeof(IronIngot), 1044036, 5, 1044037);
			index = AddCraft(typeof(WinecraftersTools), "Outils", "Outil fabrication de vin", 30.0, 55.0, typeof(IronIngot), 1044036, 5, 1044037);
			index = AddCraft(typeof(Boline), "Outils", "Serpe", 15.0, 30.0, typeof(IronIngot), 1044036, 4, 1044037);
			#endregion

			#region Anneaux
			AddCraft(typeof(GoldRing), "Anneaux", "Anneau Simple", 10.0, 30.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer cet anneau.");


			AddCraft(typeof(Ring1), "Anneaux", "Anneau", 10.0, 30.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer cet anneau.");

			index = AddCraft(typeof(Ring1), "Anneaux", "Anneau serti d'ambre", 15.0, 35.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer cet anneau.");
			AddRes(index, typeof(Amber), "Ambre", 1, "Vous n'avez pas assez d'ambre pour fabriquer cet anneau.");

			index = AddCraft(typeof(Ring1), "Anneaux", "Anneau serti de citrine", 15.0, 35.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer cet anneau.");
			AddRes(index, typeof(Citrine), "Citrine", 1, "Vous n'avez pas assez de citrine pour fabriquer cet anneau.");

			index = AddCraft(typeof(Ring1), "Anneaux", "Anneau serti d'améthyste", 20.0, 40.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer cet anneau.");
			AddRes(index, typeof(Amethyst), "Améthyste", 1, "Vous n'avez pas assez d'améthyste pour fabriquer cet anneau.");

			index = AddCraft(typeof(Ring1), "Anneaux", "Anneau serti de tourmaline", 20.0, 40.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer cet anneau.");
			AddRes(index, typeof(Tourmaline), "Tourmaline", 1, "Vous n'avez pas assez de tourmaline pour fabriquer cet anneau.");

			index = AddCraft(typeof(Ring1), "Anneaux", "Anneau serti d'émeraude", 25.0, 45.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer cet anneau.");
			AddRes(index, typeof(Emerald), "Émeraude", 1, "Vous n'avez pas assez d'émeraude pour fabriquer cet anneau.");

			index = AddCraft(typeof(Ring1), "Anneaux", "Anneau serti de saphir", 25.0, 45.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer cet anneau.");
			AddRes(index, typeof(Sapphire), "Saphir", 1, "Vous n'avez pas assez de saphir pour fabriquer cet anneau.");

			index = AddCraft(typeof(Ring1), "Anneaux", "Anneau serti de rubis", 30.0, 50.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer cet anneau.");
			AddRes(index, typeof(Ruby), "Rubis", 1, "Vous n'avez pas assez de rubis pour fabriquer cet anneau.");

			index = AddCraft(typeof(Ring1), "Anneaux", "Anneau serti de saphir étoilé", 35.0, 55.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer cet anneau.");
			AddRes(index, typeof(StarSapphire), "Saphir étoilé", 1, "Vous n'avez pas assez de saphir étoilé pour fabriquer cet anneau.");

			index = AddCraft(typeof(Ring1), "Anneaux", "Anneau serti de diamant", 40.0, 60.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer cet anneau.");
			AddRes(index, typeof(Diamond), "Diamant", 1, "Vous n'avez pas assez de diamant pour fabriquer cet anneau.");
			#endregion

			#region Colliers
			AddCraft(typeof(GoldNecklace), "Colliers", "Collier Simple", 10.0, 30.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer ce collier.");


			AddCraft(typeof(Necklace1), "Colliers", "Collier", 10.0, 30.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer ce collier.");

			index = AddCraft(typeof(Necklace1), "Colliers", "Collier serti d'ambre", 15.0, 35.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer ce collier.");
			AddRes(index, typeof(Amber), "Ambre", 1, "Vous n'avez pas assez d'ambre pour fabriquer ce collier.");

			index = AddCraft(typeof(Necklace1), "Colliers", "Collier serti de citrine", 15.0, 35.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer ce collier.");
			AddRes(index, typeof(Citrine), "Citrine", 1, "Vous n'avez pas assez de citrine pour fabriquer ce collier.");

		
			index = AddCraft(typeof(Necklace1), "Colliers", "Collier serti d'améthyste", 20.0, 40.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer ce collier.");
			AddRes(index, typeof(Amethyst), "Améthyste", 1, "Vous n'avez pas assez d'améthyste pour fabriquer ce collier.");

			index = AddCraft(typeof(Necklace1), "Colliers", "Collier serti de tourmaline", 20.0, 40.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer ce collier.");
			AddRes(index, typeof(Tourmaline), "Tourmaline", 1, "Vous n'avez pas assez de tourmaline pour fabriquer ce collier.");

			
			index = AddCraft(typeof(Necklace1), "Colliers", "Collier serti d'émeraude", 25.0, 45.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer ce collier.");
			AddRes(index, typeof(Emerald), "Émeraude", 1, "Vous n'avez pas assez d'émeraude pour fabriquer ce collier.");

			index = AddCraft(typeof(Necklace1), "Colliers", "Collier serti de saphir", 25.0, 45.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer ce collier.");
			AddRes(index, typeof(Sapphire), "Saphir", 1, "Vous n'avez pas assez de saphir pour fabriquer ce collier.");

			index = AddCraft(typeof(Necklace1), "Colliers", "Collier serti de rubis", 30.0, 50.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer ce collier.");
			AddRes(index, typeof(Ruby), "Rubis", 1, "Vous n'avez pas assez de rubis pour fabriquer ce collier.");

			index = AddCraft(typeof(Necklace1), "Colliers", "Collier serti de saphir étoilé", 35.0, 55.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer ce collier.");
			AddRes(index, typeof(StarSapphire), "Saphir étoilé", 1, "Vous n'avez pas assez de saphir étoilé pour fabriquer ce collier.");

			index = AddCraft(typeof(Necklace1), "Colliers", "Collier serti de diamant", 40.0, 60.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer ce collier.");
			AddRes(index, typeof(Diamond), "Diamant", 1, "Vous n'avez pas assez de diamant pour fabriquer ce collier.");

			index = AddCraft(typeof(Collier), "Colliers", "Collier massif doré", 15.0, 35.0, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(Collier2), "Colliers", "Collier croix Ânkh", 15.0, 35.0, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(Collier3), "Colliers", "Collier bolo doré", 15.0, 35.0, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(Collier4), "Colliers", "Grande chaîne dorée", 20.0, 40.0, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(Collier5), "Colliers", "Collier croix Ânkh doré", 20.0, 40.0, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(Collier6), "Colliers", "Petit collier Usekh", 20.0, 40.0, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(Collier7), "Colliers", "Petit collier doré", 30.0, 50.0, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(Collier8), "Colliers", "Collier de feuilles dorées", 30.0, 50.0, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(Collier9), "Colliers", "Collier de perle", 30.0, 50.0, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(Collier10), "Colliers", "Collier simple avec pendentif", 35.0, 55.0, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(Collier11), "Colliers", "Collier simple", 35.0, 55.0, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(Collier12), "Colliers", "Grand collier doré avec pendentif", 40.0, 60.0, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(DiademeFeuilleOr), "Colliers", "Collier doré avec pendentif", 40.0, 60.0, typeof(GoldIngot), "lingots d'or", 3, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(EpauletteDoree), "Colliers", "Grand collier Usekh", 40.0, 60.0, typeof(GoldIngot), "lingots d'or", 5, "Vous n'avez pas assez de lingots.");





			#endregion

			#region Bracelets
			AddCraft(typeof(GoldBracelet), "Bracelets", "Bracelet Simple", 10.0, 30.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer ce bracelet.");


			AddCraft(typeof(Bracelet1), "Bracelets", "Bracelet", 10.0, 30.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer ce bracelet.");

			index = AddCraft(typeof(Bracelet1), "Bracelets", "Bracelet serti d'ambre", 15.0, 35.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer ce bracelet.");
			AddRes(index, typeof(Amber), "Ambre", 1, "Vous n'avez pas assez d'ambre pour fabriquer ce bracelet.");

			index = AddCraft(typeof(Bracelet1), "Bracelets", "Bracelet serti de citrine", 15.0, 35.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer ce bracelet.");
			AddRes(index, typeof(Citrine), "Citrine", 1, "Vous n'avez pas assez de citrine pour fabriquer ce bracelet.");

			index = AddCraft(typeof(Bracelet1), "Bracelets", "Bracelet serti d'améthyste", 20.0, 40.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer ce bracelet.");
			AddRes(index, typeof(Amethyst), "Améthyste", 1, "Vous n'avez pas assez d'améthyste pour fabriquer ce bracelet.");

			index = AddCraft(typeof(Bracelet1), "Bracelets", "Bracelet serti de tourmaline", 20.0, 40.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer ce bracelet.");
			AddRes(index, typeof(Tourmaline), "Tourmaline", 1, "Vous n'avez pas assez de tourmaline pour fabriquer ce bracelet.");

			index = AddCraft(typeof(Bracelet1), "Bracelets", "Bracelet serti d'émeraude", 25.0, 45.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer ce bracelet.");
			AddRes(index, typeof(Emerald), "Émeraude", 1, "Vous n'avez pas assez d'émeraude pour fabriquer ce bracelet.");

			index = AddCraft(typeof(Bracelet1), "Bracelets", "Bracelet serti de saphir", 25.0, 45.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer ce bracelet.");
			AddRes(index, typeof(Sapphire), "Saphir", 1, "Vous n'avez pas assez de saphir pour fabriquer ce bracelet.");

			index = AddCraft(typeof(Bracelet1), "Bracelets", "Bracelet serti de rubis", 30.0, 50.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer ce bracelet.");
			AddRes(index, typeof(Ruby), "Rubis", 1, "Vous n'avez pas assez de rubis pour fabriquer ce bracelet.");

			index = AddCraft(typeof(Bracelet1), "Bracelets", "Bracelet serti de saphir étoilé", 35.0, 55.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer ce bracelet.");
			AddRes(index, typeof(StarSapphire), "Saphir étoilé", 1, "Vous n'avez pas assez de saphir étoilé pour fabriquer ce bracelet.");

			index = AddCraft(typeof(Bracelet1), "Bracelets", "Bracelet serti de diamant", 40.0, 60.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer ce bracelet.");
			AddRes(index, typeof(Diamond), "Diamant", 1, "Vous n'avez pas assez de diamant pour fabriquer ce bracelet.");


			#endregion

			#region Boucles d'oreilles
			AddCraft(typeof(GoldEarrings), "Boucles d'oreilles", "Boucles d'oreilles simple ", 10.0, 30.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer ces boucles d'oreilles.");


			AddCraft(typeof(Earrings1), "Boucles d'oreilles", "Boucles d'oreilles", 10.0, 30.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer ces boucles d'oreilles.");

			index = AddCraft(typeof(Earrings1), "Boucles d'oreilles", "Boucles d'oreilles serti d'ambre", 15.0, 35.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer ces boucles d'oreilles.");
			AddRes(index, typeof(Amber), "Ambre", 1, "Vous n'avez pas assez d'ambre pour fabriquer ces boucles d'oreilles.");

			index = AddCraft(typeof(Earrings1), "Boucles d'oreilles", "Boucles d'oreilles serti de citrine", 15.0, 35.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer ces boucles d'oreilles.");
			AddRes(index, typeof(Citrine), "Citrine", 1, "Vous n'avez pas assez de citrine pour fabriquer ces boucles d'oreilles.");

			index = AddCraft(typeof(Earrings1), "Boucles d'oreilles", "Boucles d'oreilles serti d'améthyste", 20.0, 40.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer ces boucles d'oreilles.");
			AddRes(index, typeof(Amethyst), "Améthyste", 1, "Vous n'avez pas assez d'améthyste pour fabriquer ces boucles d'oreilles.");

			index = AddCraft(typeof(Earrings1), "Boucles d'oreilles", "Boucles d'oreilles serti de tourmaline", 20.0, 40.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer ces boucles d'oreilles.");
			AddRes(index, typeof(Tourmaline), "Tourmaline", 1, "Vous n'avez pas assez de tourmaline pour fabriquer ces boucles d'oreilles.");

			index = AddCraft(typeof(Earrings1), "Boucles d'oreilles", "Boucles d'oreilles serti d'émeraude", 25.0, 45.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer ces boucles d'oreilles.");
			AddRes(index, typeof(Emerald), "Émeraude", 1, "Vous n'avez pas assez d'émeraude pour fabriquer ces boucles d'oreilles.");

			index = AddCraft(typeof(Earrings1), "Boucles d'oreilles", "Boucles d'oreilles serti de saphir", 25.0, 45.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer ces boucles d'oreilles.");
			AddRes(index, typeof(Sapphire), "Saphir", 1, "Vous n'avez pas assez de saphir pour fabriquer ces boucles d'oreilles.");

			index = AddCraft(typeof(Earrings1), "Boucles d'oreilles", "Boucles d'oreilles serti de rubis", 30.0, 50.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer ces boucles d'oreilles.");
			AddRes(index, typeof(Ruby), "Rubis", 1, "Vous n'avez pas assez de rubis pour fabriquer ces boucles d'oreilles.");

			index = AddCraft(typeof(Earrings1), "Boucles d'oreilles", "Boucles d'oreilles serti de saphir étoilé", 35.0, 55.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer ces boucles d'oreilles.");
			AddRes(index, typeof(StarSapphire), "Saphir étoilé", 1, "Vous n'avez pas assez de saphir étoilé pour fabriquer ces boucles d'oreilles.");

			index = AddCraft(typeof(Earrings1), "Boucles d'oreilles", "Boucles d'oreilles serti de diamant", 40.0, 60.0, typeof(IronIngot), "Lingot de fer", 4, "Vous n'avez pas assez de lingots pour fabriquer ces boucles d'oreilles.");
			AddRes(index, typeof(Diamond), "Diamant", 1, "Vous n'avez pas assez de diamant pour fabriquer ces boucles d'oreilles.");

			#endregion

			#region Bijoux Divers
			index = AddCraft(typeof(Couronne2), "Bijoux Divers", "Petite couronne", 30.0, 80.0, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(Couronne3), "Bijoux Divers", "Diadème", 30.0, 80.0, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(Couronne4), "Bijoux Divers", "Grande couronne", 35.0, 85.0, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(Lunettes), "Bijoux Divers", "Lunette dorée", 35.0, 85.0, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(Tiare), "Bijoux Divers", "Tiare", 35.0, 85.0, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(Ceinture10), "Bijoux Divers", "Ceinture de feuilles dorées", 40.0, 90.0, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			index = AddCraft(typeof(MenotteDoree), "Bijoux Divers", "Menotte dorée", 40.0, 90.0, typeof(IronIngot), "lingots", 5, "Vous n'avez pas assez de lingots.");
			#endregion

			#region Paniers et boîtes
			index = AddCraft(typeof(RoundBasket), "Paniers et boîtes", "Panier rond", 10.0, 30.0, typeof(Kindling), "Petit Bois", 5, "Vous manquez de petit bois");
			AddRes(index, typeof(Shaft), 1027125, 3, 1044351);
			index = AddCraft(typeof(RoundBasketHandles), "Paniers et boîtes", "Panier rond avec poignées", 10.0, 30.0, typeof(Kindling), "Petit Bois", 5, "Vous manquez de petit bois");
			AddRes(index, typeof(Shaft), 1027125, 3, 1044351);
			index = AddCraft(typeof(SmallBushel), "Paniers et boîtes", "Petit panier rond avec poignées", 10.0, 30.0, typeof(Kindling), "Petit Bois", 5, "Vous manquez de petit bois");
			AddRes(index, typeof(Shaft), 1027125, 2, 1044351);
			index = AddCraft(typeof(PicnicBasket2), "Paniers et boîtes", "Panier à pique-nique", 25.0, 45.0, typeof(Kindling), "Petit Bois", 5, "Vous manquez de petit bois");
			AddRes(index, typeof(Shaft), 1027125, 2, 1044351);
			index = AddCraft(typeof(WinnowingBasket), "Paniers et boîtes", "Panier à vanner", 25.0, 45.0, typeof(Kindling), "Petit Bois", 5, "Vous manquez de petit bois");
			AddRes(index, typeof(Shaft), 1027125, 3, 1044351);
			index = AddCraft(typeof(SquareBasket), "Paniers et boîtes", "Panier carré", 25.0, 45.0, typeof(Kindling), "Petit Bois", 5, "Vous manquez de petit bois");
			AddRes(index, typeof(Shaft), 1027125, 3, 1044351);
			index = AddCraft(typeof(BasketCraftable), "Paniers et boîtes", "Panier tressé", 35.0, 50.0, typeof(Kindling), "Petit Bois", 5, "Vous manquez de petit bois");
			AddRes(index, typeof(Shaft), 1027125, 3, 1044351);
			index = AddCraft(typeof(TallRoundBasket), "Paniers et boîtes", "Panier haut tressé", 35.0, 50.0, typeof(Kindling), "Petit Bois", 5, "Vous manquez de petit bois");
			AddRes(index, typeof(Shaft), 1027125, 4, 1044351);
			index = AddCraft(typeof(SmallSquareBasket), "Paniers et boîtes", "Petit panier carré", 35.0, 50.0, typeof(Kindling), "Petit Bois", 5, "Vous manquez de petit bois");
			AddRes(index, typeof(Shaft), 1027125, 2, 1044351);
			index = AddCraft(typeof(TallBasket), "Paniers et boîtes", "Grand panier tressé", 45.0, 65.0, typeof(Kindling), "Petit Bois", 5, "Vous manquez de petit bois");
			AddRes(index, typeof(Shaft), 1027125, 4, 1044351);
			index = AddCraft(typeof(SmallRoundBasket), "Paniers et boîtes", "Panier tressé rond", 45.0, 65.0, typeof(Kindling), "Petit Bois", 5, "Vous manquez de petit bois");
			AddRes(index, typeof(Shaft), 1027125, 2, 1044351);
			index = AddCraft(typeof(GiftBoxAngel), "Paniers et boîtes", "Boite Cadeau, Ange", 45.0, 65.0, typeof(Kindling), "Petit Bois", 5, "Vous manquez de petit bois");
			AddRes(index, typeof(Shaft), 1027125, 2, 1044351);
			index = AddCraft(typeof(GiftBoxCube), "Paniers et boîtes", "Boite Cadeau, Carré", 55.0, 75.0, typeof(Kindling), "Petit Bois", 5, "Vous manquez de petit bois");
			AddRes(index, typeof(Shaft), 1027125, 2, 1044351);
			index = AddCraft(typeof(GiftBoxCylinder), "Paniers et boîtes", "Boite Cadeau, Cylindre", 55.0, 75.0, typeof(Kindling), "Petit Bois", 5, "Vous manquez de petit bois");
			AddRes(index, typeof(Shaft), 1027125, 2, 1044351);
			index = AddCraft(typeof(GiftBoxOctogon), "Paniers et boîtes", "Boite Cadeau, Octogone", 55.0, 75.0, typeof(Kindling), "Petit Bois", 5, "Vous manquez de petit bois");
			AddRes(index, typeof(Shaft), 1027125, 2, 1044351);
			index = AddCraft(typeof(GiftBoxRectangle), "Paniers et boîtes", "Boite Cadeau, Rectangle", 55.0, 75.0, typeof(Kindling), "Petit Bois", 5, "Vous manquez de petit bois");
			AddRes(index, typeof(Shaft), 1027125, 2, 1044351);
			index = AddCraft(typeof(RedVelvetGiftBox), "Paniers et boîtes", "Boite Cadeau, Petite rouge", 55.0, 75.0, typeof(Kindling), "Petit Bois", 5, "Vous manquez de petit bois");
			AddRes(index, typeof(Shaft), 1027125, 2, 1044351);

			#endregion

			#region Pièces d'assemblages
			index = AddCraft(typeof(Gears), "Pièces d'assemblages", "Engrenages", 5.0, 55.0, typeof(IronIngot), 1044036, 5, 1044037);
			index = AddCraft(typeof(ClockFrame), "Pièces d'assemblages", "Cadre d'horloge", 0.0, 50.0, typeof(RegularBoard), 1044041, 6, 1044351);
			SetUseSubRes2(index, true);
			index = AddCraft(typeof(BarrelTap), "Pièces d'assemblages", "Robinet de baril", 35.0, 85.0, typeof(IronIngot), 1044036, 5, 1044037);
			index = AddCraft(typeof(Springs), "Pièces d'assemblages", "Ressorts", 5.0, 55.0, typeof(IronIngot), 1044036, 5, 1044037);
			index = AddCraft(typeof(BarrelHoops), "Pièces d'assemblages", "Cercles de tonneau", -15.0, 35.0, typeof(IronIngot), 1044036, 5, 1044037);
			index = AddCraft(typeof(Hinge), "Pièces d'assemblages", "Charnière", 5.0, 55.0, typeof(IronIngot), 1044036, 5, 1044037);
			index = AddCraft(typeof(Axle), "Pièces d'assemblages", "Essieu", -25.0, 25.0, typeof(RegularBoard), 1044041, 2, 1044351);
			#endregion

			#region Assemblages
			index = AddCraft(typeof(AxleGears), "Assemblages", "Engrenage d'essieu", 0.0, 0.0, typeof(Axle), "Essieu", 1, 1044253);
			AddRes(index, typeof(Gears), 1044254, 1, 1044253);
			index = AddCraft(typeof(ClockParts), "Assemblages", "Pièces d'horloge", 0.0, 0.0, typeof(AxleGears), "Engrenage d'essieu", 1, 1044253);
			AddRes(index, typeof(Springs), "Ressorts", 1, 1044253);
			index = AddCraft(typeof(SextantParts), "Assemblages", "Pièces de sextant", 0.0, 0.0, typeof(AxleGears), "Engrenage d'essieu", 1, 1044253);
			AddRes(index, typeof(Hinge), "Charnière", 1, 1044253);
			index = AddCraft(typeof(ClockRight), "Assemblages", "Horloge (D)", 30.0, 60.0, typeof(ClockFrame), "Cadre d'horloge", 1, 1044253);
			AddRes(index, typeof(ClockParts), "Pièces d'horloge", 1, 1044253);
			index = AddCraft(typeof(ClockLeft), "Assemblages", "Horloge (G)", 30.0, 60.0, typeof(ClockFrame), "Cadre d'horloge", 1, 1044253);
			AddRes(index, typeof(ClockParts), "Pièces d'horloge", 1, 1044253);
			index = AddCraft(typeof(SmallGrandfatherClock), "Assemblages", "Petite Horloge Grand Père", 50.0, 90.0, typeof(ClockFrame), "Cadre d'horloge", 1, 1044253);
			AddRes(index, typeof(ClockParts), "Pièces d'horloge", 2, 1044253);
			AddRes(index, typeof(RegularBoard), 1044041, 8, 1044351);
			SetUseSubRes2(index, true);
			index = AddCraft(typeof(LargeGrandfatherClock), "Assemblages", "Horloge Grand Père", 50.0, 90.0, typeof(ClockFrame), "Cadre d'horloge", 1, 1044253);
			AddRes(index, typeof(ClockParts), "Pièces d'horloge", 2, 1044253);
			AddRes(index, typeof(RegularBoard), 1044041, 8, 1044351);
			SetUseSubRes2(index, true);
			index = AddCraft(typeof(WhiteGrandfatherClock), "Assemblages", "Horloge Grand Père Blanche", 50.0, 90.0, typeof(ClockFrame), "Cadre d'horloge", 1, 1044253);
			AddRes(index, typeof(ClockParts), "Pièces d'horloge", 2, 1044253);
			AddRes(index, typeof(RegularBoard), 1044041, 8, 1044351);
			SetUseSubRes2(index, true);
			index = AddCraft(typeof(Sextant), "Assemblages", "Sextant", 0.0, 0.0, typeof(SextantParts), "Pièces de sextant", 1, 1044253);
			AddRes(index, typeof(PlainoisLeather), 1044462, 3, 1044463);
			index = AddCraft(typeof(PotionKeg), "Assemblages", "Tonnelet de potions", 35.0, 55.0, typeof(Keg), "Tonnelet", 1, 1044253);
			AddRes(index, typeof(Bottle), 1044250, 10, 1044253);
			AddRes(index, typeof(BarrelLid), "Couvercle de baril", 1, 1044253);
			AddRes(index, typeof(BarrelTap), "Robinet de baril", 1, 1044253);
			index = AddCraft(typeof(Rope), "Assemblages", "Corde", 60.0, 120.0, typeof(Cloth), "Tissus", 10, "Vous avez besoin de plus de tissus");
			index = AddCraft(typeof(DistillerySouthAddonDeed), "Assemblages", "Distillerie (S)",65.0, 100.0, typeof(LiquorBarrel), "Tonneau d'alcool", 2, 1044253);
			AddRes(index, typeof(HeatingStand), "Support chauffant", 4, 1044253);
			AddRes(index, typeof(CopperWire), "Fil de cuivre", 20, 1044253);
			ForceNonExceptional(index);
			index = AddCraft(typeof(DistilleryEastAddonDeed), "Assemblages", "Distillerie (E)", 65.0, 100.0, typeof(LiquorBarrel), "Tonneau d'alcool", 2, 1044253);
			AddRes(index, typeof(HeatingStand), "Support chauffant", 4, 1044253);
			AddRes(index, typeof(CopperWire), "Fil de cuivre", 20, 1044253);
			ForceNonExceptional(index);
			index = AddCraft(typeof(AdvancedTrainingDummySouthDeed), "Assemblages", "Mannequin d'entrainement avancé (S)", 80.0, 110.0, typeof(TrainingDummySouthDeed), 1044336, 1, 1044253);
			ForceNonExceptional(index);
			index = AddCraft(typeof(AdvancedTrainingDummyEastDeed), "Assemblages", "Mannequin d'entrainement avancé (E)", 80.0, 110.0, typeof(TrainingDummyEastDeed), 1044335, 1, 1044253);
			ForceNonExceptional(index);
			index = AddCraft(typeof(SteamPoweredBeverageMakerDeed), "Assemblages", "Machine à café", 50.0, 80.0, typeof(IronIngot), "lingots", 30, "Vous n'avez pas assez de lingots.");
			AddRes(index, typeof(Gears), 1044254, 5, 1044253);
			AddRes(index, typeof(Axle), "Essieu", 5, 1044253);

			ForceNonExceptional(index);
			#endregion

			#region Ustensiles
			index = AddCraft(typeof(FoodPlate), "Ustensiles", "Assiette", 25.0, 45.0, typeof(IronIngot), 1044036, 5, 1044037);

			index = AddCraft(typeof(SpoonLeft), "Ustensiles", "Cuillière (G)", 0.0, 50.0, typeof(IronIngot), 1044036, 3, 1044037);
			index = AddCraft(typeof(SpoonRight), "Ustensiles", "Cuillière (D)", 0.0, 50.0, typeof(IronIngot), 1044036, 3, 1044037);
			index = AddCraft(typeof(ForkLeft), "Ustensiles", "Fourchette (G)", 0.0, 50.0, typeof(IronIngot), 1044036, 3, 1044037);
			index = AddCraft(typeof(ForkRight), "Ustensiles", "Fourchette (D)", 0.0, 50.0, typeof(IronIngot), 1044036, 3, 1044037);
			index = AddCraft(typeof(KnifeLeft), "Ustensiles", "Couteau (G)", 0.0, 50.0, typeof(IronIngot), 1044036, 3, 1044037);
			index = AddCraft(typeof(KnifeRight), "Ustensiles", "Couteau (D)", 0.0, 50.0, typeof(IronIngot), 1044036, 3, 1044037);
			index = AddCraft(typeof(Goblet), "Ustensiles", "Gobelet", 10.0, 60.0, typeof(IronIngot), 1044036, 5, 1044037);
			index = AddCraft(typeof(PewterMug), "Ustensiles", "Chope en étain", 10.0, 60.0, typeof(IronIngot), 1044036, 5, 1044037);
			index = AddCraft(typeof(Tray), "Ustensiles", "Plateau", 25.0, 75.0, typeof(RegularBoard), 1044041, 2, 1044351);
			index = AddCraft(typeof(Silverware), "Ustensiles", "Argenterie", 25.0, 75.0, typeof(IronIngot), 1044036, 4, 1044037);
			#endregion

			#region Luminaires et décorations
			index = AddCraft(typeof(Torch), "Luminaires et décorations", "Torche", 0.0, 50.0, typeof(RegularBoard), 1044041, 2, 1044253);
			index = AddCraft(typeof(CandleLarge), "Luminaires et décorations", "Chandelier Simple", 45.0, 105.0, typeof(IronIngot), 1044036, 5, 1044037);
			index = AddCraft(typeof(Candelabra), "Luminaires et décorations", "Chandelier", 55.0, 105.0, typeof(IronIngot), 1044036, 10, 1044037);
			index = AddCraft(typeof(CandelabraStand), "Luminaires et décorations", "Grand Chandelier", 65.0, 105.0, typeof(IronIngot), 1044036, 8, 1044037);
			index = AddCraft(typeof(WallSconce), "Luminaires et décorations", "Chandelle Murale", 35.0, 105.0, typeof(IronIngot), 1044036, 3, 1044037);
			index = AddCraft(typeof(WallTorch), "Luminaires et décorations", "Torche murale", 35.0, 105.0, typeof(IronIngot), 1044036, 3, 1044037);
			index = AddCraft(typeof(Lantern), "Luminaires et décorations", "Lanterne", 30.0, 80.0, typeof(IronIngot), 1044036, 5, 1044037);
			index = AddCraft(typeof(HeatingStand), "Luminaires et décorations", "Support chauffant", 60.0, 110.0, typeof(IronIngot), 1044036, 4, 1044037);
			index = AddCraft(typeof(ShojiLantern), "Luminaires et décorations", "Lanterne sophistiquée", 65.0, 115.0, typeof(IronIngot), 1044036, 30, 1044037);
			AddRes(index, typeof(RegularBoard), 1044041, 5, 1044351);
			index = AddCraft(typeof(Brazier), "Luminaires et décorations", "Brasero", 45.0, 100.0, typeof(IronIngot), 1044036, 55, 1044253);
			index = AddCraft(typeof(BrazierTall), "Luminaires et décorations", "Brasero Long", 65.0, 100.0, typeof(IronIngot), 1044036, 55, 1044253);
			index = AddCraft(typeof(DragonBrazier), "Luminaires et décorations", "Brasero Cage", 85.0, 100.0, typeof(IronIngot), 1044036, 55, 1044253);
			index = AddCraft(typeof(TerMurStyleCandelabra), "Luminaires et décorations", "Chandelier élégant", 55.0, 105.0, typeof(IronIngot), 1044036, 4, 1044037);
			index = AddCraft(typeof(PaperLantern), "Luminaires et décorations", "Lanterne en papier", 65.0, 115.0, typeof(IronIngot), 1044036, 30, 1044037);
			AddRes(index, typeof(RegularBoard), 1044041, 5, 1044351);
			index = AddCraft(typeof(RoundPaperLantern), "Luminaires et décorations", "Lanterne en papier ronde", 65.0, 115.0, typeof(IronIngot), 1044036, 30, 1044037);
			AddRes(index, typeof(RegularBoard), 1044041, 5, 1044351);
			index = AddCraft(typeof(WindChimes), "Luminaires et décorations", "Carillons éoliens", 80.0, 130.0, typeof(IronIngot), 1044036, 35, 1044037);
			index = AddCraft(typeof(FancyWindChimes), "Luminaires et décorations", "Carillons", 80.0, 130.0, typeof(IronIngot), 1044036, 35, 1044037);
			#endregion

			#region Divers
			index = AddCraft(typeof(KeyRing), "Divers", "Trousseau de clés", 10.0, 60.0, typeof(IronIngot), 1044036, 5, 1044037);
			index = AddCraft(typeof(Key), "Divers", "Clé en fer", 20.0, 70.0, typeof(IronIngot), 1044036, 3, 1044037);
			index = AddCraft(typeof(DyeTub), "Divers", "Bac de Teinture", 35.0, 65.0, typeof(RegularBoard), 1044041, 5, 1044351);
			index = AddCraft(typeof(Scales), "Divers", "Balance", 60.0, 110.0, typeof(IronIngot), 1044036, 4, 1044037);
			index = AddCraft(typeof(Globe), "Divers", "Globe terrestre", 55.0, 105.0, typeof(IronIngot), 1044036, 4, 1044037);
			index = AddCraft(typeof(Spyglass), "Divers", "Longue vue", 60.0, 110.0, typeof(IronIngot), 1044036, 4, 1044037);
			index = AddCraft(typeof(Fouet4), "Divers", "Fouet 4 mètres", 50.0, 70.0, typeof(PlainoisLeather), 1044462, 3, 1044463);
			index = AddCraft(typeof(Fouet6), "Divers", "Fouet 6 mètres", 65.0, 85.0, typeof(PlainoisLeather), 1044462, 4, 1044463);
			index = AddCraft(typeof(Fouet8), "Divers", "Fouet 8 mètres", 85.0, 105.0, typeof(PlainoisLeather), 1044462, 5, 1044463);
			index = AddCraft(typeof(IronWire), "Divers", "Fil de fer", 30.0, 60.0, typeof(IronIngot), "Lingot de fer", 2, 1044037);
			index = AddCraft(typeof(CopperWire), "Divers", "Fil de cuivre", 30.0, 60.0, typeof(CopperIngot), "Lingot de cuivre", 2, 1044037);
			index = AddCraft(typeof(SilverWire), "Divers", "Fil d'argent", 50.0, 90.0, typeof(IronIngot), "Lingot de fer", 2, 1044037);
			index = AddCraft(typeof(GoldWire), "Divers", "Fil d'or", 70.0, 110.0, typeof(GoldIngot), "Lingot d'or", 2, 1044037);
			index = AddCraft(typeof(Lunettes1), "Divers", "Lunettes de soleil", 50.0, 90.0, typeof(IronIngot), 1044036, 3, 1044037);
			index = AddCraft(typeof(Lunettes2), "Divers", "Lunettes de navigateur", 50.0, 90.0, typeof(IronIngot), 1044036, 3, 1044037);
			index = AddCraft(typeof(Lunettes3), "Divers", "Lunettes De vision", 50.0, 90.0, typeof(IronIngot), 1044036, 3, 1044037);
			index = AddCraft(typeof(Bottle), "Divers", "Bouteille Vide (1)", 15.0, 35.0, typeof(IronIngot), 1044036, 3, 1044037);
			index = AddCraft(typeof(Bottle), "Divers", "Bouteille Vide (Max)", 15.0, 35.0, typeof(IronIngot), 1044036, 3, 1044037);
			SetUseAllRes(index, true);
			AddCraft(typeof(EmptyWineBottle), "Divers", "Bouteille de Vin", 22.5, 42.5, typeof(IronIngot), 1044036, 5, 1044037);
			AddCraft(typeof(EmptyAleBottle), "Divers", "Bouteille de Bière", 32.5, 52.5, typeof(IronIngot), 1044036, 5, 1044037);
			index = AddCraft(typeof(PetLeash), "Divers", "Harnais pour animaux", 70.0, 110.0, typeof(PlainoisLeather), 1044462, 5, 1044463);
			AddRes(index, typeof(PoussiereNecrotique), "Poussière Nécrotique", 10, "Vous n'avez pas suffisament de Poussière Nécrotique");

			#endregion

			// Set the overridable material
			SetSubRes(typeof(IronIngot), 1044022);

			// Add every material you want the player to be able to choose from
			// This will override the overridable material
			AddSubRes(typeof(IronIngot), "Fer", 0.0, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(BronzeIngot), "Bronze", 0.0, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(CopperIngot), "Copper", 0.0, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(SonneIngot), "Sonne", 20.0, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(ArgentIngot), "Argent", 20.0, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(BorealeIngot), "Boréale", 20.0, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(ChrysteliarIngot), "Chrysteliar", 20.0, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(GlaciasIngot), "Glacias", 20.0, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(LithiarIngot), "Lithiar", 20.0, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(AcierIngot), "Acier", 40.0, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(DurianIngot), "Durian", 40.0, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(EquilibrumIngot), "Équilibrum", 40.0, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(GoldIngot), "Or", 40.0, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(JolinarIngot), "Jolinar", 40.0, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(JusticiumIngot), "Justicium", 40.0, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(AbyssiumIngot), "Abyssium", 60.0, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(BloodiriumIngot), "Bloodirium", 60.0, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(HerbrositeIngot), "Herbrosite", 60.0, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(KhandariumIngot), "Khandarium", 60.0, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(MytherilIngot), "Mytheril", 60.0, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(SombralirIngot), "Sombralir", 60.0, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(DraconyrIngot), "Draconyr", 80.0, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(HeptazionIngot), "Heptazion", 80.0, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(OceanisIngot), "Océanis", 80.0, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(BraziumIngot), "Brazium", 80.0, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(LuneriumIngot), "Lunerium", 80.0, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(MarinarIngot), "Marinar", 80.0, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(NostalgiumIngot), "Nostalgium", 100.0, "Vous n'avez pas les compétences requises pour forger ce métal.");


			// Set the overridable material
			SetSubRes2(typeof(RegularBoard), "Commun");

			// Add every material you want the player to be able to choose from
			// This will override the overridable material
			AddSubRes2(typeof(RegularBoard), "Commun", 0.0, "Vous ne savez pas travailler le bois Commun");
			//AddSubRes2(typeof(PlainoisBoard), "Plainois", 0.0, "Vous ne savez pas travailler le bois plainois");
			//AddSubRes2(typeof(CollinoisBoard), "Collinois", 20.0, "Vous ne savez pas travailler le bois collinois");
			//AddSubRes2(typeof(ForestierBoard), "Forestier", 20.0, "Vous ne savez pas travailler le bois forestier");
			//AddSubRes2(typeof(SavanoisBoard), "Savanois", 40.0, "Vous ne savez pas travailler le bois savanois");
			//AddSubRes2(typeof(DesertiqueBoard), "Desertique", 40.0, "Vous ne savez pas travailler le bois desertique");
			//AddSubRes2(typeof(MontagnardBoard), "Montagnard", 60.0, "Vous ne savez pas travailler le bois montagnard");
			//AddSubRes2(typeof(VolcaniqueBoard), "Volcanique", 60.0, "Vous ne savez pas travailler le bois volcanique");
			//AddSubRes2(typeof(TropicauxBoard), "Tropicaux", 80.0, "Vous ne savez pas travailler le bois tropicaux");
			//AddSubRes2(typeof(ToundroisBoard), "Toundrois", 80.0, "Vous ne savez pas travailler le bois toundrois");
			//AddSubRes2(typeof(AncienBoard), "Ancien", 100.0, "Vous ne savez pas travailler le bois ancien");

			MarkOption = true;
			Repair = true;
			CanEnhance = true;
			CanAlter = true;
		}
	}

	public abstract class TrapCraft : CustomCraft
	{
		private LockableContainer m_Container;

		public LockableContainer Container => m_Container;

		public abstract TrapType TrapType { get; }

		public TrapCraft(Mobile from, CraftItem craftItem, CraftSystem craftSystem, Type typeRes, ITool tool, int quality)
			: base(from, craftItem, craftSystem, typeRes, tool, quality)
		{
		}

		private int Verify(LockableContainer container)
		{
			if (container == null || container.KeyValue == 0)
				return 1005638; // You can only trap lockable chests.
			if (From.Map != container.Map || !From.InRange(container.GetWorldLocation(), 2))
				return 500446; // That is too far away.
			if (!container.Movable)
				return 502944; // You cannot trap this item because it is locked down.
			if (!container.IsAccessibleTo(From))
				return 502946; // That belongs to someone else.
			if (container.Locked)
				return 502943; // You can only trap an unlocked object.
			if (container.TrapType != TrapType.None)
				return 502945; // You can only place one trap on an object at a time.

			return 0;
		}

		private bool Acquire(object target, out int message)
		{
			LockableContainer container = target as LockableContainer;

			message = Verify(container);

			if (message > 0)
			{
				return false;
			}
			else
			{
				m_Container = container;
				return true;
			}
		}

		public override void EndCraftAction()
		{
			From.SendLocalizedMessage(502921); // What would you like to set a trap on?
			From.Target = new ContainerTarget(this);
		}

		private class ContainerTarget : Target
		{
			private readonly TrapCraft m_TrapCraft;

			public ContainerTarget(TrapCraft trapCraft)
				: base(-1, false, TargetFlags.None)
			{
				m_TrapCraft = trapCraft;
			}

			protected override void OnTarget(Mobile from, object targeted)
			{
				int message;

				if (m_TrapCraft.Acquire(targeted, out message))
					m_TrapCraft.CraftItem.CompleteCraft(m_TrapCraft.Quality, false, m_TrapCraft.From, m_TrapCraft.CraftSystem, m_TrapCraft.TypeRes, m_TrapCraft.Tool, m_TrapCraft);
				else
					Failure(message);
			}

			protected override void OnTargetCancel(Mobile from, TargetCancelType cancelType)
			{
				if (cancelType == TargetCancelType.Canceled)
					Failure(0);
			}

			private void Failure(int message)
			{
				Mobile from = m_TrapCraft.From;
				ITool tool = m_TrapCraft.Tool;

				if (Siege.SiegeShard)
				{
					AOS.Damage(from, Utility.RandomMinMax(80, 120), 50, 50, 0, 0, 0);
					message = 502902; // You fail to set the trap, and inadvertantly hurt yourself in the process.
				}

				if (tool != null && !tool.Deleted && tool.UsesRemaining > 0)
					from.SendGump(new CraftGump(from, m_TrapCraft.CraftSystem, tool, message));
				else if (message > 0)
					from.SendLocalizedMessage(message);
			}
		}

		public override Item CompleteCraft(out int message)
		{
			message = Verify(Container);

			if (message == 0)
			{
				int trapLevel = (int)(From.Skills.Tinkering.Value / 10);

				Container.TrapType = TrapType;
				Container.TrapPower = trapLevel * 9;
				Container.TrapLevel = trapLevel;
				Container.TrapOnLockpick = true;

				message = 1005639; // Trap is disabled until you lock the chest.
			}

			return null;
		}
	}

	[CraftItemID(0x1BFC)]
	public class DartTrapCraft : TrapCraft
	{
		public override TrapType TrapType => TrapType.DartTrap;

		public DartTrapCraft(Mobile from, CraftItem craftItem, CraftSystem craftSystem, Type typeRes, ITool tool, int quality)
			: base(from, craftItem, craftSystem, typeRes, tool, quality)
		{
		}
	}

	[CraftItemID(0x113E)]
	public class PoisonTrapCraft : TrapCraft
	{
		public override TrapType TrapType => TrapType.PoisonTrap;

		public PoisonTrapCraft(Mobile from, CraftItem craftItem, CraftSystem craftSystem, Type typeRes, ITool tool, int quality)
			: base(from, craftItem, craftSystem, typeRes, tool, quality)
		{
		}
	}

	[CraftItemID(0x370C)]
	public class ExplosionTrapCraft : TrapCraft
	{
		public override TrapType TrapType => TrapType.ExplosionTrap;

		public ExplosionTrapCraft(Mobile from, CraftItem craftItem, CraftSystem craftSystem, Type typeRes, ITool tool, int quality)
			: base(from, craftItem, craftSystem, typeRes, tool, quality)
		{
		}
	}
}
