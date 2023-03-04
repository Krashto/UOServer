using System; 
using System.Collections; 
using Server; 
using Server.Items; 
using Server.Mobiles; 
using Server.Network; 
using Server.Spells; 
using Server.Prompts;
using Server.Custom.Aptitudes;

namespace Server.Gumps
{
    public enum BardType
    {
        None = 0,
        Barde = 1,
        Danseur = 2
    }
    
    public class BardSpellBookEntry
    {
        private string m_Nom;
        private int m_ImageID;
        private NAptitude m_Aptitudes;
        private int m_SpellID;
        private BardType m_BardType; 

        public string Nom { get { return m_Nom; } }
        public int ImageID { get { return m_ImageID; } }
        public NAptitude Aptitude { get { return m_Aptitudes; } }
        public int SpellID { get { return m_SpellID; } }
        public BardType BardType { get { return m_BardType; } }

        public BardSpellBookEntry(BardType bard, NAptitude aptitude, string nom, int imageid, int spellid)
        {
            m_BardType = bard;
            m_Nom = nom;
            m_ImageID = imageid;
            m_Aptitudes = aptitude;
            m_SpellID = spellid;
        }
    }

    public class NewBardSpellbookGump : Gump
    {
        public static BardSpellBookEntry[] m_BardSpellBookEntry = new BardSpellBookEntry[]
        {
            new BardSpellBookEntry( BardType.Barde, NAptitude.Musique, "Mélodie", 0x172,  1600),
            new BardSpellBookEntry( BardType.Barde, NAptitude.Musique, "Chant", 0x16a, 1601),
            new BardSpellBookEntry( BardType.Barde, NAptitude.Musique, "Murmure", 0x173,  1602),
            new BardSpellBookEntry( BardType.Barde, NAptitude.Musique, "Conte", 0x16c,  1603),
            new BardSpellBookEntry( BardType.Barde, NAptitude.Musique, "Sonnette", 0x178, 1604),
            new BardSpellBookEntry( BardType.Barde, NAptitude.Musique, "Hymne", 0x170, 1605),
            new BardSpellBookEntry( BardType.Barde, NAptitude.Musique, "Composition", 0x16b,  1606),

            new BardSpellBookEntry( BardType.Danseur, NAptitude.Musique, "Marche", 0x171,  1607),
            new BardSpellBookEntry( BardType.Danseur, NAptitude.Musique, "Harmonie", 0x16f,  1608),
            new BardSpellBookEntry( BardType.Danseur, NAptitude.Musique, "Cri De Guerre", 0x16d,  1609),
            new BardSpellBookEntry( BardType.Danseur, NAptitude.Musique, "Fanfare", 0x16e,  1610),
            new BardSpellBookEntry( BardType.Danseur, NAptitude.Musique, "Symphonie", 0x179,  1611),
            new BardSpellBookEntry( BardType.Danseur, NAptitude.Musique, "Orchestre", 0x176,  1612),
            new BardSpellBookEntry( BardType.Danseur, NAptitude.Musique, "Bruit", 0x169,  1613)
        };

        public bool HasSpell(Mobile from, int spellID)
        {
            return (m_Book.HasSpell(spellID));
        }

        public Hashtable m_BardNameColors = new Hashtable();
        public Hashtable m_BardNames = new Hashtable();

        public void InitializeHashtable()
        {
            m_BardNameColors[BardType.Barde] = 99;
            m_BardNameColors[BardType.Danseur] = 79;

            m_BardNames[BardType.Barde] = "Barde";
            m_BardNames[BardType.Danseur] = "Danseur";
        }

        private NewBardSpellbook m_Book;

        public NewBardSpellbookGump(Mobile from, NewBardSpellbook book)
            : base(150, 200)
        {
            InitializeHashtable();

            m_Book = book;
            int vindex = 0;
            int totpage = 0;
            int hindex = 0;

            if (from == null || !(from is CustomPlayerMobile))
                return;

            CustomPlayerMobile m = (CustomPlayerMobile)from;

            AddPage(0);
            AddImage(100, 10, 2201);

            int oldtype = -1;
            int newtype = -1;

            int value = 0;

            //Pour tous les sorts
            for (int i = 0; i < m_BardSpellBookEntry.Length; i++)
            {
                BardSpellBookEntry info = (BardSpellBookEntry)m_BardSpellBookEntry[i];
                //on assigne la nouvelle connaissance
                newtype = (int)info.BardType;

                //on change de page au 8eme sort.
                if (newtype != -1 && newtype != oldtype)
                {
                    value++;

                    if (value % 2 == 1)
                    {
                        totpage++;
                        AddPage(totpage);
                        hindex = 0;
                    }
                    else
                        hindex = 1;

                    //On ajoute le nom du barde
                    AddLabel(160 + hindex * 145, 25, (int)m_BardNameColors[info.BardType], (string)m_BardNames[info.BardType]);

                    // Séparateurs
                    AddImageTiled(130 + hindex * 165, 40, 130, 10, 0x3A);

                    //On remet à 0 pour la nouvelle page
                    vindex = 0;

                    //On ajoute les boutons de changement de page
                    AddButton(396, 14, 0x89E, 0x89E, 18, GumpButtonType.Page, totpage + 1);
                    AddButton(123, 15, 0x89D, 0x89D, 19, GumpButtonType.Page, totpage - 1);
                }

                //Si le livre possède le sort
                if (this.HasSpell(from, info.SpellID))
                {
                    int buttonID = 2224;

                    if (m.QuickSpells.Contains(info.SpellID))
                        buttonID = 2223;

                    //On ajoute l'information et les boutons
                    AddLabel(162 + hindex * 160, 54 + (vindex * 17), 0, info.Nom);
                    AddButton(127 + hindex * 160, 59 + (vindex * 17), 2103, 2104, info.SpellID, GumpButtonType.Reply, 0);
                    AddButton(140 + hindex * 160, 58 + (vindex * 17), buttonID, buttonID, info.SpellID + 200, GumpButtonType.Reply, 0);
                    vindex++;
                }

                oldtype = (int)info.BardType;
            }

            value = 0;
            
            try
            {
                //Pour tous les sorts
                for (int i = 0; i < m_BardSpellBookEntry.Length; i++)
                {
                    BardSpellBookEntry info = (BardSpellBookEntry)m_BardSpellBookEntry[i];
                    //Si le livre possède le sort
                    if (this.HasSpell(from, info.SpellID))
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

                        if (m_BardNameColors.Contains(info.BardType))
                            namecolor = (int)m_BardNameColors[info.BardType];

                        if (m_BardNames.Contains(info.BardType))
                            name = (string)m_BardNames[info.BardType];

                        //On ajoute le nom
                        AddLabel(130 + hindex * 165, 45, namecolor, info.Nom);

                        //On ajoute les séparateurs
                        AddImageTiled(130 + hindex * 165, 60, 130, 10, 0x3A);

                        //On ajoute l'icone en tant que bouton pour lancer le sort
                        AddButton(160 + hindex * 165, 75, info.ImageID, info.ImageID, info.SpellID, GumpButtonType.Reply, 0);
                      
                        int buttonID = 2224;

                        if (m.QuickSpells.Contains(info.SpellID))
                            buttonID = 2223;

                        //On ajoute les boutons pour le lancement rapide
                        AddLabel(170 + hindex * 165, 118, 0, "Rapide");
                        AddButton(150 + hindex * 165, 121, buttonID, buttonID, info.SpellID + 200, GumpButtonType.Reply, 0);

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

        public static BardSpellBookEntry FindEntryBySpellID(int spellID)
        {
            for (int i = 0; i < m_BardSpellBookEntry.Length; i++)
            {
                BardSpellBookEntry info = (BardSpellBookEntry)m_BardSpellBookEntry[i];

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

                if (info.ButtonID >= 1600 && info.ButtonID < 1800)
                {
                    Spell spell = SpellRegistry.NewSpell(info.ButtonID, m, null);

                    if (spell != null)
                        spell.Cast();

                    m.SendGump(new NewBardSpellbookGump(m, m_Book));
                }
                else if (info.ButtonID >= 1800 && info.ButtonID < 2000)
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

                    m.SendGump(new NewBardSpellbookGump(m, m_Book));
                }
            }
        }
    }
}