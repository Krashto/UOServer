using System; 
using System.Collections; 
using Server.Items; 
using Server.Mobiles; 
using Server.Network; 
using Server.Spells; 
using Server.Custom.Aptitudes;

namespace Server.Gumps
{
    public class SpellBookEntry
    {
        private int m_ConnaissanceLevel;
        private string m_Nom;
        private Type[] m_Reagents;
        private int m_ImageID;
        private int m_Cercle;
        private NAptitude m_Aptitude;
        private int m_SpellID;

        public int ConnaissanceLevel { get { return m_ConnaissanceLevel; } }
        public string Nom { get { return m_Nom; } }
        public Type[] Reagents { get { return m_Reagents; } }
        public int ImageID { get { return m_ImageID; } }
        public int Cercle { get { return m_Cercle; } }
        public NAptitude Connaissance { get { return m_Aptitude; } }
        public int SpellID { get { return m_SpellID; } }

        public SpellBookEntry(int conn, NAptitude connaissance, string nom, Type[] regs, int imageid, int cercle, int spellid)
        {
            m_ConnaissanceLevel = conn;
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
            new SpellBookEntry( 1, NAptitude.Arcanique, "Nourriture", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(MandrakeRoot) }, 0x8c1, 1, 600),
            new SpellBookEntry( 1, NAptitude.Arcanique, "Agilite", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot) }, 0x8c8, 1, 608),
            new SpellBookEntry( 1, NAptitude.Arcanique, "Vision de nuit", new Type[] { typeof(SulfurousAsh), typeof(SpidersSilk) }, 0x8c5, 1, 601),
            new SpellBookEntry( 2, NAptitude.Arcanique, "Flèche magique", new Type[] { typeof(SulfurousAsh) }, 0x8c4, 1, 602),
            new SpellBookEntry( 3, NAptitude.Arcanique, "Force", new Type[] { typeof(MandrakeRoot), typeof(Nightshade)  }, 0x8cf, 1, 607),
            new SpellBookEntry( 4, NAptitude.Arcanique, "Intelligence", new Type[] { typeof(MandrakeRoot), typeof(Nightshade) }, 0x8c9, 2, 611),
            new SpellBookEntry( 4, NAptitude.Arcanique, "Téléportation", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot) }, 0x8d5, 3, 683),
            new SpellBookEntry( 5, NAptitude.Arcanique, "Bénédiction", new Type[] { typeof(Garlic), typeof(MandrakeRoot) }, 0x8d0, 4, 613),
            new SpellBookEntry( 6, NAptitude.Arcanique, "Rappel", new Type[] { typeof(BlackPearl), typeof(Bloodmoss), typeof(MandrakeRoot) }, 0x8df, 5, 684),
            new SpellBookEntry( 7, NAptitude.Arcanique, "Malédiction", new Type[] { typeof(Nightshade), typeof(Garlic), typeof(SulfurousAsh) }, 0x8da, 5, 614),
            new SpellBookEntry( 8, NAptitude.Arcanique, "Crochetage", new Type[] { typeof(Garlic), typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8d6, 3, 691),
            new SpellBookEntry( 8, NAptitude.Arcanique, "Télékinésie", new Type[] { typeof(MandrakeRoot), typeof(Bloodmoss) }, 0x8d4, 2, 606),
            new SpellBookEntry( 9, NAptitude.Arcanique, "Invisibilité", new Type[] { typeof(Nightshade), typeof(Bloodmoss), typeof(BlackPearl) }, 0x8eb, 5, 693),
            new SpellBookEntry( 10, NAptitude.Arcanique, "Évasion", new Type[] { typeof(BlackPearl) }, 0x5326, 1, 685),
            new SpellBookEntry( 11, NAptitude.Arcanique, "Marquage", new Type[] { typeof(BlackPearl), typeof(Bloodmoss), typeof(MandrakeRoot) }, 0x8ec, 8, 687),
            new SpellBookEntry( 12, NAptitude.Arcanique, "Trou de ver", new Type[] { typeof(BlackPearl), typeof(MandrakeRoot), typeof(SulfurousAsh) }, 0x8f3, 7, 686),

            new SpellBookEntry( 2, NAptitude.Defense, "Dissipation", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SulfurousAsh) }, 0x8e8, 3, 623),
            new SpellBookEntry( 3, NAptitude.Defense, "Protection", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(SulfurousAsh) }, 0x8ce, 2, 636),
            new SpellBookEntry( 3, NAptitude.Defense, "Secours", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SulfurousAsh) }, 0x12f, 5, 637),
            new SpellBookEntry( 4, NAptitude.Defense, "Révélation", new Type[] { typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8ef, 1, 622),
            new SpellBookEntry( 6, NAptitude.Defense, "Dissipation de mur", new Type[] { typeof(BlackPearl), typeof(SpidersSilk), typeof(Garlic) }, 0x8e1, 4, 625),
            new SpellBookEntry( 7, NAptitude.Defense, "Dissipation massive", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(BlackPearl) }, 0x8f5, 6, 626),
            new SpellBookEntry( 8, NAptitude.Defense, "Armure magique", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x11a, 7, 624),
            new SpellBookEntry( 9, NAptitude.Defense, "Armure", new Type[] { typeof(Garlic), typeof(SpidersSilk), typeof(SulfurousAsh) }, 0x8c6, 8, 634),
            new SpellBookEntry( 10, NAptitude.Defense, "Champ De Stase", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(BlackPearl) }, 0x12e, 7, 639),
            new SpellBookEntry( 11, NAptitude.Defense, "Copie", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(MandrakeRoot) }, 0x8d9, 6, 638),
            new SpellBookEntry( 12, NAptitude.Defense, "Dérobade", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SulfurousAsh) }, 0x12b, 8, 627),

            new SpellBookEntry( 1, NAptitude.Destruction, "Tremblements", new Type[] { typeof(Bloodmoss), typeof(Ginseng), typeof(SulfurousAsh) }, 0x8f8, 3, 658),
            new SpellBookEntry( 3, NAptitude.Destruction, "Éclair", new Type[] { typeof(BlackPearl), typeof(MandrakeRoot), typeof(SulfurousAsh) }, 0x8dd, 4, 653),
            new SpellBookEntry( 4, NAptitude.Destruction, "Explosion", new Type[] { typeof(SulfurousAsh), typeof(SulfurousAsh), typeof(Bloodmoss) }, 0x8ea, 4, 659),
            new SpellBookEntry( 5, NAptitude.Destruction, "Boule de glace", new Type[] { typeof(BlackPearl), typeof(Ginseng), typeof(Garlic) }, 0x127, 5, 654),
            new SpellBookEntry( 6, NAptitude.Destruction, "Boule d'énergie", new Type[] { typeof(Nightshade), typeof(BlackPearl), typeof(Garlic) }, 0x8e9, 6, 655),
            new SpellBookEntry( 7, NAptitude.Destruction, "Séisme", new Type[] { typeof(SulfurousAsh), typeof(Bloodmoss), typeof(Bloodmoss) }, 0x13d, 5, 660),
            new SpellBookEntry( 8, NAptitude.Destruction, "Éclair en chaîne", new Type[] { typeof(BlackPearl), typeof(Bloodmoss), typeof(MandrakeRoot) }, 0x8f0, 7, 661),
            new SpellBookEntry( 9, NAptitude.Destruction, "Jet de feu", new Type[] { typeof(SpidersSilk), typeof(SulfurousAsh), typeof(BlackPearl) }, 0x8f2, 7, 656),
            new SpellBookEntry( 10, NAptitude.Destruction, "Météores", new Type[] { typeof(SulfurousAsh), typeof(SulfurousAsh), typeof(SulfurousAsh) }, 0x8f6, 8, 662),
            new SpellBookEntry( 11, NAptitude.Destruction, "Fulguration", new Type[] { typeof(MandrakeRoot), typeof(SulfurousAsh), typeof(Ginseng) }, 0x126, 8, 657),
            new SpellBookEntry( 12, NAptitude.Destruction, "Vortex", new Type[] { typeof(Nightshade), typeof(Garlic), typeof(Bloodmoss) }, 0x148, 8, 663),

            new SpellBookEntry( 1, NAptitude.Invocation, "Créatures", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8e7, 1, 664),
            new SpellBookEntry( 3, NAptitude.Invocation, "Esprit animal", new Type[] { typeof(Bloodmoss), typeof(BlackPearl) }, 0x123, 3, 670),
            new SpellBookEntry( 4, NAptitude.Invocation, "Élém. : Terre", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot), typeof(BlackPearl) }, 0x8fd, 3, 665),
            new SpellBookEntry( 5, NAptitude.Invocation, "Élém. : Air", new Type[] { typeof(Ginseng), typeof(MandrakeRoot), typeof(Nightshade) }, 0x8fb, 4, 666),
            new SpellBookEntry( 6, NAptitude.Invocation, "Esprit de lames", new Type[] { typeof(BlackPearl), typeof(MandrakeRoot), typeof(Nightshade) }, 0x8e0, 5, 671),
            new SpellBookEntry( 7, NAptitude.Invocation, "Élém. : Feu", new Type[] { typeof(SulfurousAsh), typeof(SulfurousAsh), typeof(SpidersSilk) }, 0x8fe, 6, 667),
            new SpellBookEntry( 8, NAptitude.Invocation, "Élém. : Eau", new Type[] { typeof(BlackPearl), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8ff, 7, 668),
            new SpellBookEntry( 9, NAptitude.Invocation, "Élém. : Cristal", new Type[] { typeof(BlackPearl), typeof(BlackPearl), typeof(SpidersSilk) }, 0x11f, 8, 669),
            new SpellBookEntry( 10, NAptitude.Invocation, "Esprit d'énergie", new Type[] { typeof(BlackPearl), typeof(Nightshade), typeof(Bloodmoss) }, 0x8f9, 6, 672),
            new SpellBookEntry( 11, NAptitude.Invocation, "Esprit du dragon", new Type[] { typeof(Bloodmoss), typeof(Bloodmoss), typeof(Bloodmoss) }, 0x5322, 7, 673),
            new SpellBookEntry( 12, NAptitude.Invocation, "Démon", new Type[] { typeof(Bloodmoss), typeof(Garlic), typeof(SpidersSilk) }, 0x8fc, 8, 674),

            new SpellBookEntry( 1, NAptitude.Medecine, "Antidote", new Type[] { typeof(Garlic), typeof(Ginseng) }, 0x8ca, 1, 628),
            new SpellBookEntry( 2, NAptitude.Medecine, "Malaise", new Type[] { typeof(Garlic), typeof(SulfurousAsh), typeof(Ginseng) }, 0x08e5, 1, 678),
            new SpellBookEntry( 3, NAptitude.Medecine, "Guérison", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(SpidersSilk) }, 0x8c3, 2, 629),
            new SpellBookEntry( 4, NAptitude.Medecine, "Résurrection", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(Bloodmoss) }, 0x8fa, 6, 633),
            new SpellBookEntry( 5, NAptitude.Medecine, "Antidote massif", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(MandrakeRoot) }, 0x8d8, 4, 630),
            new SpellBookEntry( 6, NAptitude.Medecine, "Guérison majeure", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(SpidersSilk) }, 0x8dc, 7, 631),
            new SpellBookEntry( 7, NAptitude.Medecine, "Souffle d'esprit", new Type[] { typeof(BlackPearl), typeof(MandrakeRoot), typeof(Garlic) }, 0x8e4, 4, 679),
            new SpellBookEntry( 8, NAptitude.Medecine, "Drain vampirique", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8f4, 6, 680),
            new SpellBookEntry( 9, NAptitude.Medecine, "Jet de douleur", new Type[] { typeof(GraveDust), typeof(PigIron), typeof(BatWing) }, 0x164, 8, 707),
            new SpellBookEntry( 10, NAptitude.Medecine, "Zone de guérison", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SulfurousAsh) }, 0x14a, 7, 632),
            new SpellBookEntry( 12, NAptitude.Medecine, "Étouffements", new Type[] { typeof(SulfurousAsh), typeof(Ginseng), typeof(MandrakeRoot) }, 0x8e5, 7, 681),

            new SpellBookEntry( 2, NAptitude.Nature, "Abeilles", new Type[] { typeof(BlackPearl), typeof(Bloodmoss), typeof(Garlic) }, 0x135, 2, 647),
            new SpellBookEntry( 2, NAptitude.Nature, "Poison mineur", new Type[] { typeof(Nightshade) }, 0x134, 1, 640),
            new SpellBookEntry( 4, NAptitude.Nature, "Poison", new Type[] { typeof(NoxCrystal), typeof(Nightshade), typeof(SulfurousAsh) }, 0x8d3, 3, 641),
            new SpellBookEntry( 6, NAptitude.Nature, "Boule de feu", new Type[] { typeof(BlackPearl), typeof(Garlic), typeof(SulfurousAsh) }, 0x8d1, 2, 652),
            new SpellBookEntry( 8, NAptitude.Nature, "Geyser", new Type[] { typeof(BlackPearl), typeof(SpidersSilk), typeof(Ginseng) }, 0x128, 3, 618),
            new SpellBookEntry( 10, NAptitude.Nature, "Cri d'ours", new Type[] { typeof(Bloodmoss), typeof(Ginseng), typeof(Garlic) }, 0x59e4, 1, 649),
            new SpellBookEntry( 12, NAptitude.Nature, "Armure de pierre", new Type[] { typeof(Bloodmoss), typeof(Ginseng), typeof(SpidersSilk) }, 0x59e0, 6, 650),
            new SpellBookEntry( 12, NAptitude.Nature, "Racines", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x122, 5, 646),

            new SpellBookEntry( 1, NAptitude.Necromancie, "Familier", new Type[] { typeof(BatWing), typeof(GraveDust), typeof(DaemonBlood) }, 0x151, 2, 708),
            new SpellBookEntry( 2, NAptitude.Necromancie, "Calamité", new Type[] { typeof(PigIron) }, 0x5003, 2, 702),
            new SpellBookEntry( 3, NAptitude.Necromancie, "Peau de mort", new Type[] { typeof(BatWing), typeof(GraveDust) }, 0x167, 4, 703),
            new SpellBookEntry( 4, NAptitude.Necromancie, "Mur de poison", new Type[] { typeof(Garlic), typeof(Nightshade), typeof(NoxCrystal) }, 0x8e6, 6, 643),
            new SpellBookEntry( 5, NAptitude.Necromancie, "Jet de poison", new Type[] { typeof(NoxCrystal), typeof(Nightshade), typeof(BlackPearl) }, 0x137, 4, 642),
            new SpellBookEntry( 6, NAptitude.Necromancie, "Mauvais présage", new Type[] { typeof(BatWing), typeof(NoxCrystal) }, 0x161, 5, 704),
            new SpellBookEntry( 7, NAptitude.Necromancie, "Serment de sang", new Type[] { typeof(DaemonBlood), typeof(Garlic) }, 0x5001, 7, 706),
            new SpellBookEntry( 8, NAptitude.Necromancie, "Strangulaire", new Type[] { typeof(Bloodmoss), typeof(NoxCrystal), typeof(GraveDust) }, 0x59e3, 5, 710),
            new SpellBookEntry( 9, NAptitude.Necromancie, "Appel de la liche", new Type[] { typeof(GraveDust), typeof(DaemonBlood), typeof(PigIron) }, 0x168, 8, 712),
            new SpellBookEntry( 10, NAptitude.Necromancie, "Réanimation", new Type[] { typeof(GraveDust), typeof(DaemonBlood), typeof(DaemonBlood) }, 0x147, 6, 711),
            new SpellBookEntry( 11, NAptitude.Necromancie, "Pluie acide", new Type[] { typeof(Nightshade), typeof(Bloodmoss), typeof(NoxCrystal) }, 0x59e5, 7, 644),
            new SpellBookEntry( 12, NAptitude.Necromancie, "Pincée acide", new Type[] { typeof(Nightshade), typeof(NoxCrystal), typeof(BlackPearl) }, 0x133, 8, 645),

            //new SpellBookEntry( 4, NAptitude.Necromagie, "Lance d'os", new Type[] { typeof(MandrakeRoot), typeof(Garlic), typeof(PigIron) }, 0x12a, 6, 705),

            //new SpellBookEntry( 2, NAptitude.Necromancie, "Défraîcheur", new Type[] { typeof(NoxCrystal), typeof(GraveDust), typeof(PigIron) }, 0x500E, 3, 709),
            //new SpellBookEntry( 6, NAptitude.Necromancie, "Insurrection", new Type[] { typeof(GraveDust), typeof(GraveDust), typeof(DaemonBlood) }, 0x11c, 8, 713)

            //new SpellBookEntry( 6, NAptitude.Invocation, "Esprit vengeur", new Type[] { typeof(BlackPearl), typeof(BlackPearl), typeof(SulfurousAsh) }, 0x13f, 8, 675),

            //new SpellBookEntry( 2, NAptitude.Protection, "Réflection", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8e3, 4, 635),
            //new SpellBookEntry( 1, NAptitude.Transport, "Endurance", new Type[] { typeof(Bloodmoss), typeof(Ginseng), typeof(Garlic) }, 0x5323, 2, 682),

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
            //new SpellBookEntry( 6, NAptitude.Adjuration, "Mur de paralysie", new Type[] { typeof(MandrakeRoot), typeof(Ginseng), typeof(SpidersSilk) }, 0x8ee, 7, 621),

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

        public bool HasSpell(Mobile from, int spellID)
        {
            return (m_Book.HasSpell(spellID));
        }
        
        #region tableaux
        //Liste des magies du spellbook et leur couleur
        public NAptitude[] m_ConnaissanceList = new NAptitude[] {
            NAptitude.Arcanique,
            NAptitude.Defense,
            NAptitude.Destruction, 
            NAptitude.Medecine, 
            NAptitude.Nature,
            NAptitude.Invocation, 
            NAptitude.Necromancie
        };

        public Hashtable m_NameColors = new Hashtable();
        public Hashtable m_Names = new Hashtable();

        public void InitializeHashtable()
        {
            m_NameColors[NAptitude.Arcanique] = 498;
            m_NameColors[NAptitude.Defense] = 140;
            m_NameColors[NAptitude.Destruction] = 1450;
            m_NameColors[NAptitude.Medecine] = 340;
            m_NameColors[NAptitude.Nature] = 1050;
            m_NameColors[NAptitude.Invocation] = 2052;
            m_NameColors[NAptitude.Necromancie] = 12;

            m_Names[NAptitude.Arcanique] = "Arcanique";
            m_Names[NAptitude.Defense] = "Défense";
            m_Names[NAptitude.Destruction] = "Destruction";
            m_Names[NAptitude.Medecine] = "Médecine";
            m_Names[NAptitude.Nature] = "Nature";
            m_Names[NAptitude.Invocation] = "Invocation";
            m_Names[NAptitude.Necromancie] = "Necromancie";
        }
        #endregion

        private NewSpellbook m_Book;

        public NewSpellbookGump(Mobile from, NewSpellbook book) : base(150, 200)
        {
            InitializeHashtable();

            m_Book = book;
            int vindex = 0;
            int totpage = 0;
            int hindex = 0;

            if (!(from is CustomPlayerMobile))
                return;

            CustomPlayerMobile m = (CustomPlayerMobile)from;

            AddPage(0);
            AddImage(100, 10, 2201);

            int oldconnaissance = -1;
            int newconnaissance = -1;

            int value = 0;

            //Pour tous les sorts
            for (int i = 0; i < m_SpellBookEntry.Length; i++)
            {
                SpellBookEntry info = (SpellBookEntry)m_SpellBookEntry[i];

                //on assigne la nouvelle connaissance
                newconnaissance = (int)info.Connaissance;

                //on fait la comparaison des Aptitude pour savoir si on a changé de connaissance
                if (newconnaissance != -1 && newconnaissance != oldconnaissance)
                {
                    totpage++;
                    AddPage(totpage);
                    hindex = 0;

                    //On ajoute le nom de la connaissance
                    AddLabel(160 + hindex * 145, 25, (int)m_NameColors[info.Connaissance], (string)m_Names[info.Connaissance]);

                    // Séparateurs
                    AddImageTiled(130 + hindex * 165, 40, 130, 10, 0x3A);

                    //On remet à 0 pour la nouvelle page
                    vindex = 0;

                    //On ajoute les boutons de changement de page
                    AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, totpage + 1);
                    AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, totpage - 1);
                }

                //Si le livre possède le sort
                if (HasSpell(from, info.SpellID) && ArrayContains(m_ConnaissanceList, info.Connaissance))
                {
                    int buttonID = 2224;

                    if (m.QuickSpells.Contains(info.SpellID))
                        buttonID = 2223;

                    //On ajoute l'information et les boutons
                    AddLabel(162 + hindex * 160, 54 + (vindex * 17), 0, info.Nom);
                    AddButton(127 + hindex * 160, 59 + (vindex * 17), 2103, 2104, info.SpellID, GumpButtonType.Reply, 0);
                    AddButton(140 + hindex * 160, 58 + (vindex * 17), buttonID, buttonID, info.SpellID + 200, GumpButtonType.Reply, 0);
                    vindex++;

                    if (vindex >= 9)
                    {
                        vindex = 0;
                        hindex = 1;
                    }
                }

                oldconnaissance = (int)info.Connaissance;
             }

            value = 0;

            //Pour tous les sorts
            for (int i = 0; i < m_SpellBookEntry.Length; i++)
            {
                SpellBookEntry info = (SpellBookEntry)m_SpellBookEntry[i];

                //Si le livre possède le sort
                if (this.HasSpell(from, info.SpellID) && ArrayContains(m_ConnaissanceList, info.Connaissance))
                {
                    //Si le # du sort est pair...
                    if (value % 2 == 0)
                    {
                        //On fait une page
                        totpage++;
                        AddPage(totpage);
                        hindex = 0;

                        //On ajoute les boutons de pages
                        AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, totpage - 1);
                        AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, totpage + 1);
                    }
                    else
                        hindex = 1;

                    int namecolor = 0;
                    string name = "...";

                    if (m_NameColors.Contains(info.Connaissance))
                        namecolor = (int)m_NameColors[info.Connaissance];

                    if (m_Names.Contains(info.Connaissance))
                        name = (string)m_Names[info.Connaissance];

                    //On ajoute le nom
                    AddLabel(130 + hindex * 165, 45, namecolor, info.Nom);

                    //On ajoute les séparateurs
                    AddImageTiled(130 + hindex * 165, 60, 130, 10, 0x3A);

                    //On ajoute l'icone en tant que bouton pour lancer le sort
                    AddButton(140 + hindex * 165, 75, info.ImageID, info.ImageID, info.SpellID, GumpButtonType.Reply, 0);
                    AddLabel(190 + hindex * 165, 78, namecolor, "Cercle : " + info.Cercle.ToString());

                    int buttonID = 2224;

                    if (m.QuickSpells.Contains(info.SpellID))
                        buttonID = 2223;

                    //On ajoute les boutons pour le lancement rapide
                    AddLabel(210 + hindex * 165, 98, 0, "Rapide");
                    AddButton(190 + hindex * 165, 101, buttonID, buttonID, info.SpellID + 200, GumpButtonType.Reply, 0);

                    //On ajoute les infos diverses
                    AddLabel(130 + hindex * 165, 120, 567, "Reagents:");
                    for (int j = 0; j < info.Reagents.Length; j++)
                    {
                        Type type = (Type)info.Reagents[j];
                        AddLabel(130 + hindex * 165, 138 + j * 18, 0, type.Name);
                    }

                    AddLabel(130 + hindex * 165, 192, namecolor, name + " " + info.ConnaissanceLevel);

                    //On augmente le nombre de sort de 1 pour le prochain sort.
                    value++;
                }
            }

            totpage++;
            AddPage(totpage);
            AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, totpage - 1);
        }

        public bool ArrayContains(NAptitude[] conn, NAptitude wanted)
        {
            for (int i = 0; i < conn.Length; i++)
            {
                if (wanted == (NAptitude)conn[i])
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
                CustomPlayerMobile m = (CustomPlayerMobile)from;

                if (info.ButtonID >= 600 && info.ButtonID < 800)
                {
                    Spell spell = SpellRegistry.NewSpell(info.ButtonID, m, null);

                    if (spell != null)
                        spell.Cast();

                    m.SendGump(new NewSpellbookGump(m, m_Book));
                }
                else if (info.ButtonID >= 800 && info.ButtonID < 1000)
                {
                    if (m.QuickSpells == null)
                        return;

                    if (m.QuickSpells.Contains((int)(info.ButtonID - 200)))
                    {
                        m.SendMessage("Le sort a été retiré de votre liste de lancement rapide.");
                        m.QuickSpells.Remove((int)(info.ButtonID - 200));
                    }
                    else
                    {
                        m.SendMessage("Le sort a été ajouté à votre liste de lancement rapide.");
                        m.QuickSpells.Add((int)(info.ButtonID - 200));
                    }

                    m.SendGump(new NewSpellbookGump(m, m_Book));
                }
            }
        }
    }
}