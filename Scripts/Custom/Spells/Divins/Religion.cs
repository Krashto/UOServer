using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;
using Server.Custom.Aptitudes;

namespace Server.Spells
{
    public enum Cilias
    {
        None,
        //Zhel
        Aon,
        Kordaken,
        Lakkak,
        //Yen
        Elmagan,
        Lysaelle,
        Tork,
        //Xuan
        Derna,
        Malnara,
        Kalos,
    }

    public enum CiliasGroups
    {
        None,
        Zhel,
        Yen,
        Xuan,
    }

    public class Religion
    {
        private static string[] m_GodName = new string[]
        {
            "Aucun", "Aon", "Kordaken", "Lakkak", "Elmagan", "Lysaelle", "Tork", "Derna", "Malnara", "Kalos"
        };

        private static CiliasGroups[] m_GodGroupName = new CiliasGroups[]
        {
            CiliasGroups.None, CiliasGroups.Zhel, CiliasGroups.Zhel, CiliasGroups.Zhel, CiliasGroups.Yen, CiliasGroups.Yen, CiliasGroups.Yen, CiliasGroups.Xuan, CiliasGroups.Xuan, CiliasGroups.Xuan,
        };

        private static string[] m_GodNameNoAccent = new string[]
        {
            "Aucun", "Aon", "Kordaken", "Lakkak", "Elmagan", "Lysaelle", "Tork", "Derna", "Malnara", "Kalos"
        };

        public static string GetCiliasName(Cilias cilias)
        {
            return m_GodName[(int)cilias];
        }

        public static string GetGodName(CustomPlayerMobile from)
        {
            return m_GodName[(int)from.Cilias];
        }

        public static CiliasGroups GetGodGroupName(CustomPlayerMobile from)
        {
            return m_GodGroupName[(int)from.Cilias];
        }

        public static string GetGodNameNoAccent(CustomPlayerMobile from)
        {
            return m_GodNameNoAccent[(int)from.Cilias];
        }

        public static void DoPrayer(CustomPlayerMobile from, Cilias cilias, int seconds, int minPDP, int maxPDP, int mana, Item croix)
        {
            if (mana > from.Mana)
            {
                from.SendMessage("Vous n'avez pas assez de mana.");
            }
            else if (from.Cilias != cilias && DateTime.Now < from.NextCiliasChange)
            {
                //ResetValues(from, cilias);
                from.SendMessage("Vous ne pouvez pas changer de Cilias dès maintenant !");
                from.SendGump(new ReligionGump(from, cilias, croix));
            }
            else if (from.Cilias != cilias && DateTime.Now >= from.NextCiliasChange)
            {
                from.SendGump(new CiliasChangeGump(from, cilias, seconds, minPDP, maxPDP, mana, croix));
            }
            else
            {
                from.SendMessage("Vous débutez votre prière.");
                from.PublicOverheadMessage(MessageType.Emote, 0x59, false, "*débute une prière*", false);

                from.LastPrayerLocation = from.Location;
                from.Mana -= mana;

                TimeSpan duration = TimeSpan.FromSeconds(seconds);
                int pdp = Utility.RandomMinMax(minPDP, (int)((maxPDP / 1.5) + 0.5));

                pdp *= 1 + (GetRelation(from) / 2100);
                pdp *= 1 + (GetInfluence(from) / 5000);

                if (pdp > maxPDP)
                    pdp = maxPDP;

                if (from.TimerPraying != null)
                {
                    from.TimerPraying.Stop();
                    from.TimerPraying = null;
                }

                from.NextPrayingTime = DateTime.Now + duration;

                from.TimerPraying = new CustomPlayerMobile.PrayingTimer(from, duration, pdp);
                from.TimerPraying.Start();
            }
        }

        public static int GetPdp(CustomPlayerMobile from)
        {
            return from.PouvoirDivinProcure;
        }

        public static int GetMaxPdp(CustomPlayerMobile from)
        {
            return from.PdpMax;
        }

        public static int GetRelation(CustomPlayerMobile from)
        {
            return from.Relation;
        }

        public static int GetInfluence(CustomPlayerMobile from)
        {
            int croyant = 0;
            int total = 0;

            ArrayList mobs = new ArrayList(World.Mobiles.Values);

            foreach (Mobile mob in mobs)
            {
                if (mob is CustomPlayerMobile)
                {
                    CustomPlayerMobile m = (CustomPlayerMobile)mob;

                    if (m.Cilias != Cilias.None)
                    {
                        if (m.Cilias == from.Cilias)
                            croyant++;

                        total++;
                    }
                }
            }

            if (total <= 0)
                return 0;

            return (croyant * 1000) / total;
        }

        public static void ResetValues(CustomPlayerMobile from, Cilias cilias)
        {
        }

        public class ReligionGump : Gump
        {
            private CustomPlayerMobile m_From;
            private Cilias m_Cilias;
            private Item m_Croix;

            public ReligionGump(CustomPlayerMobile from, Cilias cilias, Item croix)
                : base(0, 0)
            {
                m_From = from;
                m_Cilias = cilias;
                m_Croix = croix;

                Closable = true;
                Disposable = true;
                Dragable = true;
                Resizable = false;

                AddPage(0);

                AddBackground(59, 24, 1090, 461, 9200);
                AddBackground(69, 298, 1067, 176, 2620);
                AddBackground(68, 32, 1070, 25, 9300);

                AddAlphaRegion(74, 805, 557, 162);

                AddLabel(478, 34, 0, "Sélectionnez votre cilias");

                for (int i = 1; i < Enum.GetValues(typeof(Cilias)).Length; i++)
                {
                    int index = i - 1;

                    AddBackground(78 + (index * 115), 66, 111, 195, 3000);
                    AddBackground(83 + (index * 115), 96, 100, 160, 2620);

                    AddLabel(88 + (index * 115), 71, 0, m_GodName[i] + " (" + m_GodGroupName[i] + ")");
                    if (i < 6)
                        AddImage(88 + (index * 115), 103, 1571 + index);
                    else
                        AddImage(108 + (index * 115), 153, 219);
                    AddButton(117 + (index * 115), 264, 2151, 2152, i, GumpButtonType.Reply, 0);
                }

                AddLabel(556, 312, 1152, "État religieux");

                AddLabel(473, 336, 1152, "Relation actuelle");
                AddLabel(662, 336, 1152, GetGodName(m_From));
                AddLabel(473, 366, 1152, "Relation divine");
                AddLabel(662, 365, 1152, GetRelation(m_From) + " / 1000");
                AddLabel(473, 396, 1152, "Influence divine");
                AddLabel(662, 396, 1152, GetInfluence(m_From) + " / 1000");
                AddLabel(473, 426, 1152, "Pouvoir divin procuré");
                AddLabel(662, 426, 1152, GetPdp(m_From) + " / " + GetMaxPdp(m_From));

                for (int i = 0; i < 4; ++i)
                    AddLabel(634, 336 + (i * 30), 1152, ":");

                AddImage(116, 356, 111);
                AddImage(1029, 356, 111);

                AddImage(9, 26, 10440);
                AddImage(1080, 26, 10441);
            }

            public override void OnResponse(NetState sender, RelayInfo info)
            {
                if (info.ButtonID == 0)
                {
                    m_From.CloseGump(typeof(ReligionGump));
                    m_From.CloseGump(typeof(PriereGump));
                }
                else if (m_Croix is Croix && (!m_From.CanSee(m_Croix) || !m_From.InRange(m_Croix.Location, 4)))
                {
                    m_From.SendLocalizedMessage(500446); // That is too far away.
                }
                else
                {
                    m_From.SendGump(new PriereGump(m_From, (Cilias)info.ButtonID, m_Croix));
                }
            }
        }

        public class PriereGump : Gump
        {
            private class PriereEntry
            {
                private int m_Duree, m_MinPDP, m_MaxPDP, m_Mana;

                public int Duree { get { return m_Duree; } }
                public int MinPDP { get { return m_MinPDP; } }
                public int MaxPDP { get { return m_MaxPDP; } }
                public int Mana { get { return m_Mana; } }

                public PriereEntry(int duree, int minPDP, int maxPDP, int mana)
                {
                    m_Duree = duree;
                    m_MinPDP = minPDP;
                    m_MaxPDP = maxPDP;
                    m_Mana = mana;
                }
            }

            private static PriereEntry[] m_Entries = new PriereEntry[]
			{
				new PriereEntry( 20, 20, 30, 10 ),
				new PriereEntry( 40, 40, 60, 20 ),
				new PriereEntry( 60, 60, 80, 30 ),
				new PriereEntry( 80, 80, 100, 40 ),
				new PriereEntry( 100, 100, 120, 50 ),
				new PriereEntry( 120, 120, 140, 60 ),
			};

            private CustomPlayerMobile m_From;
            private Cilias m_Cilias;
            private Item m_Croix;

            public PriereGump(CustomPlayerMobile from, Cilias cilias, Item croix)
                : base(0, 0)
            {
                m_From = from;
                m_Cilias = cilias;
                m_Croix = croix;

                Closable = true;
                Disposable = true;
                Dragable = true;
                Resizable = false;

                AddPage(0);

                AddBackground(58, 10, 234, 255, 9200);
                AddBackground(66, 18, 218, 25, 9300);
                AddBackground(67, 57, 214, 196, 2620);

                AddAlphaRegion(72, 64, 204, 182);

                AddItem(187, 118, 2);
                AddItem(209, 118, 3);
                AddImage(8, 12, 10400);
                AddImage(7, 184, 10402);
                AddImage(259, 12, 10410);
                AddImage(259, 184, 10412);

                AddLabel(111, 20, 0, "Choisissez une prière");

                AddLabel(103, 70, 1152, "20 secondes");
                AddButton(80, 73, 2103, 2104, 1, GumpButtonType.Reply, 0);
                AddLabel(103, 100, 1152, "40 secondes");
                AddButton(80, 103, 2103, 2104, 2, GumpButtonType.Reply, 0);
                AddLabel(103, 130, 1152, "60 secondes");
                AddButton(80, 133, 2103, 2104, 3, GumpButtonType.Reply, 0);
                AddLabel(103, 160, 1152, "80 secondes");
                AddButton(80, 163, 2103, 2104, 4, GumpButtonType.Reply, 0);
                AddLabel(103, 190, 1152, "100 secondes");
                AddButton(80, 193, 2103, 2104, 5, GumpButtonType.Reply, 0);
                AddLabel(103, 220, 1152, "120 secondes");
                AddButton(80, 224, 2103, 2104, 6, GumpButtonType.Reply, 0);
            }

            public override void OnResponse(NetState sender, RelayInfo info)
            {
                if (info.ButtonID == 0)
                {
                    m_From.CloseGump(typeof(ReligionGump));
                    m_From.CloseGump(typeof(PriereGump));
                }
                else
                {
                    if (m_Croix is Croix && (!m_From.CanSee(m_Croix) || !m_From.InRange(m_Croix.Location, 4)))
                    {
                        m_From.SendLocalizedMessage(500446); // That is too far away.
                    }
                    else if (m_From.NextActionTime > Core.TickCount)
                    {
                        m_From.SendMessage("Vous devant attendre avant de prier.");
                    }
                    else if (m_From.IsPraying)
                    {
                        m_From.SendMessage("Vous êtes déjà en train de prier.");
                    }
                    else
                    {
                        int i = info.ButtonID - 1;
                        int seconds = m_Entries[i].Duree;
                        int minPDP = m_Entries[i].MinPDP;
                        int maxPDP = m_Entries[i].MaxPDP;
                        int mana = m_Entries[i].Mana;

                        int pouvoirdivin = m_From.GetAptitudeValue(NAptitude.MagieAncestrale);

                        minPDP = (int)(minPDP * (1 + pouvoirdivin * 0.03));
                        maxPDP = (int)(maxPDP * (1 + pouvoirdivin * 0.03));

                        //m_From.SendMessage("Grâce à votre niveau de pouvoir divin, votre prière vous procurera entre " + minPDP + " et " + maxPDP + " pouvoir divin.");

                        DoPrayer(m_From, m_Cilias, seconds, minPDP, maxPDP, mana, m_Croix);
                    }
                }
            }
        }

        public class CiliasChangeGump : Gump
        {
            private CustomPlayerMobile m_From;
            private Cilias m_Cilias;
            private int m_Seconds;
            private int m_minPDP;
            private int m_maxPDP;
            private int m_mana;
            private Item m_Croix;

            public CiliasChangeGump(CustomPlayerMobile from, Cilias cilias, int seconds, int minPDP, int maxPDP, int mana, Item croix)
                : base(0, 0)
            {
                m_From = from;
                m_Cilias = cilias;
                m_Seconds = seconds;
                m_minPDP = minPDP;
                m_maxPDP = maxPDP;
                m_mana = mana;
                m_Croix = croix;

                Closable = true;
                Disposable = true;
                Dragable = true;
                Resizable = false;

                AddPage(0);

                AddBackground(0, 0, 334, 130, 9200);
                AddBackground(8, 8, 318, 25, 9300);
                AddBackground(9, 47, 314, 71, 2620);

                AddLabel(30, 10, 0, "Désirez vous changer de Cilias pour " + GetCiliasName(cilias) + " ?");

                AddLabel(45, 60, 1152, "Oui");
                AddButton(22, 63, 2103, 2104, 1, GumpButtonType.Reply, 0);
                AddLabel(45, 90, 1152, "Non");
                AddButton(22, 93, 2103, 2104, 2, GumpButtonType.Reply, 0);
            }

            public override void OnResponse(NetState sender, RelayInfo info)
            {
                if (info.ButtonID == 0 || info.ButtonID == 2)
                {
                    m_From.CloseGump(typeof(CiliasChangeGump));
                    m_From.CloseGump(typeof(ReligionGump));
                    m_From.CloseGump(typeof(PriereGump));

                    m_From.SendGump(new ReligionGump(m_From, m_Cilias, m_Croix));
                }
                else if (info.ButtonID == 1)
                {
                    ResetValues(m_From, m_Cilias);
                    DoPrayer(m_From, m_Cilias, m_Seconds, m_minPDP, m_maxPDP, m_mana, m_Croix);
                }
            }
        }
    }
}