using System;
using Server.Items;
using Server.Custom;

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
				return 1044154; // You create the item.
			}
		}

		public void AddCard(string category, Type itemType, Type soulType, double minSkill)
		{
			var item = Activator.CreateInstance(itemType) as BaseCard;
			var soul = Activator.CreateInstance(soulType) as BaseSoul;

			int index = -1;

			if (item != null)
			{
				var name = CustomUtility.GetDescription(item.EnchantType);
				name = name.Replace("regénération de points", "régen.");
				name = name.Replace("regénération", "régen.");
				name = name.Replace("enchainement", "enchan.");

				index = AddCraft(itemType, category, name, minSkill, minSkill + 10, typeof(BlankScroll), "Parchemin vierge", 5, "Il vous faut un parchemin vierge.");
				item.Delete();
			}
			else
				index = AddCraft(itemType, category, "Erreur", 0.0, 30.0, typeof(BlankScroll), "Parchemin vierge", 5, "Il vous faut un parchemin vierge.");

			if (soul != null)
			{
				AddRes(index, soulType, soul.Name, 1, $"Il vous manquent une {soul.Name}");
				soul.Delete();
			}
		}

		public override void InitCraftList()
		{
			#region Carte Plainois
			AddCard("Cartes plainoises", typeof(CarteSquelette), typeof(AmeSquelette), 50.0);
			AddCard("Cartes plainoises", typeof(CarteChevalSquelettique), typeof(AmeChevalSquelettique), 50.0);
			AddCard("Cartes plainoises", typeof(CarteMageSquelettique), typeof(AmeMageSquelette), 50.0);
			AddCard("Cartes plainoises", typeof(CarteSpectre), typeof(AmeSpectre), 50.0);
			AddCard("Cartes plainoises", typeof(CarteLiche), typeof(AmeLiche), 50.0);
			AddCard("Cartes plainoises", typeof(CarteSqueletteRapiece), typeof(AmeSquelRapiece), 50.0);
			AddCard("Cartes plainoises", typeof(CarteWight), typeof(AmeWight), 50.0);
			AddCard("Cartes plainoises", typeof(CarteChevalierSquelettique), typeof(AmeChevalierSquelettique), 50.0);
			AddCard("Cartes plainoises", typeof(CarteSeigneurLiche), typeof(AmeSeigneurLiche), 50.0);
			AddCard("Cartes plainoises", typeof(CarteCauchemar), typeof(AmeCauchemar), 50.0);
			AddCard("Cartes plainoises", typeof(CarteDragonSquelettique), typeof(AmeDragonSquelettique), 50.0);
			AddCard("Cartes plainoises", typeof(CarteLicheAncienne), typeof(AmeLicheAncienne), 50.0);
			AddCard("Cartes plainoises", typeof(CarteLicheSquelettique), typeof(AmeLicheSquelettique), 50.0);
			AddCard("Cartes plainoises", typeof(CarteDemonOs), typeof(AmeDemonOs), 50.0);
			AddCard("Cartes plainoises", typeof(CarteMelisande), typeof(AmeLadyMelisande), 50.0);
			AddCard("Cartes plainoises", typeof(CarteSerado), typeof(AmeSerado), 50.0);
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