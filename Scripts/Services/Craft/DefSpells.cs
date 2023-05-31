using Server.Items;
using System;

namespace Server.Engines.Craft
{
	public class DefSpells : CraftSystem
	{
		public override SkillName MainSkill => SkillName.Inscribe;

		// public override int GumpTitleNumber => 1044001;

		public override string GumpTitleString => "Compétences";


		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if (m_CraftSystem == null)
					m_CraftSystem = new DefSpells();

				return m_CraftSystem;
			}
		}

		public override double GetChanceAtMin(CraftItem item)
		{
			return 0.0; // 0%
		}

		private DefSpells()
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

		private int index;

		private void AddSpell(string aptitude, Type type, string name, int level)
		{
			double minSkill, maxSkill;

			switch (level)
			{
				default:
				case 1: minSkill = 00.0; maxSkill = 40.0; break;
				case 2: minSkill = 10.0; maxSkill = 50.0; break;
				case 3: minSkill = 20.0; maxSkill = 60.0; break;
				case 4: minSkill = 30.0; maxSkill = 70.0; break;
				case 5: minSkill = 40.0; maxSkill = 80.0; break;
				case 6: minSkill = 50.0; maxSkill = 90.0; break;
				case 7: minSkill = 60.0; maxSkill = 100.0; break;
				case 8: minSkill = 70.0; maxSkill = 100.0; break;
				case 9: minSkill = 80.0; maxSkill = 110.0; break;
				case 10: minSkill = 90.0; maxSkill = 120.0; break;
			}

			index = AddCraft(type, aptitude, name, minSkill, maxSkill, typeof(BlankScroll), "Blank scroll", 1, "You do not have enough blank scrolls to make that.");
		}

		public override void InitCraftList()
        {
			index = AddCraft(typeof(NewSpellbook), "Magie", "Grimoire", 35.0, 75.0, typeof(PlainoisLeather), "Cuir", 10, "Vous n'avez pas assez de cuir.");
			index = AddCraft(typeof(BlankScroll), "Magie", "Parchemin Vierge", 10.0, 30.0, typeof(Kindling), "Kindling", 3, "Vous n'avez pas assez de Petit Bois.");

			AddSpell("Aéromancie", typeof(AveuglementScroll), "Aveuglement", 1);
			AddSpell("Aéromancie", typeof(TeleportationScroll), "Téleportation", 2);
			AddSpell("Aéromancie", typeof(TornadoScroll), "Tornado", 3);
			AddSpell("Aéromancie", typeof(AuraElectrisanteScroll), "Aura électrisante", 4);
			AddSpell("Aéromancie", typeof(ToucherSuffocantScroll), "Touché suffocant", 5);
			AddSpell("Aéromancie", typeof(BrouillardScroll), "Brouillard", 6);
			AddSpell("Aéromancie", typeof(VentFavorableScroll), "Vent favorable", 7);
			AddSpell("Aéromancie", typeof(AuraDeBrouillardScroll), "Aura de brouillard", 8);
			AddSpell("Aéromancie", typeof(ExTeleportationScroll), "Ex-téleportation", 9);
			AddSpell("Aéromancie", typeof(VortexScroll), "Vortex", 10);

			AddSpell("Chasseur", typeof(AntidoteScroll), "Antidote", 1);
			AddSpell("Chasseur", typeof(MarquerScroll), "Marquer", 2);
			AddSpell("Chasseur", typeof(CompagnonAnimalScroll), "Compagnon animal", 3);
			AddSpell("Chasseur", typeof(SoinAnimalierScroll), "Soin animalier", 4);
			AddSpell("Chasseur", typeof(FrappeEnsanglanteeScroll), "Frappe ensanglantée", 5);
			AddSpell("Chasseur", typeof(SautAggressifScroll), "Saut aggressif", 6);
			AddSpell("Chasseur", typeof(RugissementScroll), "Rugissement", 7);
			AddSpell("Chasseur", typeof(ChasseurDePrimeScroll), "Chasseur de prime", 8);
			AddSpell("Chasseur", typeof(CoupDansLeGenouScroll), "Coup dans le genou", 9);
			AddSpell("Chasseur", typeof(ContratResoluScroll), "Contrat résolu", 10);

			AddSpell("Défenseur", typeof(DevotionScroll), "Dévotion", 1);
			AddSpell("Défenseur", typeof(BravadeScroll), "Bravade", 2);
			AddSpell("Défenseur", typeof(MentorScroll), "Mentor", 3);
			AddSpell("Défenseur", typeof(MutinerieScroll), "Mutinerie", 4);
			AddSpell("Défenseur", typeof(InterventionScroll), "Intervention", 5);
			AddSpell("Défenseur", typeof(LienDeVieScroll), "Lien de vie", 6);
			AddSpell("Défenseur", typeof(MiracleScroll), "Miracle", 7);
			AddSpell("Défenseur", typeof(IndomptableScroll), "Indomptable", 8);
			AddSpell("Défenseur", typeof(InsensibleScroll), "Insensible", 9);
			AddSpell("Défenseur", typeof(PiedsAuSolScroll), "Pieds au sol", 10);

			AddSpell("Géomancie", typeof(FortifieScroll), "Fortifié", 1);
			AddSpell("Géomancie", typeof(RocheScroll), "Roche", 2);
			AddSpell("Géomancie", typeof(ContaminationScroll), "Contamination", 3);
			AddSpell("Géomancie", typeof(EmpalementScroll), "Empalement", 4);
			AddSpell("Géomancie", typeof(AuraFortifianteScroll), "Aura fortifiante", 5);
			AddSpell("Géomancie", typeof(MurDePlanteScroll), "Mur de plante", 6);
			AddSpell("Géomancie", typeof(ExplosionDeRochesScroll), "Explosion de roche", 7);
			AddSpell("Géomancie", typeof(AuraPreservationManaiqueScroll), "Aura préservvation manaique", 8);
			AddSpell("Géomancie", typeof(RacinesScroll), "Racines", 9);
			AddSpell("Géomancie", typeof(FleauTerrestreScroll), "Fléau terrestre", 10);

			AddSpell("Guérison", typeof(MainCicatrisanteScroll), "Main cicatritrisante", 1);
			AddSpell("Guérison", typeof(RemedeScroll), "Remède", 2);
			AddSpell("Guérison", typeof(DonDeLaVieScroll), "Don de la vie", 3);
			AddSpell("Guérison", typeof(RayonCelesteScroll), "Rayon céleste", 4);
			AddSpell("Guérison", typeof(MurDePierreScroll), "Mur de pierre", 5);
			AddSpell("Guérison", typeof(FrayeurScroll), "Frayeur", 6);
			AddSpell("Guérison", typeof(FerveurDivineScroll), "Ferveur divine", 7);
			AddSpell("Guérison", typeof(InquisitionScroll), "Inquisition", 8);
			AddSpell("Guérison", typeof(MurDeLumiereScroll), "Mur de lumière", 9);
			AddSpell("Guérison", typeof(LumiereSacreeScroll), "Lumière sacrée", 10);

			AddSpell("Hydromancie", typeof(ArmureDeGlaceScroll), "Armure de glace", 1);
			AddSpell("Hydromancie", typeof(PieuxDeGlaceScroll), "Pieux de glace", 2);
			AddSpell("Hydromancie", typeof(RestaurationScroll), "Restauration", 3);
			AddSpell("Hydromancie", typeof(CageDeGlaceScroll), "Cage de glace", 4);
			AddSpell("Hydromancie", typeof(AuraCryogeniseeScroll), "Aura cryogenisée", 5);
			AddSpell("Hydromancie", typeof(SoinPreventifScroll), "Soin préventif", 6);
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
			AddSpell("Musique", typeof(DesorienterScroll), "Désorienter", 2);
			AddSpell("Musique", typeof(InspirationElementaireScroll), "Inspiration élémentaire", 3);
			AddSpell("Musique", typeof(CalmeToiScroll), "Calme toi!", 4);
			AddSpell("Musique", typeof(DecrescendoManaiqueScroll), "Decrescendo mana.", 5);
			AddSpell("Musique", typeof(DefiScroll), "Defi", 6);
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

			AddSpell("Polymorphie", typeof(FormeCycloniqueScroll), "Cyclonique", 1);
			AddSpell("Polymorphie", typeof(FormeMetalliqueScroll), "Métallique", 2);
			AddSpell("Polymorphie", typeof(FormeTerrestreScroll), "Terrestre", 3);
			AddSpell("Polymorphie", typeof(FormeEmpoisonneeScroll), "Empoisonnée", 4);
			AddSpell("Polymorphie", typeof(FormeGivranteScroll), "Givrante", 5);
			AddSpell("Polymorphie", typeof(FormeLiquideScroll), "Liquide", 6);
			AddSpell("Polymorphie", typeof(FormeCristallineScroll), "Cristalline", 7);
			AddSpell("Polymorphie", typeof(FormeElectrisanteScroll), "Électrisante", 8);
			AddSpell("Polymorphie", typeof(FormeEnflammeeScroll), "Enflammée", 9);
			AddSpell("Polymorphie", typeof(FormeEnsanglanteeScroll), "Ensanglantée", 10);

			AddSpell("Pyromancie", typeof(BouclierDeFeuScroll), "Bouclier de feu", 1);
			AddSpell("Pyromancie", typeof(BouleDeFeuScroll), "Boule de feu", 2);
			AddSpell("Pyromancie", typeof(CeleriteScroll), "Célérité", 3);
			AddSpell("Pyromancie", typeof(SupernovaScroll), "Supernova", 4);
			AddSpell("Pyromancie", typeof(AuraRechauffanteScroll), "Aura réchauffante", 5);
			AddSpell("Pyromancie", typeof(PassionArdenteScroll), "Passion ardente", 6);
			AddSpell("Pyromancie", typeof(CageDeFeuScroll), "Cage de feu", 7);
			AddSpell("Pyromancie", typeof(AuraExaltationScroll), "Aura d'exaltation", 8);
			AddSpell("Pyromancie", typeof(FrenesieDouloureuseScroll), "Frénésie douloureuse", 8);
			AddSpell("Pyromancie", typeof(FolieArdenteScroll), "Folie ardente", 10);

			AddSpell("Roublardise", typeof(AdrenalineScroll), "Adrénaline", 1);
			AddSpell("Roublardise", typeof(LancerPrecisScroll), "Lancer précis", 2);
			AddSpell("Roublardise", typeof(CoupArriereScroll), "Coup arrière", 3);
			AddSpell("Roublardise", typeof(SommeilScroll), "Sommeil", 4);
			AddSpell("Roublardise", typeof(MainBlesseeScroll), "Main blessée", 5);
			AddSpell("Roublardise", typeof(AttiranceScroll), "Attirance", 6);
			AddSpell("Roublardise", typeof(EvasionScroll), "Évasion", 7);
			AddSpell("Roublardise", typeof(CoupureDesTendonsScroll), "Coupure des tendons", 8);
			AddSpell("Roublardise", typeof(GazEndormantScroll), "Gaz endormant", 9);
			AddSpell("Roublardise", typeof(CoupMortelScroll), "Coup mortel", 10);

			AddSpell("Totémique", typeof(TotemDeTerreScroll), "Totem de terre", 1);
			AddSpell("Totémique", typeof(AbsorbationScroll), "Absorbation", 2);
			AddSpell("Totémique", typeof(TotemDeFeuScroll), "Totem de feu", 3);
			AddSpell("Totémique", typeof(LierParEspritScroll), "Lier par l'esprit", 4);
			AddSpell("Totémique", typeof(TotemDeauScroll), "Totem d'eau", 5);
			AddSpell("Totémique", typeof(AppelSpirituelScroll), "Appel spirituel", 6);
			AddSpell("Totémique", typeof(TotemDuVentScroll), "Totem du vent", 7);
			AddSpell("Totémique", typeof(MurTotemiqueScroll), "Mur totémique", 8);
			AddSpell("Totémique", typeof(SuperChargerScroll), "Super chargeur", 9);
			AddSpell("Totémique", typeof(MarcheAsuivreScroll), "Marche à suivre", 10);

			// Set the overridable material
			SetSubRes(typeof(PlainoisLeather), "Plainois");

			// Add every material you want the player to be able to choose from
			// This will override the overridable material
			AddSubRes(typeof(PlainoisLeather), "Plainois", 0.0, "Vous ne savez pas travailler le cuir plainois");
			//AddSubRes(typeof(CollinoisLeather), "Collinois", 20.0, "Vous ne savez pas travailler le cuir collinois");
			//AddSubRes(typeof(ForestierLeather), "Forestier", 20.0, "Vous ne savez pas travailler le cuir forestier");
			//AddSubRes(typeof(SavanoisLeather), "Savanois", 40.0, "Vous ne savez pas travailler le cuir savanois");
			//AddSubRes(typeof(DesertiqueLeather), "Desertique", 40.0, "Vous ne savez pas travailler le cuir desertique");
			//AddSubRes(typeof(MontagnardLeather), "Montagnard", 60.0, "Vous ne savez pas travailler le cuir montagnard");
			//AddSubRes(typeof(VolcaniqueLeather), "Volcanique", 60.0, "Vous ne savez pas travailler le cuir volcanique");
			//AddSubRes(typeof(TropicauxLeather), "Tropicaux", 80.0, "Vous ne savez pas travailler le cuir tropicaux");
			//AddSubRes(typeof(ToundroisLeather), "Toundrois", 80.0, "Vous ne savez pas travailler le cuir toundrois");
			//AddSubRes(typeof(AncienLeather), "Ancien", 100.0, "Vous ne savez pas travailler le cuir ancien");

			MarkOption = true;
			Repair = true;
			CanEnhance = true;
			CanAlter = true;
		}
	}
}
