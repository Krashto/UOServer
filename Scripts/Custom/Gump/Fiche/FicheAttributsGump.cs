using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Mobiles;
using Server.Gumps;

namespace Server.Gumps
{
    public class FicheAttributsGump : Gump
    {
        private CustomPlayerMobile m_From;
        private CustomPlayerMobile m_GM;

        public static int GetBaseValue(CustomPlayerMobile from, Attribut attribut)
        {
            return from.BaseAttributs[attribut];
        }

        public static int GetValue(CustomPlayerMobile from, Attribut attribut)
        {
            return from.Attributs[attribut];
        }

        public static int GetAddedValue(CustomPlayerMobile from, Attribut attribut)
        {
            int value = GetValue(from, attribut);

            return value;
        }

        public static int GetRemainingPU(CustomPlayerMobile from)
        {
            int totalValue = GetAddedValue(from, Attribut.Constitution) + GetAddedValue(from, Attribut.Intuition) + GetAddedValue(from, Attribut.Pouvoir) + GetAddedValue(from, Attribut.Resistance);

            return (from.Niveau * 3) - totalValue;
        }

        public static int GetDisponiblePU(CustomPlayerMobile from)
        {
            return from.PUDispo;
        }

        public static bool CanRaise(CustomPlayerMobile from, Attribut attribut)
        {
            int value = GetAddedValue(from, attribut);

            if (value + GetBaseValue(from, attribut) >= 160)
                return false;

            if (GetDisponiblePU(from) <= 0)
                return false;

            return true;
        }

        public static bool CanLower(CustomPlayerMobile from, Attribut attribut)
        {
            int value = GetAddedValue(from, attribut);

            if (value <= 0)
                return false;

            return true;
        }

        public FicheAttributsGump(CustomPlayerMobile from, CustomPlayerMobile gm) : base(0, 0)
        {
            try
            {
                m_From = from;
                m_GM = gm;

                Closable = true;
                Disposable = true;
                Dragable = true;
                Resizable = false;

                AddPage(0);

                AddBackground(69, 35, 448, 162, 9260);
                AddBackground(92, 59, 403, 116, 9270);

                AddImageTiled(111, 34, 391, 17, 10250);
                AddImageTiled(128, 98, 328, 3, 9101);

                AddImage(35, 40, 10421);
                AddImage(496, 40, 10431);
                AddImage(59, 22, 10420);
                AddImage(467, 22, 10430);
                AddImage(155, 30, 1141);
                AddImage(19, 172, 10402);
                AddImage(485, 172, 10412);

                AddLabel(259, 32, 2101, "Attributs");
                AddLabel(139, 76, 2101, String.Format("Points d'attribut disponibles / en attente: {0} / {1}", GetDisponiblePU(m_From), GetRemainingPU(m_From) - GetDisponiblePU(m_From)));

                AddLabel(110, 109, 2101, "Constitution");
                AddLabel(200, 109, 2101, String.Format(": {0}", m_From.GetAttributValue(Attribut.Constitution)));

                if (gm == null && CanLower(m_From, Attribut.Constitution))
                    AddButton(235, 110, 5603, 5607, 5, GumpButtonType.Reply, 0);

                if (gm == null && CanRaise(m_From, Attribut.Constitution))
                    AddButton(259, 110, 5601, 5605, 1, GumpButtonType.Reply, 0);

                AddLabel(110, 141, 2101, "Intuition");
                AddLabel(200, 141, 2101, String.Format(": {0}", m_From.GetAttributValue(Attribut.Intuition)));

                if (gm == null && CanLower(m_From, Attribut.Intuition))
                    AddButton(235, 142, 5603, 5607, 6, GumpButtonType.Reply, 0);

                if (gm == null && CanRaise(m_From, Attribut.Intuition))
                    AddButton(259, 142, 5601, 5605, 2, GumpButtonType.Reply, 0);

                AddLabel(311, 109, 2101, "Pouvoir");
                AddLabel(401, 109, 2101, String.Format(": {0}", m_From.GetAttributValue(Attribut.Pouvoir)));

                if (gm == null && CanLower(m_From, Attribut.Pouvoir))
                    AddButton(436, 110, 5603, 5607, 7, GumpButtonType.Reply, 0);

                if (gm == null && CanRaise(m_From, Attribut.Pouvoir))
                    AddButton(460, 110, 5601, 5605, 3, GumpButtonType.Reply, 0);

                AddLabel(311, 141, 2101, "Résistance");
                AddLabel(401, 141, 2101, String.Format(": {0}", m_From.GetAttributValue(Attribut.Resistance)));

                if (gm == null && CanLower(m_From, Attribut.Resistance))
                    AddButton(436, 142, 5603, 5607, 8, GumpButtonType.Reply, 0);

                if (gm == null && CanRaise(m_From, Attribut.Resistance))
                    AddButton(460, 142, 5601, 5605, 4, GumpButtonType.Reply, 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            try
            {
                int oldValue = 0;
                Attribut attribut;

                if (info.ButtonID >= 5)
                {
                    attribut = (Attribut)(info.ButtonID - 5);
                    oldValue = GetAddedValue(m_From, attribut);

                    if (CanLower(m_From, attribut))
                    {
                        m_From.Attributs.SetValue(attribut, oldValue - 1);
                    }
                }
                else if (info.ButtonID >= 1)
                {
                    attribut = (Attribut)(info.ButtonID - 1);
                    oldValue = GetAddedValue(m_From, attribut);

                    if (CanRaise(m_From, attribut))
                    {
                        m_From.PUDispo -= 1;
                        m_From.Attributs.SetValue(attribut, oldValue + 1);
                    }
                }

                if (m_GM != null)
                {
                    if (info.ButtonID > 0)
                        m_GM.SendGump(new FicheAttributsGump(m_From, m_GM));
                    else
                        m_GM.SendGump(new FicheGump(m_From, m_GM));
                }
                else
                {
                    if (info.ButtonID > 0)
                        m_From.SendGump(new FicheAttributsGump(m_From, m_GM));
                    else
                        m_From.SendGump(new FicheGump(m_From, m_GM));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}