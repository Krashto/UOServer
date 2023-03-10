using Server.Items;
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
            typeof( Bone ),
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

		private void AddSpell(Type type, string name, int level)
		{
			double minSkill, maxSkill;

			switch (level)
			{
				default:
				case 1: minSkill = 30; maxSkill = 50; break;
				case 2: minSkill = 40; maxSkill = 60; break;
				case 3: minSkill = 50; maxSkill = 75; break;
				case 4: minSkill = 60; maxSkill = 90; break;
				case 5: minSkill = 70; maxSkill = 100; break;
				case 6: minSkill = 80; maxSkill = 110.0; break;
			}

			index = AddCraft(type, GetCircle(level), name, minSkill, maxSkill, typeof(BlankScroll), "Blank scroll", 1, "You do not have enough blank scrolls to make that.");
		}

		private string GetCircle(int circle)
		{
			if (circle >= 0 && circle <= 7)
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
			};

		public override void InitCraftList()
        {
			AddSpell(typeof(NourritureScroll), "Nourriture", 1);
			AddSpell(typeof(VisionDeNuitScroll), "Vision de Nuit", 2);
			AddSpell(typeof(FlecheMagiqueScroll), "Flèche magique", 3);
			AddSpell(typeof(BlessureScroll), "Blessure", 4);
			AddSpell(typeof(ForceScroll), "Force", 1);
			AddSpell(typeof(AgiliteScroll), "Agilité", 1);
			AddSpell(typeof(FaiblesseScroll), "Faiblesse", 2);
			AddSpell(typeof(MaladresseScroll), "Maladresse", 2);
			AddSpell(typeof(IntelligenceScroll), "Intelligence", 3);
			AddSpell(typeof(StupiditeScroll), "Stupidité", 3);
			AddSpell(typeof(BenedictionScroll), "Bénédiction", 4);
			AddSpell(typeof(MurDeHaieScroll), "Mur de haie", 1);
			AddSpell(typeof(MurDePierreScroll), "Mur de pierre", 2);
			AddSpell(typeof(GeyserScroll), "Geyser", 3);
			AddSpell(typeof(MurDeFeuScroll), "Mur de feu", 4);
			AddSpell(typeof(RevelationScroll), "Révélation", 1);
			AddSpell(typeof(DissipationScroll), "Dissipation", 2);
			AddSpell(typeof(DissipationDeMurScroll), "Dissipation de mur", 3);
			AddSpell(typeof(DissipationDeMasseScroll), "Dissipation de masse", 4);
			AddSpell(typeof(AntidoteScroll), "Antidote", 1);
			AddSpell(typeof(GuerisonScroll), "Guérison", 2);
			AddSpell(typeof(AntidoteDeMasseScroll), "Antidote de masse", 3);
			AddSpell(typeof(NResurrectionScroll), "Resurrection", 4);
			AddSpell(typeof(ProtectScroll), "Protection", 1);
			AddSpell(typeof(ReflectionScroll), "Réflection", 2);
			AddSpell(typeof(SecoursScroll), "Secours", 3);
			AddSpell(typeof(CopieScroll), "Copie", 4);
			AddSpell(typeof(CriDOursScroll), "Cris d'ours", 1);
			AddSpell(typeof(AbeillesScroll), "Abeilles", 2);
			AddSpell(typeof(EpinesScroll), "Épines", 3);
			AddSpell(typeof(RacinesScroll), "Racines", 4);
			AddSpell(typeof(BouleDeFeuScroll), "Boule de feu", 1);
			AddSpell(typeof(EclairScroll), "Éclair", 2);
			AddSpell(typeof(BouleDeGlaceScroll), "Boule de glace", 3);
			AddSpell(typeof(BouleDEnergieScroll), "Boule d'énergie", 4);
			AddSpell(typeof(TremblementsScroll), "Tremblements", 1);
			AddSpell(typeof(ExplosionsScroll), "Explosions", 2);
			AddSpell(typeof(SeismeScroll), "Séisme", 3);
			AddSpell(typeof(EclairEnChaineScroll), "Éclair en chaîne", 4);
			AddSpell(typeof(CreatureScroll), "Créature", 1);
			AddSpell(typeof(ElementaireTerreScroll), "Élémentaire de terre", 2);
			AddSpell(typeof(ElementaireAirScroll), "Élémentaire d'air", 3);
			AddSpell(typeof(ElementaireFeuScroll), "Élémentaire de feu", 4);
			AddSpell(typeof(EspritAnimalScroll), "Esprit animal", 1);
			AddSpell(typeof(EspritDeLamesScroll), "Esprit de lames", 2);
			AddSpell(typeof(EspritDEnergieScroll), "Esprit d'énergie", 3);
			AddSpell(typeof(DragonScroll), "Dragon", 4);
			AddSpell(typeof(PourritureDEspritScroll), "Pourriture d'esprit", 1);
			AddSpell(typeof(DrainDeManaScroll), "Drain de mana", 2);
			AddSpell(typeof(MalaiseScroll), "Malaise", 3);
			AddSpell(typeof(SouffleDEspritScroll), "Souffle d'esprit", 4);
			AddSpell(typeof(EnduranceScroll), "Endurance", 1);
			AddSpell(typeof(TeleportationScroll), "Téléportation", 2);
			AddSpell(typeof(RappelScroll), "Rappel", 3);
			AddSpell(typeof(EvasionScroll), "Évasion", 4);
			AddSpell(typeof(PiegeScroll), "Piège", 1);
			AddSpell(typeof(DesamorcageScroll), "Désamorçage", 1);
			AddSpell(typeof(SerrureScroll), "Serrure", 2);
			AddSpell(typeof(CrochetageScroll), "Crochetage", 2);
			AddSpell(typeof(NIncognitoScroll), "Incognito", 3);
			AddSpell(typeof(InvisibiliteScroll), "Invisibilité", 4);
			AddSpell(typeof(AlterationScroll), "Alteration", 1);
			AddSpell(typeof(SubterfugeScroll), "Subterguge", 2);
			AddSpell(typeof(ChimereScroll), "Chimere", 3);
			AddSpell(typeof(TransmutationScroll), "Transmutation", 4);
			AddSpell(typeof(CalamiteScroll), "Calamité", 1);
			AddSpell(typeof(PeauDeMortScroll), "Peau de mort", 2);
			AddSpell(typeof(MauvaisPresageScroll), "Mauvais présage", 3);
			AddSpell(typeof(LanceOsScroll), "Lance d'os", 4);
			AddSpell(typeof(FamilierScroll), "Familier", 1);
			AddSpell(typeof(DefraicheurScroll), "Défraîcheur", 2);
			AddSpell(typeof(StrangulaireScroll), "Strangulaire", 3);
			AddSpell(typeof(ReanimationScroll), "Réanimation", 4);
			AddSpell(typeof(PoisonMineurScroll), "Poison mineur", 1);
			AddSpell(typeof(NPoisonScroll), "Poison", 2);
			AddSpell(typeof(JetDePoisonScroll), "Jet de poison", 3);
			AddSpell(typeof(MurDePoisonScroll), "Mur de poison", 4);

			AddSpell(typeof(VisionDivineScroll), "Vision divine", 1);
			AddSpell(typeof(PoingDeValeurScroll), "Poing de valeur", 2);
			AddSpell(typeof(EssouflementScroll), "Essouflement", 3);
			AddSpell(typeof(LumiereDivineScroll), "Lumière divine", 4);
			AddSpell(typeof(RetablissementScroll), "Rétablissement", 1);
			AddSpell(typeof(RegenerationScroll), "Régénération", 2);
			AddSpell(typeof(BouclierScroll), "Bouclier", 3);
			AddSpell(typeof(AmuletteScroll), "Amulette", 4);
			AddSpell(typeof(RepartitionScroll), "Répartition", 1);
			AddSpell(typeof(RenouvellementScroll), "Renouvellement", 2);
			AddSpell(typeof(PurificationScroll), "Purification", 3);
			AddSpell(typeof(PromptitudeScroll), "Promptitude", 4);
			AddSpell(typeof(HautePrecisionScroll), "Haute précision", 1);
			AddSpell(typeof(AgglomerationScroll), "Agglomération", 2);
			AddSpell(typeof(RudesseScroll), "Rudesse", 3);
			AddSpell(typeof(ConsecrationScroll), "Consécration", 4);
			AddSpell(typeof(FamineScroll), "Famine", 1);
			AddSpell(typeof(ErranceScroll), "Errance", 2);
			AddSpell(typeof(BetesScroll), "Bêtes", 3);
			AddSpell(typeof(HypnoseScroll), "Hypnose", 4);
			AddSpell(typeof(PiedAncreScroll), "Pied ancré", 1);
			AddSpell(typeof(RobustesseScroll), "Robustesse", 2);
			AddSpell(typeof(SouplesseScroll), "Souplesse", 3);
			AddSpell(typeof(CorpsPurScroll), "Corps pur", 4);
			AddSpell(typeof(ConscienceScroll), "Conscience", 1);
			AddSpell(typeof(AppelDeLaNatureScroll), "Appel de la nature", 2);
			AddSpell(typeof(AnimauxScroll), "Animaux", 3);
			AddSpell(typeof(InstinctCharnelScroll), "Instinct charnel", 4);
			AddSpell(typeof(PlumeScroll), "Plume", 1);
			AddSpell(typeof(IntrinsequeScroll), "Intrinsèque", 2);
			AddSpell(typeof(VoileScroll), "Voile", 3);
			AddSpell(typeof(EchoScroll), "Écho", 4);
			AddSpell(typeof(AuraDeFatigueScroll), "Aura de fatigue", 1);
			AddSpell(typeof(MortificationScroll), "Mortification", 2);
			AddSpell(typeof(ExecrationScroll), "Exécration", 3);
			AddSpell(typeof(HalenePutrideScroll), "Halène putride", 4);
			AddSpell(typeof(CourageScroll), "Courage", 1);
			AddSpell(typeof(SagesseScroll), "Sagesse", 2);
			AddSpell(typeof(BerseckScroll), "Berseck", 3);
			AddSpell(typeof(TranscendanceScroll), "Transcendance", 4);
			AddSpell(typeof(SauvegardeScroll), "Sauvegarde", 1);
			AddSpell(typeof(ExaltationScroll), "Exaltation", 2);
			AddSpell(typeof(LabyrintheScroll), "Labyrinthe", 3);
			AddSpell(typeof(VisionReelleScroll), "Vision réelle", 4);
			AddSpell(typeof(TalismanScroll), "Talisman", 1);
			AddSpell(typeof(BarilDeBiereScroll), "Baril de bière", 2);
			AddSpell(typeof(PointDeParesseScroll), "Point de paresse", 3);
			AddSpell(typeof(SoutienScroll), "Soutien", 4);

			AddSpell(typeof(PieuxDeTerreScroll), "Pieux de terre", 5);
			AddSpell(typeof(TelekinesieScroll), "Télékinésie", 6);
			AddSpell(typeof(MaledictionScroll), "Malédiction", 5);
			AddSpell(typeof(ReversScroll), "Revers", 6);
			AddSpell(typeof(MurDEnergieScroll), "Mur d'énergie", 5);
			AddSpell(typeof(MurDeParalysieScroll), "Mur de paralysie", 6);
			AddSpell(typeof(ArmureMagiqueScroll), "Armure magique", 5);
			AddSpell(typeof(DerobadeScroll), "Derobade", 6);
			AddSpell(typeof(ZoneDeGuerisonScroll), "Zone de guérison", 6);
			AddSpell(typeof(GuerisonMajeureScroll), "Guérison majeure", 5);
			AddSpell(typeof(ChampDeStaseScroll), "Champ de stase", 5);
			AddSpell(typeof(ArmureScroll), "Armure", 6);
			AddSpell(typeof(PluieAcideScroll), "Pluie acide", 5);
			AddSpell(typeof(PinceeAcideScroll), "Pincée acide", 6);
			AddSpell(typeof(ArmurePierreScroll), "Armure de pierre", 5);
			AddSpell(typeof(JetDEpinesScroll), "Jet d'épines", 6);
			AddSpell(typeof(JetDeFeuScroll), "Jet de feu", 5);
			AddSpell(typeof(FulgurationScroll), "Fulguration", 6);
			AddSpell(typeof(MeteoresScroll), "Météores", 5);
			AddSpell(typeof(VortexScroll), "Vortex", 6);
			AddSpell(typeof(ElementaireEauScroll), "Élémentaire d'eau", 5);
			AddSpell(typeof(ElementaireCristalScroll), "Élémentaire de cristal", 6);
			AddSpell(typeof(DemonScroll), "Démon", 5);
			AddSpell(typeof(EspritVengeurScroll), "Esprit vengeur", 6);
			AddSpell(typeof(DrainVampiriqueScroll), "Drain vampirique", 5);
			AddSpell(typeof(EtouffementsScroll), "Étouffements", 6);
			AddSpell(typeof(TrouDeVerScroll), "Trou de ver", 5);
			AddSpell(typeof(MarquageScroll), "Marquage", 6);
			AddSpell(typeof(HallucinationsScroll), "Hallucinations", 5);
			AddSpell(typeof(DisparitionScroll), "Disparition", 6);
			AddSpell(typeof(MetamorphoseScroll), "Métamorphose", 5);
			AddSpell(typeof(MutationScroll), "Mutation", 6);
			AddSpell(typeof(SermentDeSangScroll), "Serment de sang", 5);
			AddSpell(typeof(JetDeDouleurScroll), "Jet de douleur", 6);
			AddSpell(typeof(AppelDeLaLicheScroll), "Appel de la liche", 5);
			AddSpell(typeof(InsurectionScroll), "Insurection", 6);

			AddSpell(typeof(GriffesScroll), "Griffes", 5);
			AddSpell(typeof(ImbroglioScroll), "Imbroglio", 6);
			AddSpell(typeof(RefecteurScroll), "Réfecteur", 5);
			AddSpell(typeof(MiracleScroll), "Miracle", 6);
			AddSpell(typeof(PassionScroll), "Passion", 5);
			AddSpell(typeof(RegenerescenceScroll), "Régénérescence", 6);
			AddSpell(typeof(ConfessionScroll), "Confession", 5);
			AddSpell(typeof(ForceDeLaFoiScroll), "Force de la foi", 6);
			AddSpell(typeof(FetichismeScroll), "Fétichisme", 5);
			AddSpell(typeof(VoodooScroll), "Voodoo", 6);
			AddSpell(typeof(EternelleJeunesseScroll), "Éternelle jeunesse", 5);
			AddSpell(typeof(ProuesseScroll), "Prouesse", 6);
			AddSpell(typeof(TransfertScroll), "Transfert", 5);
			AddSpell(typeof(DominationScroll), "Domination", 6);
			AddSpell(typeof(StupefactionScroll), "Stupéfaction", 5);
			AddSpell(typeof(DecheanceScroll), "Déchéance", 6);
			AddSpell(typeof(HorreurScroll), "Horreur", 5);
			AddSpell(typeof(PourrissementScroll), "Pourrissement", 6);
			AddSpell(typeof(SpiritualiteScroll), "Spiritualité", 5);
			AddSpell(typeof(SoifDuCombatScroll), "Soif du combat", 6);
			AddSpell(typeof(AppuiScroll), "Appui", 5);
			AddSpell(typeof(PatronageScroll), "Patronage", 6);
			AddSpell(typeof(DonDesRochersScroll), "Don des rochers", 5);
			AddSpell(typeof(CouvertureScroll), "Couverture", 6);

			index = AddCraft(typeof(Runebook), "Magie", 1041267, 45.0, 95.0, typeof(BlankScroll), 1044377, 8, 1044378);
			AddRes(index, typeof(RecallScroll), 1044445, 1, 1044253);
			AddRes(index, typeof(GateTravelScroll), 1044446, 1, 1044253);

			//index = AddCraft(typeof(BulkOrders.BulkOrderBook), "Autres", 1028793, 65.0, 115.0, typeof(BlankScroll), 1044377, 10, 1044378);

			index = AddCraft(typeof(NewSpellbook), "Magie", "Livre de sort", 50.0, 126, typeof(Leather), 1044377, 10, 1044378);

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
			SetSubRes(typeof(Leather), 1049150);

			// Add every material you want the player to be able to choose from
			// This will override the overridable material
			AddSubRes(typeof(Leather), "Cuir", 0.0, 1049312);
			AddSubRes(typeof(LupusLeather), "Lupus", 65.0, 1049312);
			AddSubRes(typeof(ReptilienLeather), "Reptilien", 70.0, 1049312);
			AddSubRes(typeof(GeantLeather), "Geant", 75.0, 1049312);
			AddSubRes(typeof(OphidienLeather), "Ophidien", 80.0, 1049312);
			AddSubRes(typeof(ArachnideLeather), "Arachnide", 85.0, 1049312);
			AddSubRes(typeof(DragoniqueLeather), "Dragonique", 90.0, 1049312);
			AddSubRes(typeof(DemoniaqueLeather), "Demoniaque", 95.0, 1049312);
			AddSubRes(typeof(AncienLeather), "Ancien", 99.0, 1049312);

			MarkOption = true;
			Repair = true;
			CanEnhance = true;
			CanAlter = true;
		}
    }
}
