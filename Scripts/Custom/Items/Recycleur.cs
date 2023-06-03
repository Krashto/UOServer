using System;
using System.Collections.Generic;
using Server.Engines.Craft;
using Server.Targeting;

namespace Server.Items
{
	[FlipableAttribute(4787, 4787)]
	public class Recycleur : Item
	{
        private int m_UsesRemaining;

        [CommandProperty(AccessLevel.GameMaster)]
        public int UsesRemaining
        {
            get { return m_UsesRemaining; }
            set { m_UsesRemaining = value; InvalidateProperties(); }
        }

        public bool ShowUsesRemaining { get { return true; } set { } }

		[Constructable]
        public Recycleur() : base(4787)
		{
            Name = "Recycleur";
			Hue = 1109;
			Weight = 2.0;
            m_UsesRemaining = Utility.Random(50, 75);
		}

		public Recycleur( Serial serial ) : base( serial )
		{
		}

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            list.Add(String.Format("Utilisations restantes: {0}", m_UsesRemaining));
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (from.Backpack == null || this.Parent != from.Backpack)
            {
                from.SendMessage("Ce doit être dans votre sac.");
            }
            else
            {
                from.SendMessage("Sélectionner un objet à recycler.");
                from.Target = new InternalTarget(this);
            }
        }

        private class InternalTarget : Target
        {
            private Recycleur m_Recycleur;

            public InternalTarget(Recycleur recycleur) : base(1, false, TargetFlags.None)
            {
                m_Recycleur = recycleur;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
				CraftResource resource = CraftResource.None;

                if (targeted is BaseArmor armor)
                    resource = armor.Resource;
                else if (targeted is BaseWeapon weapon)
                    resource = weapon.Resource;
                else if (targeted is BaseShoes shoes)
                    resource = shoes.Resource;
				else if (targeted is BaseClothing clothing)
					resource = clothing.Resource;
				else if (targeted is NewSpellbook spellbook)
					resource = spellbook.Resource;
				else
                    from.SendMessage( "Cet article ne peut pas être recyclé.");

                if (resource == CraftResource.None)
                {
                    from.SendMessage( "Vous ne pouvez pas recycler ceci. (Code: -1)");
                    return;
                }

				var m_CraftSystem = new List<CraftSystem>();

				switch (resource)
				{
					case CraftResource.DullCopper:
					case CraftResource.ShadowIron:
					case CraftResource.Agapite:
					case CraftResource.Verite:
					case CraftResource.Valorite:
					case CraftResource.Iron:
					case CraftResource.Bronze:
					case CraftResource.Copper:
					case CraftResource.Sonne:
					case CraftResource.Argent:
					case CraftResource.Boreale:
					case CraftResource.Chrysteliar:
					case CraftResource.Glacias:
					case CraftResource.Lithiar:
					case CraftResource.Acier:
					case CraftResource.Durian:
					case CraftResource.Equilibrum:
					case CraftResource.Gold:
					case CraftResource.Jolinar:
					case CraftResource.Justicium:
					case CraftResource.Abyssium:
					case CraftResource.Bloodirium:
					case CraftResource.Herbrosite:
					case CraftResource.Khandarium:
					case CraftResource.Mytheril:
					case CraftResource.Sombralir:
					case CraftResource.Draconyr:
					case CraftResource.Heptazion:
					case CraftResource.Oceanis:
					case CraftResource.Brazium:
					case CraftResource.Lunerium:
					case CraftResource.Marinar:
					case CraftResource.Nostalgium:			m_CraftSystem = new List<CraftSystem>() { DefBlacksmithy.CraftSystem, DefTinkering.CraftSystem }; break;

					case CraftResource.PlainoisLeather:
					case CraftResource.ForestierLeather:    
					case CraftResource.DesertiqueLeather:	
					case CraftResource.CollinoisLeather:	
					case CraftResource.SavanoisLeather:	    
                    case CraftResource.ToundroisLeather:    
                    case CraftResource.TropicauxLeather:    
                    case CraftResource.MontagnardLeather:
                    case CraftResource.VolcaniqueLeather:
					case CraftResource.AncienLeather: m_CraftSystem = new List<CraftSystem>() { DefLeatherArmor.CraftSystem }; break;

                    case CraftResource.PlainoisBone:        
					case CraftResource.ForestierBone:	    
					case CraftResource.DesertiqueBone:	    
					case CraftResource.CollinoisBone:	    
                    case CraftResource.SavanoisBone:        
                    case CraftResource.ToundroisBone:       
                    case CraftResource.TropicauxBone:       
					case CraftResource.MontagnardBone:      
                    case CraftResource.VolcaniqueBone:
                    case CraftResource.AncienBone: m_CraftSystem = new List<CraftSystem>() { DefBoneTailoring.CraftSystem }; break;

					case CraftResource.RegularWood:
					case CraftResource.PlainoisWood:
					case CraftResource.ForestierWood:
					case CraftResource.DesertiqueWood:
					case CraftResource.CollinoisWood:
					case CraftResource.SavanoisWood:
					case CraftResource.ToundroisWood:
					case CraftResource.TropicauxWood:
					case CraftResource.MontagnardWood:
					case CraftResource.VolcaniqueWood:
					case CraftResource.AncienWood:
					case CraftResource.OakWood:
					case CraftResource.AshWood:
					case CraftResource.YewWood:
					case CraftResource.Heartwood:
					case CraftResource.Bloodwood:
					case CraftResource.Frostwood: m_CraftSystem = new List<CraftSystem>() { DefBowFletching.CraftSystem, DefCarpentry.CraftSystem, DefTinkering.CraftSystem }; break;
				}

                if (m_CraftSystem == null || m_CraftSystem.Count <= 0)
                {
                    from.SendMessage( "Vous ne pouvez pas recycler ceci. (Code: 0)");
                    return;
                }

                CraftResourceInfo info = CraftResources.GetInfo(resource);

                if (info == null || info.ResourceTypes.Length == 0)
                {
                    from.SendMessage( "Vous ne pouvez pas recycler ceci. (Code: 1)");
                    return;
                }

				CraftItem craftItem = null;

				foreach(var system in m_CraftSystem)
				{
					var found = system.CraftItems.SearchFor(targeted.GetType());

					if (found != null)
					{
						craftItem = found;
						break;
					}
				}

                if (craftItem == null || craftItem.Resources.Count == 0)
                {
                    from.SendMessage( "Vous ne pouvez pas recycler ceci. (Code: 2)");
                    return;
                }

				var resourceReturned = false;

                foreach(CraftRes craftRes in craftItem.Resources)
				{
					if (craftRes.Amount <= 1)
						continue;

					Type resourceType = info.ResourceTypes[0];
					Item resItem = (Item)Activator.CreateInstance(resourceType);

					int newAmount = (int)(craftRes.Amount * 0.5);

					if (newAmount < 1)
						newAmount = 1;


					resItem.Amount = newAmount;

					from.AddToBackpack(resItem);

					resourceReturned = true;
				}

				if (!resourceReturned)
				{
                    from.SendMessage( "Cet objet ne contient pas suffisamment de ressources pour être recyclé.");
                    return;
                }

                ((Item)targeted).Delete();
                    
                m_Recycleur.UsesRemaining -= 1;

                if (m_Recycleur.UsesRemaining < 1)
                {
                    m_Recycleur.Delete();
                    from.SendMessage( "Vous brisez votre outil!");
                }

                from.PlaySound(0x5CA);
            }
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

            writer.Write((int)m_UsesRemaining);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

            m_UsesRemaining = reader.ReadInt();
		}
	}
}