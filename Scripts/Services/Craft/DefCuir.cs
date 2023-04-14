﻿using Server.Items;
using System;
using System.Collections.Generic;

namespace Server.Engines.Craft
{
 
    public class DefCuir : CraftSystem
    {
        #region Statics

  

        // singleton instance
        private static CraftSystem m_CraftSystem;

        public static CraftSystem CraftSystem
        {
            get
            {
                if (m_CraftSystem == null)
                    m_CraftSystem = new DefCuir();

                return m_CraftSystem;
            }
        }
        #endregion

        #region Constructor
        private DefCuir()
            : base(1, 1, 1.25)// base( 1, 1, 4.5 )
        {
        }

        #endregion

        #region Overrides
        public override SkillName MainSkill => SkillName.Tailoring;

		public override string GumpTitleString
		{
			get { return "<CENTER>Travail du Cuir</CENTER>"; }
		}

		public override CraftECA ECA => CraftECA.Chance3Max;

		public override double GetChanceAtMin(CraftItem item)
		{
			return 0.5; // 50%
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
            from.PlaySound(0x248);
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

        public override void InitCraftList()
        {
            int index = -1;

			#region Bottes
			index = AddCraft(typeof(Bottes), "Bottes", "Bottes à talon", 45.7, 65.7, typeof(PlainoisLeather), 1044462, 15, 1044463);
			index = AddCraft(typeof(Bottes2), "Bottes", "Bottes en cuir", 71.8, 91.8, typeof(PlainoisLeather), 1044462, 15, 1044463);
			index = AddCraft(typeof(Bottes3), "Bottes", "Bottes ajustées", 75.7, 95.7, typeof(PlainoisLeather), 1044462, 15, 1044463);
			index = AddCraft(typeof(Bottes4), "Bottes", "Bottes lacées", 57.6, 77.6, typeof(PlainoisLeather), 1044462, 15, 1044463);
			index = AddCraft(typeof(Bottes5), "Bottes", "Bottes à Sangles", 52.0, 72.0, typeof(PlainoisLeather), 1044462, 15, 1044463);
			index = AddCraft(typeof(Bottes6), "Bottes", "Bottes en cuir large", 85.6, 105.6, typeof(PlainoisLeather), 1044462, 15, 1044463);
			index = AddCraft(typeof(Bottes7), "Bottes", "Bottes en fourrure", 74.1, 94.1, typeof(PlainoisLeather), 1044462, 15, 1044463);
			index = AddCraft(typeof(Bottes8), "Bottes", "Bottes en tissus", 69.6, 89.6, typeof(PlainoisLeather), 1044462, 15, 1044463);
			index = AddCraft(typeof(Bottes9), "Bottes", "Bottes à rebord", 86.9, 106.9, typeof(PlainoisLeather), 1044462, 15, 1044463);
			index = AddCraft(typeof(Bottes10), "Bottes", "Botte haute à sangles", 62.8, 82.8, typeof(PlainoisLeather), 1044462, 15, 1044463);
			index = AddCraft(typeof(BottesPoils), "Bottes", "Bottes de Poils", 62.8, 82.8, typeof(PlainoisLeather), 1044462, 15, 1044463);
			index = AddCraft(typeof(SoulierTissus), "Bottes", "Soulier en Tissus", 62.8, 82.8, typeof(PlainoisLeather), 1044462, 15, 1044463);
			index = AddCraft(typeof(SandaleCuir), "Bottes", "Sandales en cuir", 62.8, 82.8, typeof(PlainoisLeather), 1044462, 10, 1044463);
			index = AddCraft(typeof(ElvenBoots), "Bottes", "Bottes délicate", 80.0, 105.0, typeof(PlainoisLeather), 1044462, 15, 1044463);


			AddCraft(typeof(Sandals), "Bottes", "Sandales", 12.4, 37.4, typeof(PlainoisLeather), 1044462, 15, 1044463);
			AddCraft(typeof(Shoes), "Bottes", "Souliers", 16.5, 41.5, typeof(PlainoisLeather), 1044462, 15, 1044463);
			AddCraft(typeof(Boots), "Bottes", "Bottes simples", 33.1, 58.1, typeof(PlainoisLeather), 1044462, 15, 1044463);
			AddCraft(typeof(ThighBoots), "Bottes", "Cuissardes", 41.4, 66.4, typeof(PlainoisLeather), 1044462, 15, 1044463);

			AddCraft(typeof(LeatherTalons), "Bottes", "Soulier en cuir", 40.4, 65.4, typeof(PlainoisLeather), 1044462, 15, 1044463);

			#endregion

			#region Ceintures

			index = AddCraft(typeof(Ceinture), "Ceintures", "Ceinture boucle ronde", 52.4, 72.4, typeof(PlainoisLeather), "cuir", 10, "Vous n'avez pas assez de cuir.");
			index = AddCraft(typeof(Ceinture2), "Ceintures", "Ceinture boucle carrée", 63.8, 83.8, typeof(PlainoisLeather), "cuir", 10, "Vous n'avez pas assez de cuir.");
			index = AddCraft(typeof(Ceinture3), "Ceintures", "Ceinture d'artisan", 87.4, 107.4, typeof(PlainoisLeather), "cuir", 10, "Vous n'avez pas assez de cuir.");
			index = AddCraft(typeof(Ceinture4), "Ceintures", "Ceinture à pochettes", 53.7, 73.7, typeof(PlainoisLeather), "cuir", 10, "Vous n'avez pas assez de cuir.");
			index = AddCraft(typeof(Ceinture5), "Ceintures", "Ceinture mince", 90.9, 110.9, typeof(PlainoisLeather), "cuir", 10, "Vous n'avez pas assez de cuir.");
			index = AddCraft(typeof(Ceinture6), "Ceintures", "Ceinture poche à gauche", 94.8, 114.8, typeof(PlainoisLeather), "cuir", 10, "Vous n'avez pas assez de cuir.");
			index = AddCraft(typeof(Ceinture7), "Ceintures", "Ceinture en tissu", 56.4, 76.4, typeof(PlainoisLeather), "cuir", 10, "Vous n'avez pas assez de cuir.");
			index = AddCraft(typeof(Ceinture8), "Ceintures", "Ceinture en bandouillère", 59.6, 79.6, typeof(PlainoisLeather), "cuir", 10, "Vous n'avez pas assez de cuir.");
			index = AddCraft(typeof(Ceinture9), "Ceintures", "Bourse carrée", 80.5, 100.5, typeof(PlainoisLeather), "cuir", 10, "Vous n'avez pas assez de cuir.");
			index = AddCraft(typeof(CeintureBaril), "Ceintures", "Ceinture Barril", 80.5, 100.5, typeof(PlainoisLeather), "cuir", 10, "Vous n'avez pas assez de cuir.");
			index = AddCraft(typeof(CeintureMetal), "Ceintures", "Ceinture Métalique", 80.5, 100.5, typeof(PlainoisLeather), "cuir", 10, "Vous n'avez pas assez de cuir.");
			index = AddCraft(typeof(CentureDoreeLarge), "Ceintures", "Ceinture Dorée Large", 80.5, 100.5, typeof(PlainoisLeather), "cuir", 10, "Vous n'avez pas assez de cuir.");

			#endregion


			#region Masques
			index = AddCraft(typeof(OrcMask), "Masques", "Masque d'orc", 75.0, 100.0, typeof(PlainoisLeather), "cuir", 10, "Vous n'avez pas assez de cuir.");
			index = AddCraft(typeof(BearMask), "Masques", "Masque d'ours", 77.5, 102.5, typeof(PlainoisLeather), "cuir", 10, "Vous n'avez pas assez de cuir.");
			index = AddCraft(typeof(DeerMask), "Masques", "Marsque de Cerf", 77.5, 102.5, typeof(PlainoisLeather), "cuir", 10, "Vous n'avez pas assez de cuir.");
			index = AddCraft(typeof(TribalMask), "Masques", "Masque Tribal", 82.5, 107.5, typeof(PlainoisLeather), "cuir", 10, "Vous n'avez pas assez de cuir.");
			index = AddCraft(typeof(HornedTribalMask), "Masques", "Masque tribal Ornée", 82.5, 107.5, typeof(PlainoisLeather), "cuir", 10, "Vous n'avez pas assez de cuir.");
			index = AddCraft(typeof(CoiffeGuepard), "Chapeaux", "Coiffe Guepard", 75.3, 95.3, typeof(PlainoisLeather), "cuir", 10, "Vous n'avez pas assez de cuir.");
			index = AddCraft(typeof(CoiffeLoupBlanc), "Chapeaux", "Coiffe Loup Blanc", 75.3, 95.3, typeof(PlainoisLeather), "cuir", 10, "Vous n'avez pas assez de cuir.");
			index = AddCraft(typeof(CoiffeLion), "Chapeaux", "Coiffe Lion", 75.3, 95.3, typeof(PlainoisLeather), "cuir", 10, "Vous n'avez pas assez de cuir.");
			index = AddCraft(typeof(CoiffeSanglier), "Chapeaux", "Coiffe Sanglier", 75.3, 95.3, typeof(PlainoisLeather), "cuir", 10, "Vous n'avez pas assez de cuir.");
			index = AddCraft(typeof(TeteCoyote), "Chapeaux", "Tete de Coyote", 85.5, 105.5, typeof(PlainoisLeather), "cuir", 10, "Vous n'avez pas assez de cuir.");
			index = AddCraft(typeof(TeteTaureau), "Chapeaux", "Tete de Taureau", 89.3, 109.3, typeof(PlainoisLeather), "cuir", 10, "Vous n'avez pas assez de cuir.");
			#endregion

	

			#region Armure de Cuir
			AddCraft(typeof(LeatherGorget), "Armures de cuir", "Leather gorget", 20.0, 40.0, typeof(PlainoisLeather), "Cuir", 5, "You do not have sufficient leather to make that item.");
			AddCraft(typeof(LeatherGloves), "Armures de cuir", "Leather gloves", 20.0, 40.0, typeof(PlainoisLeather), "Cuir", 6, "You do not have sufficient leather to make that item.");
			AddCraft(typeof(LeatherCap), "Armures de cuir", "Leather cap", 23.0, 43.0, typeof(PlainoisLeather), "Cuir", 5, "You do not have sufficient leather to make that item.");
			AddCraft(typeof(LeatherArms), "Armures de cuir", "Leather arms", 23.0, 43.0, typeof(PlainoisLeather), "Cuir", 8, "You do not have sufficient leather to make that item.");
			AddCraft(typeof(LeatherShorts), "Armures de cuir", "Leather shorts", 25.0, 45.0, typeof(PlainoisLeather), "Cuir", 11, "You do not have sufficient leather to make that item.");
			AddCraft(typeof(LeatherSkirt), "Armures de cuir", "Leather skirt", 25.0, 45.0, typeof(PlainoisLeather), "Cuir", 11, "You do not have sufficient leather to make that item.");
			AddCraft(typeof(LeatherLegs), "Armures de cuir", "Leather legs", 25.0, 45.0, typeof(PlainoisLeather), "Cuir", 11, "You do not have sufficient leather to make that item.");
			AddCraft(typeof(LeatherChest), "Armures de cuir", "Leather chest", 30.0, 50.0, typeof(PlainoisLeather), "Cuir", 14, "You do not have sufficient leather to make that item.");
			AddCraft(typeof(FemaleLeatherChest), "Armures de cuir", "Female leather chest", 30.0, 50.0, typeof(PlainoisLeather), "Cuir", 14, "You do not have sufficient leather to make that item.");
			AddCraft(typeof(LeatherBustierArms), "Armures de cuir", "Leather bustier arms", 30.0, 50.0, typeof(PlainoisLeather), "Cuir", 14, "You do not have sufficient leather to make that item.");

			index = AddCraft(typeof(LeafChest), "Armures de Cuir", "Coffre de feuille", 30.0, 50.0, typeof(PlainoisLeather), "Cuir", 14, "You do not have sufficient leather to make that item.");

			index = AddCraft(typeof(LeafArms), "Armures de Cuir", "Brassards de feuille", 23.0, 43.0, typeof(PlainoisLeather), "Cuir", 8, "You do not have sufficient leather to make that item.");

			index = AddCraft(typeof(LeafGloves), "Armures de Cuir", "Gants de feuille", 20.0, 40.0, typeof(PlainoisLeather), "Cuir", 6, "You do not have sufficient leather to make that item.");

			index = AddCraft(typeof(LeafLegs), "Armures de Cuir", "Pantalons de feuille", 25.0, 45.0, typeof(PlainoisLeather), "Cuir", 11, "You do not have sufficient leather to make that item.");

			index = AddCraft(typeof(LeafGorget), "Armures de Cuir", "Gorget de feuille", 20.0, 40.0, typeof(PlainoisLeather), "Cuir", 5, "You do not have sufficient leather to make that item.");

			index = AddCraft(typeof(LeafTonlet), "Armures de Cuir", "Casque de feuille", 23.0, 43.0, typeof(PlainoisLeather), "Cuir", 5, "You do not have sufficient leather to make that item.");
			#endregion

			#region Armure Cloutée
			index = AddCraft(typeof(StuddedGorget), "Armures de cuir", "Studded gorget", 26.0, 46.0, typeof(PlainoisLeather), "Leather", 6, "You do not have sufficient leather to make that item.");

			index = AddCraft(typeof(StuddedGloves), "Armures de cuir", "Studded gloves", 26.0, 46.0, typeof(PlainoisLeather), "Leather", 7, "You do not have sufficient leather to make that item.");

			index = AddCraft(typeof(StuddedArms), "Armures de cuir", "Studded arms", 29.0, 49.0, typeof(PlainoisLeather), "Leather", 9, "You do not have sufficient leather to make that item.");

			index = AddCraft(typeof(StuddedLegs), "Armures de cuir", "Studded legs", 31.0, 51.0, typeof(PlainoisLeather), "Leather", 12, "You do not have sufficient leather to make that item.");

			index = AddCraft(typeof(StuddedBustierArms), "Armures de cuir", "Studded bustier arms", 36.0, 56.0, typeof(PlainoisLeather), "Leather", 15, "You do not have sufficient leather to make that item.");

			index = AddCraft(typeof(StuddedChest), "Armures de cuir", "Studded chest", 36.0, 56.0, typeof(PlainoisLeather), "Leather", 15, "You do not have sufficient leather to make that item.");

			index = AddCraft(typeof(FemaleStuddedChest), "Armures de cuir", "Female studded chest", 36.0, 56.0, typeof(PlainoisLeather), "Leather", 15, "You do not have sufficient leather to make that item.");


			AddCraft(typeof(BrassardCloute), "Armures Cloutée", "Brassard Clouté", 36.0, 56.0, typeof(PlainoisLeather), 1044462, 10, 1044463);
			AddCraft(typeof(JupeCloute), "Armures Cloutée", "Jupe Clouté", 36.0, 56.0, typeof(PlainoisLeather), 1044462, 12, 1044463);

			AddCraft(typeof(PlastronCloute), "Armures Cloutée", "Plastron Clouté", 36.0, 56.0, typeof(PlainoisLeather), 1044462, 14, 1044463);
			AddCraft(typeof(PlastronCloute2), "Armures Cloutée", "Plastron Clouté2", 36.0, 56.0, typeof(PlainoisLeather), 1044462, 14, 1044463);
			AddCraft(typeof(PlastronCloute3), "Armures Cloutée", "Plastron Clouté3", 36.0, 56.0, typeof(PlainoisLeather), 1044462, 14, 1044463);
			AddCraft(typeof(PlastronCloute4), "Armures Cloutée", "Plastron Clouté4", 36.0, 56.0, typeof(PlainoisLeather), 1044462, 14, 1044463);

			index = AddCraft(typeof(HideChest), "Armures Cloutée", "Coffre de Peaux", 36.0, 56.0, typeof(PlainoisLeather), 1044462, 15, 1044463);

			index = AddCraft(typeof(HidePauldrons), "Armures Cloutée", "Épaulettes de Peaux", 29.0, 49.0, typeof(PlainoisLeather), 1044462, 12, 1044463);

			index = AddCraft(typeof(HideGloves), "Armures Cloutée", "Gants de Peaux", 26.0, 46.0, typeof(PlainoisLeather), 1044462, 10, 1044463);

			index = AddCraft(typeof(HidePants), "Armures Cloutée", "Pantalons de Peaux", 31.0, 51.0, typeof(PlainoisLeather), 1044462, 15, 1044463);

			index = AddCraft(typeof(HideGorget), "Armures Cloutée", "Gorgerin de Peaux", 26.0, 46.0, typeof(PlainoisLeather), 1044462, 12, 1044463);
			#endregion

			#region Divers
			index = AddCraft(typeof(Backpack), "Divers", "Sac à dos", 10, 35.0, typeof(PlainoisLeather), 1044462, 5, 1044463);
			index = AddCraft(typeof(Pouch), "Divers", "Bourse", 0.0, 25.0, typeof(PlainoisLeather), 1044462, 3, 1044463);
			index = AddCraft(typeof(Bag), "Divers", "Sac", 5, 30.0, typeof(PlainoisLeather), 1044462, 4, 1044463);

			index = AddCraft(typeof(Carquois), "Divers", "Carquois", 60.6, 80.6, typeof(PlainoisLeather), "cuir", 10, "Vous n'avez pas assez de cuir.");
			index = AddCraft(typeof(fourreau), "Divers", "Fourreau épée longue", 80.7, 100.7, typeof(PlainoisLeather), "cuir", 10, "Vous n'avez pas assez de cuir.");
			index = AddCraft(typeof(fourreau2), "Divers", "Fourreau croisé", 98.1, 118.1, typeof(PlainoisLeather), "cuir", 10, "Vous n'avez pas assez de cuir.");
			index = AddCraft(typeof(fourreau3), "Divers", "Fourreau bandouillère", 66.9, 86.9, typeof(PlainoisLeather), "cuir", 10, "Vous n'avez pas assez de cuir.");
			index = AddCraft(typeof(FourreauDore), "Divers", "Fourreau Doré", 66.9, 86.9, typeof(PlainoisLeather), "cuir", 10, "Vous n'avez pas assez de cuir.");

			AddCraft(typeof(BrownBearRugSouthDeed), "Decorations", "Peau Ours Sud", 85.0, 115.0, typeof(PlainoisLeather), 1044462, 10, 1044463);
			AddCraft(typeof(BrownBearRugEastDeed), "Decorations", "Peau Ours Est", 85.0, 115.0, typeof(PlainoisLeather), 1044462, 10, 1044463);
			AddCraft(typeof(PolarBearRugSouthDeed), "Decorations", "Peau Ours Polaire Sud", 85.0, 115.0, typeof(PlainoisLeather), 1044462, 10, 1044463);
			AddCraft(typeof(PolarBearRugEastDeed), "Decorations", "Peau Ours Polaire Est", 85.0, 115.0, typeof(PlainoisLeather), 1044462, 10, 1044463);

			index = AddCraft(typeof(Corde), "Divers", "Corde", 60.0, 75.0, typeof(PlainoisLeather), "cuir", 10, "Vous n'avez pas assez de cuir.");
			#endregion

			// Set the overridable material
			SetSubRes(typeof(PlainoisLeather), "Plainois");

			// Add every material you want the player to be able to choose from
			// This will override the overridable material
			AddSubRes(typeof(PlainoisLeather), "Plainois", 0.0, "Vous ne savez pas travailler le cuir plainois");
			AddSubRes(typeof(CollinoisLeather), "Collinois", 20.0, "Vous ne savez pas travailler le cuir collinois");
			AddSubRes(typeof(ForestierLeather), "Forestier", 20.0, "Vous ne savez pas travailler le cuir forestier");
			AddSubRes(typeof(SavanoisLeather), "Savanois", 40.0, "Vous ne savez pas travailler le cuir savanois");
			AddSubRes(typeof(DesertiqueLeather), "Desertique", 40.0, "Vous ne savez pas travailler le cuir desertique");
			AddSubRes(typeof(MontagnardLeather), "Montagnard", 60.0, "Vous ne savez pas travailler le cuir montagnard");
			AddSubRes(typeof(VolcaniqueLeather), "Volcanique", 60.0, "Vous ne savez pas travailler le cuir volcanique");
			AddSubRes(typeof(TropicauxLeather), "Tropicaux", 80.0, "Vous ne savez pas travailler le cuir tropicaux");
			AddSubRes(typeof(ToundroisLeather), "Toundrois", 80.0, "Vous ne savez pas travailler le cuir toundrois");
		    AddSubRes(typeof(AncienLeather), "Ancien", 100.0, "Vous ne savez pas travailler le cuir ancien");

			MarkOption = true;
            Repair = true;
            CanEnhance = true;
            CanAlter = true;
        } 
        #endregion

        private void CutUpCloth(Mobile m, CraftItem craftItem, ITool tool)
        {
            PlayCraftEffect(m);

            Timer.DelayCall(TimeSpan.FromSeconds(Delay), () =>
                {
                    if (m.Backpack == null)
                    {
                        m.SendGump(new CraftGump(m, this, tool, null));
                    }

                    Dictionary<int, int> bolts = new Dictionary<int, int>();
                    List<Item> toConsume = new List<Item>();
                    object num = null;
                    Container pack = m.Backpack;

                    foreach (Item item in pack.Items)
                    {
                        if (item.GetType() == typeof(BoltOfCloth))
                        {
                            if (!bolts.ContainsKey(item.Hue))
                            {
                                toConsume.Add(item);
                                bolts[item.Hue] = item.Amount;
                            }
                            else
                            {
                                toConsume.Add(item);
                                bolts[item.Hue] += item.Amount;
                            }
                        }
                    }

                    if (bolts.Count == 0)
                    {
                        num = 1044253; // You don't have the components needed to make that.
                    }
                    else
                    {
                        foreach (Item item in toConsume)
                        {
                            item.Delete();
                        }

                        foreach (KeyValuePair<int, int> kvp in bolts)
                        {
                            UncutCloth cloth = new UncutCloth(kvp.Value * 50)
                            {
                                Hue = kvp.Key
                            };

                            DropItem(m, cloth, tool);
                        }
                    }

                    if (tool != null)
                    {
                        tool.UsesRemaining--;

                        if (tool.UsesRemaining <= 0 && !tool.Deleted)
                        {
                            tool.Delete();
                            m.SendLocalizedMessage(1044038);
                        }
                        else
                        {
                            m.SendGump(new CraftGump(m, this, tool, num));
                        }
                    }

                    ColUtility.Free(toConsume);
                    bolts.Clear();
                });
        }

        private void DropItem(Mobile from, Item item, ITool tool)
        {
            if (tool is Item && ((Item)tool).Parent is Container)
            {
                Container cntnr = (Container)((Item)tool).Parent;

                if (!cntnr.TryDropItem(from, item, false))
                {
                    if (cntnr != from.Backpack)
                        from.AddToBackpack(item);
                    else
                        item.MoveToWorld(from.Location, from.Map);
                }
            }
            else
            {
                from.AddToBackpack(item);
            }
        }
    }
}
