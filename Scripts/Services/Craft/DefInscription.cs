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
            : base(1, 1, 1.25)// base( 1, 1, 3.0 )
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

         /*       int id = _Buffer[typeItem];
                Spellbook book = Spellbook.Find(from, id);

                if (book == null || !book.HasSpell(id))
                    return 1042404; // You don't have that spell!*/
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

        private int m_Circle, m_Mana;

        private enum Reg { BlackPearl, Bloodmoss, Garlic, Ginseng, MandrakeRoot, Nightshade, SulfurousAsh, SpidersSilk, BatWing, GraveDust, DaemonBlood, NoxCrystal, PigIron, Bone, DragonBlood, FertileDirt, DaemonBone }

        private readonly Type[] m_RegTypes = new Type[]
        {
            typeof( BlackPearl ),
            typeof( Bloodmoss ),
            typeof( Garlic ),
            typeof( Ginseng ),
            typeof( MandrakeRoot ),
            typeof( Nightshade ),
            typeof( SulfurousAsh ),
            typeof( SpidersSilk ),
            typeof( BatWing ),
            typeof( GraveDust ),
            typeof( DaemonBlood ),
            typeof( NoxCrystal ),
            typeof( PigIron ),
            typeof( PlainoisBone ),
            typeof( DragonBlood ),
            typeof( FertileDirt ),
            typeof( DaemonBone )
        };

        private int m_Index;

        private int GetRegLocalization(Reg reg)
        {
            int loc = 0;

            switch (reg)
            {
                case Reg.BatWing: loc = 1023960; break;
                case Reg.GraveDust: loc = 1023983; break;
                case Reg.DaemonBlood: loc = 1023965; break;
                case Reg.NoxCrystal: loc = 1023982; break;
                case Reg.PigIron: loc = 1023978; break;
                case Reg.Bone: loc = 1023966; break;
                case Reg.DragonBlood: loc = 1023970; break;
                case Reg.FertileDirt: loc = 1023969; break;
                case Reg.DaemonBone: loc = 1023968; break;
            }

            if (loc == 0)
                loc = 1044353 + (int)reg;

            return loc;
        }

		private int index;

		private void AddSpell(string aptitude, Type type, string name, int level)
		{
			double minSkill, maxSkill;

			switch (level)
			{
				default:
				case 1: minSkill = 0; maxSkill = 30; break;
				case 2: minSkill = 10; maxSkill = 40; break;
				case 3: minSkill = 20; maxSkill = 50; break;
				case 4: minSkill = 30; maxSkill = 60; break;
				case 5: minSkill = 40; maxSkill = 70; break;
				case 6: minSkill = 50; maxSkill = 80; break;
				case 7: minSkill = 60; maxSkill = 90; break;
				case 8: minSkill = 70; maxSkill = 100; break;
				case 9: minSkill = 80; maxSkill = 110; break;
				case 10: minSkill = 90; maxSkill = 120; break;
			}

			index = AddCraft(type, aptitude, name, minSkill, maxSkill, typeof(BlankScroll), "Blank scroll", 1, "You do not have enough blank scrolls to make that.");
		}

		private string GetCircle(int circle)
		{
			if (circle >= 0 && circle <= 10)
				return m_GetCircle[circle];

			return "";
		}

		private static string[] m_GetCircle = new string[]
			{
				"Niveau 0",
				"Niveau 1",
				"Niveau 2",
				"Niveau 3",
				"Niveau 4",
				"Niveau 5",
				"Niveau 6",
				"Niveau 7",
				"Niveau 8",
				"Niveau 9",
				"Niveau 10",
			};

		public override void InitCraftList()
        {
			AddSpell("Sorts", typeof(AveuglementScroll), "Aéro. - Aveuglement", 1);
			AddSpell("Sorts", typeof(BrouillardScroll), "Aéro. - Brouillard", 2);
			AddSpell("Sorts", typeof(TeleportationScroll), "Aéro. - Téleportation", 3);
			AddSpell("Sorts", typeof(TornadoScroll), "Aéro. - Tornado", 4);
			AddSpell("Sorts", typeof(AuraEvasiveScroll), "Aéro. - Aura évasive", 5);
			AddSpell("Sorts", typeof(ExTeleportationScroll), "Aéro. - Ex-téleportation", 6);
			AddSpell("Sorts", typeof(ToucheSuffosantScroll), "Aéro. - Touché suffosant", 7);
			AddSpell("Sorts", typeof(AuraDeBrouillardScroll), "Aéro. - Aura de brouillard", 8);
			AddSpell("Sorts", typeof(VentFavorableScroll), "Aéro. - Vent favorable", 9);
			AddSpell("Sorts", typeof(VortexScroll), "Aéro. - Vortex", 10);

			AddSpell("Sorts", typeof(AntidoteScroll), "Chasseur - Antidote", 1);
			AddSpell("Sorts", typeof(MarquerScroll), "Chasseur - Marquer", 2);
			AddSpell("Sorts", typeof(CompagnonAnimalScroll), "Chasseur - Compagnon anim.", 3);
			AddSpell("Sorts", typeof(SoinAnimalierScroll), "Chasseur - Soin animalier", 4);
			AddSpell("Sorts", typeof(RugissementScroll), "Chasseur - Rugissement", 5);
			AddSpell("Sorts", typeof(FrappeEnsanglanteeScroll), "Chasseur - Frappe ensangl.", 6);
			AddSpell("Sorts", typeof(SautAggressifScroll), "Chasseur - Saut aggressif", 7);
			AddSpell("Sorts", typeof(CoupDansLeGenouScroll), "Chasseur - Coup dans le gen.", 8);
			AddSpell("Sorts", typeof(ChasseurDePrimeScroll), "Chasseur - Chasseur de prime", 9);
			AddSpell("Sorts", typeof(ContratResoluScroll), "Chasseur - Contrat résolu", 10);

			AddSpell("Sorts", typeof(CoupDeBouclierScroll), "Défenseur - Coup de bouclier", 1);
			AddSpell("Sorts", typeof(BravadeScroll), "Défenseur - Bravade", 2);
			AddSpell("Sorts", typeof(DevotionScroll), "Défenseur - Dévotion", 3);
			AddSpell("Sorts", typeof(MutinerieScroll), "Défenseur - Mutinerie", 4);
			AddSpell("Sorts", typeof(MentorScroll), "Défenseur - Mentor", 5);
			AddSpell("Sorts", typeof(LienDeVieScroll), "Défenseur - Lien de vie", 6);
			AddSpell("Sorts", typeof(MiracleScroll), "Défenseur - Miracle", 7);
			AddSpell("Sorts", typeof(IndomptableScroll), "Défenseur - Indomptable", 8);
			AddSpell("Sorts", typeof(InsensibleScroll), "Défenseur - Insensible", 9);
			AddSpell("Sorts", typeof(PiedsAuSolScroll), "Défenseur - Pieds su sol", 10);

			AddSpell("Sorts", typeof(FortifieScroll), "Géo. - Fortifié", 1);
			AddSpell("Sorts", typeof(RocheScroll), "Géo. - Roche", 2);
			AddSpell("Sorts", typeof(ContaminationScroll), "Géo. - Contamination", 3);
			AddSpell("Sorts", typeof(EmpalementScroll), "Géo. - Empalement", 4);
			AddSpell("Sorts", typeof(AuraFortifianteScroll), "Géo. - Aura fortifiante", 5);
			AddSpell("Sorts", typeof(MurDePlanteScroll), "Géo. - Mur de plante", 6);
			AddSpell("Sorts", typeof(ExplosionDeRocheScroll), "Géo. - Explosion de roche", 7);
			AddSpell("Sorts", typeof(AuraPreservationManiaqueScroll), "Géo. - Aura préserv. manaique", 8);
			AddSpell("Sorts", typeof(RacinesScroll), "Géo. - Racines", 9);
			AddSpell("Sorts", typeof(FleauTerrestreScroll), "Géo. - Fléau terrestre", 10);

			AddSpell("Sorts", typeof(MainCicatrisanteScroll), "Guérison - Main cicatri.", 1);
			AddSpell("Sorts", typeof(RemedeScroll), "Guérison - Remède", 2);
			AddSpell("Sorts", typeof(MurDePierreScroll), "Guérison - Mur de pierre", 3);
			AddSpell("Sorts", typeof(RayonCelesteScroll), "Guérison - Rayon céleste", 4);
			AddSpell("Sorts", typeof(LumiereSacreeScroll), "Guérison - Lumière sacrée", 5);
			AddSpell("Sorts", typeof(FrayeurScroll), "Guérison - Frayeur", 6);
			AddSpell("Sorts", typeof(FerveurDivineScroll), "Guérison - Ferveur divi.", 7);
			AddSpell("Sorts", typeof(InquisitionScroll), "Guérison - Inquisition", 8);
			AddSpell("Sorts", typeof(MurDeLumiereScroll), "Guérison - Mur de lumière", 9);
			AddSpell("Sorts", typeof(DonDeLaVieScroll), "Guérison - Don de la vie", 10);

			AddSpell("Sorts", typeof(ArmureDeGlaceScroll), "Hydro. - Armure de glace", 1);
			AddSpell("Sorts", typeof(RestaurationScroll), "Hydro. - Restauration", 2);
			AddSpell("Sorts", typeof(SoinPreventifScroll), "Hydro. - Soin préventif", 3);
			AddSpell("Sorts", typeof(CageDeGlaceScroll), "Hydro. - Cage de glace", 4);
			AddSpell("Sorts", typeof(AuraCryogeniseeScroll), "Hydro. - Aura cryogenisée", 5);
			AddSpell("Sorts", typeof(PieuxDeGlaceScroll), "Hydro. - Pieux de glace", 6);
			AddSpell("Sorts", typeof(CerveauGeleScroll), "Hydro. - Cerveau gelé", 7);
			AddSpell("Sorts", typeof(AuraRefrigeranteScroll), "Hydro. - Aura réfrigerante", 8);
			AddSpell("Sorts", typeof(AvatarDuFroidScroll), "Hydro. - Avatar de froid", 9);
			AddSpell("Sorts", typeof(BlizzardScroll), "Hydro. - Blizzard", 10);

			AddSpell("Sorts", typeof(SecondSouffleScroll), "Martial - Second souffle", 1);
			AddSpell("Sorts", typeof(ProvocationScroll), "Martial - Provocation", 2);
			AddSpell("Sorts", typeof(SautDevastateurScroll), "Martial - Saut dévastateur", 3);
			AddSpell("Sorts", typeof(DuelScroll), "Martial - Duel", 4);
			AddSpell("Sorts", typeof(ChargeFurieuseScroll), "Martial - Charge furieuse", 5);
			AddSpell("Sorts", typeof(EnrageScroll), "Martial - Enragé", 6);
			AddSpell("Sorts", typeof(BouclierMagiqueScroll), "Martial - Bouclier magique", 7);
			AddSpell("Sorts", typeof(CommandementScroll), "Martial - Commandement", 8);
			AddSpell("Sorts", typeof(PresenceInspiranteScroll), "Martial - Présence inspir.", 9);
			AddSpell("Sorts", typeof(AngeGardienScroll), "Martial - Ange gardien", 10);

			AddSpell("Sorts", typeof(DiversionScroll), "Musique - Diversion", 1);
			AddSpell("Sorts", typeof(CalmeToiScroll), "Musique - Calme toi!", 2);
			AddSpell("Sorts", typeof(DesorienterScroll), "Musique - Désorienter", 3);
			AddSpell("Sorts", typeof(DefiScroll), "Musique - Defi", 4);
			AddSpell("Sorts", typeof(DecrescendoManiaqueScroll), "Musique - Decrescendo mana.", 5);
			AddSpell("Sorts", typeof(InspirationElementaireScroll), "Musique - Inspiration élément.", 6);
			AddSpell("Sorts", typeof(AbsorbationSonoreScroll), "Musique - Absorba. sonore", 7);
			AddSpell("Sorts", typeof(ParfaiteAspirationScroll), "Musique - Parfaite aspirat.", 8);
			AddSpell("Sorts", typeof(RevelationDiscordanteScroll), "Musique - Révelation discord.", 9);
			AddSpell("Sorts", typeof(HavreDePaixScroll), "Musique - Havre de paix", 10);

			AddSpell("Sorts", typeof(SoifDeSangScroll), "Nécro. - Soif de sang", 1);
			AddSpell("Sorts", typeof(ToucheAbsorbantScroll), "Nécro. - Touché absorbant", 2);
			AddSpell("Sorts", typeof(InfectionScroll), "Nécro. - Infection", 3);
			AddSpell("Sorts", typeof(ArmureOsScroll), "Nécro. - Armure d'os", 4);
			AddSpell("Sorts", typeof(FamilierMorbideScroll), "Nécro. - Familier morbide", 5);
			AddSpell("Sorts", typeof(ReanimationScroll), "Nécro. - Réanimation", 6);
			AddSpell("Sorts", typeof(ConsommationMortelleScroll), "Nécro. - Consommation mortelle", 7);
			AddSpell("Sorts", typeof(AuraVampiriqueScroll), "Nécro. - Aura vampirique", 8);
			AddSpell("Sorts", typeof(AppelDuSangScroll), "Nécro. - Appel du sang", 9);
			AddSpell("Sorts", typeof(PluieDeSangScroll), "Nécro. - Pluie de sang", 10);

			AddSpell("Sorts", typeof(FormeCycloniqueScroll), "Polymorphie - Cyclonique", 1);
			AddSpell("Sorts", typeof(FormeMetalliqueScroll), "Polymorphie - Métallique", 2);
			AddSpell("Sorts", typeof(FormeTerrestreScroll), "Polymorphie - Terrestre", 3);
			AddSpell("Sorts", typeof(FormeEmpoisonneeScroll), "Polymorphie - Empoisonnée", 4);
			AddSpell("Sorts", typeof(FormeGivranteScroll), "Polymorphie - Givrante", 5);
			AddSpell("Sorts", typeof(FormeLiquideScroll), "Polymorphie - Liquide", 6);
			AddSpell("Sorts", typeof(FormeCristallineScroll), "Polymorphie - Cristalline", 7);
			AddSpell("Sorts", typeof(FormeElectrisanteScroll), "Polymorphie - Électrisante", 8);
			AddSpell("Sorts", typeof(FormeEnflammeeScroll), "Polymorphie - Enflammée", 9);
			AddSpell("Sorts", typeof(FormeEnsanglanteeScroll), "Polymorphie - Ensanglantée", 10);

			AddSpell("Sorts", typeof(BouclierDeFeuScroll), "Pyro. - Bouclier de feu", 1);
			AddSpell("Sorts", typeof(BouleDeFeuScroll), "Pyro. - Boule de feu", 2);
			AddSpell("Sorts", typeof(CeleriteScroll), "Pyro. - Célérité", 3);
			AddSpell("Sorts", typeof(SupernovaScroll), "Pyro. - Supernova", 4);
			AddSpell("Sorts", typeof(AuraRechauffanteScroll), "Pyro. - Aura réchauffante", 5);
			AddSpell("Sorts", typeof(FrenesieDouloureuseScroll), "Pyro. - Frénésie douloureuse", 6);
			AddSpell("Sorts", typeof(FolieArdenteScroll), "Pyro. - Folie ardente", 7);
			AddSpell("Sorts", typeof(AuraExaltationScroll), "Pyro. - Aura d'exaltation", 8);
			AddSpell("Sorts", typeof(CageDeFeuScroll), "Pyro. - Cage de feu", 9);
			AddSpell("Sorts", typeof(PassionArdenteScroll), "Pyro. - Passion ardente", 10);

			AddSpell("Sorts", typeof(AdrenalineScroll), "Roubl. - Adrénaline", 1);
			AddSpell("Sorts", typeof(SommeilScroll), "Roubl. - Sommeil", 2);
			AddSpell("Sorts", typeof(LancerPrecisScroll), "Roubl. - Lancer précis", 3);
			AddSpell("Sorts", typeof(CoupArriereScroll), "Roubl. - Coup arrière", 4);
			AddSpell("Sorts", typeof(EvasionScroll), "Roubl. - Évasion", 5);
			AddSpell("Sorts", typeof(AttiranceScroll), "Roubl. - Attirance", 6);
			AddSpell("Sorts", typeof(MainBlesseeScroll), "Roubl. - Main blessée", 7);
			AddSpell("Sorts", typeof(CoupureDesTendonsScroll), "Roubl. - Coupure des tendons", 8);
			AddSpell("Sorts", typeof(GazEndormantScroll), "Roubl. - Gaz endormant", 9);
			AddSpell("Sorts", typeof(CoupMortelScroll), "Roubl. - Coup mortel", 10);

			AddSpell("Sorts", typeof(TotemDeFeuScroll), "Toté. - Totem de feu", 1);
			AddSpell("Sorts", typeof(TotemDeauScroll), "Toté. - Totem d'eau", 2);
			AddSpell("Sorts", typeof(TotemDeTerreScroll), "Toté. - Totem de terre", 3);
			AddSpell("Sorts", typeof(TotemDeVentScroll), "Toté. - Totem de vent", 4);
			AddSpell("Sorts", typeof(AbsorbationScroll), "Toté. - Absorbation", 5);
			AddSpell("Sorts", typeof(LierParEspritScroll), "Toté. - Lier par l'esprit", 6);
			AddSpell("Sorts", typeof(SuperChargeurScroll), "Toté. - Super chargeur", 7);
			AddSpell("Sorts", typeof(MurTotemiqueScroll), "Toté. - Mur totémique", 8);
			AddSpell("Sorts", typeof(AppelSpirituelScroll), "Toté. - Appel spirituel", 9);
			AddSpell("Sorts", typeof(MarcheAsuivreScroll), "Toté. - Marche à suivre", 10);

			index = AddCraft(typeof(NewSpellbook), "Magie/Classes", "Livre de sort", 50.0, 126, typeof(PlainoisLeather), 1044377, 10, 1044378);
			index = AddCraft(typeof(LivreClasseAucune), "Magie/Classes", "Livre d'oubli de classe", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");

			index = AddCraft(typeof(TreasureMap), "Carte aux trésors", "Niveau 1", 50.0, 126, typeof(TreasureMapLevelOnePart), "Morceau de carte niveau 1", 1, "Vous n'avez pas assez de morceau de carte niveau 1");
			index = AddCraft(typeof(TreasureMap), "Carte aux trésors", "Niveau 2", 50.0, 126, typeof(TreasureMapLevelTwoPart), "Morceau de carte niveau 2", 1, "Vous n'avez pas assez de morceau de carte niveau 2");
			index = AddCraft(typeof(TreasureMap), "Carte aux trésors", "Niveau 3", 50.0, 126, typeof(TreasureMapLevelThreePart), "Morceau de carte niveau 3", 1, "Vous n'avez pas assez de morceau de carte niveau 3");
			index = AddCraft(typeof(TreasureMap), "Carte aux trésors", "Niveau 4", 50.0, 126, typeof(TreasureMapLevelFourPart), "Morceau de carte niveau 4", 1, "Vous n'avez pas assez de morceau de carte niveau 4");
			index = AddCraft(typeof(TreasureMap), "Carte aux trésors", "Niveau 5", 50.0, 126, typeof(TreasureMapLevelFivePart), "Morceau de carte niveau 5", 1, "Vous n'avez pas assez de morceau de carte niveau 5");
			index = AddCraft(typeof(TreasureMap), "Carte aux trésors", "Niveau 6", 50.0, 126, typeof(TreasureMapLevelSixPart), "Morceau de carte niveau 6", 1, "Vous n'avez pas assez de morceau de carte niveau 6");
			index = AddCraft(typeof(TreasureMap), "Carte aux trésors", "Niveau 7", 50.0, 126, typeof(TreasureMapLevelSevenPart), "Morceau de carte niveau 7", 1, "Vous n'avez pas assez de morceau de carte niveau 7");

			#region Skills
			index = AddCraft(typeof(LivreSkillsAlchemy), "Livre d'étude (skills)", "Alchemy", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsAnatomy), "Livre d'étude (skills)", "Anatomy", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsAnimalLore), "Livre d'étude (skills)", "AnimalLore", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsAnimalTaming), "Livre d'étude (skills)", "AnimalTaming", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsArchery), "Livre d'étude (skills)", "Archery", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsArmsLore), "Livre d'étude (skills)", "ArmsLore", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsBegging), "Livre d'étude (skills)", "Begging", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsBlacksmith), "Livre d'étude (skills)", "Blacksmith", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsCamping), "Livre d'étude (skills)", "Camping", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsCarpentry), "Livre d'étude (skills)", "Carpentry", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsCartography), "Livre d'étude (skills)", "Cartography", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsCooking), "Livre d'étude (skills)", "Cooking", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsDetectHidden), "Livre d'étude (skills)", "DetectHidden", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsDiscordance), "Livre d'étude (skills)", "Discordance", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsEvalInt), "Livre d'étude (skills)", "EvalInt", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsFencing), "Livre d'étude (skills)", "Fencing", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsFishing), "Livre d'étude (skills)", "Fishing", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsFletching), "Livre d'étude (skills)", "Fletching", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsForensics), "Livre d'étude (skills)", "Forensics", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsHealing), "Livre d'étude (skills)", "Healing", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsHerding), "Livre d'étude (skills)", "Herding", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsHiding), "Livre d'étude (skills)", "Hiding", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsInscribe), "Livre d'étude (skills)", "Inscribe", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsItemID), "Livre d'étude (skills)", "ItemID", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsLockpicking), "Livre d'étude (skills)", "Lockpicking", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsLumberjacking), "Livre d'étude (skills)", "Lumberjacking", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsMacing), "Livre d'étude (skills)", "Macing", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsMagery), "Livre d'étude (skills)", "Magery", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsMagicResist), "Livre d'étude (skills)", "MagicResist", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsMeditation), "Livre d'étude (skills)", "Meditation", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsMining), "Livre d'étude (skills)", "Mining", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsMusicianship), "Livre d'étude (skills)", "Musicianship", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsNecromancy), "Livre d'étude (skills)", "Necromancy", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsParry), "Livre d'étude (skills)", "Parry", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsPeacemaking), "Livre d'étude (skills)", "Peacemaking", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsPoisoning), "Livre d'étude (skills)", "Poisoning", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsProvocation), "Livre d'étude (skills)", "Provocation", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsRemoveTrap), "Livre d'étude (skills)", "Remove Trap", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsSpiritSpeak), "Livre d'étude (skills)", "SpiritSpeak", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsSnooping), "Livre d'étude (skills)", "Snooping", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsStealing), "Livre d'étude (skills)", "Stealing", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsStealth), "Livre d'étude (skills)", "Stealth", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsSwords), "Livre d'étude (skills)", "Swords", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsTactics), "Livre d'étude (skills)", "Tactics", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsTailoring), "Livre d'étude (skills)", "Tailoring", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsTasteID), "Livre d'étude (skills)", "TasteID", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsTinkering), "Livre d'étude (skills)", "Tinkering", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsTracking), "Livre d'étude (skills)", "Tracking", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsVeterinary), "Livre d'étude (skills)", "Veterinary", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsWrestling), "Livre d'étude (skills)", "Wrestling", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			#endregion

			#region Artisans
			index = AddCraft(typeof(LivreClasseEmbouteilleur), "Artisans", "Alchimiste - Embouteilleur", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseAlchimiste), "Artisans", "Alchimiste - Alchimiste", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseApothicaire), "Artisans", "Alchimiste - Apothicaire", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");

			index = AddCraft(typeof(LivreClasseBricoleur), "Artisans", "Bricoleur - Bricoleur", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseIngenieur), "Artisans", "Bricoleur - Ingénieur", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseInventeur), "Artisans", "Bricoleur - Inventeur", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			
			index = AddCraft(typeof(LivreClasseStyliste), "Artisans", "Couturier - Styliste", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseModeleur), "Artisans", "Couturier - Modeleur", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseCouturier), "Artisans", "Couturier - Couturier", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");

			index = AddCraft(typeof(LivreClasseArmurier), "Artisans", "Forgeron - Armurier", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseForgeron), "Artisans", "Forgeron - Forgeron", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseForgefer), "Artisans", "Forgeron - Forgefer", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");

			index = AddCraft(typeof(LivreClasseEleve), "Artisans", "Savant - Élève", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseErudit), "Artisans", "Savant - Érudit", 60.0, 60.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseSage), "Artisans", "Savant - Sage", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			#endregion

			#region Guerriers
			index = AddCraft(typeof(LivreClasseArcher), "Guerriers", "Archer - Archer", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseFrancTireur), "Guerriers", "Archer - Franc tireur", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseMaitreArcher), "Guerriers", "Archer - Maître archer", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");

			index = AddCraft(typeof(LivreClasseEcuyer), "Guerriers", "Chevaucheur - Écuyer", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseJouteur), "Guerriers", "Chevaucheur - Jouteur", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseCavalier), "Guerriers", "Chevaucheur - Cavalier", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");

			index = AddCraft(typeof(LivreClasseCombattant), "Guerriers", "Guerrier - Combattant", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseMirmillon), "Guerriers", "Guerrier - Mirmillon", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseChampion), "Guerriers", "Guerrier - Champion", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");

			index = AddCraft(typeof(LivreClasseDefenseur), "Guerriers", "Protecteur - Défenseur", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseGardien), "Guerriers", "Protecteur - Gardien", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseProtecteur), "Guerriers", "Protecteur - Protecteur", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			#endregion

			#region Mages
			index = AddCraft(typeof(LivreClasseApprenti), "Mages", "Aéromancien - Apprenti", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseEvocateur), "Mages", "Aéromancien - Évocateur", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseAeromancien), "Mages", "Aéromancien - Aéromancien", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			
			index = AddCraft(typeof(LivreClasseNaturaliste), "Mages", "Géomancien - Naturaliste", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseDruide), "Mages", "Géomancien - Druide", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseGeomancien), "Mages", "Géomancien - Géomancien", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");

			index = AddCraft(typeof(LivreClasseIntervenant), "Mages", "Guérisseur - Intervenant", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseSoigneur), "Mages", "Guérisseur - Soigneur", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseGuerisseur), "Mages", "Guérisseur - Guérisseur", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");

			index = AddCraft(typeof(LivreClasseMage), "Mages", "Hydromancien - Mage", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseMagicien), "Mages", "Hydromancien - Magicien", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseHydromancien), "Mages", "Hydromancien - Hydromancien", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			
			index = AddCraft(typeof(LivreClasseThanathauste), "Mages", "Nécromancien - Thanathauste", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseNecromage), "Mages", "Nécromancien - Nécromage", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseNecromancien), "Mages", "Nécromancien - Nécromancien", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");

			index = AddCraft(typeof(LivreClasseIncantateur), "Mages", "Pyromancien - Incantateur", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseSorcier), "Mages", "Pyromancien - Sorcier", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClassePyromancien), "Mages", "Pyromancien - Pyromancien", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");

			index = AddCraft(typeof(LivreClasseInvocateur), "Mages", "Spiritualiste - Invocateur", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseConjurateur), "Mages", "Spiritualiste - Conjurateur", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseSpiritualiste), "Mages", "Spiritualiste - Spiritualiste", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			#endregion

			#region Roublards
			index = AddCraft(typeof(LivreClasseMultiforme), "Roublards", "Changeforme - Multiforme", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseDiversiforme), "Roublards", "Changeforme - Diversiforme", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseChangeforme), "Roublards", "Changeforme - Changeforme", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");

			index = AddCraft(typeof(LivreClasseTroubadour), "Roublards", "Ménestrel - Troubadour", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseBarde), "Roublards", "Ménestrel - Barde", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseMenestrel), "Roublards", "Ménestrel - Ménestrel", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");

			index = AddCraft(typeof(LivreClasseTraqueur), "Roublards", "Rôdeur - Traqueur", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClassePisteur), "Roublards", "Rôdeur - Pisteur", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseRodeur), "Roublards", "Rôdeur - Rôdeur", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");

			index = AddCraft(typeof(LivreClasseVagabond), "Roublards", "Roublard - Vagabond", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseVoleur), "Roublards", "Roublard - Voleur", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseRoublard), "Roublards", "Roublard - Roublard", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			#endregion

			index = AddCraft(typeof(BlankScroll), "Autres", 1023636, 50.0, 100.0, typeof(Kindling), "Kindling", 1, "Vous n'avez pas assez de Petit Bois.");
			index = AddCraft(typeof(Missive), "Autres", "Missive", 15.0, 50.0, typeof(BlankScroll), 1044377, 1, 1044378);

			index = AddCraft(typeof(GargoyleBook100), "Autres", 1113290, 60.0, 100.0, typeof(BlankScroll), 1044377, 40, 1044378);
			AddRes(index, typeof(Beeswax), 1025154, 2, 1053098);

			index = AddCraft(typeof(GargoyleBook200), "Autres", 1113291, 72.0, 100.0, typeof(BlankScroll), 1044377, 40, 1044378);
			AddRes(index, typeof(Beeswax), 1025154, 4, 1053098);

			index = AddCraft(typeof(CarnetAdresse), "Autres", "Carnet d'Adresse", 25.0, 50.0, typeof(BlankScroll), 1044377, 40, 1044378);
			AddRes(index, typeof(Beeswax), 1025154, 4, 1053098);

			index = AddCraft(typeof(Calendrier), "Autres", "Calendrier", 0.0, 25.0, typeof(BlankScroll), 1044377, 20, 1044378);
			index = AddCraft(typeof(GlassblowingBook), "Autres", "Connaissances Verre", 65, 100, typeof(BlankScroll), 1044377, 5, 1044378);
			index = AddCraft(typeof(SandMiningBook), "Autres", "Connaissances Sable", 65, 100, typeof(BlankScroll), 1044377, 5, 1044378);
			index = AddCraft(typeof(StoneMiningBook), "Autres", "Connaissances Granite", 65, 100, typeof(BlankScroll), 1044377, 5, 1044378);
			index = AddCraft(typeof(MasonryBook), "Autres", "Connaissances Pierre", 65, 100, typeof(BlankScroll), 1044377, 5, 1044378);
			index = AddCraft(typeof(GemMiningBook), "Autres", "Connaissances Gems", 65, 100, typeof(BlankScroll), 1044377, 5, 1044378);

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
