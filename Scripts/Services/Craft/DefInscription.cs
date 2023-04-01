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
			AddSpell("Aéromancie", typeof(AveuglementScroll), "Aveuglement", 1);
			AddSpell("Aéromancie", typeof(BrouillardScroll), "Brouillard", 2);
			AddSpell("Aéromancie", typeof(TeleportationScroll), "Téleportation", 3);
			AddSpell("Aéromancie", typeof(TornadoScroll), "Tornado", 4);
			AddSpell("Aéromancie", typeof(AuraEvasiveScroll), "Aura évasive", 5);
			AddSpell("Aéromancie", typeof(ExTeleportationScroll), "Ex-téleportation", 6);
			AddSpell("Aéromancie", typeof(ToucheSuffosantScroll), "Touché suffosant", 7);
			AddSpell("Aéromancie", typeof(AuraDeBrouillardScroll), "Aura de brouillard", 8);
			AddSpell("Aéromancie", typeof(VentFavorableScroll), "Vent favorable", 9);
			AddSpell("Aéromancie", typeof(VortexScroll), "Vortex", 10);

			AddSpell("Chasseur", typeof(AntidoteScroll), "Antidote", 1);
			AddSpell("Chasseur", typeof(MarquerScroll), "Marquer", 2);
			AddSpell("Chasseur", typeof(CompagnonAnimalScroll), "Compagnon animal", 3);
			AddSpell("Chasseur", typeof(SoinAnimalierScroll), "Soin animalier", 4);
			AddSpell("Chasseur", typeof(RugissementScroll), "Rugissement", 5);
			AddSpell("Chasseur", typeof(FrappeEnsanglanteeScroll), "Frappe ensanglantee", 6);
			AddSpell("Chasseur", typeof(SautAggressifScroll), "Saut aggressif", 7);
			AddSpell("Chasseur", typeof(CoupDansLeGenouScroll), "Coup dans le genou", 8);
			AddSpell("Chasseur", typeof(ChasseurDePrimeScroll), "Chasseur de prime", 9);
			AddSpell("Chasseur", typeof(ContratResoluScroll), "Contrat résolu", 10);

			AddSpell("Défenseur", typeof(CoupDeBouclierScroll), "Coup de bouclier", 1);
			AddSpell("Défenseur", typeof(BravadeScroll), "Bravade", 2);
			AddSpell("Défenseur", typeof(DevotionScroll), "Dévotion", 3);
			AddSpell("Défenseur", typeof(MutinerieScroll), "Mutinerie", 4);
			AddSpell("Défenseur", typeof(MentorScroll), "Mentor", 5);
			AddSpell("Défenseur", typeof(LienDeVieScroll), "Lien de vie", 6);
			AddSpell("Défenseur", typeof(MiracleScroll), "Miracle", 7);
			AddSpell("Défenseur", typeof(IndomptableScroll), "Indomptable", 8);
			AddSpell("Défenseur", typeof(InsensibleScroll), "Insensible", 9);
			AddSpell("Défenseur", typeof(PiedsAuSolScroll), "Pieds su sol", 10);

			AddSpell("Géomancie", typeof(FortifieScroll), "Fortifié", 1);
			AddSpell("Géomancie", typeof(RocheScroll), "Roche", 2);
			AddSpell("Géomancie", typeof(ContaminationScroll), "Contamination", 3);
			AddSpell("Géomancie", typeof(EmpalementScroll), "Empalement", 4);
			AddSpell("Géomancie", typeof(AuraFortifianteScroll), "Aura fortifiante", 5);
			AddSpell("Géomancie", typeof(MurDePlanteScroll), "Mur de plante", 6);
			AddSpell("Géomancie", typeof(ExplosionDeRocheScroll), "Explosion de roche", 7);
			AddSpell("Géomancie", typeof(AuraPreservationManiaqueScroll), "Aura préservation maniaque", 8);
			AddSpell("Géomancie", typeof(RacinesScroll), "Racines", 9);
			AddSpell("Géomancie", typeof(FleauTerrestreScroll), "Fléau terrestre", 10);

			AddSpell("Guérison", typeof(MainCicatrisanteScroll), "Main cicatrisante", 1);
			AddSpell("Guérison", typeof(RemedeScroll), "Remède", 2);
			AddSpell("Guérison", typeof(MurDePierreScroll), "Mur de pierre", 3);
			AddSpell("Guérison", typeof(RayonCelesteScroll), "Rayon céleste", 4);
			AddSpell("Guérison", typeof(LumiereSacreeScroll), "Lumière sacrée", 5);
			AddSpell("Guérison", typeof(FrayeurScroll), "Frayeur", 6);
			AddSpell("Guérison", typeof(FerveurDivineScroll), "Ferveur divine", 7);
			AddSpell("Guérison", typeof(InquisitionScroll), "Inquisition", 8);
			AddSpell("Guérison", typeof(MurDeLumiereScroll), "Mur de lumière", 9);
			AddSpell("Guérison", typeof(DonDeLaVieScroll), "Don de la vie", 10);

			AddSpell("Hydromancie", typeof(ArmureDeGlaceScroll), "Armure de glace", 1);
			AddSpell("Hydromancie", typeof(RestaurationScroll), "Restauration", 2);
			AddSpell("Hydromancie", typeof(SoinPreventifScroll), "Soin préventif", 3);
			AddSpell("Hydromancie", typeof(CageDeGlaceScroll), "Cage de glace", 4);
			AddSpell("Hydromancie", typeof(AuraCryogeniseeScroll), "Aura cryogenisée", 5);
			AddSpell("Hydromancie", typeof(PieuxDeGlaceScroll), "Pieux de glace", 6);
			AddSpell("Hydromancie", typeof(CerveauGeleScroll), "Cerveau gelé", 7);
			AddSpell("Hydromancie", typeof(AuraRefrigeranteScroll), "Aura réfrigerante", 8);
			AddSpell("Hydromancie", typeof(AvatarDuFroidScroll), "Avatar de froid", 9);
			AddSpell("Hydromancie", typeof(BlizzardScroll), "Blizzard", 10);

			AddSpell("Martial", typeof(SecondSouffleScroll), "Second souffle", 1);
			AddSpell("Martial", typeof(ProvocationScroll), "Provocation", 2);
			AddSpell("Martial", typeof(SautDevastateurScroll), "Saut dévastateur", 3);
			AddSpell("Martial", typeof(DuelScroll), "Duel", 4);
			AddSpell("Martial", typeof(ChargeFurieuseScroll), "Charge furieuse", 5);
			AddSpell("Martial", typeof(EnrageScroll), "Enragé", 6);
			AddSpell("Martial", typeof(BouclierMagiqueScroll), "Bouclier magique", 7);
			AddSpell("Martial", typeof(CommandementScroll), "Commandement", 8);
			AddSpell("Martial", typeof(PresenceInspiranteScroll), "Présence inspirante", 9);
			AddSpell("Martial", typeof(AngeGardienScroll), "Ange gardien", 10);

			AddSpell("Musique", typeof(DiversionScroll), "Diversion", 1);
			AddSpell("Musique", typeof(CalmeToiScroll), "Calme toi!", 2);
			AddSpell("Musique", typeof(DesorienterScroll), "Désorienter", 3);
			AddSpell("Musique", typeof(DefiScroll), "Defi", 4);
			AddSpell("Musique", typeof(DecrescendoManiaqueScroll), "Decrescendo maniaque", 5);
			AddSpell("Musique", typeof(InspirationElementaireScroll), "Inspiration élémentaire", 6);
			AddSpell("Musique", typeof(AbsorbationSonoreScroll), "Absorbation sonore", 7);
			AddSpell("Musique", typeof(ParfaiteAspirationScroll), "Parfaite aspiration", 8);
			AddSpell("Musique", typeof(RevelationDiscordanteScroll), "Révelation discordante", 9);
			AddSpell("Musique", typeof(HavreDePaixScroll), "Havre de paix", 10);

			AddSpell("Nécromancie", typeof(SoifDeSangScroll), "Soif de sang", 1);
			AddSpell("Nécromancie", typeof(ToucheAbsorbantScroll), "Touché absorbant", 2);
			AddSpell("Nécromancie", typeof(InfectionScroll), "Infection", 3);
			AddSpell("Nécromancie", typeof(ArmureOsScroll), "Armure d'os", 4);
			AddSpell("Nécromancie", typeof(FamilierMorbideScroll), "Familier morbide", 5);
			AddSpell("Nécromancie", typeof(ReanimationScroll), "Réanimation", 6);
			AddSpell("Nécromancie", typeof(ConsommationMortelleScroll), "Consommation mortelle", 7);
			AddSpell("Nécromancie", typeof(AuraVampiriqueScroll), "Aura vampirique", 8);
			AddSpell("Nécromancie", typeof(AppelDuSangScroll), "Appel du sang", 9);
			AddSpell("Nécromancie", typeof(PluieDeSangScroll), "Pluie de sang", 10);

			AddSpell("Polymorphie", typeof(FormeCycloniqueScroll), "Forme cyclonique", 1);
			AddSpell("Polymorphie", typeof(FormeMetalliqueScroll), "Forme métallique", 2);
			AddSpell("Polymorphie", typeof(FormeTerrestreScroll), "Forme terrestre", 3);
			AddSpell("Polymorphie", typeof(FormeEmpoisonneeScroll), "Forme empoisonnée", 4);
			AddSpell("Polymorphie", typeof(FormeGivranteScroll), "Forme givrante", 5);
			AddSpell("Polymorphie", typeof(FormeLiquideScroll), "Forme liquide", 6);
			AddSpell("Polymorphie", typeof(FormeCristallineScroll), "Forme cristalline", 7);
			AddSpell("Polymorphie", typeof(FormeElectrisanteScroll), "Forme électrisante", 8);
			AddSpell("Polymorphie", typeof(FormeEnflammeeScroll), "Forme enflammée", 9);
			AddSpell("Polymorphie", typeof(FormeEnsanglanteeScroll), "Forme ensanglantée", 10);

			AddSpell("Pyromancie", typeof(BouclierDeFeuScroll), "Bouclier de feu", 1);
			AddSpell("Pyromancie", typeof(BouleDeFeuScroll), "Boule de feu", 2);
			AddSpell("Pyromancie", typeof(CeleriteScroll), "Célérité", 3);
			AddSpell("Pyromancie", typeof(SupernovaScroll), "Supernova", 4);
			AddSpell("Pyromancie", typeof(AuraRechauffanteScroll), "Aura réchauffante", 5);
			AddSpell("Pyromancie", typeof(FrenesieDouloureuseScroll), "Frénésie douloureuse", 6);
			AddSpell("Pyromancie", typeof(FolieArdenteScroll), "Folie ardente", 7);
			AddSpell("Pyromancie", typeof(AuraExaltationScroll), "Aura d'exaltation", 8);
			AddSpell("Pyromancie", typeof(CageDeFeuScroll), "Cage de feu", 9);
			AddSpell("Pyromancie", typeof(PassionArdenteScroll), "Passion ardente", 10);

			AddSpell("Roublardise", typeof(AdrenalineScroll), "Adrénaline", 1);
			AddSpell("Roublardise", typeof(SommeilScroll), "Sommeil", 2);
			AddSpell("Roublardise", typeof(LancerPrecisScroll), "Lancer précis", 3);
			AddSpell("Roublardise", typeof(CoupArriereScroll), "Coup arrière", 4);
			AddSpell("Roublardise", typeof(EvasionScroll), "Évasion", 5);
			AddSpell("Roublardise", typeof(AttiranceScroll), "Attirance", 6);
			AddSpell("Roublardise", typeof(MainBlesseeScroll), "Main blessée", 7);
			AddSpell("Roublardise", typeof(CoupureDesTendonsScroll), "Coupure des tendons", 8);
			AddSpell("Roublardise", typeof(GazEndormantScroll), "Gaz endormant", 9);
			AddSpell("Roublardise", typeof(CoupMortelScroll), "Coup mortel", 10);

			AddSpell("Totémique", typeof(TotemDeFeuScroll), "Totem de feu", 1);
			AddSpell("Totémique", typeof(TotemDeauScroll), "Totem d'eau", 2);
			AddSpell("Totémique", typeof(TotemDeTerreScroll), "Totem de terre", 3);
			AddSpell("Totémique", typeof(TotemDeVentScroll), "Totem de vent", 4);
			AddSpell("Totémique", typeof(AbsorbationScroll), "Absorbation", 5);
			AddSpell("Totémique", typeof(LierParEspritScroll), "Lier par l'esprit", 6);
			AddSpell("Totémique", typeof(SuperChargeurScroll), "Super chargeur", 7);
			AddSpell("Totémique", typeof(MurTotemiqueScroll), "Mur totémique", 8);
			AddSpell("Totémique", typeof(AppelSpirituelScroll), "Appel spirituel", 9);
			AddSpell("Totémique", typeof(MarcheAsuivreScroll), "Marche à suivre", 10);

			//index = AddCraft(typeof(Runebook), "Magie", 1041267, 45.0, 95.0, typeof(BlankScroll), 1044377, 8, 1044378);
			//AddRes(index, typeof(RecallScroll), 1044445, 1, 1044253);
			//AddRes(index, typeof(GateTravelScroll), 1044446, 1, 1044253);

			//index = AddCraft(typeof(BulkOrders.BulkOrderBook), "Autres", 1028793, 65.0, 115.0, typeof(BlankScroll), 1044377, 10, 1044378);

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
			index = AddCraft(typeof(LivreSkillsBegging), "Livre d'étude (skills)", "Begging", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsBlacksmith), "Livre d'étude (skills)", "Blacksmith", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsCamping), "Livre d'étude (skills)", "Camping", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsCarpentry), "Livre d'étude (skills)", "Carpentry", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsCartography), "Livre d'étude (skills)", "Cartography", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsCooking), "Livre d'étude (skills)", "Cooking", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsDetectHidden), "Livre d'étude (skills)", "DetectHidden", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsDiscordance), "Livre d'étude (skills)", "Discordance", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsEvalInt), "Livre d'étude (skills)", "EvalInt", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsFencing), "Livre d'étude (skills)", "Fencing", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsFishing), "Livre d'étude (skills)", "Fishing", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsFletching), "Livre d'étude (skills)", "Fletching", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsForensics), "Livre d'étude (skills)", "Forensics", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsHealing), "Livre d'étude (skills)", "Healing", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsHerding), "Livre d'étude (skills)", "Herding", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsHiding), "Livre d'étude (skills)", "Hiding", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsInscribe), "Livre d'étude (skills)", "Inscribe", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsItemID), "Livre d'étude (skills)", "ItemID", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsLockpicking), "Livre d'étude (skills)", "Lockpicking", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsMacing), "Livre d'étude (skills)", "Macing", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsMagery), "Livre d'étude (skills)", "Magery", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsMagicResist), "Livre d'étude (skills)", "MagicResist", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsMeditation), "Livre d'étude (skills)", "Meditation", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsMining), "Livre d'étude (skills)", "Mining", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsMusicianship), "Livre d'étude (skills)", "Musicianship", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsParry), "Livre d'étude (skills)", "Parry", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsPeacemaking), "Livre d'étude (skills)", "Peacemaking", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsPoisoning), "Livre d'étude (skills)", "Poisoning", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsProvocation), "Livre d'étude (skills)", "Provocation", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsRemoveTrap), "Livre d'étude (skills)", "Remove Trap", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsSpiritSpeak), "Livre d'étude (skills)", "SpiritSpeak", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsSnooping), "Livre d'étude (skills)", "Snooping", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsStealing), "Livre d'étude (skills)", "Stealing", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsEquitation), "Livre d'étude (skills)", "Equitation", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsSwords), "Livre d'étude (skills)", "Swords", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsTactics), "Livre d'étude (skills)", "Tactics", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsTailoring), "Livre d'étude (skills)", "Tailoring", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsTasteID), "Livre d'étude (skills)", "TasteID", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsTinkering), "Livre d'étude (skills)", "Tinkering", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsTracking), "Livre d'étude (skills)", "Tracking", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			//index = AddCraft(typeof(LivreSkillsVeterinary), "Livre d'étude (skills)", "Veterinary", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsWrestling), "Livre d'étude (skills)", "Wrestling", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreSkillsLumberjacking), "Livre d'étude (skills)", "Lumberjacking", 0.0, 0.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
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

			index = AddCraft(typeof(LivreClasseMultiforme), "Mages", "Changeforme - Multiforme", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseDiversiforme), "Mages", "Changeforme - Diversiforme", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseChangeforme), "Mages", "Changeforme - Changeforme", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");

			index = AddCraft(typeof(LivreClasseNaturaliste), "Mages", "Géomancien - Naturaliste", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseDruide), "Mages", "Géomancien - Druide", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseGeomancien), "Mages", "Géomancien - Géomancien", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");

			index = AddCraft(typeof(LivreClasseMage), "Mages", "Hydromancien - Mage", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseMagicien), "Mages", "Hydromancien - Magicien", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseHydromancien), "Mages", "Hydromancien - Hydromancien", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");

			index = AddCraft(typeof(LivreClasseTroubadour), "Mages", "Ménestrel - Troubadour", 50.0, 50.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseBarde), "Mages", "Ménestrel - Barde", 70.0, 70.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");
			index = AddCraft(typeof(LivreClasseMenestrel), "Mages", "Ménestrel - Ménestrel", 90.0, 90.0, typeof(LivreVierge), "Livre vierge", 1, "Vous n'avez pas de livre vierge.");

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
			SetSubRes(typeof(PlainoisLeather), 1049150);

			// Add every material you want the player to be able to choose from
			// This will override the overridable material
			AddSubRes(typeof(PlainoisLeather), "Cuir", 0.0, 1049312);
			AddSubRes(typeof(ForestierLeather), "Lupus", 65.0, 1049312);
			AddSubRes(typeof(DesertiqueLeather), "Reptilien", 70.0, 1049312);
			AddSubRes(typeof(CollinoisLeather), "Geant", 75.0, 1049312);
			AddSubRes(typeof(SavanoisLeather), "Ophidien", 80.0, 1049312);
			AddSubRes(typeof(ToundroisLeather), "Arachnide", 85.0, 1049312);
			AddSubRes(typeof(TropicauxLeather), "Dragonique", 90.0, 1049312);
			AddSubRes(typeof(MontagnardLeather), "Demoniaque", 95.0, 1049312);
			AddSubRes(typeof(AncienLeather), "Ancien", 99.0, 1049312);

			MarkOption = true;
			Repair = true;
			CanEnhance = true;
			CanAlter = true;
		}
	}
}
