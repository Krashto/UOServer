using System; 
using System.Collections; 
using Server.Items; 
using Server.Mobiles; 
using Server.Network; 
using Server.Spells; 
using Server.Custom.Aptitudes;
using Server.Custom;
using Server.Custom.Spells.NewSpells.Aeromancie;
using System.Linq;
using Server.Custom.Spells.NewSpells.Chasseur;
using Server.Custom.Spells.NewSpells.Geomancie;
using Server.Custom.Spells.NewSpells.Defenseur;
using Server.Custom.Spells.NewSpells.Polymorphie;
using Server.Custom.Spells.NewSpells.Guerison;
using Server.Custom.Spells.NewSpells.Martial;
using Server.Custom.Spells.NewSpells.Musique;
using Server.Custom.Spells.NewSpells.Necromancie;
using Server.Custom.Spells.NewSpells.Pyromancie;
using Server.Custom.Spells.NewSpells.Roublardise;
using Server.Custom.Spells.NewSpells.Totemique;
using Server.Custom.Spells.NewSpells.Hydromancie;
using static Server.Config;

namespace Server.Gumps
{
    public class SpellBookEntry
    {
        public Type SpellType { get; private set; }
		public string Description { get; private set; }
		public int SpellID { get; private set; }
        public int Level { get; private set; }
        public string Name { get; private set; }
		public Type[] Reagents { get; private set; }
		public Aptitude Aptitude { get; private set; }

		public SpellBookEntry(Type spellType, string description)
        {
			SpellType = spellType;
			Description = description;

			if (SpellType != null)
			{
				SpellID = SpellRegistry.GetSpellIdFromType(SpellType);

				var spell = SpellRegistry.GetSpellFromType(SpellType);

				if (spell != null)
				{
					Name = spell.Name;
					Reagents = spell.Reagents;
					Aptitude = spell.RequiredAptitude.FirstOrDefault();
					Level = spell.RequiredAptitudeValue;
				}
			}
		}
	}

    public class NewSpellbookGump : Gump
    {
		public static SpellBookEntry[] m_SpellBookEntry = new SpellBookEntry[]
		{
			new SpellBookEntry( typeof(AveuglementSpell), "R�duction des chances de toucher de la cible"),
			new SpellBookEntry( typeof(BrouillardSpell), "Rend invisible la cible."),
			new SpellBookEntry( typeof(TeleportationSpell), "Permet de vous t�l�porter sur la case de votre choix."),
			new SpellBookEntry( typeof(TornadoSpell), "Cr�e un champ de force autour de vous qui pousse les ennemis qui vous approchent."),
			new SpellBookEntry( typeof(AuraElectrisanteSpell), "Augmente la r�sistance � l'�nergie de vous et vos alli�s."),
			new SpellBookEntry( typeof(ExTeleportationSpell), "Permet d'interchanger votre place avec votre cible."),
			new SpellBookEntry( typeof(ToucherSuffocantSpell), "Rend muet votre cible, l'emp�chant de lancer des sorts."),
            new SpellBookEntry( typeof(AuraDeBrouillardSpell), "Rend invisible les alli�s autour de vous."),
			new SpellBookEntry( typeof(VentFavorableSpell), "Vous procure la rapidit� de d�placement � pieds d'un cheval."),
			new SpellBookEntry( typeof(VortexSpell), "Cr�e une zone de temp�te, envoyant des �clairs ici et l� � ceux qui traversent la zone."),

            new SpellBookEntry( typeof(AntidoteSpell), "Permet de gu�rir le poison sur soi-m�me."),
			new SpellBookEntry( typeof(MarquerSpell), "Marque une cible et gagne de la rapidit� d'attaque."),
			new SpellBookEntry( typeof(CompagnonAnimalSpell), "Permet d'invoquer un compagnon animal."),
			new SpellBookEntry( typeof(SoinAnimalierSpell), "Permet de soigner son compagnon animal."),
			new SpellBookEntry( typeof(RugissementSpell), "Ordonne � votre compagnon animal de rugir, attirant vers lui les cr�atures autour de lui."),
			new SpellBookEntry( typeof(FrappeEnsanglanteeSpell), "Permet de faire saigner une cible, l'emp�chant par le fait m�me de se soigner."),
			new SpellBookEntry( typeof(SautAggressifSpell), "Permet de reculer de quelques cas tout en frappant la cible."),
			new SpellBookEntry( typeof(CoupDansLeGenouSpell), "Emp�che la cible de courir."),
			new SpellBookEntry( typeof(ChasseurDePrimeSpell), "Si la cible est touch�e par le sort Marquer, ces r�sistances sont diminu�es drastiquement."),
            new SpellBookEntry( typeof(ContratResoluSpell), "Si la cible est marqu�e, ne peut plus courir* et est ensanglant�e, vous t�l�porte sur la cible pour la tuer d'un coup. *Le fait de frapper ou d'ensanglanter une cible lui retire l'emp�chement de courir, alors soyez rapide ou soyez plusieurs!"),

			new SpellBookEntry( typeof(DevotionSpell), "Augmente ces points de vie maximun."),
			new SpellBookEntry( typeof(BravadeSpell), "Provoque une cible."),
			new SpellBookEntry( typeof(InterventionSpell), "Permet de se t�l�porter sur une cible."),
			new SpellBookEntry( typeof(MutinerieSpell), "Provoque toutes les cr�atures autour de vous."),
			new SpellBookEntry( typeof(MentorSpell), "Procure de la r�duction de co�t de mana sur votre cible."),
			new SpellBookEntry( typeof(LienDeVieSpell), "La moiti� des d�g�ts re�us sur votre cible vous est transf�r�e."),
			new SpellBookEntry( typeof(MiracleSpell), "Ressuscite un joueur. Vous devez cibler son corps inerte."),
			new SpellBookEntry( typeof(IndomptableSpell), "La cible est immunit�e contre la paralysie, le sommeil, l'emp�chement de bouger et l'emp�chement de courir."),
			new SpellBookEntry( typeof(InsensibleSpell), "La cible est immunit�e contre le poison, le saignement, l'emp�chement de se soigner et � la mal�diction."),
			new SpellBookEntry( typeof(PiedsAuSolSpell), "Vous cloue au sol, mais les d�g�ts re�us sont r�duits."),

			new SpellBookEntry( typeof(FortifieSpell), "Augmente votre r�sistance physique."),
			new SpellBookEntry( typeof(RocheSpell), "Lance une roche sur la cible."),
			new SpellBookEntry( typeof(ContaminationSpell), "Empoisonne la cible."),
			new SpellBookEntry( typeof(EmpalementSpell), "Lance des �pines autour de vous, ensanglante les cibles touch�es."),
			new SpellBookEntry( typeof(AuraFortifianteSpell), "Augmente la r�sistance physique de vous et vos alli�s."),
			new SpellBookEntry( typeof(MurDePlanteSpell), "Invoque un mur de plante qui empoisonne les cibles autour."),
			new SpellBookEntry( typeof(ExplosionDeRochesSpell), "Permet de faire exploser sa r�sistance physique et d'envoyer des pierres sur les cibles autour. *Les sorts Fortifi� et Aura fortifiante augmentent les d�g�ts du sort."),
			new SpellBookEntry( typeof(AuraPreservationManaiqueSpell), "Procure de la r�duction de co�t de mana � vous et vos alli�s."),
			new SpellBookEntry( typeof(RacinesSpell), "Enracine une cible, l'emp�chant de bouger."),
			new SpellBookEntry( typeof(FleauTerrestreSpell), "Endommage, empoisonne et emp�che de se soigner les ennemis autour de vous."),

			new SpellBookEntry( typeof(MainCicatrisanteSpell), "Permet de lancer un sortil�ge de soin."),
			new SpellBookEntry( typeof(RemedeSpell), "Permet de gu�rir le poison d'une cible."),
			new SpellBookEntry( typeof(MurDePierreSpell), "Invoque un mur de pierre."),
			new SpellBookEntry( typeof(RayonCelesteSpell), "Permet de lancer un sortil�ge de soin am�lior�."),
			new SpellBookEntry( typeof(DonDeLaVieSpell), "Ressuscite un joueur. Vous devez cibler son corps inerte."),
			new SpellBookEntry( typeof(FrayeurSpell), "Votre cible est prise de peur."),
			new SpellBookEntry( typeof(FerveurDivineSpell), "Permet d�interchanger vos points de mana avec votre cible."),
			new SpellBookEntry( typeof(InquisitionSpell), "Augmente votre rapidit� de lancer des sorts, vos sorts de soins sont am�lior�s et vos murs durent plus longtemps."),
			new SpellBookEntry( typeof(MurDeLumiereSpell), "Permet de lancer un mur de paralysie."),
			new SpellBookEntry( typeof(LumiereSacreeSpell), "Endommage les ennemis et soigne les alli�s autour de votre cible."),

			new SpellBookEntry( typeof(ArmureDeGlaceSpell), "Augmente votre r�sistance au froid."),
			new SpellBookEntry( typeof(RestaurationSpell), "Procure une reg�n�ration de points de vie � votre cible."),
			new SpellBookEntry( typeof(SoinPreventifSpell), "Permet de se t�l�porter sur un alli� et lui appliquer le sort Restauration."),
			new SpellBookEntry( typeof(CageDeGlaceSpell), "Entoure une cible de mur de glace, l'emp�chant de bouger."),
			new SpellBookEntry( typeof(AuraCryogeniseeSpell), "Augmente la r�sistance au froid de vous et vos alli�s."),
			new SpellBookEntry( typeof(PieuxDeGlaceSpell), "La cible est assaillit de pieux de glace qui explosent autour d'elle."),
			new SpellBookEntry( typeof(CerveauGeleSpell), "Si la cible est affect�e par le sort 'Blizzard' ou 'Cage de glace', ses points de vie sont r�duits � la moiti� de son maximum."),
			new SpellBookEntry( typeof(AuraRefrigeranteSpell), "Applique le sort Restauration � vous et aux alli�s autour de vous."),
			new SpellBookEntry( typeof(AvatarDuFroidSpell), "Vous cloue les pieds au sol, mais vos sorts de soin sont am�lior�s."),
			new SpellBookEntry(	typeof(BlizzardSpell), "Cr�e une zone de blizzard, emp�chant les ennemis de courir et leur fait perdre de la stamina."),

			new SpellBookEntry( typeof(SecondSouffleSpell), "Augmente la r�g�n�ration de point de vie."),
			new SpellBookEntry( typeof(ProvocationSpell), "La cible est attir�e vers vous."),
			new SpellBookEntry( typeof(SautDevastateurSpell), "Saute de quelques cases et cr�e une zone de feu lors de l'impact."),
			new SpellBookEntry( typeof(DuelSpell), "Gagne un bonus de d�g�ts contre la cible."),
			new SpellBookEntry( typeof(ChargeFurieuseSpell), "Charge vers la cible, la repoussant lors de l'impact."),
			new SpellBookEntry( typeof(EnrageSpell), "R�duit sa r�sistance physique, mais augmente ses d�g�ts physiques."),
			new SpellBookEntry( typeof(BouclierMagiqueSpell), "Permet de renvoyer le prochain sort sur vous sur le lanceur du sort."),
			new SpellBookEntry( typeof(CommandementSpell), "Augmente vos d�g�ts et ceux de vos alli�s."),
			new SpellBookEntry( typeof(PresenceInspiranteSpell), "Augmente la reg�n�ration de vos points de vie et celle de vos alli�s."),
			new SpellBookEntry( typeof(AngeGardienSpell), "Vous perdez des points de vie, mais votre r�sistance est grandement am�lior�e."),

			new SpellBookEntry( typeof(DiversionSpell), "Permet d�attirer l�attention d�un monstre sur une cible*. *Ciblez le sol."),
			new SpellBookEntry( typeof(CalmeToiSpell), "Apaise une cr�ature."),
			new SpellBookEntry( typeof(DesorienterSpell), "D�soriente une cr�ature."),
			new SpellBookEntry( typeof(DefiSpell), "Provoque une cr�ature sur une autre."),
			new SpellBookEntry( typeof(DecrescendoManaiqueSpell), "Procure de la r�duction de co�t de mana � vous et vos alli�s."),
			new SpellBookEntry( typeof(InspirationElementaireSpell), "Ajoute des effets magiques � votre arme de mani�re al�atoire (Ex: boule de feu, �clair, etc)"),
			new SpellBookEntry( typeof(AbsorbationSonoreSpell), "Permet de drainer la mana des ennemis autour de vous."),
			new SpellBookEntry( typeof(ParfaiteAspirationSpell), "Augmente la concentration d'une cible, ce qui lui emp�che de r�ter un sort lorsqu'elle est touch�e."),
			new SpellBookEntry( typeof(RevelationDiscordanteSpell), "Permet de r�v�ler tous les invisibles de votre �cran et les d�soriente."),
			new SpellBookEntry( typeof(HavreDePaixSpell), "Apaise toutes les cr�atures autour de vous."),

			new SpellBookEntry( typeof(SoifDeSangSpell), "Ensanglante la cible."),
			new SpellBookEntry( typeof(ToucheAbsorbantSpell), "Permet de se soigner en ciblant un corp inerte au sol."),
			new SpellBookEntry( typeof(InfectionSpell), "Applique une mal�diction sur la cible."),
			new SpellBookEntry( typeof(ArmureOsSpell), "Vous procure un aura qui r�fl�te les d�g�ts."),
			new SpellBookEntry( typeof(FamilierMorbideSpell), "Invoque une cr�ature morbide."),
			new SpellBookEntry( typeof(ReanimationSpell), "Permet de relever les cadavres."),
			new SpellBookEntry( typeof(ConsommationMortelleSpell), "Permet de consommer l'existance d'une cr�ature invoqu�es et de se soigner."),
			new SpellBookEntry( typeof(AuraVampiriqueSpell), "Donne un aura de regain de vie � ses alli�s quand ils sont des d�g�ts."),
			new SpellBookEntry( typeof(AppelDuSangSpell), "Invoque un �l�mentaire de sang."),
			new SpellBookEntry( typeof(PluieDeSangSpell), "Ensanglante et applique une mal�diction aux ennemis autour de soi."),

			new SpellBookEntry( typeof(FormeCycloniqueSpell), "Gagne un bonus de comp�tence 'Hiding'."),
			new SpellBookEntry( typeof(FormeMetalliqueSpell), "Procure une meilleure reg�n�ration de points de vie."),
			new SpellBookEntry( typeof(FormeTerrestreSpell), "Augmente votre r�sistance phjysique, mais diminue votre r�sistance au feu et � l'�nergie."),
			new SpellBookEntry( typeof(FormeEmpoisonneeSpell), "Permet d'appliquer un poison lorsque vous frappez une cible."),
			new SpellBookEntry( typeof(FormeGivranteSpell), "Augmente vos d�g�ts physiques et votre r�g�n�ration de points de vie."),
			new SpellBookEntry( typeof(FormeLiquideSpell), "Procure un bonus de gu�rison avec les bandages sur soi-m�me."),
			new SpellBookEntry( typeof(FormeCristallineSpell), "Augmente votre reg�n�ration de mana, mais vous perdez des points de vie. Augmente votre r�sistance au froid et poison."),
			new SpellBookEntry( typeof(FormeElectrisanteSpell), "Augmente votre vitesse de d�placement, de pr�cision des coups et vos points de vie."),
			new SpellBookEntry( typeof(FormeEnflammeeSpell), "Br�le les ennemis qui sont trop pr�s de vous."),
			new SpellBookEntry( typeof(FormeEnsanglanteeSpell), "Procure un regain de vie lors de coups, augmente votre reg�n�ration de mana et de stamina. Vous �tes immunis� aux poisons, mais vous perdez de la r�sistance au feu."),

			new SpellBookEntry( typeof(BouclierDeFeuSpell), "Augmente votre r�sistance au feu."),
			new SpellBookEntry( typeof(BouleDeFeuSpell), "Lance une boule de feu."),
			new SpellBookEntry( typeof(CeleriteSpell), "Augmente la vitesse d'attaque de votre cible."),
			new SpellBookEntry( typeof(SupernovaSpell), "Permet de lancer des boules de feu autour de vous."),
			new SpellBookEntry( typeof(AuraRechauffanteSpell), "Augmente la r�sistance au feu de vous et vos alli�s."),
			new SpellBookEntry( typeof(PassionArdenteSpell), "Une partie des d�g�ts de feu re�us vous soigne. Une partie des d�g�ts de feu envoy�s vous soigne �galement."),
			new SpellBookEntry( typeof(CageDeFeuSpell), "La cible est t�l�port�e � vous, vous entourant tous les deux d'une cage de feu. Tous les gens entour�s par la cage de feu ne peuvent s'en �chapper."),
			new SpellBookEntry( typeof(AuraExaltationSpell), "Augmente la vitesse d'attaque de vous et de vos alli�s."),
			new SpellBookEntry( typeof(FrenesieDouloureuseSpell), "Votre cible est attir�e vers vous tout en �tant br�l�e."),
			new SpellBookEntry( typeof(FolieArdenteSpell), "Br�le votre cible de mani�re r�p�titive."),

			new SpellBookEntry( typeof(AdrenalineSpell), "Augmente votre reg�n�ration de stamina."),
			new SpellBookEntry( typeof(LancerPrecisSpell), "Lance un couteau qui ensanglante votre cible."),
			new SpellBookEntry( typeof(CoupArriereSpell), "Permet de se t�l�porter en arri�re de votre cible pour la frapper."),
			new SpellBookEntry( typeof(SommeilSpell), "Endort une cible."),
			new SpellBookEntry( typeof(MainBlesseeSpell), "D�sarmera la prochaine personne que vous frapperez."),
			new SpellBookEntry( typeof(AttiranceSpell), "T�l�porte une cible vers vous."),
			new SpellBookEntry( typeof(EvasionSpell), "Permet de se t�l�porter � une case al�atoire et vous rend invisible."),
			new SpellBookEntry( typeof(CoupureDesTendonsSpell), "Ensanglante une cible et l'emp�che de courir."),
			new SpellBookEntry( typeof(GazEndormantSpell), "Endort les ennemis autour de votre cible."),
			new SpellBookEntry( typeof(CoupMortelSpell), "Si les points de vie de votre cible sont sous la barre des 20%, la cible est ex�cut�e."),

			new SpellBookEntry( typeof(TotemDeFeuSpell), "Invoque un totem de feu qui lance des boules de feu."),
			new SpellBookEntry( typeof(TotemDeauSpell), "Invoque un totem d'eau qui vous soigne."),
			new SpellBookEntry( typeof(TotemDeTerreSpell), "Invoque un totem de terre qui attirent les ennemis autour de lui."),
			new SpellBookEntry( typeof(TotemDuVentSpell), "Invoque un totem de vent qui lance des �clairs."),
			new SpellBookEntry( typeof(AbsorbationSpell), "Absorbe un totem pour regagner de la vie, de la stamina et de la mana."),
			new SpellBookEntry( typeof(LierParEspritSpell), "Permet de t�l�porter les totems sur soi."),
			new SpellBookEntry( typeof(SuperChargerSpell), "Am�liore la puissance des totems."),
			new SpellBookEntry( typeof(MurTotemiqueSpell), "Permet d'invoquer un mur de totems d'�nergie, vous emp�chant de les traverser.."),
			new SpellBookEntry( typeof(AppelSpirituelSpell), "Permet de retourner une cible � la ville."),
			new SpellBookEntry( typeof(MarcheAsuivreSpell), "Permet aux totems de vous suivre."),
        };

        public bool HasSpell(int spellID)
        {
            return m_Book.HasSpell(spellID);
        }
        
        #region Tableaux
        //Liste des magies du spellbook et leur couleur
        public Aptitude[] m_AptitudeList = new Aptitude[] {
			Aptitude.Martial,
			Aptitude.Chasseur,
			Aptitude.Roublardise,
			Aptitude.Polymorphie,
			Aptitude.Totemique,
			Aptitude.Musique,
			Aptitude.Hydromancie,
			Aptitude.Pyromancie,
			Aptitude.Geomancie,
			Aptitude.Aeromancie,
			Aptitude.Necromancie,
			Aptitude.Defenseur,
			Aptitude.Guerison,
		};

        public Hashtable m_NameColors = new Hashtable();
        public Hashtable m_Names = new Hashtable();
        public Hashtable m_Symbols = new Hashtable();

        public void InitializeHashtable()
        {
            m_NameColors[Aptitude.Aeromancie] = (int)AptitudeColor.Aeromancie;
			m_NameColors[Aptitude.Chasseur] = (int)AptitudeColor.Chasseur;
			m_NameColors[Aptitude.Defenseur] = (int)AptitudeColor.Defenseur;
			m_NameColors[Aptitude.Geomancie] = (int)AptitudeColor.Geomancie;
			m_NameColors[Aptitude.Guerison] = (int)AptitudeColor.Guerison;
			m_NameColors[Aptitude.Hydromancie] = (int)AptitudeColor.Hydromancie;
			m_NameColors[Aptitude.Martial] = (int)AptitudeColor.Martial;
			m_NameColors[Aptitude.Musique] = (int)AptitudeColor.Musique;
			m_NameColors[Aptitude.Necromancie] = (int)AptitudeColor.Necromancie;
			m_NameColors[Aptitude.Polymorphie] = (int)AptitudeColor.Polymorphie;
			m_NameColors[Aptitude.Pyromancie] = (int)AptitudeColor.Pyromancie;
			m_NameColors[Aptitude.Roublardise] = (int)AptitudeColor.Roublardise;
            m_NameColors[Aptitude.Totemique] = (int)AptitudeColor.Totemique;

			m_Names[Aptitude.Aeromancie] = "A�romancie";
			m_Names[Aptitude.Chasseur] = "Chasseur";
			m_Names[Aptitude.Defenseur] = "D�fenseur";
			m_Names[Aptitude.Geomancie] = "G�omancie";
			m_Names[Aptitude.Guerison] = "Gu�rison";
			m_Names[Aptitude.Hydromancie] = "Hydromancie";
			m_Names[Aptitude.Martial] = "Martial";
			m_Names[Aptitude.Musique] = "Musique";
			m_Names[Aptitude.Necromancie] = "N�cromancie";
			m_Names[Aptitude.Polymorphie] = "Polymorphie";
			m_Names[Aptitude.Pyromancie] = "Pyromancie";
			m_Names[Aptitude.Roublardise] = "Roublardise";
			m_Names[Aptitude.Totemique] = "Tot�mique";
		}
        #endregion

        private NewSpellbook m_Book;
        private int m_Page;
		private const int EntriesPerPage = 20;

		public NewSpellbookGump(Mobile from, NewSpellbook book, int page) : base(150, 200)
        {
            InitializeHashtable();

            m_Book = book;
			m_Page = page;
            int vindex = 0;
            int hindex = 0;

			if (!(from is CustomPlayerMobile))
                return;

            CustomPlayerMobile pm = (CustomPlayerMobile)from;

            AddImage(100, 10, 500);

			//On ajoute les boutons de changement de page
			if (m_Page < (m_SpellBookEntry.Length / EntriesPerPage))
				AddButton(456, 10, 502, 502, 18, GumpButtonType.Reply, 0);
			else if (m_Page == m_SpellBookEntry.Length / EntriesPerPage)
				AddButton(456, 10, 502, 502, 1600, GumpButtonType.Reply, 0);

			if (m_Page > 0)
				AddButton(100, 10, 501, 501, 19, GumpButtonType.Reply, 0);

			AddPage(0);

			//Pour tous les sorts
			for (int i = m_Page * EntriesPerPage, count = 0; count < EntriesPerPage && i < m_SpellBookEntry.Length; ++i, count++)
			{
				var entry = m_SpellBookEntry[i];

				if (count % EntriesPerPage == 0)
				{
					vindex = 0;
					hindex = 0;
					AddLabel(180 + hindex * 190, 25, (int)m_NameColors[entry.Aptitude] - 1, (string)m_Names[entry.Aptitude]);
				}

				if (count % (EntriesPerPage / 2) == 0 && count % EntriesPerPage != 0)
				{
					vindex = 0;
					hindex = 1;
					AddLabel(180 + hindex * 190, 25, (int)m_NameColors[entry.Aptitude] - 1, (string)m_Names[entry.Aptitude]);
				}

				// S�parateurs
				AddImageTiled(140 + hindex * 190, 40, 130, 10, 0x3A);

				//Si le livre poss�de le sort
				if (HasSpell(entry.SpellID) && ArrayContains(m_AptitudeList, entry.Aptitude))
				{
					//On ajoute l'information et les boutons
					AddLabel(163 + hindex * 190, 54 + (vindex * 15), 0, entry.Name);
					AddButton(128 + hindex * 190, 59 + (vindex * 15), 2103, 2104, entry.SpellID, GumpButtonType.Reply, 0); //Cast
					AddButton(140 + hindex * 190, 57 + (vindex * 15), 2224, 2224, 1000 + entry.SpellID, GumpButtonType.Reply, 0); //Info
					vindex++;
				}
			}

			//Pour tous les sorts
			if (m_Page >= 600)
			{
				foreach(var spell in m_SpellBookEntry)
				{
					if (spell.SpellID != m_Page)
						continue;

					//Si le livre poss�de le sort
					if (this.HasSpell(spell.SpellID) && ArrayContains(m_AptitudeList, spell.Aptitude))
					{
						hindex = 0;

						//On ajoute les boutons de pages
						if (m_Page > 600)
							AddButton(100, 10, 501, 501, 1000 + spell.SpellID - 1, GumpButtonType.Reply, 0);
						else
							AddButton(100, 10, 501, 501, 20, GumpButtonType.Reply, 0);

						if (m_Page < 729)
							AddButton(456, 10, 502, 502, 1000 + spell.SpellID + 1, GumpButtonType.Reply, 0);

						int namecolor = 0;
						string name = "...";

						if (m_NameColors.Contains(spell.Aptitude))
							namecolor = (int)m_NameColors[spell.Aptitude] - 1;

						if (m_Names.Contains(spell.Aptitude))
							name = (string)m_Names[spell.Aptitude];

						//On ajoute le nom
						AddButton(175 + hindex * 190, 22, 2223, 2223, 100 + ((spell.SpellID - 600) / EntriesPerPage), GumpButtonType.Reply, 0);
						AddLabel(200 + hindex * 190, 20, namecolor, name);
						AddButton(140 + hindex * 190, 44, 2103, 2104, spell.SpellID, GumpButtonType.Reply, 0);
						AddLabel(155 + hindex * 190, 40, 0, spell.Name);

						//On ajoute les s�parateurs
						AddImageTiled(140 + hindex * 190, 60, 130, 10, 0x3A);

						//On ajoute l'icone en tant que bouton pour lancer le sort
						AddLabel(140 + hindex * 190, 80, 0, $"Niveau : {spell.Level}");
						AddLabel(140 + hindex * 190, 100, 0, $"Mana : {Spell.GetManaBase(spell.Level)}");
						AddLabel(140 + hindex * 190, 120, 0, $"Temps : {Spell.GetCastDelayBase(spell.Level).TotalSeconds}s");

						//On ajoute l'icone en tant que bouton pour lancer le sort
						AddLabel(140 + hindex * 190, 140, 0, $"Skill : {Aptitudes.GetSkillName(spell.Aptitude)}");

						//On ajoute les infos diverses
						AddHtml(140 + hindex * 190, 160, 100, 20, "R�actifs:", false, false);
						for (int j = 0; j < spell.Reagents.Length; j++)
						{
							Type type = (Type)spell.Reagents[j];
							AddLabel(140 + hindex * 190, 180 + j * 20, 0, $"- {type.Name}");
						}

						hindex = 1;

						AddHtml(130 + hindex * 190, 25, 100, 20, "Description:", false, false);
						AddHtml(130 + hindex * 190, 45, 170, 180, spell.Description, false, false);
					}
				}
			}
		}

        public bool ArrayContains(Aptitude[] conn, Aptitude wanted)
        {
            for (int i = 0; i < conn.Length; i++)
            {
                if (wanted == (Aptitude)conn[i])
                    return true;
            }

            return false;
        }

        public static SpellBookEntry FindEntryBySpellID(int spellID)
        {
            for (int i = 0; i < m_SpellBookEntry.Length; i++)
            {
                SpellBookEntry info = (SpellBookEntry)m_SpellBookEntry[i];

                if (info.SpellID == spellID)
                    return info;
            }

            return null;
        }

        public class CompareSpellID : IComparer
        {
            public int Compare(object obj1, object obj2)
            {
                SpellBookEntry a = (SpellBookEntry)obj1;
                SpellBookEntry b = (SpellBookEntry)obj2;

                return ((int)a.SpellID).CompareTo(((int)b.SpellID));
            }
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            Mobile from = state.Mobile;

            if (from is CustomPlayerMobile)
            {
                CustomPlayerMobile pm = (CustomPlayerMobile)from;

				if (info.ButtonID == 18 && m_Page < m_SpellBookEntry.Length / EntriesPerPage)
                    pm.SendGump(new NewSpellbookGump(pm, m_Book, m_Page + 1));
				else if (info.ButtonID == 19 && m_Page > 0)
					pm.SendGump(new NewSpellbookGump(pm, m_Book, m_Page - 1));
				else if (info.ButtonID == 20 && m_Page > 0)
					pm.SendGump(new NewSpellbookGump(pm, m_Book, m_SpellBookEntry.Length / EntriesPerPage));
				else if (info.ButtonID >= 100 && info.ButtonID < 200)
					pm.SendGump(new NewSpellbookGump(pm, m_Book, info.ButtonID - 100));
				else if (info.ButtonID >= 600 && info.ButtonID < 800)
                {
                    Spell spell = SpellRegistry.NewSpell(info.ButtonID, pm, null);

                    if (spell != null)
                        spell.Cast();

                    pm.SendGump(new NewSpellbookGump(pm, m_Book, m_Page));
                }
				else if (info.ButtonID >= 1600 && info.ButtonID < 1800)
				{
					pm.SendGump(new NewSpellbookGump(pm, m_Book, info.ButtonID - 1000));
				}
			}
        }
    }
}