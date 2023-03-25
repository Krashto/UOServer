﻿#region References
using Server.Items;
using System;
#endregion

namespace Server.Engines.Craft
{

	#region Mondain's Legacy
	public enum SmithRecipes
	{
		// magical
		TrueSpellblade = 300,
		IcySpellblade = 301,
		FierySpellblade = 302,
		SpellbladeOfDefense = 303,
		TrueAssassinSpike = 304,
		ChargedAssassinSpike = 305,
		MagekillerAssassinSpike = 306,
		WoundingAssassinSpike = 307,
		TrueLeafblade = 308,
		Luckblade = 309,
		MagekillerLeafblade = 310,
		LeafbladeOfEase = 311,
		KnightsWarCleaver = 312,
		ButchersWarCleaver = 313,
		SerratedWarCleaver = 314,
		TrueWarCleaver = 315,
		AdventurersMachete = 316,
		OrcishMachete = 317,
		MacheteOfDefense = 318,
		DiseasedMachete = 319,
		Runesabre = 320,
		MagesRuneBlade = 321,
		RuneBladeOfKnowledge = 322,
		CorruptedRuneBlade = 323,
		TrueRadiantScimitar = 324,
		DarkglowScimitar = 325,
		IcyScimitar = 326,
		TwinklingScimitar = 327,
		GuardianAxe = 328,
		SingingAxe = 329,
		ThunderingAxe = 330,
		HeavyOrnateAxe = 331,
		RubyMace = 332, //good
		EmeraldMace = 333, //good
		SapphireMace = 334, //good
		SilverEtchedMace = 335, //good
		BoneMachete = 336,

		// arties
		RuneCarvingKnife = 350,
		ColdForgedBlade = 351,
		OverseerSunderedBlade = 352,
		LuminousRuneBlade = 353,
		ShardTrasher = 354, //good

		// doom
		BritchesOfWarding = 355,
		GlovesOfFeudalGrip = 356,
	}
	#endregion

	public class DefBlacksmithy : CraftSystem
	{
		public override SkillName MainSkill => SkillName.Blacksmith;

		//    public override int GumpTitleNumber => 1044002;

		public override string GumpTitleString => "Forge";



		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem => m_CraftSystem ?? (m_CraftSystem = new DefBlacksmithy());

		public override CraftECA ECA => CraftECA.Chance3Max;

		public override double GetChanceAtMin(CraftItem item)
		{
			if (item.NameNumber == 1157349 || item.NameNumber == 1157345) // Gloves Of FeudalGrip and Britches Of Warding
				return 0.05; // 5%

			return 0.0; // 0%
		}

		private DefBlacksmithy()
			: base(1, 1, 1.25) // base( 1, 2, 1.7 )
		{
			/*
            base( MinCraftEffect, MaxCraftEffect, Delay )
            MinCraftEffect    : The minimum number of time the mobile will play the craft effect
            MaxCraftEffect    : The maximum number of time the mobile will play the craft effect
            Delay            : The delay between each craft effect
            Example: (3, 6, 1.7) would make the mobile do the PlayCraftEffect override
            function between 3 and 6 time, with a 1.7 second delay each time.
            */
		}

		private static readonly Type typeofAnvil = typeof(AnvilAttribute);
		private static readonly Type typeofForge = typeof(ForgeAttribute);

		public static void CheckAnvilAndForge(Mobile from, int range, out bool anvil, out bool forge)
		{
			anvil = false;
			forge = false;

			Map map = from.Map;

			if (map == null)
			{
				return;
			}

			IPooledEnumerable eable = map.GetItemsInRange(from.Location, range);

			foreach (Item item in eable)
			{
				Type type = item.GetType();

				bool isAnvil = (type.IsDefined(typeofAnvil, false) || item.ItemID == 4015 || item.ItemID == 4016 ||
								item.ItemID == 0x2DD5 || item.ItemID == 0x2DD6 || (item.ItemID >= 0xA102 && item.ItemID <= 0xA10D));
				bool isForge = (type.IsDefined(typeofForge, false) || item.ItemID == 4017 ||
								(item.ItemID >= 6522 && item.ItemID <= 6569) || item.ItemID == 0x2DD8) ||
								item.ItemID == 0xA531 || item.ItemID == 0xA535;

				if (!isAnvil && !isForge)
				{
					continue;
				}

				if ((from.Z + 16) < item.Z || (item.Z + 16) < from.Z || !from.InLOS(item))
				{
					continue;
				}

				anvil = anvil || isAnvil;
				forge = forge || isForge;

				if (anvil && forge)
				{
					break;
				}
			}

			eable.Free();

			for (int x = -range; (!anvil || !forge) && x <= range; ++x)
			{
				for (int y = -range; (!anvil || !forge) && y <= range; ++y)
				{
					StaticTile[] tiles = map.Tiles.GetStaticTiles(from.X + x, from.Y + y, true);

					for (int i = 0; (!anvil || !forge) && i < tiles.Length; ++i)
					{
						int id = tiles[i].ID;

						bool isAnvil = (id == 4015 || id == 4016 || id == 0x2DD5 || id == 0x2DD6);
						bool isForge = (id == 4017 || (id >= 6522 && id <= 6569) || id == 0x2DD8);

						if (!isAnvil && !isForge)
						{
							continue;
						}

						if ((from.Z + 16) < tiles[i].Z || (tiles[i].Z + 16) < from.Z ||
							!from.InLOS(new Point3D(from.X + x, from.Y + y, tiles[i].Z + (tiles[i].Height / 2) + 1)))
						{
							continue;
						}

						anvil = anvil || isAnvil;
						forge = forge || isForge;
					}
				}
			}
		}

		public override int CanCraft(Mobile from, ITool tool, Type itemType)
		{
			int num = 0;

			if (tool == null || tool.Deleted || tool.UsesRemaining <= 0)
			{
				return 1044038; // You have worn out your tool!
			}

			if (tool is Item && !BaseTool.CheckTool((Item)tool, from))
			{
				return 1048146; // If you have a tool equipped, you must use that tool.
			}

			else if (!tool.CheckAccessible(from, ref num))
			{
				return num; // The tool must be on your person to use.
			}

			if (tool is AddonToolComponent && from.InRange(((AddonToolComponent)tool).GetWorldLocation(), 2))
			{
				return 0;
			}

			bool anvil, forge;
			CheckAnvilAndForge(from, 2, out anvil, out forge);

			if (anvil && forge)
			{
				return 0;
			}

			return 1044267; // You must be near an anvil and a forge to smith items.
		}

		public override void PlayCraftEffect(Mobile from)
		{
			// no animation, instant sound
			//if ( from.Body.Type == BodyType.Human && !from.Mounted )
			//    from.Animate( 9, 5, 1, true, false, 0 );
			//new InternalTimer( from ).Start();
			from.PlaySound(0x2A);
		}

		// Delay to synchronize the sound with the hit on the anvil
		private class InternalTimer : Timer
		{
			private readonly Mobile m_From;

			public InternalTimer(Mobile from)
				: base(TimeSpan.FromSeconds(0.7))
			{
				m_From = from;
			}

			protected override void OnTick()
			{
				m_From.PlaySound(0x2A);
			}
		}

		public override int PlayEndingEffect(
			Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, bool makersMark, CraftItem item)
		{
			if (toolBroken)
			{
				from.SendLocalizedMessage(1044038); // You have worn out your tool
			}

			if (failed)
			{
				if (lostMaterial)
				{
					return 1044043; // You failed to create the item, and some of your materials are lost.
				}

				return 1044157; // You failed to create the item, but no materials were lost.
			}

			if (quality == 0)
			{
				return 502785; // You were barely able to make this item.  It's quality is below average.
			}

			if (makersMark && quality == 2)
			{
				return 1044156; // You create an exceptional quality item and affix your maker's mark.
			}

			if (quality == 2)
			{
				return 1044155; // You create an exceptional quality item.
			}

			return 1044154; // You create the item.
		}

		public override void InitCraftList()
		{
			/*
            Synthax for a SIMPLE craft item
            AddCraft( ObjectType, Group, MinSkill, MaxSkill, ResourceType, Amount, Message )
            ObjectType        : The type of the object you want to add to the build list.
            Group            : The group in wich the object will be showed in the craft menu.
            MinSkill        : The minimum of skill value
            MaxSkill        : The maximum of skill value
            ResourceType    : The type of the resource the mobile need to create the item
            Amount            : The amount of the ResourceType it need to create the item
            Message            : String or Int for Localized.  The message that will be sent to the mobile, if the specified resource is missing.
            Synthax for a COMPLEXE craft item.  A complexe item is an item that need either more than
            only one skill, or more than only one resource.
            Coming soon....
            */

			int index;
			#region "Armure Légère"
			AddCraft(typeof(RingmailGloves), "Armure Légère", "Gants d’anneaux", 20.0, 40.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(RingmailGorget), "Armure Légère", "Gorgerin d’anneaux", 22.0, 42.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(RingmailLegs), "Armure Légère", "Jambes d’anneaux", 28.0, 48.0, typeof(IronIngot), 1044036, 16, 1044037);
			AddCraft(typeof(RingmailArms), "Armure Légère", "Brassard d’anneaux", 25.0, 45.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(RingmailChest), "Armure Légère", "Torse d’anneaux", 32.0, 52.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(PlastronMaille2), "Armure Légère", "Torse d’anneaux fins", 32.0, 52.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(JambiereMaille2), "Armure Légère", "Jambière d’anneaux fins", 28.0, 48.0, typeof(IronIngot), 1044036, 16, 1044037);
			AddCraft(typeof(BrassardMaille), "Armure Légère", "Brassard d’anneaux fins", 25.0, 45.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(Bascinet), "Armure Légère","Bascinet", 40.0, 60.0, typeof(IronIngot), 1044036, 15, 1044037);
			AddCraft(typeof(Helmet), "Armure Légère", "Casque", 35.0, 55.0, typeof(IronIngot), 1044036, 15, 1044037);
			AddCraft(typeof(NorseHelm), "Armure Légère", "Haume Nordique", 40.0, 60.0, typeof(IronIngot), 1044036, 15, 1044037);
			#endregion

			#region "Armure Intermédiaire"
			AddCraft(typeof(ChainCoif), "Armure Intermédiaire", "Coiffe de mailles", 40.0, 60.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(CasqueKorain), "Armure Intermédiaire", "Casque Korain", 40.0, 60.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(ChainGorget), "Armure Intermédiaire", "Gorgerin de mailles", 42.0, 62.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(ChainmailArms), "Armure Intermédiaire", "Brassards de mailles", 45.0, 65.0, typeof(IronIngot), 1044036, 16, 1044037);
			AddCraft(typeof(ChainLegs), "Armure Intermédiaire", "Jambes de mailles", 48.0, 68.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(ChainChest), "Armure Intermédiaire", "Tunique de maille", 50.0, 70.0, typeof(IronIngot), 1044036, 20, 1044037);
			AddCraft(typeof(CloseHelm), "Armure Intermédiaire", "Casque fermé", 45.0, 65.0, typeof(IronIngot), 1044036, 15, 1044037);


			AddCraft(typeof(CasqueMaille), "Armure Intermédiaire", "Coiffe de mailles matelassée", 40.0, 60.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(GantsMaille), "Armure Intermédiaire", "Gants de mailles matelassées", 43.0, 63.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(JambiereMaille), "Armure Intermédiaire", "Jambière de mailles matelassée", 48.0, 68.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(PlastronMaille), "Armure Intermédiaire", "Tunique de mailles matelassée", 50.0, 70.0, typeof(IronIngot), 1044036, 20, 1044037);
			#endregion

			#region "Armure Lourde"
			AddCraft(typeof(PlateArms), "Armure Lourde", "Brassards de plaque", 45.0, 65.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(PlateGloves), "Armure Lourde", "Gants de plaque", 42.0, 62.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(PlateGorget), "Armure Lourde", "Gorgerin de plaque", 39.0, 59.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(PlateLegs), "Armure Lourde", "Jambières de plaque", 48.0, 68.0, typeof(IronIngot), 1044036, 20, 1044037);
			AddCraft(typeof(PlateChest), "Armure Lourde", "Torse de plaque", 52.0, 72.0, typeof(IronIngot), 1044036, 25, 1044037);
			AddCraft(typeof(FemalePlateChest), "Armure Lourde", "Torse de plaque femme", 51.0, 71.0, typeof(IronIngot), 1044036, 20, 1044037);
			AddCraft(typeof(BrassardChaos), "Armure Lourde", "Brassard du Chaos", 45.0, 65.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(PlastronChaos), "Armure Lourde", "Plastron du Chaos", 52.0, 72.0, typeof(IronIngot), 1044036, 25, 1044037);
			AddCraft(typeof(BrassardDecoratif), "Armure Lourde", "Brassard Décoratif", 45.0, 65.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(JambiereDecoratif), "Armure Lourde", "Jambière Décoratif", 48.0, 68.0, typeof(IronIngot), 1044036, 20, 1044037);
			AddCraft(typeof(PlastronDecoratif), "Armure Lourde", "Plastron Décoratif", 52.0, 72.0, typeof(IronIngot), 1044036, 25, 1044037);
			AddCraft(typeof(BottesElfique), "Armure Lourde", "Bottes Elfique", 41.0, 61.0, typeof(IronIngot), 1044036, 20, 1044037);
			AddCraft(typeof(GantsElfique), "Armure Lourde", "Gants Elfique", 42.0, 62.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(GorgetElfique), "Armure Lourde", "Gorget Elfique", 39.0, 59.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(PlastronElfique), "Armure Lourde", "Plastron Elfique", 52.0, 72.0, typeof(IronIngot), 1044036, 25, 1044037);
			AddCraft(typeof(PlastronPlaque), "Armure Lourde", "Harnois", 52.0, 72.0, typeof(IronIngot), 1044036, 25, 1044037);
			AddCraft(typeof(PlastronPlaqueDoree), "Armure Lourde", "Plastron de plaque Dorée", 52.0, 72.0, typeof(IronIngot), 1044036, 25, 1044037);
			AddCraft(typeof(PlateHelm), "Armure Lourde", "Casque de Plaque", 50.0, 70.0, typeof(IronIngot), 1044036, 15, 1044037);
			AddCraft(typeof(CasqueChaos), "Armure Lourde", "Casque du Chaos", 50.0, 70.0, typeof(IronIngot), 1044036, 15, 1044037);


			#endregion


			#region "Boucliers"
			AddCraft(typeof(Buckler), "Boucliers", "Bouclier", 32.0, 52.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(MetalShield), "Boucliers", "Rampart", 39.0, 59.0, typeof(IronIngot), 1044036, 14, 1044037);
			index = AddCraft(typeof(SmallPlateShield), "Boucliers", "Targe", 32.0, 52.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(WoodenKiteShield), "Boucliers", "La pointe", 41.0, 61.0, typeof(IronIngot), 1044036, 8, 1044037);
			AddCraft(typeof(MediumPlateShield), "Boucliers", "Rondache", 49.0, 69.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(BronzeShield), "Boucliers", "Rondache résonnante", 36.0, 56.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(EcuBois), "Boucliers", "Écu de bois", 32.0, 52.0, typeof(IronIngot), 1044036, 8, 1044037);
			AddCraft(typeof(BouclierRond2), "Boucliers", "Bouclier Rond", 32.0, 52.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(Targe3), "Boucliers", "Targe renforcé", 41.0, 61.0, typeof(IronIngot), 1044036, 25, 1044037);
			AddCraft(typeof(Rondache), "Boucliers", "Rondache renforcée", 41.0, 41.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(MetalKiteShield), "Boucliers", "Le blason", 45.0, 65.0, typeof(IronIngot), 1044036, 16, 1044037);
			AddCraft(typeof(BouclierRond), "Boucliers", "Bouclier Rond Renforcé", 41.0, 61.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(ChaosShield), "Boucliers", "Targe décoré", 41.0, 61.0, typeof(IronIngot), 1044036, 25, 1044037);
			AddCraft(typeof(HeaterShield), "Boucliers", "Muraille", 49.0, 49.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(Pavois), "Boucliers", "Pavois", 32.0, 52.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(Targe), "Boucliers", "Targe Bicolore", 41.0, 61.0, typeof(IronIngot), 1044036, 25, 1044037);
			AddCraft(typeof(OrderShield), "Boucliers", "Égide", 41.0, 61.0, typeof(IronIngot), 1044036, 25, 1044037);
			AddCraft(typeof(EcuLong), "Boucliers", "Écu Long", 41.0, 61.0, typeof(IronIngot), 1044036, 16, 1044037);
			AddCraft(typeof(Pavois2), "Boucliers", "Pavois Décoratif", 41.0, 61.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(Targe2), "Boucliers", "Rondache Colimaçon", 41.0, 61.0, typeof(IronIngot), 1044036, 25, 1044037);
			#endregion

			#region "Armes de poings"
			AddCraft(typeof(DoubleLames), "Armes de poings", "Double Lames de poing", 0.0, 25.0, typeof(IronIngot), 1044036, 15, 1044037);
			AddCraft(typeof(Sai), "Armes de poings", "Sai", 10.0, 35.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(Kama), "Armes de poings", "Kama", 10.0, 35.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(Tekagi), "Armes de poings", "Griffes", 20.0, 55.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(AnneauxCombat), "Armes de poings", "Anneaux de Combat", 20.0, 55.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(GriffesCombat), "Armes de poings", "Griffes de Combat", 35.0, 65.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(KamaKuya), "Armes de poings", "Kama Kuya", 35.0, 65.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(LameCirculaire), "Armes de poings", "Lames Circulaires", 50.0, 75.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(Kama1), "Armes de poings", "Kama Bonga", 50.0, 75.0, typeof(IronIngot), 1044036, 12, 1044037);
			#endregion

			#region "Dagues"
			AddCraft(typeof(Dagger), "Dagues", "Dague", 0.0, 40.0, typeof(IronIngot), 1044036, 3, 1044037);
			AddCraft(typeof(ElvenSpellblade), "Dagues", "Égorgeuse", 20.0, 40.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(AssassinSpike), "Dagues", "Épineuse", 25.0, 45.0, typeof(IronIngot), 1044036, 9, 1044037);
			AddCraft(typeof(Leafblade), "Dagues", "Coupe-gorge", 30.0, 50.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(SkinningKnife), "Dagues", 1023781, 0.0, 20.0, typeof(IronIngot), 1044036, 2, 1044037);
			AddCraft(typeof(Cleaver), "Dagues", 1097478, 0.0, 20.0, typeof(IronIngot), 1044036, 3, 1044037);
			AddCraft(typeof(ButcherKnife), "Dagues", 1097486, 0.0, 20.0, typeof(IronIngot), 1044036, 2, 1044037);
			#endregion

			#region "Épées"
			AddCraft(typeof(BoneHarvester), "Épées", "Serpe", 10.0, 35.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(Broadsword), "Épées", "Épée courte", 10.0, 35.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(Cutlass), "Épées", "Sabre Kroise", 10.0, 35.0, typeof(IronIngot), 1044036, 8, 1044037);
			AddCraft(typeof(Katana), "Épées", "Katana", 10.0, 35.0, typeof(IronIngot), 1044036, 8, 1044037);
			AddCraft(typeof(Longsword), "Épées", "Épée longue", 10.0, 35.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(Scimitar), "Épées", "Cimeterre", 10.0, 35.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(VikingSword), "Épées", "Épée Kaloise", 10.0, 35.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(EpeeCourte), "Épées", "Épée Koraine", 10.0, 35.0, typeof(IronIngot), 1044036, 8, 1044037);
			AddCraft(typeof(SabreLuxe), "Épées", "Sabre Kershe", 30.0, 55.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(EpeeBatardeLuxe), "Épées", "Épée bâtarde de luxe", 30.0, 55.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(EpeeDoubleTranchant), "Épées", "Épée à Double Tranchants", 30.0, 55.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(EpeeLongue), "Épées", "Épée Longue", 30.0, 55.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(EpeeBatarde), "Épées", "Épée bâtarde", 45.0, 70.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(EpeeDeuxMains), "Épées", "Épée Deux Mains", 45.0, 70.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(Runire), "Épées", "Runire", 45.0, 70.0, typeof(IronIngot), 1044036, 8, 1044037);
			AddCraft(typeof(NoDachi), "Épées", "Éclat solaire", 45.0, 70.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(Wakizashi), "Épées", "Surineur", 45.0, 70.0, typeof(IronIngot), 1044036, 8, 1044037);
			AddCraft(typeof(RadiantScimitar), "Épées", "Cimeterre infini", 45.0, 70.0, typeof(IronIngot), 1044036, 15, 1044037);
			AddCraft(typeof(RuneBlade), "Épées", "Lame vorpal", 45.0, 70.0, typeof(IronIngot), 1044036, 15, 1044037);
			AddCraft(typeof(ElvenMachete), "Épées", "Machette runique", 60.0, 85.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(DoubleEpee), "Épées", "Double épée", 60.0, 85.0, typeof(IronIngot), 1044036, 15, 1044037);
			AddCraft(typeof(CrescentBlade), "Épées", "Épée Croissant", 60.0, 85.0, typeof(IronIngot), 1044036, 15, 1044037);
			AddCraft(typeof(WakizashiLong), "Épées", "Wakizashi Long", 75.0, 105.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(Runire), "Épées", "Runire", 75.0, 105.0, typeof(IronIngot), 1044036, 8, 1044037);
			AddCraft(typeof(Daisho), "Épées", "Les jumelles", 75.0, 105.0, typeof(IronIngot), 1044036, 15, 1044037);
			#endregion

			#region "Haches"
			AddCraft(typeof(Axe), "Haches", "Hache simple", 10.0, 35.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(BattleAxe), "Haches", "Hache de guerre", 10.0, 35.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(DoubleAxe), "Haches", "Hache double", 10.0, 35.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(ExecutionersAxe), "Haches", "Hachette", 30.0, 55.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(LargeBattleAxe), "Haches", "Hache de bataille", 30.0, 55.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(TwoHandedAxe), "Haches", "Hache à deux mains", 30.0, 55.0, typeof(IronIngot), 1044036, 16, 1044037);
			AddCraft(typeof(WarAxe), "Haches", "Tranchar", 30.0, 55.0, typeof(IronIngot), 1044036, 16, 1044037);
			AddCraft(typeof(GrandeHache), "Haches", "Éventreuse", 45.0, 70.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(GrandeHacheDouble), "Haches", "Francisque", 45.0, 70.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(HacheDouble), "Haches", "Trombe", 45.0, 70.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(HAchePique), "Haches", "Barbelé", 60.0, 85.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(HacheDoublePiques), "Haches", "Exécutrice", 60.0, 85.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(DoubleAxe), "Haches", "Naga", 60.0, 85.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(HacheDoubleNaine), "Haches", "Gardienne", 60.0, 85.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(OrnateAxe), "Haches", "Hache ornée", 75.0, 105.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(DualShortAxes), "Haches", "Double hache courte", 75.0, 105.0, typeof(IronIngot), 1044036, 24, 1044037);
			AddCraft(typeof(DoubleHachette), "Haches", "Double Hachette", 75.0, 105.0, typeof(IronIngot), 1044036, 15, 1044037);

			
			#endregion

			#region Hallebarde
			index = AddCraft(typeof(Pitchfork), "Hallebardes", "Pitchfork", 10.0, 35.0, typeof(IronIngot), "Iron ingot", 5, "You do not have enough iron ingots to make that.");
			AddCraft(typeof(Bardiche), "Hallebardes", "Bardiche", 40.0, 60.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(Hellebarde), "Hallebardes", "Hellebarde", 50.0, 70.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(BladedStaff), "Hallebardes", "BladedStaff", 55.0, 75.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(DoubleBladedStaff), "Hallebardes", "DoubleBladedStaff", 80.0, 100.0, typeof(IronIngot), 1044036, 16, 1044037);
			AddCraft(typeof(Halberd), "Hallebardes", "Hallebarde", 85.0, 105.0, typeof(IronIngot), 1044036, 20, 1044037);
			#endregion

			#region "Lances"
			AddCraft(typeof(Lance), "Lances", "Lance", 10.0, 35.0, typeof(IronIngot), 1044036, 20, 1044037);
			AddCraft(typeof(Pike), "Lances", "Pique", 10.0, 35.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(ShortSpear), "Lances", "Lance courte", 20.0, 45.0, typeof(IronIngot), 1044036, 6, 1044037);
			AddCraft(typeof(Scythe), "Lances", "Scythe", 30.0, 55.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(Spear), "Lances", "Lance de guerre", 35.0, 60.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(Epieu), "Lances", "Épieu", 40.0, 65.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(GrandeFourche), "Lances", "Fourche", 50.0, 75.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(JavelotLuxe), "Lances", "Javelot de Luxe", 60.0, 85.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(Trident), "Lances", "Trident", 65.0, 90.0, typeof(IronIngot), 1044036, 12, 1044037);
			AddCraft(typeof(WarFork), "Lances", "Fourche de guerre", 70.0, 95.0, typeof(IronIngot), 1044036, 12, 1044037);
			#endregion

			#region "Masses et marteaux"
			AddCraft(typeof(HammerPick), "Masses et marteaux", "Marteau à pointes", 10.0, 35.0, typeof(IronIngot), 1044036, 16, 1044037);
			AddCraft(typeof(Mace), "Masses et marteaux", "Masse", 10.0, 35.0, typeof(IronIngot), 1044036, 6, 1044037);
			AddCraft(typeof(Maul), "Masses et marteaux", "Maul", 10.0, 35.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(Scepter), "Masses et marteaux", "Sceptre", 30.0, 55.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(WarMace), "Masses et marteaux", "Masse de guerre", 30.0, 55.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(GrandeMasse), "Masses et marteaux", "Grande Masse", 30.0, 55.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(MarteauPointes), "Masses et marteaux", "Étoile du matin", 45.0, 70.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(Marteau), "Masses et marteaux", "Marteau", 45.0, 70.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(MassueClous), "Masses et marteaux", "Massue à Clous", 45.0, 70.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(MassuePointes), "Masses et marteaux", "Massue à Pointes", 30.0, 55.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(Massue), "Masses et marteaux", "Massue", 30.0, 55.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(MorgensternBoules), "Masses et marteaux", "Morgenstern à Boules", 30.0, 55.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(MorgensternPointes), "Masses et marteaux", "Morgenstern à Pointes", 30.0, 55.0, typeof(IronIngot), 1044036, 14, 1044037);
			AddCraft(typeof(WarHammer), "Masses et marteaux", "War Hammer", 60.0, 85.0, typeof(IronIngot), 1044036, 16, 1044037);
			AddCraft(typeof(Tessen), "Masses et marteaux", "Tessen", 60.0, 85.0, typeof(IronIngot), 1044036, 16, 1044037);
			AddCraft(typeof(DiamondMace), "Masses et marteaux", "Masse diamant", 60.0, 85.0, typeof(IronIngot), 1044036, 20, 1044037);
			AddCraft(typeof(WarHammer), "Masses et marteaux", "Dispenseur", 75.0, 105.0, typeof(IronIngot), 1044036, 16, 1044037);
			AddCraft(typeof(Maul), "Masses et marteaux", "Ogrillonne", 75.0, 105.0, typeof(IronIngot), 1044036, 10, 1044037);	
			
			#endregion

			#region "Rapières et Estoc"
			AddCraft(typeof(Rapiere), "Rapières et Estoc", "Rapière", 10.0, 35.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(RapiereLuxe), "Rapières et Estoc", "Rapière de Luxe", 30.0, 55.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(RapiereDecoree), "Rapières et Estoc", "Rapière Décorée", 45.0, 70.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(Astoria), "Rapières et Estoc", "Astoria", 45.0, 70.0, typeof(IronIngot), 1044036, 10, 1044037);
			AddCraft(typeof(Kryss), "Rapières et Estoc", "Kryss", 60.0, 80.0, typeof(IronIngot), 1044036, 8, 1044037);
			AddCraft(typeof(WarCleaver), "Rapières et Estoc", "Éclat lunaire", 60.0, 80.0, typeof(IronIngot), 1044036, 18, 1044037);
			AddCraft(typeof(Lajatang), "Rapières et Estoc", "Croissants de lune", 60.0, 80.0, typeof(IronIngot), 1044036, 25, 1044037);
			#endregion

			#region "Divers"
			
			AddCraft(typeof(AnvilEastDeed), "Divers", "Enclume (Est)", 52.0, 100.0, typeof(IronIngot), 1044036, 5, 1044037);
			AddRes(index, typeof(IronIngot), 1044036, 200, 1044037);
			AddCraft(typeof(AnvilSouthDeed), "Divers", "Enclume (Sud)", 52.0, 100.0, typeof(IronIngot), 1044036, 5, 1044037);
			AddRes(index, typeof(IronIngot), 1044036, 200, 1044037);
			AddCraft(typeof(SmallForgeDeed), "Divers", "Petite Forge", 52.0, 100.0, typeof(IronIngot), 1044036, 5, 1044037);
			AddRes(index, typeof(IronIngot), 1044036, 200, 1044037);
			AddCraft(typeof(LargeForgeEastDeed), "Divers", "Grande Forge (Est)", 72.0, 120.0, typeof(IronIngot), 1044036, 5, 1044037);
			AddRes(index, typeof(IronIngot), 1044036, 250, 1044037);
			AddCraft(typeof(LargeForgeSouthDeed), "Divers", "Grande Forge (Sud)", 72.0, 120.0, typeof(IronIngot), 1044036, 5, 1044037);
			AddRes(index, typeof(IronIngot), 1044036, 250, 1044037);
			#endregion

			#region Alliages


			index = AddCraft(typeof(DraconyrIngot), "Alliages", "Lingot de Draconyr", 80, 110, typeof(IronIngot), "Lingot de Fer", 4, "You do not have enough iron ingots to make that.");
			AddRes(index, typeof(CopperIngot), "Lingot de Cuivre", 3, "You do not have enough copper ingot to make that.");
			AddRes(index, typeof(GlaciasIngot), "Lingot de Glacias", 2, "You do not have enough glacias ingot to make that.");
			AddRes(index, typeof(DurianIngot), "Lingot de Durian", 1, "You do not have enough durian ingot to make that.");
			AddRes(index, typeof(JusticiumIngot), "Lingot de Justicium", 1, "You do not have enough justicium ingot to make that.");

			

			index = AddCraft(typeof(HeptazionIngot), "Alliages", "Lingot d'Heptazion", 80, 110, typeof(IronIngot), "Lingot de Fer", 4, "You do not have enough iron ingots to make that.");
			AddRes(index, typeof(LithiarIngot), "Lingot de Lithiar", 3, "You do not have enough lithiar ingot to make that.");
			AddRes(index, typeof(ArgentIngot), "Lingot d'Argent", 2, "You do not have enough argent ingot to make that.");
			AddRes(index, typeof(SombralirIngot), "Lingot de Sombralir", 1, "You do not have enough sombralir ingot to make that.");
			AddRes(index, typeof(AcierIngot), "Lingot d'Acier", 1, "You do not have enough acier ingot to make that.");


			index = AddCraft(typeof(OceanisIngot), "Alliages", "Lingot d'Océanis", 80, 110, typeof(IronIngot), "Lingot de Fer", 4, "You do not have enough iron ingots to make that.");
			AddRes(index, typeof(CopperIngot), "Lingot de Cuivre", 3, "You do not have enough copper ingot to make that.");
			AddRes(index, typeof(BorealeIngot), "Lingot de Boréale", 2, "You do not have enough boreale ingot to make that.");
			AddRes(index, typeof(JolinarIngot), "Lingot de Jolinar", 1, "You do not have enough jolinar ingot to make that.");
		

			index = AddCraft(typeof(BraziumIngot), "Alliages", "Lingot de Brazium", 80, 120, typeof(BloodiriumIngot), "Lingot de Bloodirium", 3, "You do not have enough bloodirium ingots to make that.");
			
			index = AddCraft(typeof(LuneriumIngot), "Alliages", "Lingot de Lunérium", 80, 120, typeof(HerbrositeIngot), "Lingot de Herbrosite", 3, "You do not have enough herbrosite ingots to make that.");
			AddRes(index, typeof(HeptazionIngot), "Lingot d'Heptazion", 1, "You do not have enough heptazion ingot to make that.");

			index = AddCraft(typeof(MarinarIngot), "Alliages", "Lingot de Marinar", 80, 120, typeof(IronIngot), "Lingot de Maritium", 3, "You do not have enough maritium ingots to make that.");
			AddRes(index, typeof(MytherilIngot), "Lingot de Mytheril", 3, "You do not have enough mytheril ingot to make that.");
			AddRes(index, typeof(DraconyrIngot), "Lingot de Draconyr", 1, "You do not have enough draconyr ingot to make that.");
			AddRes(index, typeof(OceanisIngot), "Lingot d'Océanis", 1, "You do not have enough oceanis ingot to make that.");

			index = AddCraft(typeof(NostalgiumIngot), "Alliages", "Lingots de Nostalgium (1)", 80, 130, typeof(BraziumIngot), "Lingot de Brazium", 3, "You do not have enough brazium ingots to make that.");
			AddRes(index, typeof(LuneriumIngot), "Lingot de Lunérium", 3, "You do not have enough lunerium ingot to make that.");
			AddRes(index, typeof(MarinarIngot), "Lingot de Marinar", 3, "You do not have enough marinar ingot to make that.");

		
			#endregion

			// Set the overridable material
			SetSubRes(typeof(IronIngot), 1044022);

			// Add every material you want the player to be able to choose from
			// This will override the overridable material
			AddSubRes(typeof(IronIngot), "Fer", 0, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(BronzeIngot), "Bronze", 15, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(CopperIngot), "Copper", 15, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(SonneIngot), "Sonne", 20, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(ArgentIngot), "Argent", 30, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(BorealeIngot), "Boréale", 30, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(ChrysteliarIngot), "Chrysteliar", 30, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(GlaciasIngot), "Glacias", 30, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(LithiarIngot), "Lithiar", 30, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(AcierIngot), "Acier", 45, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(DurianIngot), "Durian", 45, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(EquilibrumIngot), "Équilibrum", 45, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(GoldIngot), "Or", 45, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(JolinarIngot), "Jolinar", 45, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(JusticiumIngot), "Justicium", 45, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(AbyssiumIngot), "Abyssium", 60, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(BloodiriumIngot), "Bloodirium", 60, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(HerbrositeIngot), "Herbrosite", 60, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(KhandariumIngot), "Khandarium", 60, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(MytherilIngot), "Mytheril", 60, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(SombralirIngot), "Sombralir", 60, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(DraconyrIngot), "Draconyr", 80, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(HeptazionIngot), "Heptazion", 80, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(OceanisIngot), "Océanis", 80, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(BraziumIngot), "Brazium", 80, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(LuneriumIngot), "Lunerium", 80, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(MarinarIngot), "Marinar", 80, "Vous n'avez pas les compétences requises pour forger ce métal.");
			AddSubRes(typeof(NostalgiumIngot), "Nostalgium", 90, "Vous n'avez pas les compétences requises pour forger ce métal.");

			Resmelt = true;
			Repair = true;
			MarkOption = true;
			CanEnhance = true;
			CanAlter = true;
		}
	}

	public class ForgeAttribute : Attribute
	{ }

	public class AnvilAttribute : Attribute
	{ }
}

