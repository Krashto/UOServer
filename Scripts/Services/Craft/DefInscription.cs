using Server.Custom.Aptitudes;
using Server.Items;
using Server.Mobiles;
using System;

namespace Server.Engines.Craft
{
    public enum InscriptionRecipes
    {
        
    }

    public class DefInscription : CraftSystem
    {
        public override SkillName MainSkill => SkillName.Inscribe;

		public override string GumpTitleString => "Écriture";

		private static CraftSystem m_CraftSystem;

        public static CraftSystem CraftSystem
        {
            get
            {
                if (m_CraftSystem == null)
                    m_CraftSystem = new DefInscription();

                return m_CraftSystem;
            }
        }

        public override double GetChanceAtMin(CraftItem item)
        {
            return 0.0; // 0%
        }

        private DefInscription()
            : base(3, 4, 1.50)// base( 1, 1, 3.0 )
		{
        }

        public override int CanCraft(Mobile from, ITool tool, Type typeItem)
        {
            int num = 0;

            if (tool == null || tool.Deleted || tool.UsesRemaining <= 0)
                return 1044038; // You have worn out your tool!
            else if (!tool.CheckAccessible(from, ref num))
                return num; // The tool must be on your person to use.

            if (typeItem != null && typeItem.IsSubclassOf(typeof(SpellScroll)))
            {
                if (!_Buffer.ContainsKey(typeItem))
                {
                    object o = Activator.CreateInstance(typeItem);

                    if (o is SpellScroll)
                    {
                        SpellScroll scroll = (SpellScroll)o;
                        _Buffer[typeItem] = scroll.SpellID;
                        scroll.Delete();
                    }
                    else if (o is IEntity)
                    {
                        ((IEntity)o).Delete();
                        return 1042404; // You don't have that spell!
                    }
                }
            }

            return 0;
        }

        private readonly System.Collections.Generic.Dictionary<Type, int> _Buffer = new System.Collections.Generic.Dictionary<Type, int>();

        public override void PlayCraftEffect(Mobile from)
        {
            from.PlaySound(0x249);
        }

        private static readonly Type typeofSpellScroll = typeof(SpellScroll);

        public override int PlayEndingEffect(Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, bool makersMark, CraftItem item)
        {
            if (toolBroken)
                from.SendLocalizedMessage(1044038); // You have worn out your tool

            if (!typeofSpellScroll.IsAssignableFrom(item.ItemType)) //  not a scroll
            {
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
            else
            {
                if (failed)
                    return 501630; // You fail to inscribe the scroll, and the scroll is ruined.
                else
                    return 501629; // You inscribe the spell and put the scroll in your backpack.
            }
        }
        
		private int index;


		public override void InitCraftList()
        {
			index = AddCraft(typeof(LivreClasseAucune), "Classes", "Livre d'oubli de classe", 25.0, 25.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");

			#region Artisans
			index = AddCraft(typeof(LivreClasseEmbouteilleur), "Artisans", "Alchimiste - Embouteilleur", 25.0, 25.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseAlchimiste), "Artisans", "Alchimiste - Alchimiste", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseApothicaire), "Artisans", "Alchimiste - Apothicaire", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");

			index = AddCraft(typeof(LivreClasseBricoleur), "Artisans", "Bricoleur - Bricoleur", 25.0, 25.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseIngenieur), "Artisans", "Bricoleur - Ingénieur", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseInventeur), "Artisans", "Bricoleur - Inventeur", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			
			index = AddCraft(typeof(LivreClasseStyliste), "Artisans", "Couturier - Styliste", 25.0, 25.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseModeleur), "Artisans", "Couturier - Modeleur", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseCouturier), "Artisans", "Couturier - Couturier", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");

			index = AddCraft(typeof(LivreClasseArmurier), "Artisans", "Forgeron - Armurier", 25.0, 25.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseForgeron), "Artisans", "Forgeron - Forgeron", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseForgefer), "Artisans", "Forgeron - Forgefer", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");

			index = AddCraft(typeof(LivreClasseEleve), "Artisans", "Savant - Élève", 20.0, 20.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseErudit), "Artisans", "Savant - Érudit", 40.0, 40.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseSage), "Artisans", "Savant - Sage", 60.0, 60.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			#endregion

			#region Guerriers
			index = AddCraft(typeof(LivreClasseArcher), "Guerriers", "Archer - Archer", 25.0, 25.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseFrancTireur), "Guerriers", "Archer - Franc tireur", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseMaitreArcher), "Guerriers", "Archer - Maître archer", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");

			index = AddCraft(typeof(LivreClasseEcuyer), "Guerriers", "Chevaucheur - Écuyer", 25.0, 25.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseJouteur), "Guerriers", "Chevaucheur - Jouteur", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseCavalier), "Guerriers", "Chevaucheur - Cavalier", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");

			index = AddCraft(typeof(LivreClasseCombattant), "Guerriers", "Guerrier - Combattant", 25.0, 25.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseMirmillon), "Guerriers", "Guerrier - Mirmillon", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseChampion), "Guerriers", "Guerrier - Champion", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");

			index = AddCraft(typeof(LivreClasseDefenseur), "Guerriers", "Protecteur - Défenseur", 25.0, 25.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseGardien), "Guerriers", "Protecteur - Gardien", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseProtecteur), "Guerriers", "Protecteur - Protecteur", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			#endregion

			#region Mages
			index = AddCraft(typeof(LivreClasseApprenti), "Mages", "Aéromancien - Apprenti", 25.0, 25.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseEvocateur), "Mages", "Aéromancien - Évocateur", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseAeromancien), "Mages", "Aéromancien - Aéromancien", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			
			index = AddCraft(typeof(LivreClasseNaturaliste), "Mages", "Géomancien - Naturaliste", 25.0, 25.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseDruide), "Mages", "Géomancien - Druide", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseGeomancien), "Mages", "Géomancien - Géomancien", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");

			index = AddCraft(typeof(LivreClasseIntervenant), "Mages", "Guérisseur - Intervenant", 25.0, 25.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseSoigneur), "Mages", "Guérisseur - Soigneur", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseGuerisseur), "Mages", "Guérisseur - Guérisseur", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");

			index = AddCraft(typeof(LivreClasseMage), "Mages", "Hydro. - Mage", 25.0, 25.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseMagicien), "Mages", "Hydro. - Magicien", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseHydromancien), "Mages", "Hydro. - Hydromancien", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			
			index = AddCraft(typeof(LivreClasseThanathauste), "Mages", "Nécromancien - Thanathauste", 25.0, 25.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseNecromage), "Mages", "Nécromancien - Nécromage", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseNecromancien), "Mages", "Nécromancien - Nécromancien", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");

			index = AddCraft(typeof(LivreClasseIncantateur), "Mages", "Pyromancien - Incantateur", 25.0, 25.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseSorcier), "Mages", "Pyromancien - Sorcier", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClassePyromancien), "Mages", "Pyromancien - Pyromancien", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");

			index = AddCraft(typeof(LivreClasseInvocateur), "Mages", "Spiritualiste - Invocateur", 25.0, 25.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseConjurateur), "Mages", "Spiritualiste - Conjurateur", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseSpiritualiste), "Mages", "Spiritualiste - Spiritualiste", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			#endregion

			#region Roublards
			index = AddCraft(typeof(LivreClasseMultiforme), "Roublards", "Changeforme - Multiforme", 25.0, 25.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseDiversiforme), "Roublards", "Changeforme - Diversiforme", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseChangeforme), "Roublards", "Changeforme - Changeforme", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");

			index = AddCraft(typeof(LivreClasseTroubadour), "Roublards", "Ménestrel - Troubadour", 25.0, 25.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseBarde), "Roublards", "Ménestrel - Barde", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseMenestrel), "Roublards", "Ménestrel - Ménestrel", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");

			index = AddCraft(typeof(LivreClasseTraqueur), "Roublards", "Rôdeur - Traqueur", 25.0, 25.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClassePisteur), "Roublards", "Rôdeur - Pisteur", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseRodeur), "Roublards", "Rôdeur - Rôdeur", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");

			index = AddCraft(typeof(LivreClasseVagabond), "Roublards", "Roublard - Vagabond", 25.0, 25.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseVoleur), "Roublards", "Roublard - Voleur", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseRoublard), "Roublards", "Roublard - Roublard", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			#endregion

			#region Skills
			index = AddCraft(typeof(LivreSkillsAlchemy), "Livre d'étude (skills)", "Alchemy", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsAnatomy), "Livre d'étude (skills)", "Anatomy", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsAnimalLore), "Livre d'étude (skills)", "AnimalLore", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsAnimalTaming), "Livre d'étude (skills)", "AnimalTaming", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsArchery), "Livre d'étude (skills)", "Archery", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsArmsLore), "Livre d'étude (skills)", "ArmsLore", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsBegging), "Livre d'étude (skills)", "Begging", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsBlacksmith), "Livre d'étude (skills)", "Blacksmith", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsCamping), "Livre d'étude (skills)", "Camping", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsCarpentry), "Livre d'étude (skills)", "Carpentry", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsCartography), "Livre d'étude (skills)", "Cartography", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsCooking), "Livre d'étude (skills)", "Cooking", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsDetectHidden), "Livre d'étude (skills)", "DetectHidden", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsDiscordance), "Livre d'étude (skills)", "Discordance", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsEvalInt), "Livre d'étude (skills)", "EvalInt", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsFencing), "Livre d'étude (skills)", "Fencing", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsFishing), "Livre d'étude (skills)", "Fishing", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsFletching), "Livre d'étude (skills)", "Fletching", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsForensics), "Livre d'étude (skills)", "Forensics", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsHealing), "Livre d'étude (skills)", "Healing", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsHerding), "Livre d'étude (skills)", "Herding", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsHiding), "Livre d'étude (skills)", "Hiding", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsInscribe), "Livre d'étude (skills)", "Inscribe", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsItemID), "Livre d'étude (skills)", "ItemID", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsLockpicking), "Livre d'étude (skills)", "Lockpicking", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsLumberjacking), "Livre d'étude (skills)", "Lumberjacking", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsMacing), "Livre d'étude (skills)", "Macing", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsMagery), "Livre d'étude (skills)", "Magery", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsMagicResist), "Livre d'étude (skills)", "MagicResist", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsMeditation), "Livre d'étude (skills)", "Meditation", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsMining), "Livre d'étude (skills)", "Mining", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsMusicianship), "Livre d'étude (skills)", "Musicianship", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsNecromancy), "Livre d'étude (skills)", "Necromancy", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsParry), "Livre d'étude (skills)", "Parry", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsPeacemaking), "Livre d'étude (skills)", "Peacemaking", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsPoisoning), "Livre d'étude (skills)", "Poisoning", 25.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsProvocation), "Livre d'étude (skills)", "Provocation", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsRemoveTrap), "Livre d'étude (skills)", "Remove Trap", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsSpiritSpeak), "Livre d'étude (skills)", "SpiritSpeak", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsSnooping), "Livre d'étude (skills)", "Snooping", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsStealing), "Livre d'étude (skills)", "Stealing", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsStealth), "Livre d'étude (skills)", "Stealth", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsSwords), "Livre d'étude (skills)", "Swords", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsTactics), "Livre d'étude (skills)", "Tactics", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsTailoring), "Livre d'étude (skills)", "Tailoring", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsTasteID), "Livre d'étude (skills)", "TasteID", 50.0.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsTinkering), "Livre d'étude (skills)", "Tinkering", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsTracking), "Livre d'étude (skills)", "Tracking", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsVeterinary), "Livre d'étude (skills)", "Veterinary", 50.0.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsWrestling), "Livre d'étude (skills)", "Wrestling", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			#endregion

			index = AddCraft(typeof(BlankScroll), "Autres", "Parchemin Vierge", 10.0, 20.0, typeof(Kindling), "Kindling", 5, "Vous n'avez pas assez de Petit Bois.");
			index = AddCraft(typeof(Missive), "Autres", "Missive", 15.0, 50.0, typeof(BlankScroll), 1044377, 1, 1044378);
			index = AddCraft(typeof(TanBook), "Autres", "Livre de 20 pages (Beige)", 10.0, 30.0, typeof(BlankScroll), 1044377, 5, 1044378);
			index = AddCraft(typeof(BlueBook), "Autres", "Livre de 20 pages (Bleu)", 10.0, 30.0, typeof(BlankScroll), 1044377, 5, 1044378);
			index = AddCraft(typeof(RedBook), "Autres", "Livre de 20 pages (Rouge)", 10.0, 30.0, typeof(BlankScroll), 1044377, 5, 1044378);
			index = AddCraft(typeof(BrownBook), "Autres", "Livre de 20 pages (Brun)", 10.0, 30.0, typeof(BlankScroll), 1044377, 5, 1044378);
			index = AddCraft(typeof(GargoyleBook100), "Autres", "Livre 100 pages", 60.0, 100.0, typeof(BlankScroll), 1044377, 15, 1044378);
			index = AddCraft(typeof(CarnetAdresse), "Autres", "Carnet d'Adresse", 25.0, 50.0, typeof(BlankScroll), 1044377, 10, 1044378);
			index = AddCraft(typeof(Calendrier), "Autres", "Calendrier", 0.0, 25.0, typeof(BlankScroll), 1044377, 5, 1044378);

			index = AddCraft(typeof(TreasureMap), "Carte aux trésors", "Niveau 1", 50.0, 100.0, typeof(TreasureMapLevelOnePart), "Morceau de carte niveau 1", 1, "Vous n'avez pas assez de morceau de carte niveau 1");
			index = AddCraft(typeof(TreasureMap), "Carte aux trésors", "Niveau 2", 50.0, 100.0, typeof(TreasureMapLevelTwoPart), "Morceau de carte niveau 2", 1, "Vous n'avez pas assez de morceau de carte niveau 2");
			index = AddCraft(typeof(TreasureMap), "Carte aux trésors", "Niveau 3", 50.0, 100.0, typeof(TreasureMapLevelThreePart), "Morceau de carte niveau 3", 1, "Vous n'avez pas assez de morceau de carte niveau 3");
			index = AddCraft(typeof(TreasureMap), "Carte aux trésors", "Niveau 4", 50.0, 100.0, typeof(TreasureMapLevelFourPart), "Morceau de carte niveau 4", 1, "Vous n'avez pas assez de morceau de carte niveau 4");
			index = AddCraft(typeof(TreasureMap), "Carte aux trésors", "Niveau 5", 50.0, 100.0, typeof(TreasureMapLevelFivePart), "Morceau de carte niveau 5", 1, "Vous n'avez pas assez de morceau de carte niveau 5");
			index = AddCraft(typeof(TreasureMap), "Carte aux trésors", "Niveau 6", 50.0, 100.0, typeof(TreasureMapLevelSixPart), "Morceau de carte niveau 6", 1, "Vous n'avez pas assez de morceau de carte niveau 6");
			index = AddCraft(typeof(TreasureMap), "Carte aux trésors", "Niveau 7", 50.0, 100.0, typeof(TreasureMapLevelSevenPart), "Morceau de carte niveau 7", 1, "Vous n'avez pas assez de morceau de carte niveau 7");

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
	}
}
