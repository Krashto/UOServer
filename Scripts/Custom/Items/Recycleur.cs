using System;
using Server;
using Server.Engines.Craft;
using Server.Targeting;
using Server.CustomScripts;

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
                CraftSystem m_CraftSystem = null;
                CraftResource resource = CraftResource.None;

                if (targeted is BaseArmor)
                {
                    BaseArmor armor = (BaseArmor)targeted;
                    resource = armor.Resource;
                }
                else if (targeted is BaseWeapon)
                {
                    BaseWeapon weapon = (BaseWeapon)targeted;
                    resource = weapon.Resource;
                }
                else if (targeted is BaseShoes)
                {
                    BaseShoes shoes = (BaseShoes)targeted;
                    resource = shoes.Resource;
                }
                else
                {
                    from.SendMessage( "Cet article ne peut pas être recyclé.");
                }

                if (resource == CraftResource.None)
                {
                    from.SendMessage( "Vous ne pouvez pas recycler ceci. (Code: -1)");
                    return;
                }

                switch (resource)
				{
                    case CraftResource.Iron:             m_CraftSystem = DefBlacksmithy.CraftSystem; break;
                    case CraftResource.DullCopper:                 m_CraftSystem = DefBlacksmithy.CraftSystem; break;
                    case CraftResource.ShadowIron:		        m_CraftSystem = DefBlacksmithy.CraftSystem; break;
                    case CraftResource.Copper:		        m_CraftSystem = DefBlacksmithy.CraftSystem; break;
					case CraftResource.Bronze:			        m_CraftSystem = DefBlacksmithy.CraftSystem; break;
					case CraftResource.Gold:			    m_CraftSystem = DefBlacksmithy.CraftSystem; break;
					case CraftResource.Agapite:			    m_CraftSystem = DefBlacksmithy.CraftSystem; break;
					case CraftResource.Verite:			    m_CraftSystem = DefBlacksmithy.CraftSystem; break;
					case CraftResource.Valorite:		    m_CraftSystem = DefBlacksmithy.CraftSystem; break;
					case CraftResource.Mytheril:		    m_CraftSystem = DefBlacksmithy.CraftSystem; break;

                    case CraftResource.ForestierLeather:     m_CraftSystem = DefTailoring.CraftSystem; break;
					case CraftResource.DesertiqueLeather:	        m_CraftSystem = DefTailoring.CraftSystem; break;
					case CraftResource.CollinoisLeather:	    m_CraftSystem = DefTailoring.CraftSystem; break;
					case CraftResource.SavanoisLeather:	    m_CraftSystem = DefTailoring.CraftSystem; break;
                    case CraftResource.ToundroisLeather:         m_CraftSystem = DefTailoring.CraftSystem; break;
                    case CraftResource.TropicauxLeather:       m_CraftSystem = DefTailoring.CraftSystem; break;
                    case CraftResource.MontagnardLeather:      m_CraftSystem = DefTailoring.CraftSystem; break;
                    case CraftResource.AncienLeather:        m_CraftSystem = DefTailoring.CraftSystem; break;
                    case CraftResource.PlainoisLeather:       m_CraftSystem = DefTailoring.CraftSystem; break;

                    case CraftResource.PlainoisBone:        m_CraftSystem = DefBoneTailoring.CraftSystem; break;
					case CraftResource.ForestierBone:	            m_CraftSystem = DefBoneTailoring.CraftSystem; break;
					case CraftResource.DesertiqueBone:	        m_CraftSystem = DefBoneTailoring.CraftSystem; break;
					case CraftResource.CollinoisBone:	        m_CraftSystem = DefBoneTailoring.CraftSystem; break;
                    case CraftResource.SavanoisBone:            m_CraftSystem = DefBoneTailoring.CraftSystem; break;
                    case CraftResource.ToundroisBone:          m_CraftSystem = DefBoneTailoring.CraftSystem; break;
                    case CraftResource.TropicauxBone:         m_CraftSystem = DefBoneTailoring.CraftSystem; break;
                    case CraftResource.MontagnardBone:           m_CraftSystem = DefBoneTailoring.CraftSystem; break;
                    case CraftResource.AncienBone:          m_CraftSystem = DefBoneTailoring.CraftSystem; break;

                    case CraftResource.RegularWood:          m_CraftSystem = DefBowFletching.CraftSystem; break;
					case CraftResource.OakWood:	        m_CraftSystem = DefBowFletching.CraftSystem; break;
					case CraftResource.AshWood:	    m_CraftSystem = DefBowFletching.CraftSystem; break;
                    case CraftResource.YewWood:           m_CraftSystem = DefBowFletching.CraftSystem; break;
                    case CraftResource.Heartwood:        m_CraftSystem = DefBowFletching.CraftSystem; break;
                    case CraftResource.Bloodwood:           m_CraftSystem = DefBowFletching.CraftSystem; break;
                    case CraftResource.Frostwood:          m_CraftSystem = DefBowFletching.CraftSystem; break;
              

              
				}

                if (m_CraftSystem == null)
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

                CraftItem craftItem = m_CraftSystem.CraftItems.SearchFor(targeted.GetType());

                if (craftItem == null || craftItem.Resources.Count == 0)
                {
                    switch (resource)
				    {
						case CraftResource.Iron: m_CraftSystem = DefTinkering.CraftSystem; break;
						case CraftResource.DullCopper: m_CraftSystem = DefTinkering.CraftSystem; break;
						case CraftResource.ShadowIron: m_CraftSystem = DefTinkering.CraftSystem; break;
						case CraftResource.Copper: m_CraftSystem = DefTinkering.CraftSystem; break;
						case CraftResource.Bronze: m_CraftSystem = DefTinkering.CraftSystem; break;
						case CraftResource.Gold: m_CraftSystem = DefTinkering.CraftSystem; break;
						case CraftResource.Agapite: m_CraftSystem = DefTinkering.CraftSystem; break;
						case CraftResource.Verite: m_CraftSystem = DefTinkering.CraftSystem; break;
						case CraftResource.Valorite: m_CraftSystem = DefTinkering.CraftSystem; break;
						case CraftResource.Mytheril: m_CraftSystem = DefTinkering.CraftSystem; break;

						case CraftResource.ForestierLeather: m_CraftSystem = DefTailoring.CraftSystem; break;
						case CraftResource.DesertiqueLeather: m_CraftSystem = DefTailoring.CraftSystem; break;
						case CraftResource.CollinoisLeather: m_CraftSystem = DefTailoring.CraftSystem; break;
						case CraftResource.SavanoisLeather: m_CraftSystem = DefTailoring.CraftSystem; break;
						case CraftResource.ToundroisLeather: m_CraftSystem = DefTailoring.CraftSystem; break;
						case CraftResource.TropicauxLeather: m_CraftSystem = DefTailoring.CraftSystem; break;
						case CraftResource.MontagnardLeather: m_CraftSystem = DefTailoring.CraftSystem; break;
						case CraftResource.AncienLeather: m_CraftSystem = DefTailoring.CraftSystem; break;
						case CraftResource.PlainoisLeather: m_CraftSystem = DefTailoring.CraftSystem; break;



						case CraftResource.RegularWood: m_CraftSystem = DefTinkering.CraftSystem; break;
						case CraftResource.OakWood: m_CraftSystem = DefTinkering.CraftSystem; break;
						case CraftResource.AshWood: m_CraftSystem = DefTinkering.CraftSystem; break;
						case CraftResource.YewWood: m_CraftSystem = DefTinkering.CraftSystem; break;
						case CraftResource.Heartwood: m_CraftSystem = DefTinkering.CraftSystem; break;
						case CraftResource.Bloodwood: m_CraftSystem = DefTinkering.CraftSystem; break;
						case CraftResource.Frostwood: m_CraftSystem = DefTinkering.CraftSystem; break;
					}

                    craftItem = m_CraftSystem.CraftItems.SearchFor(targeted.GetType());
                }

                if (craftItem == null || craftItem.Resources.Count == 0)
                {
                    from.SendMessage( "Vous ne pouvez pas recycler ceci. (Code: 2)");
                    return;
                }

                CraftRes craftResource = craftItem.Resources.GetAt(0);

                if (craftResource.Amount < 2)
                {
                    from.SendMessage( "Cet objet ne contient pas suffisamment de ressources pour être recyclé.");
                    return;
                }

                Type resourceType = info.ResourceTypes[0];
                Item resItem = (Item)Activator.CreateInstance(resourceType);

                if (resItem is BaseIngot)
                {
                    switch (resource)
                    {
                        case CraftResource.Iron:         resItem = new IronIngot(); break;
                        case CraftResource.Copper:      resItem = new CopperIngot(); break;
                        case CraftResource.DullCopper:       resItem = new DullCopperIngot(); break;
                        case CraftResource.ShadowIron:      resItem = new ShadowIronIngot(); break;
						case CraftResource.Bronze:		resItem = new BronzeIngot(); break;
						case CraftResource.Gold:          resItem = new GoldIngot(); break;
                        case CraftResource.Agapite:     resItem = new AgapiteIngot(); break;
                        case CraftResource.Verite:      resItem = new VeriteIngot(); break;
                        case CraftResource.Valorite:    resItem = new ValoriteIngot(); break;
                        case CraftResource.Mytheril:    resItem = new MytherilIngot(); break;
                    }
                }
                else if (resItem is BaseLog)
                {
                    switch (resource)
                    {
                        case CraftResource.RegularWood:      resItem = new Board(); break;
                        case CraftResource.OakWood:       resItem = new OakBoard(); break;
                        case CraftResource.AshWood:    resItem = new AshBoard(); break;
                        case CraftResource.YewWood:       resItem = new YewBoard(); break;
                        case CraftResource.Heartwood:    resItem = new HeartwoodBoard(); break;
                        case CraftResource.Bloodwood:       resItem = new BloodwoodBoard(); break;
                        case CraftResource.Frostwood:      resItem = new FrostwoodBoard(); break;
                      
                    }
                }
                else if (resItem is BaseBone)
                {
                    switch (resource)
                    {
                        case CraftResource.PlainoisBone:  resItem = new PlainoisBone(); break;
                        case CraftResource.ForestierBone:       resItem = new LupusBone(); break;
                        case CraftResource.DesertiqueBone:     resItem = new DesertiqueBone(); break;
                        case CraftResource.CollinoisBone:   resItem = new CollinoisBone(); break;
                        case CraftResource.SavanoisBone:      resItem = new SavanoisBone(); break;
                        case CraftResource.ToundroisBone:    resItem = new ToundroisBone(); break;
                        case CraftResource.TropicauxBone:   resItem = new TropicauxBone(); break;
                        case CraftResource.MontagnardBone:     resItem = new MontagnardBone(); break;
                        case CraftResource.AncienBone:    resItem = new AncienBone(); break;
                    }
                }
                
                else if (resItem is BaseHides)
                {
                    switch (resource)
                    {
                        case CraftResource.PlainoisLeather:  resItem = new PlainoisLeather(); break;
                        case CraftResource.ForestierLeather:       resItem = new ForestierLeather(); break;
                        case CraftResource.DesertiqueLeather:     resItem = new DesertiqueLeather(); break;
                        case CraftResource.CollinoisLeather:   resItem = new CollinoisLeather(); break;
                        case CraftResource.SavanoisLeather:      resItem = new SavanoisLeather(); break;
                        case CraftResource.ToundroisLeather:    resItem = new ToundroisLeather(); break;
                        case CraftResource.TropicauxLeather:   resItem = new TropicauxLeather(); break;
                        case CraftResource.MontagnardLeather:     resItem = new MontagnardLeather(); break;
                        case CraftResource.AncienLeather:    resItem = new AncienLeather(); break;
                    }
                }

                int newAmount = (int)(craftResource.Amount * 0.5);
                
                if (newAmount < 1)
                    newAmount = 1;

				resItem.Amount = newAmount;


                from.AddToBackpack(resItem);

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