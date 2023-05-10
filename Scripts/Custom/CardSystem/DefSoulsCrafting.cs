using System;
using Server.Items;
using Server.Mobiles;
using Server.Engines.CannedEvil;

namespace Server.Engines.Craft
{
	public class DefSoulsCrafting : CraftSystem
	{
		public override SkillName MainSkill
		{
			get{ return SkillName.Inscribe; }
		}


		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefSoulsCrafting();

				return m_CraftSystem;
			}
		}

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.0; // 0%
		}

		private DefSoulsCrafting() : base(3, 4, 1.50) // base( 1, 2, 1.7 )
		{
		}



		public override void PlayCraftEffect( Mobile from )
		{
			from.PlaySound( 0x1F5 ); // magic

			//if ( from.Body.Type == BodyType.Human && !from.Mounted )
			//	from.Animate( 9, 5, 1, true, false, 0 );

			//new InternalTimer( from ).Start();
		}

		// Delay to synchronize the sound with the hit on the anvil
		private class InternalTimer : Timer
		{
			private Mobile m_From;

			public InternalTimer( Mobile from ) : base( TimeSpan.FromSeconds( 0.7 ) )
			{
				m_From = from;
			}

			protected override void OnTick()
			{
				m_From.PlaySound( 0x2A );
			}
		}

		public override int PlayEndingEffect( Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, bool makersMark, CraftItem item )
		{
			if ( toolBroken )
				from.SendLocalizedMessage( 1044038 ); // You have worn out your tool

			if ( failed )
			{
				from.PlaySound( 65 ); // rune breaking
				if ( lostMaterial )
					return 1044043; // You failed to create the item, and some of your materials are lost.
				else
					return 1044157; // You failed to create the item, but no materials were lost.
			}
			else
			{
				//from.PlaySound( 65 ); // rune breaking
				//if ( quality == 0 )
					//return 502785; // You were barely able to make this item.  It's quality is below average.
				//else if ( makersMark && quality == 2 )
					//return 1044156; // You create an exceptional quality item and affix your maker's mark.
				//else if ( quality == 2 )
					//return 1044155; // You create an exceptional quality item.
				//else				
					return 1044154; // You create the item.
			}
		}

		public override void InitCraftList()
		{
		
			int

			#region Carte Plainois
			index = AddCraft( typeof( CarteSquelette ), "Cartes Plainois", "Bonus de Vie", 0.0, 30.0, typeof(BlankScroll), "Parchemin vierge", 5, "Il vous faut un parchemin vierge.");
			AddRes(index, typeof(AmeSquelette), "Ame de Squelette", 1, "Il vous manquent une ame de Squelette");

			index = AddCraft(typeof(CarteChevalSquelettique), "Cartes Plainois", "Bonus de Stam", 0.0, 30.0, typeof(BlankScroll), "Parchemin vierge", 5, "Il vous faut un parchemin vierge.");
			AddRes(index, typeof(AmeChevalSquelettique), "Ame de Cheval Squelettique", 1, "Il vous manquent une ame de Cheval Squelettique");

			index = AddCraft(typeof(CarteMageSquelettique), "Cartes Plainois", "Bonus de Mana", 0.0, 30.0, typeof(BlankScroll), "Parchemin vierge", 5, "Il vous faut un parchemin vierge.");
			AddRes(index, typeof(AmeMageSquelette), "Ame de mage Squelette", 1, "Il vous manquent une ame de mage Squelette");

			index = AddCraft(typeof(CarteSpectre), "Cartes Plainois", "Réduction en cout de mana", 0.0, 30.0, typeof(BlankScroll), "Parchemin vierge", 5, "Il vous faut un parchemin vierge.");
			AddRes(index, typeof(AmeSpectre), "Ame de spectre", 1, "Il vous manquent une ame de spectre");

			index = AddCraft(typeof(CarteLiche), "Cartes Plainois", "Réduction en cout d'ingrédients", 0.0, 30.0, typeof(BlankScroll), "Parchemin vierge", 5, "Il vous faut un parchemin vierge.");
			AddRes(index, typeof(AmeLiche), "Ame de Liche", 1, "Il vous manquent une ame de Liche");

			index = AddCraft(typeof(CarteSqueletteRapiece), "Cartes Plainois", "Vitesse d'Attaque", 0.0, 30.0, typeof(BlankScroll), "Parchemin vierge", 5, "Il vous faut un parchemin vierge.");
			AddRes(index, typeof(AmeSquelRapiece), "Ame de Squelette rapiece", 1, "Il vous manquent une ame de Squelette rapiece");

			index = AddCraft(typeof(CarteWight), "Cartes Plainois", "Défense Accrue", 0.0, 30.0, typeof(BlankScroll), "Parchemin vierge", 5, "Il vous faut un parchemin vierge.");
			AddRes(index, typeof(AmeWight), "Ame de Wight", 1, "Il vous manquent une ame de wight");

			index = AddCraft(typeof(CarteSpectreAstral), "Cartes Plainois", "Chance de Toucher", 0.0, 30.0, typeof(BlankScroll), "Parchemin vierge", 5, "Il vous faut un parchemin vierge.");
			AddRes(index, typeof(AmeSpectreAstral), "Ame de Spectre Astral", 1, "Il vous manquent une ame de Spectre Astral");

			index = AddCraft(typeof(CarteChevalierSquelettique), "Cartes Plainois", "Résistance Physique", 0.0, 30.0, typeof(BlankScroll), "Parchemin vierge", 5, "Il vous faut un parchemin vierge.");
			AddRes(index, typeof(AmeChevalierSquelettique), "Ame de Chevalier Squelettique", 1, "Il vous manquent une ame de Chevalier Squelettique");

			index = AddCraft(typeof(CarteSeigneurLiche), "Cartes Plainois", "Résistance au Poison", 0.0, 30.0, typeof(BlankScroll), "Parchemin vierge", 5, "Il vous faut un parchemin vierge.");
			AddRes(index, typeof(AmeSeigneurLiche), "Ame de Seigneur Liche", 1, "Il vous manquent une ame de Seigneur Liche");

			index = AddCraft(typeof(CarteCauchemar), "Cartes Plainois", "Résistance au Feu", 0.0, 30.0, typeof(BlankScroll), "Parchemin vierge", 5, "Il vous faut un parchemin vierge.");
			AddRes(index, typeof(AmeCauchemar), "Ame de Cauchemar", 1, "Il vous manquent une ame de Cauchemar");

			index = AddCraft(typeof(CarteDragonSquelettique), "Cartes Plainois", "Resistance à l'Énergie", 0.0, 30.0, typeof(BlankScroll), "Parchemin vierge", 5, "Il vous faut un parchemin vierge.");
			AddRes(index, typeof(AmeDragonSquel), "Ame de Dragon Squelette", 1, "Il vous manquent une ame de Dragon Squelette");

			index = AddCraft(typeof(CarteLicheAncienne), "Cartes Plainois", "Résistance au Froid", 0.0, 30.0, typeof(BlankScroll), "Parchemin vierge", 5, "Il vous faut un parchemin vierge.");
			AddRes(index, typeof(AmeLicheAncienne), "Ame de Liche Ancienne", 1, "Il vous manquent une ame de Liche Ancienne");

			index = AddCraft(typeof(CarteLicheSquelettique), "Cartes Plainois", "Récupération de sortilège", 0.0, 30.0, typeof(BlankScroll), "Parchemin vierge", 5, "Il vous faut un parchemin vierge.");
			AddRes(index, typeof(AmeLicheSquel), "Ame de Liche Squelettique", 1, "Il vous manquent une ame de Liche Squelettique");

			index = AddCraft(typeof(CarteDemonOs), "Cartes Plainois", "Vitesse d'incantation de sortilège", 0.0, 30.0, typeof(BlankScroll), "Parchemin vierge", 5, "Il vous faut un parchemin vierge.");
			AddRes(index, typeof(AmeDemonOs), "Ame de Demon d'os", 1, "Il vous manquent une ame de Demon d'os");

			index = AddCraft(typeof(CarteMelisande), "Cartes Plainois", "Régénération de vie", 0.0, 30.0, typeof(BlankScroll), "Parchemin vierge", 5, "Il vous faut un parchemin vierge.");
			AddRes(index, typeof(AmeLadyMelisande), "Ame de Lady Melisande", 1, "Il vous manquent une ame de Lady Melisande");

			index = AddCraft(typeof(CarteSerado), "Cartes Plainois", "Regénération de Mana", 0.0, 30.0, typeof(BlankScroll), "Parchemin vierge", 5, "Il vous faut un parchemin vierge.");
			AddRes(index, typeof(AmeSerado), "Ame de Serado", 1, "Il vous manquent une ame de Serado");
			#endregion

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
	}
}