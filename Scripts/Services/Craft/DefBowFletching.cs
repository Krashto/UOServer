using Server.Items;
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
		public override SkillName MainSkill => SkillName.Carpentry;

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
			: base(1, 1, 1.25)// base( 1, 2, 1.7 )
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
			// no animation
			//if ( from.Body.Type == BodyType.Human && !from.Mounted )
			//	from.Animate( 33, 5, 1, true, false, 0 );
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

			// Munitions
			index = AddCraft(typeof(Kindling), "Munitions", "Petit bois", 0.0, 00.0, typeof(Board), 1044041, 1, 1044351);
			index = AddCraft(typeof(Shaft), "Munitions", "Fût", 0.0, 40.0, typeof(Board), 1044041, 1, 1044351);
			SetUseAllRes(index, true);
			index = AddCraft(typeof(Arrow), "Munitions", "Flèche", 0.0, 40.0, typeof(Shaft), 1044560, 1, 1044561);
			AddRes(index, typeof(Feather), 1044562, 1, 1044563);
			SetUseAllRes(index, true);
			index = AddCraft(typeof(Bolt), "Munitions", "Carreaux", 0.0, 40.0, typeof(Shaft), 1044560, 1, 1044561);
			AddRes(index, typeof(Feather), 1044562, 1, 1044563);
			SetUseAllRes(index, true);
			index = index = AddCraft(typeof(FukiyaDarts), "Munitions", 1030246, 50.0, 73.8, typeof(Board), 1044041, 1, 1044351);
			SetUseAllRes(index, true);
			
			// Arcs
			index = AddCraft(typeof(Bow), "Arcs", "Arc simple", 30.0, 70.0, typeof(Board), 1044041, 7, 1044351);
			index = AddCraft(typeof(Legarc), "Arcs", "Legarc", 60.0, 90.0, typeof(Board), 1044041, 7, 1044351);
			index = AddCraft(typeof(Tarkarc), "Arcs", "Arc court renforcit", 60.0, 90.0, typeof(Board), 1044041, 7, 1044351);
			index = AddCraft(typeof(Souplecorde), "Arcs", "Souplecorde", 60.0, 90.0, typeof(Board), 1044041, 7, 1044351);
			index = AddCraft(typeof(Sombrevent), "Arcs", "Sombrevent", 60.0, 90.0, typeof(Board), 1044041, 7, 1044351);
			index = AddCraft(typeof(CompositeBow), "Arcs", "Arc composite", 60.0, 90.0, typeof(Board), 1044041, 7, 1044351);
			index = AddCraft(typeof(MagicalShortbow), "Arcs", "Percecoeur", 60.0, 90.0, typeof(Board), 1044041, 15, 1044351);
			index = AddCraft(typeof(Yumi), "Arcs longs", "Arc long", 60.0, 90.0, typeof(Board), 1044041, 10, 1044351);
			index = AddCraft(typeof(ElvenCompositeLongbow), "Arcs longs", "Arc long composite", 60.0, 90.0, typeof(Board), 1044041, 20, 1044351);

			// Arbalètes
			index = AddCraft(typeof(Crossbow), "Arbalètes", "Arbalète simple", 30.0, 70.0, typeof(Board), 1044041, 7, 1044351);
			index = AddCraft(typeof(Percemurs), "Arbalètes", "Percemurs", 60.0, 90.0, typeof(Board), 1044041, 7, 1044351);
			index = AddCraft(typeof(Arbavive), "Arbalètes", "Arbavive", 60.0, 90.0, typeof(Board), 1044041, 7, 1044351);
			index = AddCraft(typeof(Lumitrait), "Arbalètes", "Lumitrait", 60.0, 90.0, typeof(Board), 1044041, 10, 1044351);
			index = AddCraft(typeof(ArbaletteChasse), "Arbalètes", "Arbalète de chasse", 60.0, 90.0, typeof(Board), 1044041, 10, 1044351);
			index = AddCraft(typeof(RepeatingCrossbow), "Arbalètes", "Arbalète à répétition", 60.0, 90.0, typeof(Board), 1044041, 10, 1044351);
			index = AddCraft(typeof(HeavyCrossbow), "Arbalètes lourdes", "Arbalète lourde", 60.0, 90.0, typeof(Board), 1044041, 10, 1044351);

			SetSubRes(typeof(Board), 1072643);

			// Add every material you want the player to be able to choose from
			// This will override the overridable material
			AddSubRes(typeof(Board), 1072643, 0.0, 1044041, 1072653);
			AddSubRes(typeof(OakBoard), 1072644, 65.0, 1044041, 1072653);
			AddSubRes(typeof(AshBoard), 1072645, 75.0, 1044041, 1072653);
			AddSubRes(typeof(YewBoard), 1072646, 85.0, 1044041, 1072653);
			AddSubRes(typeof(HeartwoodBoard), 1072647, 95.0, 1044041, 1072653);
			AddSubRes(typeof(BloodwoodBoard), 1072648, 95.0, 1044041, 1072653);
			AddSubRes(typeof(FrostwoodBoard), 1072649, 95.0, 1044041, 1072653);

			Resmelt = true;
			MarkOption = true;
			Repair = true;
			CanEnhance = true;
		}
	}
}
