using System; 
using System.Collections; 
using Server.Items; 
using Server.Mobiles; 
using Server.Network; 
using Server.Spells; 
using Server.Custom.Aptitudes;

namespace Server.Gumps
{
    public class DivineSpellBookEntry
    {
        private int m_ConnaissanceLevel;
        private string m_Nom;
        private int m_ImageID;
        private int m_Cercle;
        private NAptitude m_Aptitude;
        private int m_SpellID;

        public int ConnaissanceLevel { get { return m_ConnaissanceLevel; } }
        public string Nom { get { return m_Nom; } }
        public int ImageID { get { return m_ImageID; } }
        public int Cercle { get { return m_Cercle; } }
        public NAptitude Aptitude { get { return m_Aptitude; } }
        public int SpellID { get { return m_SpellID; } }
        public int Pdp { get { return Spell.m_PdPTable[(int)Cercle - 1]; } }

        public DivineSpellBookEntry(int conn, NAptitude connaissance, string nom, int imageid, int cercle, int spellid)
        {
            m_ConnaissanceLevel = conn;
            m_Nom = nom;
            m_ImageID = imageid;
            m_Cercle = cercle;
            m_Aptitude = connaissance;
            m_SpellID = spellid;
        }
    }

    public class NewDivineSpellbookGump : Gump
    {
        public static DivineSpellBookEntry[] m_DivineSpellBookEntry = new DivineSpellBookEntry[]
        {
            new DivineSpellBookEntry( 1, NAptitude.MagieAncestrale, "Vision réelle", 0x166, 1, 1063),
            new DivineSpellBookEntry( 2, NAptitude.MagieAncestrale, "Errance", 0x124, 2, 1025),
            new DivineSpellBookEntry( 3, NAptitude.MagieAncestrale, "Poing de valeur", 0x15c, 3, 1001),
            new DivineSpellBookEntry( 4, NAptitude.MagieAncestrale, "Aura de fatigue", 0x5108, 4, 1048),
            new DivineSpellBookEntry( 5, NAptitude.MagieAncestrale, "Spiritualité", 0x5104, 5, 1058),
            new DivineSpellBookEntry( 6, NAptitude.MagieAncestrale, "Consécration", 0x5107, 5, 1021),
            new DivineSpellBookEntry( 7, NAptitude.MagieAncestrale, "Corps pur", 0x11d, 5, 1033),
            new DivineSpellBookEntry( 8, NAptitude.MagieAncestrale, "Souplesse", 0x5420, 6, 1032),
            new DivineSpellBookEntry( 9, NAptitude.MagieAncestrale, "Passion", 0x15b, 6, 1016),
            new DivineSpellBookEntry( 10, NAptitude.MagieAncestrale, "Soif du combat", 0x5201, 7, 1059),
            new DivineSpellBookEntry( 10, NAptitude.MagieAncestrale, "Don des rochers", 0x120, 7, 1070),
            new DivineSpellBookEntry( 10, NAptitude.MagieAncestrale, "Baril de bière", 0x13a, 7, 1067),
            new DivineSpellBookEntry( 11, NAptitude.MagieAncestrale, "Pourrissement", 0x5100, 7, 1053),
            new DivineSpellBookEntry( 11, NAptitude.MagieAncestrale, "Fétichisme", 0x5325, 7, 1028),
            new DivineSpellBookEntry( 11, NAptitude.MagieAncestrale, "Voodoo", 0x80B, 7, 1029),
            new DivineSpellBookEntry( 12, NAptitude.MagieAncestrale, "Labyrinthe", 0x149, 8, 1062),

            new DivineSpellBookEntry( 1, NAptitude.MagieAncestrale, "Talisman", 0x163, 1, 1066),
            new DivineSpellBookEntry( 2, NAptitude.MagieAncestrale, "Pied ancré", 0x5324, 2, 1030),
            new DivineSpellBookEntry( 3, NAptitude.MagieAncestrale, "Robustesse", 0x142, 3, 1031),
            new DivineSpellBookEntry( 4, NAptitude.MagieAncestrale, "Haute précision", 0x5216, 4, 1018),
            new DivineSpellBookEntry( 5, NAptitude.MagieAncestrale, "Agglomération", 0x119, 5, 1019),
            new DivineSpellBookEntry( 6, NAptitude.MagieAncestrale, "Point de paresse", 0x136, 6, 1068),
            new DivineSpellBookEntry( 7, NAptitude.MagieAncestrale, "Berseck", 0x5109, 7, 1056),
            new DivineSpellBookEntry( 8, NAptitude.MagieAncestrale, "Purification", 0x15f, 7, 1014),
            new DivineSpellBookEntry( 9, NAptitude.MagieAncestrale, "Soutien", 0x140, 7, 1069),
            new DivineSpellBookEntry( 10, NAptitude.MagieAncestrale, "Voile", 0x13c, 8, 1044),
            new DivineSpellBookEntry( 11, NAptitude.MagieAncestrale, "Appui", 0x14f, 8, 1064),
            new DivineSpellBookEntry( 12, NAptitude.MagieAncestrale, "Mortification", 0x5200, 8, 1049),

            //new DivineSpellBookEntry( 1, NAptitude.Pretre, "Vision divine", 0x146, 1, 1000),
            //new DivineSpellBookEntry( 3, NAptitude.Pretre, "Essouflement", 0x520E, 3, 1002),
            //new DivineSpellBookEntry( 4, NAptitude.Pretre, "Lumière divine", 0x59E6, 4, 1003),
            //new DivineSpellBookEntry( 5, NAptitude.Pretre, "Imbroglio", 0x59E1, 5, 1005),
            //new DivineSpellBookEntry( 6, NAptitude.Pretre, "Griffes", 0x5212, 6, 1004),

            //new DivineSpellBookEntry( 1, NAptitude.Pretre, "Rétablissement", 0x5320, 1, 1006),
            //new DivineSpellBookEntry( 2, NAptitude.Pretre, "Régénération", 0x15f, 2, 1007),
            //new DivineSpellBookEntry( 3, NAptitude.Pretre, "Bouclier", 0x11b, 4, 1008),
            //new DivineSpellBookEntry( 4, NAptitude.Pretre, "Amulette", 0x14b, 5, 1009),
            //new DivineSpellBookEntry( 5, NAptitude.Pretre, "Réfecteur", 0x145, 7, 1010),
            //new DivineSpellBookEntry( 6, NAptitude.Pretre, "Miracle", 0x13b, 8, 1011),

            //new DivineSpellBookEntry( 1, NAptitude.Pretre, "Répartition", 0x520F, 1, 1012),
            //new DivineSpellBookEntry( 2, NAptitude.Pretre, "Renouvellement", 0x139, 3, 1013),
            //new DivineSpellBookEntry( 4, NAptitude.Pretre, "Promptitude", 0x5321, 6, 1015),
            //new DivineSpellBookEntry( 6, NAptitude.Pretre, "Régénérescence", 0x160, 8, 1017),

            //new DivineSpellBookEntry( 3, NAptitude.Pretre, "Rudesse", 0x59D9, 4, 1020),
            //new DivineSpellBookEntry( 5, NAptitude.Pretre, "Confession", 0x5208, 6, 1022),
            //new DivineSpellBookEntry( 6, NAptitude.Pretre, "Force de la foi", 0x59DB, 7, 1023),

            //new DivineSpellBookEntry( 1, NAptitude.Pretre, "Famine", 0x125, 2, 1024),
            //new DivineSpellBookEntry( 3, NAptitude.Pretre, "Bêtes", 0x11e, 4, 1026),
            //new DivineSpellBookEntry( 4, NAptitude.Pretre, "Hypnose", 0x158, 5, 1027),

            //new DivineSpellBookEntry( 5, NAptitude.Pretre, "Éternelle jeunesse", 0x5426, 7, 1034),
            //new DivineSpellBookEntry( 6, NAptitude.Pretre, "Prouesse", 0x15d, 8, 1035),

            //new DivineSpellBookEntry( 1, NAptitude.Pretre, "Conscience", 0x131, 1, 1036),
            //new DivineSpellBookEntry( 2, NAptitude.Pretre, "Appel de la nature", 0x144, 2, 1037),
            //new DivineSpellBookEntry( 3, NAptitude.Pretre, "Animaux", 0x14c, 4, 1038),
            //new DivineSpellBookEntry( 4, NAptitude.Pretre, "Instinct charnel", 0x59DE, 5, 1039),
            //new DivineSpellBookEntry( 5, NAptitude.Pretre, "Domination", 0x59D8, 7, 1041),
            //new DivineSpellBookEntry( 6, NAptitude.Pretre, "Transfert", 0x14d, 8, 1040),

            //new DivineSpellBookEntry( 1, NAptitude.Pretre, "Plume", 0x5203, 2, 1042),
            //new DivineSpellBookEntry( 2, NAptitude.Pretre, "Intrinsèque", 0x159, 3, 1043),
            //new DivineSpellBookEntry( 4, NAptitude.Pretre, "Écho", 0x5425, 5, 1045),
            //new DivineSpellBookEntry( 5, NAptitude.Pretre, "Stupéfaction", 0x162, 7, 1046),
            //new DivineSpellBookEntry( 6, NAptitude.Pretre, "Déchéance", 0x152, 8, 1047),

            //new DivineSpellBookEntry( 3, NAptitude.Pretre, "Exécration", 0x5103, 4, 1050),
            //new DivineSpellBookEntry( 4, NAptitude.Pretre, "Halène putride", 0x157, 5, 1051),
            //new DivineSpellBookEntry( 5, NAptitude.Pretre, "Horreur", 0x59DD, 7, 1052),

            //new DivineSpellBookEntry( 1, NAptitude.Pretre, "Courage", 0x5211, 2, 1054),
            //new DivineSpellBookEntry( 2, NAptitude.Pretre, "Sagesse", 0x59E2, 3, 1055),
            //new DivineSpellBookEntry( 4, NAptitude.Pretre, "Transcendance", 0x5105, 5, 1057),

            //new DivineSpellBookEntry( 1, NAptitude.Pretre, "Sauvegarde", 0x5207, 2, 1060),
            //new DivineSpellBookEntry( 2, NAptitude.Pretre, "Exaltation", 0x155, 3, 1061),
            //new DivineSpellBookEntry( 6, NAptitude.Pretre, "Patronage", 0x121, 8, 1065),

            //new DivineSpellBookEntry( 6, NAptitude.Pretre, "Couverture", 0x5106, 8, 1071),
        };

        public bool HasSpell(Mobile from, int spellID)
        {
            return (m_Book.HasSpell(spellID));
        }
        
        #region tableaux
        //Liste des magies du spellbook et leur couleur
        public NAptitude[] m_DivineConnaissanceList = new NAptitude[] {
            NAptitude.MagieAncestrale,  
        };
        
        public Hashtable m_DivineNameColors = new Hashtable();
        public Hashtable m_DivineNames = new Hashtable();

        public void InitializeHashtable()
        {
            m_DivineNameColors[NAptitude.MagieAncestrale] = 498;
            m_DivineNames[NAptitude.MagieAncestrale] = "Magie Ancestrale";
        }
        #endregion

        private NewDivineSpellbook m_Book;

        public NewDivineSpellbookGump(Mobile from, NewDivineSpellbook book) : base(150, 200)
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
            for (int i = 0; i < m_DivineSpellBookEntry.Length; i++)
            {
                DivineSpellBookEntry info = (DivineSpellBookEntry)m_DivineSpellBookEntry[i];
                //on assigne la nouvelle connaissance
                newconnaissance = (int)info.Aptitude;

                //on fait la comparaison des connaissances pour savoir si on a changé de connaissance
                if (newconnaissance != -1 && newconnaissance != oldconnaissance)
                {
                    totpage++;
                    AddPage(totpage);
                    hindex = 0;

                    //On ajoute le nom de la connaissance
                    AddLabel(160 + hindex * 145, 25, (int)m_DivineNameColors[info.Aptitude], (string)m_DivineNames[info.Aptitude]);

                    // Séparateurs
                    AddImageTiled(130 + hindex * 165, 40, 130, 10, 0x3A);

                    //On remet à 0 pour la nouvelle page
                    vindex = 0;

                    //On ajoute les boutons de changement de page
                    AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, totpage + 1);
                    AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, totpage - 1);
                }

                //Si le livre possède le sort
                if (this.HasSpell(from, info.SpellID) && ArrayContains(m_DivineConnaissanceList, info.Aptitude))
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

                oldconnaissance = (int)info.Aptitude;
             }

            value = 0;

            try
            {
                //Pour tous les sorts
                for (int i = 0; i < m_DivineSpellBookEntry.Length; i++)
                {
                    DivineSpellBookEntry info = (DivineSpellBookEntry)m_DivineSpellBookEntry[i];
                    //Si le livre possède le sort
                    if (this.HasSpell(from, info.SpellID) && ArrayContains(m_DivineConnaissanceList, info.Aptitude))
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

                        if (m_DivineNameColors.Contains(info.Aptitude))
                            namecolor = (int)m_DivineNameColors[info.Aptitude];

                        if (m_DivineNames.Contains(info.Aptitude))
                            name = (string)m_DivineNames[info.Aptitude];

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
                        AddLabel(130 + hindex * 165, 120, 0, "Pdp : " + info.Pdp);
                        AddLabel(130 + hindex * 165, 138, namecolor, name + " " + info.ConnaissanceLevel);

                        //On augmente le nombre de sort de 1 pour le prochain sort.
                        value++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
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

        public static DivineSpellBookEntry FindEntryBySpellID(int spellID)
        {
            for (int i = 0; i < m_DivineSpellBookEntry.Length; i++)
            {
                DivineSpellBookEntry info = (DivineSpellBookEntry)m_DivineSpellBookEntry[i];

                if (info.SpellID == spellID)
                    return info;
            }

            return null;
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            Mobile from = state.Mobile;

            if (from is CustomPlayerMobile)
            {
                CustomPlayerMobile m = (CustomPlayerMobile)from;

                if (info.ButtonID >= 1000 && info.ButtonID < 1200)
                {
                    Spell spell = SpellRegistry.NewSpell(info.ButtonID, m, null);

                    if (spell != null)
                        spell.Cast();

                    m.SendGump(new NewDivineSpellbookGump(m, m_Book));
                }
                else if (info.ButtonID >= 1200 && info.ButtonID < 1400)
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

                    m.SendGump(new NewDivineSpellbookGump(m, m_Book));
                }
            }
        }
    }
}