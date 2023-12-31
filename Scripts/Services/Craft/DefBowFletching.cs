﻿using Server.Engines.Quests;
using Server.Items;
using Server.Mobiles;
using System;

namespace Server.Engines.Craft
{
	#region Mondain's Legacy
	public enum BowRecipes
	{
		//magical
		BarbedLongbow = 200,
		SlayerLongbow = 201,
		FrozenLongbow = 202,
		LongbowOfMight = 203,
		RangersShortbow = 204,
		LightweightShortbow = 205,
		MysticalShortbow = 206,
		AssassinsShortbow = 207,

		// arties
		BlightGrippedLongbow = 250,
		FaerieFire = 251,
		SilvanisFeywoodBow = 252,
		MischiefMaker = 253,
		TheNightReaper = 254,
	}
	#endregion

	public class DefBowFletching : CraftSystem
	{
		public override SkillName MainSkill => SkillName.Tinkering;

		//  public override int GumpTitleNumber => 1044006;


		public override string GumpTitleString => "Fabrication d'Arc";


		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if (m_CraftSystem == null)
					m_CraftSystem = new DefBowFletching();

				return m_CraftSystem;
			}
		}

		public override double GetChanceAtMin(CraftItem item)
		{
			return 0.5; // 50%
		}

		private DefBowFletching()
			: base(3, 4, 1.50)// base( 1, 2, 1.7 )
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
			 //no animation
			if ( from.Body.Type == BodyType.Human && !from.Mounted )
				from.Animate( 33, 5, 1, true, false, 0 );
			from.PlaySound(0x55);
		}

		public override int PlayEndingEffect(Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, bool makersMark, CraftItem item)
		{
			if (toolBroken)
				from.SendLocalizedMessage(1044038); // You have worn out your tool

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

		public override CraftECA ECA => CraftECA.Chance3Max;

		public override void InitCraftList()
		{
			int index = -1;

			#region Munitions
			index = AddCraft(typeof(Kindling), "Munitions", "Brindilles (5)", 0.0, 20.0, typeof(RegularBoard), 1044041, 1, 1044351);
			index = AddCraft(typeof(Kindling), "Munitions", "Brindilles (Max)", 0.0, 20.0, typeof(RegularBoard), 1044041, 1, 1044351);
			SetUseAllRes(index, true);
			index = AddCraft(typeof(Shaft), "Munitions", "Fût (5)", 0.0, 20.0, typeof(RegularBoard), "Planche", 1, "Vous n'avez pas suffisament de planche");
			index = AddCraft(typeof(Shaft), "Munitions", "Fût (Max)", 0.0, 20.0, typeof(RegularBoard), "Planche", 1, "Vous n'avez pas suffisament de planche");
			SetUseAllRes(index, true);
			index = AddCraft(typeof(Arrow), "Munitions", "Flèche (1)", 10.0, 30.0, typeof(Shaft), 1044560, 1, 1044561);
			AddRes(index, typeof(Feather), 1044562, 1, 1044563);
			index = AddCraft(typeof(Arrow), "Munitions", "Flèche (Max)", 10.0, 30.0, typeof(Shaft), 1044560, 1, 1044561);
			AddRes(index, typeof(Feather), 1044562, 1, 1044563);
			SetUseAllRes(index, true);
			index = AddCraft(typeof(Bolt), "Munitions", "Carreaux (1)", 10.0, 30.0, typeof(Shaft), 1044560, 1, 1044561);
			AddRes(index, typeof(Feather), 1044562, 1, 1044563);
			index = AddCraft(typeof(Bolt), "Munitions", "Carreaux (Max)", 10.0, 30.0, typeof(Shaft), 1044560, 1, 1044561);
			AddRes(index, typeof(Feather), 1044562, 1, 1044563);
			SetUseAllRes(index, true);
			#endregion

			#region Arcs
			index = AddCraft(typeof(TrainingBow), "Arcs", "Arc d'entrainement", 0.0, 50.0, typeof(RegularBoard), 1044041, 5, 1044351);
			index = AddCraft(typeof(Blancorde), "Arcs", "Blancorde", 10.0, 40.0, typeof(RegularBoard), 1044041, 10, 1044351);
			index = AddCraft(typeof(Glaciale), "Arcs", "Glaciale", 10.0, 40.0, typeof(RegularBoard), 1044041, 10, 1044351);
			index = AddCraft(typeof(Bow), "Arcs", "Arc simple", 10.0, 40.0, typeof(RegularBoard), 1044041, 7, 1044351);
			index = AddCraft(typeof(Legarc), "Arcs", "Legarc", 15.0, 45.0, typeof(RegularBoard), 1044041, 7, 1044351);
			index = AddCraft(typeof(Tarkarc), "Arcs", "Arc court renforcit", 15.0, 45.0, typeof(RegularBoard), 1044041, 7, 1044351);
			index = AddCraft(typeof(Ebonie), "Arcs", "Ebonie", 15.0, 45.0, typeof(RegularBoard), 1044041, 8, 1044351);
			index = AddCraft(typeof(Mirka), "Arcs", "Mirka", 20.0, 50.0, typeof(RegularBoard), 1044041, 8, 1044351);
			index = AddCraft(typeof(Souplecorde), "Arcs", "Souplecorde", 20.0, 50.0, typeof(RegularBoard), 1044041, 7, 1044351);
			index = AddCraft(typeof(Sombrevent), "Arcs", "Sombrevent", 20.0, 50.0, typeof(RegularBoard), 1044041, 7, 1044351);
			index = AddCraft(typeof(CompositeBow), "Arcs", "Arc composite", 30.0, 60.0, typeof(RegularBoard), 1044041, 7, 1044351);
			index = AddCraft(typeof(MagicalShortbow), "Arcs", "Percecoeur", 30.0, 60.0, typeof(RegularBoard), 1044041, 15, 1044351);
			index = AddCraft(typeof(Vigne), "Arcs", "Vigne", 30.0, 60.0, typeof(RegularBoard), 1044041, 8, 1044351);
			index = AddCraft(typeof(Foudre), "Arcs", "Foudre", 40.0, 70.0, typeof(RegularBoard), 1044041, 8, 1044351);
			index = AddCraft(typeof(Flamfleche), "Arcs", "Flamflèche", 40.0, 70.0, typeof(RegularBoard), 1044041, 8, 1044351);
			index = AddCraft(typeof(Yumi), "Arcs", "Arc long", 40.0, 70.0, typeof(RegularBoard), 1044041, 10, 1044351);
			index = AddCraft(typeof(Mirielle), "Arcs", "Mirielle", 40.0, 70.0, typeof(RegularBoard), 1044041, 8, 1044351);
			index = AddCraft(typeof(ElvenCompositeLongbow), "Arcs", "Arc long composite", 40.0, 70.0, typeof(RegularBoard), 1044041, 20, 1044351);
			index = AddCraft(typeof(Barbatrine), "Arcs", "Barbatrine", 40.0, 70.0, typeof(RegularBoard), 1044041, 8, 1044351);
			index = AddCraft(typeof(Chantefleche), "Arcs", "Chantefleche", 40.0, 70.0, typeof(RegularBoard), 1044041, 8, 1044351);
			index = AddCraft(typeof(Sifflecrin), "Arcs", "Sifflecrin", 45.0, 75.0, typeof(RegularBoard), 1044041, 8, 1044351);
			index = AddCraft(typeof(Maegie), "Arcs", "Maegie", 45.0, 75.0, typeof(RegularBoard), 1044041, 8, 1044351);
			index = AddCraft(typeof(Foliere), "Arcs", "Foliere", 45.0, 75.0, typeof(RegularBoard), 1044041, 8, 1044351);
			index = AddCraft(typeof(Composite), "Arcs", "Composite", 50.0, 80.0, typeof(RegularBoard), 1044041, 8, 1044351);
			index = AddCraft(typeof(Pieuse), "Arcs", "Pieuse", 50.0, 80.0, typeof(RegularBoard), 1044041, 8, 1044351);
			#endregion
			// Arbalètes	
			index = AddCraft(typeof(Crossbow), "Arbalètes", "Arbalète simple", 10.0, 40.0, typeof(RegularBoard), 1044041, 7, 1044351);
			index = AddCraft(typeof(Arbalete), "Arbalètes", "Arbalète", 10.0, 40.0, typeof(RegularBoard), 1044041, 7, 1044351);
			index = AddCraft(typeof(ArbaletteChasse), "Arbalètes", "Arbalète de chasse", 20.0, 50.0, typeof(RegularBoard), 1044041, 10, 1044351);
			index = AddCraft(typeof(RepeatingCrossbow), "Arbalètes", "Arbalète Complexe", 20.0, 50.0, typeof(RegularBoard), 1044041, 10, 1044351);
			index = AddCraft(typeof(HeavyCrossbow), "Arbalètes", "Arbalète lourde", 20.0, 50.0, typeof(RegularBoard), 1044041, 10, 1044351);
			index = AddCraft(typeof(ArbalettePistolet), "Arbalètes", "Arbalète à Main", 30.0, 60.0, typeof(RegularBoard), 1044041, 7, 1044351);
			index = AddCraft(typeof(ArbaletteRepetition), "Arbalètes", "Arbalète à Répétition", 40.0, 70.0, typeof(RegularBoard), 1044041, 8, 1044351);
			index = AddCraft(typeof(ArbaletteLourde), "Arbalètes", "Arbalète à Méchanisme", 40.0, 70.0, typeof(RegularBoard), 1044041, 7, 1044351);
			index = AddCraft(typeof(Percemurs), "Arbalètes", "Percemurs", 40.0, 70.0, typeof(RegularBoard), 1044041, 7, 1044351);
			index = AddCraft(typeof(Arbavive), "Arbalètes", "Arbavive", 50.0, 80.0, typeof(RegularBoard), 1044041, 7, 1044351);
			index = AddCraft(typeof(Lumitrait), "Arbalètes", "Lumitrait", 50.0, 80.0, typeof(RegularBoard), 1044041, 10, 1044351);

			SetSubRes(typeof(RegularBoard), "Commun");

			// Add every material you want the player to be able to choose from
			// This will override the overridable material
			AddSubRes(typeof(RegularBoard), "Commun", 0.0, "Vous ne savez pas travailler le bois Commun");
			AddSubRes(typeof(PlainoisBoard), "Plainois", 0.0, "Vous ne savez pas travailler le bois plainois");
			AddSubRes(typeof(CollinoisBoard), "Collinois", 20.0, "Vous ne savez pas travailler le bois collinois");
			AddSubRes(typeof(ForestierBoard), "Forestier", 20.0, "Vous ne savez pas travailler le bois forestier");
			AddSubRes(typeof(SavanoisBoard), "Savanois", 40.0, "Vous ne savez pas travailler le bois savanois");
			AddSubRes(typeof(DesertiqueBoard), "Desertique", 40.0, "Vous ne savez pas travailler le bois desertique");
			AddSubRes(typeof(MontagnardBoard), "Montagnard", 60.0, "Vous ne savez pas travailler le bois montagnard");
			AddSubRes(typeof(VolcaniqueBoard), "Volcanique", 60.0, "Vous ne savez pas travailler le bois volcanique");
			AddSubRes(typeof(TropicauxBoard), "Tropicaux", 80.0, "Vous ne savez pas travailler le bois tropicaux");
			AddSubRes(typeof(ToundroisBoard), "Toundrois", 80.0, "Vous ne savez pas travailler le bois toundrois");
			AddSubRes(typeof(AncienBoard), "Ancien", 100.0, "Vous ne savez pas travailler le bois ancien");

			Resmelt = true;
			MarkOption = true;
			Repair = true;
			CanEnhance = true;
		}
	}
}
