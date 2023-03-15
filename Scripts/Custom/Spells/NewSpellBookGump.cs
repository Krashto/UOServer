using System; 
using System.Collections; 
using Server.Items; 
using Server.Mobiles; 
using Server.Network; 
using Server.Spells; 
using Server.Custom.Aptitudes;
using System.Web.UI;

namespace Server.Gumps
{
    public class SpellBookEntry
    {
        private int m_AptitudeLevel;
        private string m_Nom;
        private Type[] m_Reagents;
        private int m_ImageID;
        private int m_Cercle;
        private Aptitude m_Aptitude;
        private int m_SpellID;

        public int AptitudeLevel { get { return m_AptitudeLevel; } }
        public string Nom { get { return m_Nom; } }
        public Type[] Reagents { get { return m_Reagents; } }
        public int ImageID { get { return m_ImageID; } }
        public int Cercle { get { return m_Cercle; } }
        public Aptitude Aptitude { get { return m_Aptitude; } }
        public int SpellID { get { return m_SpellID; } }

        public SpellBookEntry(int conn, Aptitude connaissance, string nom, Type[] regs, int imageid, int cercle, int spellid)
        {
            m_AptitudeLevel = conn;
            m_Nom = nom;
            m_Reagents = regs;
            m_ImageID = imageid;
            m_Cercle = cercle;
            m_Aptitude = connaissance;
            m_SpellID = spellid;
        }
    }

    public class NewSpellbookGump : Gump
    {
        public static SpellBookEntry[] m_SpellBookEntry = new SpellBookEntry[]
        {
			new SpellBookEntry( 1, Aptitude.Aeromancie, "Aveuglement", new Type[] { typeof(Garlic), typeof(SpidersSilk), typeof(SulfurousAsh) }, 0x8c6, 1, 627),
			new SpellBookEntry( 2, Aptitude.Aeromancie, "Brouillard", new Type[] { typeof(Nightshade), typeof(Bloodmoss), typeof(BlackPearl) }, 0x8eb, 2, 693),
			new SpellBookEntry( 3, Aptitude.Aeromancie, "Téléportation", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot) }, 0x8d5, 3, 683),
            new SpellBookEntry( 4, Aptitude.Aeromancie, "Tornado", new Type[] { typeof(BlackPearl), typeof(SpidersSilk), typeof(Ginseng) }, 0x128, 3, 618),
            new SpellBookEntry( 5, Aptitude.Aeromancie, "Aura Évasive", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(BlackPearl) }, 0x12e, 4, 634),
			new SpellBookEntry( 6, Aptitude.Aeromancie, "Ex-Téléportation", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot) }, 0x8d5, 4, 635),
			new SpellBookEntry( 7, Aptitude.Aeromancie, "Toucher suffocant", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SulfurousAsh) }, 0x8e8, 5, 623),
            new SpellBookEntry( 8, Aptitude.Aeromancie, "Aura de brouillard", new Type[] { typeof(MandrakeRoot), typeof(Ginseng), typeof(SpidersSilk) }, 0x8ee, 6, 621),
			new SpellBookEntry( 9, Aptitude.Aeromancie, "Vent favorable", new Type[] { typeof(Bloodmoss), typeof(Ginseng), typeof(Garlic) }, 0x59e4, 7, 649),
			new SpellBookEntry( 10, Aptitude.Aeromancie, "Vortex", new Type[] { typeof(Nightshade), typeof(Garlic), typeof(Bloodmoss) }, 0x148, 8, 663),

            new SpellBookEntry( 1, Aptitude.Chasseur, "Antidote", new Type[] { typeof(Garlic), typeof(Ginseng) }, 0x8ca, 1, 628),
			new SpellBookEntry( 2, Aptitude.Chasseur, "Marquer", new Type[] { typeof(Nightshade), typeof(BlackPearl), typeof(Garlic) }, 0x8e9, 2, 655),
			new SpellBookEntry( 3, Aptitude.Chasseur, "Ricochet", new Type[] { typeof(BlackPearl), typeof(MandrakeRoot), typeof(SulfurousAsh) }, 0x8dd, 3, 653),
			new SpellBookEntry( 4, Aptitude.Chasseur, "Soin animalier", new Type[] { typeof(SulfurousAsh), typeof(SulfurousAsh), typeof(Bloodmoss) }, 0x8ea, 4, 659),
			new SpellBookEntry( 5, Aptitude.Chasseur, "Rugissement", new Type[] { typeof(Garlic), typeof(SulfurousAsh), typeof(Ginseng) }, 0x08e5, 4, 678),
			new SpellBookEntry( 6, Aptitude.Chasseur, "Frappe ensanglantée", new Type[] { typeof(SpidersSilk), typeof(SulfurousAsh), typeof(BlackPearl) }, 0x8f2, 5, 656),
			new SpellBookEntry( 7, Aptitude.Chasseur, "Saut aggressif", new Type[] { typeof(Nightshade) }, 0x134, 5, 640),
			new SpellBookEntry( 8, Aptitude.Chasseur, "Coup dans le genou", new Type[] { typeof(MandrakeRoot), typeof(SulfurousAsh), typeof(Ginseng) }, 0x126, 6, 657),
			new SpellBookEntry( 9, Aptitude.Chasseur, "Chasseur de prime", new Type[] { typeof(SulfurousAsh), typeof(Ginseng), typeof(MandrakeRoot) }, 0x8e5, 7, 681),
            new SpellBookEntry( 10, Aptitude.Chasseur, "Contrat résolu", new Type[] { typeof(Bloodmoss), typeof(Ginseng), typeof(Garlic) }, 0x5323, 8, 682),

			new SpellBookEntry( 1, Aptitude.Geomancie, "Fortifié", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot) }, 0x8c8, 1, 608),
			new SpellBookEntry( 2, Aptitude.Geomancie, "Roche", new Type[] { typeof(BlackPearl), typeof(Garlic), typeof(SulfurousAsh) }, 0x8d1, 2, 652),
			new SpellBookEntry( 3, Aptitude.Geomancie, "Contamination", new Type[] { typeof(NoxCrystal), typeof(Nightshade), typeof(SulfurousAsh) }, 0x8d3, 3, 641),
			new SpellBookEntry( 4, Aptitude.Geomancie, "Empalement", new Type[] { typeof(SulfurousAsh), typeof(SulfurousAsh), typeof(SulfurousAsh) }, 0x8f6, 3, 662),
			new SpellBookEntry( 5, Aptitude.Geomancie, "Aura Fortifiante", new Type[] { typeof(MandrakeRoot), typeof(Nightshade)  }, 0x8cf, 4, 607),
			new SpellBookEntry( 6, Aptitude.Geomancie, "Mur de plante", new Type[] { typeof(Garlic), typeof(Nightshade), typeof(NoxCrystal) }, 0x8e6, 4, 643),
			new SpellBookEntry( 7, Aptitude.Geomancie, "Explosion de roche", new Type[] { typeof(Garlic), typeof(MandrakeRoot) }, 0x8d0, 5, 613),
			new SpellBookEntry( 8, Aptitude.Geomancie, "Aura de remède", new Type[] { typeof(MandrakeRoot), typeof(Nightshade) }, 0x8c9, 6, 611),
			new SpellBookEntry( 9, Aptitude.Geomancie, "Racines", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x122, 7, 646),
			new SpellBookEntry( 10, Aptitude.Geomancie, "Fléau terrestre", new Type[] { typeof(Bloodmoss), typeof(Ginseng), typeof(SulfurousAsh) }, 0x8f8, 8, 658),

			new SpellBookEntry( 1, Aptitude.Hydromancie, "Armure de glace", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x11a, 1, 624),
			new SpellBookEntry( 2, Aptitude.Hydromancie, "Restauration", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SulfurousAsh) }, 0x14a, 2, 632),
			new SpellBookEntry( 3, Aptitude.Hydromancie, "Soin préventif", new Type[] { typeof(SulfurousAsh), typeof(SpidersSilk) }, 0x8c5, 3, 601),
			new SpellBookEntry( 4, Aptitude.Hydromancie, "Cage de glace", new Type[] { typeof(SulfurousAsh), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8c4, 4, 602),
			new SpellBookEntry( 5, Aptitude.Hydromancie, "Aura cryogénisée", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(MandrakeRoot) }, 0x8c1, 4, 600),
			new SpellBookEntry( 6, Aptitude.Hydromancie, "Explosion de glace", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(BlackPearl) }, 0x12e, 5, 639),
			new SpellBookEntry( 7, Aptitude.Hydromancie, "Cerveau gelé", new Type[] { typeof(BlackPearl), typeof(Ginseng), typeof(Garlic) }, 0x127, 5, 654),
			new SpellBookEntry( 8, Aptitude.Hydromancie, "Aura réfrigérante", new Type[] { typeof(BlackPearl), typeof(Bloodmoss), typeof(MandrakeRoot) }, 0x8f0, 6, 661),
			new SpellBookEntry( 9, Aptitude.Hydromancie, "Avatar du froid", new Type[] { typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8ef, 1, 622),
			new SpellBookEntry( 10, Aptitude.Hydromancie, "Blizzard", new Type[] { typeof(SulfurousAsh), typeof(Bloodmoss), typeof(Bloodmoss) }, 0x13d, 5, 660),

			new SpellBookEntry( 1, Aptitude.Necromancie, "Soif de sang", new Type[] { typeof(BlackPearl), typeof(Bloodmoss), typeof(Garlic) }, 0x135, 1, 647),
			new SpellBookEntry( 2, Aptitude.Necromancie, "Touché absorbant", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(SpidersSilk) }, 0x8dc, 2, 638),
			new SpellBookEntry( 3, Aptitude.Necromancie, "Infection", new Type[] { typeof(Nightshade), typeof(Garlic), typeof(SulfurousAsh) }, 0x8da, 3, 614),
			new SpellBookEntry( 4, Aptitude.Necromancie, "Armure d'os", new Type[] { typeof(DaemonBlood), typeof(Garlic) }, 0x5001, 3, 706),
			new SpellBookEntry( 5, Aptitude.Necromancie, "Aura exsangue", new Type[] { typeof(Bloodmoss), typeof(Ginseng), typeof(SpidersSilk) }, 0x59e0, 4, 650),
			new SpellBookEntry( 6, Aptitude.Necromancie, "Réanimation", new Type[] { typeof(GraveDust), typeof(DaemonBlood), typeof(DaemonBlood) }, 0x147, 4, 711),
			new SpellBookEntry( 7, Aptitude.Necromancie, "Regard nécrotique", new Type[] { typeof(BatWing), typeof(GraveDust) }, 0x167, 5, 703),
			new SpellBookEntry( 8, Aptitude.Necromancie, "Aura vampirique", new Type[] { typeof(PigIron) }, 0x5003, 6, 702),
			new SpellBookEntry( 9, Aptitude.Necromancie, "Appel du sang", new Type[] { typeof(GraveDust), typeof(DaemonBlood), typeof(PigIron) }, 0x168, 7, 712),
			new SpellBookEntry( 10, Aptitude.Necromancie, "Pluie de sang", new Type[] { typeof(Nightshade), typeof(Bloodmoss), typeof(NoxCrystal) }, 0x59e5, 8, 644),

			new SpellBookEntry( 1, Aptitude.Polymorphie, "Forme terrestre", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot), typeof(BlackPearl) }, 0x8fd, 8, 665),
			new SpellBookEntry( 2, Aptitude.Polymorphie, "Forme liquide", new Type[] { typeof(Bloodmoss), typeof(Bloodmoss), typeof(Bloodmoss) }, 0x5322, 8, 673),
			new SpellBookEntry( 3, Aptitude.Polymorphie, "Forme enflammée", new Type[] { typeof(SulfurousAsh), typeof(SulfurousAsh), typeof(SpidersSilk) }, 0x8fe, 8, 667),
			new SpellBookEntry( 4, Aptitude.Polymorphie, "Forme métallique", new Type[] { typeof(Bloodmoss), typeof(Garlic), typeof(SpidersSilk) }, 0x8fc, 8, 674),
			new SpellBookEntry( 5, Aptitude.Polymorphie, "Forme électrisante", new Type[] { typeof(BlackPearl), typeof(Nightshade), typeof(Bloodmoss) }, 0x8f9, 8, 672),
			new SpellBookEntry( 6, Aptitude.Polymorphie, "Forme ensanglantée", new Type[] { typeof(Ginseng), typeof(MandrakeRoot), typeof(Nightshade) }, 0x8fb, 8, 666),
			new SpellBookEntry( 7, Aptitude.Polymorphie, "Forme cyclonique", new Type[] { typeof(BlackPearl), typeof(MandrakeRoot), typeof(Nightshade) }, 0x8e0, 8, 671),
			new SpellBookEntry( 8, Aptitude.Polymorphie, "Forme empoisonnée", new Type[] { typeof(BlackPearl), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8ff, 8, 668),
			new SpellBookEntry( 9, Aptitude.Polymorphie, "Forme givrante", new Type[] { typeof(Bloodmoss), typeof(BlackPearl) }, 0x123, 8, 670),
			new SpellBookEntry( 10, Aptitude.Polymorphie, "Forme cristalline", new Type[] { typeof(BlackPearl), typeof(BlackPearl), typeof(SpidersSilk) }, 0x11f, 8, 669),

			new SpellBookEntry( 1, Aptitude.Roublardise, "Adrénaline", new Type[] { typeof(BlackPearl), typeof(MandrakeRoot), typeof(Garlic) }, 0x8e4, 1, 679),
			new SpellBookEntry( 2, Aptitude.Roublardise, "Sommeil", new Type[] { typeof(GraveDust), typeof(PigIron), typeof(BatWing) }, 0x164, 2, 707),
			new SpellBookEntry( 3, Aptitude.Roublardise, "Lancer précis", new Type[] { typeof(NoxCrystal), typeof(Nightshade), typeof(BlackPearl) }, 0x137, 3, 642),
			new SpellBookEntry( 4, Aptitude.Roublardise, "Coup Arrière", new Type[] { typeof(Nightshade), typeof(NoxCrystal), typeof(BlackPearl) }, 0x133, 3, 645),
			new SpellBookEntry( 5, Aptitude.Roublardise, "Évasion", new Type[] { typeof(BlackPearl) }, 0x5326, 4, 685),
			new SpellBookEntry( 6, Aptitude.Roublardise, "Attirance", new Type[] { typeof(BatWing), typeof(NoxCrystal) }, 0x161, 4, 704),
			new SpellBookEntry( 7, Aptitude.Roublardise, "Main blessée", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8f4, 5, 680),
			new SpellBookEntry( 8, Aptitude.Roublardise, "Coupure des tendons", new Type[] { typeof(BlackPearl), typeof(SpidersSilk), typeof(Garlic) }, 0x8e1, 6, 625),
			new SpellBookEntry( 9, Aptitude.Roublardise, "Gas endormant", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(MandrakeRoot) }, 0x8d8, 7, 630),
			new SpellBookEntry( 10, Aptitude.Roublardise, "Coup Mortel", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(BlackPearl) }, 0x8f5, 6, 626),











			//new SpellBookEntry( 1, NAptitude.Polymorphie, "Créatures", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8e7, 1, 664),

			//new SpellBookEntry( 6, Aptitude.Aeromancie, "Rappel", new Type[] { typeof(BlackPearl), typeof(Bloodmoss), typeof(MandrakeRoot) }, 0x8df, 5, 684),
   //         new SpellBookEntry( 8, Aptitude.Aeromancie, "Crochetage", new Type[] { typeof(Garlic), typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8d6, 3, 691),
   //         new SpellBookEntry( 8, Aptitude.Aeromancie, "Télékinésie", new Type[] { typeof(MandrakeRoot), typeof(Bloodmoss) }, 0x8d4, 2, 606),
   //         new SpellBookEntry( 11, Aptitude.Aeromancie, "Marquage", new Type[] { typeof(BlackPearl), typeof(Bloodmoss), typeof(MandrakeRoot) }, 0x8ec, 8, 687),
   //         new SpellBookEntry( 12, Aptitude.Aeromancie, "Trou de ver", new Type[] { typeof(BlackPearl), typeof(MandrakeRoot), typeof(SulfurousAsh) }, 0x8f3, 7, 686),

   //         new SpellBookEntry( 3, Aptitude.Defense, "Protection", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(SulfurousAsh) }, 0x8ce, 2, 636),
   //         new SpellBookEntry( 3, Aptitude.Defense, "Secours", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SulfurousAsh) }, 0x12f, 5, 637),
   //         new SpellBookEntry( 11, Aptitude.Defense, "Copie", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(MandrakeRoot) }, 0x8d9, 6, 638),
   //         new SpellBookEntry( 12, Aptitude.Defense, "Dérobade", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SulfurousAsh) }, 0x12b, 8, 627),

   //         new SpellBookEntry( 3, Aptitude.Medecine, "Guérison", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(SpidersSilk) }, 0x8c3, 2, 629),
   //         new SpellBookEntry( 4, Aptitude.Medecine, "Résurrection", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(Bloodmoss) }, 0x8fa, 6, 633),
   //         new SpellBookEntry( 6, Aptitude.Medecine, "Guérison majeure", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(SpidersSilk) }, 0x8dc, 7, 631),


			//new SpellBookEntry( 1, Aptitude.Necromancie, "Familier", new Type[] { typeof(BatWing), typeof(GraveDust), typeof(DaemonBlood) }, 0x151, 2, 708),
   //         new SpellBookEntry( 8, Aptitude.Necromancie, "Strangulaire", new Type[] { typeof(Bloodmoss), typeof(NoxCrystal), typeof(GraveDust) }, 0x59e3, 5, 710),

            //new SpellBookEntry( 4, NAptitude.Necromagie, "Lance d'os", new Type[] { typeof(MandrakeRoot), typeof(Garlic), typeof(PigIron) }, 0x12a, 6, 705),

            //new SpellBookEntry( 2, NAptitude.Necromancie, "Défraîcheur", new Type[] { typeof(NoxCrystal), typeof(GraveDust), typeof(PigIron) }, 0x500E, 3, 709),
            //new SpellBookEntry( 6, NAptitude.Necromancie, "Insurrection", new Type[] { typeof(GraveDust), typeof(GraveDust), typeof(DaemonBlood) }, 0x11c, 8, 713)

            //new SpellBookEntry( 6, NAptitude.Invocation, "Esprit vengeur", new Type[] { typeof(BlackPearl), typeof(BlackPearl), typeof(SulfurousAsh) }, 0x13f, 8, 675),

            //new SpellBookEntry( 2, NAptitude.Protection, "Réflection", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8e3, 4, 635),

            //new SpellBookEntry( 2, NAptitude.Benediction, "Faiblesse", new Type[] { typeof(Garlic), typeof(Nightshade) }, 0x8c7, 1, 609),
            //new SpellBookEntry( 2, NAptitude.Benediction, "Maladresse", new Type[] { typeof(Bloodmoss), typeof(Nightshade) }, 0x8c0, 1, 610),
            //new SpellBookEntry( 3, NAptitude.Benediction, "Stupidité", new Type[] { typeof(Ginseng), typeof(Nightshade) }, 0x8c2, 2, 612),
            //new SpellBookEntry( 6, NAptitude.Benediction, "Revers", new Type[] { typeof(Nightshade), typeof(Garlic), typeof(SulfurousAsh) }, 0x8ed, 7, 615),

            //new SpellBookEntry( 4, NAptitude.Apprentissage, "Blessure", new Type[] { typeof(Nightshade), typeof(SpidersSilk) }, 0x5101, 2, 603),
            //new SpellBookEntry( 5, NAptitude.Apprentissage, "Pieux de terre", new Type[] { typeof(BlackPearl), typeof(Bloodmoss), typeof(Garlic) }, 0x132, 2, 604),

            //new SpellBookEntry( 1, NAptitude.Adjuration, "Mur de haies", new Type[] { typeof(BlackPearl), typeof(Garlic), typeof(SpidersSilk) }, 0x130, 1, 616),
            //new SpellBookEntry( 2, NAptitude.Adjuration, "Mur de pierre", new Type[] { typeof(Bloodmoss), typeof(Garlic) }, 0x8d7, 2, 617),
            //new SpellBookEntry( 4, NAptitude.Adjuration, "Mur de feu", new Type[] { typeof(SpidersSilk), typeof(BlackPearl), typeof(SulfurousAsh) }, 0x8db, 5, 619),
            //new SpellBookEntry( 5, NAptitude.Adjuration, "Mur d'énergie", new Type[] { typeof(BlackPearl), typeof(MandrakeRoot), typeof(SulfurousAsh) }, 0x8f1, 6, 620),

            //new SpellBookEntry( 3, NAptitude.Nature, "Épines", new Type[] { typeof(BlackPearl), typeof(SulfurousAsh), typeof(MandrakeRoot) }, 0x138, 3, 648),
            //new SpellBookEntry( 6, NAptitude.Nature, "Jet d'épines", new Type[] { typeof(SulfurousAsh), typeof(MandrakeRoot), typeof(Ginseng) }, 0x129, 7, 651),
            
            //new SpellBookEntry( 2, NAptitude.Confrontation, "Drain de mana", new Type[] { typeof(BlackPearl), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8de, 2, 677),
            //new SpellBookEntry( 9, NAptitude.Confrontation, "Pourriture d'esprit", new Type[] { typeof(BlackPearl), typeof(SulfurousAsh), typeof(Ginseng) }, 0x156, 5, 676),

            //new SpellBookEntry( 1, NAptitude.Illusion, "Piège", new Type[] { typeof(Garlic), typeof(SpidersSilk), typeof(SulfurousAsh) }, 0x8cc, 2, 688),
            //new SpellBookEntry( 1, NAptitude.Illusion, "Désamorçage", new Type[] { typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8cd, 2, 689),
            //new SpellBookEntry( 2, NAptitude.Illusion, "Serrure", new Type[] { typeof(Garlic), typeof(Bloodmoss), typeof(Ginseng) }, 0x8d2, 3, 690),
            //new SpellBookEntry( 3, NAptitude.Illusion, "Incognito", new Type[] { typeof(Bloodmoss), typeof(Garlic), typeof(Nightshade) }, 0x8e2, 4, 692),
            //new SpellBookEntry( 5, NAptitude.Illusion, "Hallucinations", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(BlackPearl) }, 0x12c, 6, 694),
            //new SpellBookEntry( 6, NAptitude.Illusion, "Disparition", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(Nightshade) }, 0x12d, 7, 695),

            //new SpellBookEntry( 1, NAptitude.Transformation, "Alteration", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(SulfurousAsh) }, 0x174, 1, 696),
            //new SpellBookEntry( 2, NAptitude.Transformation, "Subterfuge", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(Nightshade) }, 0x17a, 2, 697),
            //new SpellBookEntry( 3, NAptitude.Transformation, "Chimere", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(BlackPearl) }, 0x177, 4, 698),
            //new SpellBookEntry( 4, NAptitude.Transformation, "Transmutation", new Type[] { typeof(BlackPearl), typeof(Ginseng), typeof(SulfurousAsh) }, 0x175, 5, 699),
            //new SpellBookEntry( 5, NAptitude.Transformation, "Métamorphose", new Type[] { typeof(Bloodmoss), typeof(SpidersSilk), typeof(MandrakeRoot) }, 0x8f7, 7, 700),
            //new SpellBookEntry( 6, NAptitude.Transformation, "Mutation", new Type[] { typeof(SulfurousAsh), typeof(SulfurousAsh), typeof(SulfurousAsh) }, 0x59df, 8, 701),
        };

        public bool HasSpell(int spellID)
        {
            return m_Book.HasSpell(spellID);
        }
        
        #region tableaux
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
		};

        public Hashtable m_NameColors = new Hashtable();
        public Hashtable m_Names = new Hashtable();

        public void InitializeHashtable()
        {
            m_NameColors[Aptitude.Martial] = 1105;
            m_NameColors[Aptitude.Chasseur] = 1050;
            m_NameColors[Aptitude.Roublardise] = 1109;
            m_NameColors[Aptitude.Polymorphie] = 1129;
            m_NameColors[Aptitude.Totemique] = 1139;
            m_NameColors[Aptitude.Musique] = 1250;
            m_NameColors[Aptitude.Hydromancie] = 1264;
            m_NameColors[Aptitude.Pyromancie] = 1258;
            m_NameColors[Aptitude.Geomancie] = 1190;
            m_NameColors[Aptitude.Aeromancie] = 1153;
            m_NameColors[Aptitude.Necromancie] = 2006;

            m_Names[Aptitude.Martial] = "Martial";
            m_Names[Aptitude.Chasseur] = "Chasseur";
			m_Names[Aptitude.Roublardise] = "Roublardise";
			m_Names[Aptitude.Polymorphie] = "Polymorphie";
			m_Names[Aptitude.Totemique] = "Totémique";
            m_Names[Aptitude.Musique] = "Musique";
            m_Names[Aptitude.Hydromancie] = "Hydromancie";
            m_Names[Aptitude.Pyromancie] = "Pyromancie";
            m_Names[Aptitude.Geomancie] = "Géomancie";
            m_Names[Aptitude.Aeromancie] = "Aéromancie";
            m_Names[Aptitude.Necromancie] = "Nécromancie";
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

            CustomPlayerMobile m = (CustomPlayerMobile)from;

            AddImage(100, 10, 2201);

			//On ajoute les boutons de changement de page
			if (m_Page < (m_SpellBookEntry.Length / 20))
				AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Reply, 0);
			if (m_Page > 0)
				AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Reply, 0);

			//Pour tous les sorts
			for (int i = m_Page * EntriesPerPage, count = 0; count < EntriesPerPage && i < m_SpellBookEntry.Length; ++i, count++)
			{
				var entry = m_SpellBookEntry[i];

				if (count % EntriesPerPage == 0)
				{
					AddPage(count / EntriesPerPage);
					
					vindex = 0;
					hindex = 0;
					AddLabel(160 + hindex * 145, 25, (int)m_NameColors[entry.Aptitude] - 1, (string)m_Names[entry.Aptitude]);
				}

				if (count % (EntriesPerPage / 2) == 0 && count % EntriesPerPage != 0)
				{
					vindex = 0;
					hindex = 1;
					AddLabel(160 + hindex * 145, 25, (int)m_NameColors[entry.Aptitude] - 1, (string)m_Names[entry.Aptitude]);
				}

				//on assigne la nouvelle connaissance
				var newconnaissance = (int)entry.Aptitude;
				
				// Séparateurs
				AddImageTiled(130 + hindex * 165, 40, 130, 10, 0x3A);

				//Si le livre possède le sort
				if (HasSpell(entry.SpellID) && ArrayContains(m_AptitudeList, entry.Aptitude))
				{
					int buttonID = 2224;

					if (m.QuickSpells.Contains(entry.SpellID))
						buttonID = 2223;

					//On ajoute l'information et les boutons
					AddLabel(162 + hindex * 160, 54 + (vindex * 15), 0, entry.Nom);
					AddButton(127 + hindex * 160, 59 + (vindex * 15), 2103, 2104, entry.SpellID, GumpButtonType.Reply, 0); //Cast
					AddButton(140 + hindex * 160, 58 + (vindex * 15), buttonID, buttonID, entry.SpellID + 200, GumpButtonType.Reply, 0); //AddQSL
					vindex++;
				}
			}



			//int oldconnaissance = -1;

			////Pour tous les sorts
			//for (int i = 0; i < m_SpellBookEntry.Length; i++)
   //         {
   //             SpellBookEntry info = m_SpellBookEntry[i];

			//	//on assigne la nouvelle connaissance
			//	var newconnaissance = (int)info.Aptitude;

			//	//on fait la comparaison des Aptitude pour savoir si on a changé de connaissance
			//	if (newconnaissance != -1 && newconnaissance != oldconnaissance)
   //             {
   //                 totpage++;
   //                 AddPage(totpage);
					
   //                 hindex = 0;

   //                 //On ajoute le nom de la connaissance
   //                 AddLabel(160 + hindex * 145, 25, (int)m_NameColors[info.Aptitude], (string)m_Names[info.Aptitude]);

   //                 // Séparateurs
   //                 AddImageTiled(130 + hindex * 165, 40, 130, 10, 0x3A);

   //                 //On remet à 0 pour la nouvelle page
   //                 vindex = 0;

   //                 //On ajoute les boutons de changement de page
   //                 AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, totpage + 1);
   //                 AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, totpage - 1);
   //             }

   //             //Si le livre possède le sort
   //             if (HasSpell(info.SpellID) && ArrayContains(m_AptitudeList, info.Aptitude))
   //             {
   //                 int buttonID = 2224;

   //                 if (m.QuickSpells.Contains(info.SpellID))
   //                     buttonID = 2223;

   //                 //On ajoute l'information et les boutons
   //                 AddLabel(162 + hindex * 160, 54 + (vindex * 17), 0, info.Nom);
   //                 AddButton(127 + hindex * 160, 59 + (vindex * 17), 2103, 2104, info.SpellID, GumpButtonType.Reply, 0); //Cast
   //                 AddButton(140 + hindex * 160, 58 + (vindex * 17), buttonID, buttonID, info.SpellID + 200, GumpButtonType.Reply, 0); //AddQSL
   //                 vindex++;

   //                 if (vindex >= 9)
   //                 {
   //                     vindex = 0;
   //                     hindex = 1;
   //                 }
   //             }

   //             oldconnaissance = (int)info.Aptitude;
   //          }

			//var value = 0;

			////Pour tous les sorts
			//for (int i = 0; i < m_SpellBookEntry.Length; i++)
   //         {
   //             SpellBookEntry info = (SpellBookEntry)m_SpellBookEntry[i];

   //             //Si le livre possède le sort
   //             if (this.HasSpell(info.SpellID) && ArrayContains(m_AptitudeList, info.Aptitude))
   //             {
   //                 //Si le # du sort est pair...
   //                 if (value % 2 == 0)
   //                 {
   //                     //On fait une page
   //                     totpage++;
   //                     AddPage(totpage);
   //                     hindex = 0;

   //                     //On ajoute les boutons de pages
   //                     AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, totpage - 1);
   //                     AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, totpage + 1);
   //                 }
   //                 else
   //                     hindex = 1;

   //                 int namecolor = 0;
   //                 string name = "...";

   //                 if (m_NameColors.Contains(info.Aptitude))
   //                     namecolor = (int)m_NameColors[info.Aptitude];

   //                 if (m_Names.Contains(info.Aptitude))
   //                     name = (string)m_Names[info.Aptitude];

   //                 //On ajoute le nom
   //                 AddLabel(130 + hindex * 165, 45, namecolor, info.Nom);

   //                 //On ajoute les séparateurs
   //                 AddImageTiled(130 + hindex * 165, 60, 130, 10, 0x3A);

   //                 //On ajoute l'icone en tant que bouton pour lancer le sort
   //                 AddButton(140 + hindex * 165, 75, info.ImageID, info.ImageID, info.SpellID, GumpButtonType.Reply, 0);
   //                 AddLabel(190 + hindex * 165, 78, namecolor, "Cercle : " + info.Cercle.ToString());

   //                 int buttonID = 2224;

   //                 if (m.QuickSpells.Contains(info.SpellID))
   //                     buttonID = 2223;

   //                 //On ajoute les boutons pour le lancement rapide
   //                 AddLabel(210 + hindex * 165, 98, 0, "Rapide");
   //                 AddButton(190 + hindex * 165, 101, buttonID, buttonID, info.SpellID + 200, GumpButtonType.Reply, 0);

   //                 //On ajoute les infos diverses
   //                 AddLabel(130 + hindex * 165, 120, 567, "Reagents:");
   //                 for (int j = 0; j < info.Reagents.Length; j++)
   //                 {
   //                     Type type = (Type)info.Reagents[j];
   //                     AddLabel(130 + hindex * 165, 138 + j * 18, 0, type.Name);
   //                 }

   //                 AddLabel(130 + hindex * 165, 192, namecolor, name + " " + info.AptitudeLevel);

   //                 //On augmente le nombre de sort de 1 pour le prochain sort.
   //                 value++;
   //             }
   //         }

   //         totpage++;
   //         AddPage(totpage);
   //         AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, totpage - 1);
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

				if (info.ButtonID == 18 && m_Page < (m_SpellBookEntry.Length / 20))
                    pm.SendGump(new NewSpellbookGump(pm, m_Book, m_Page + 1));
				else if (info.ButtonID == 19 && m_Page > 0)
					pm.SendGump(new NewSpellbookGump(pm, m_Book, m_Page - 1));
				else if (info.ButtonID >= 600 && info.ButtonID < 800)
                {
                    Spell spell = SpellRegistry.NewSpell(info.ButtonID, pm, null);

                    if (spell != null)
                        spell.Cast();

                    pm.SendGump(new NewSpellbookGump(pm, m_Book, m_Page));
                }
                else if (info.ButtonID >= 800 && info.ButtonID < 1000)
                {
                    if (pm.QuickSpells == null)
                        return;

                    if (pm.QuickSpells.Contains((int)(info.ButtonID - 200)))
                    {
                        pm.SendMessage("Le sort a été retiré de votre liste de lancement rapide.");
                        pm.QuickSpells.Remove((int)(info.ButtonID - 200));
                    }
                    else
                    {
                        pm.SendMessage("Le sort a été ajouté à votre liste de lancement rapide.");
                        pm.QuickSpells.Add((int)(info.ButtonID - 200));
                    }

                    pm.SendGump(new NewSpellbookGump(pm, m_Book, m_Page));
                }
            }
        }
    }
}