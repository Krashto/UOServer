using Server.Network;
using Server.Spells;
using System.Xml;

namespace Server.Regions
{
    public class TwistedWealdDesert : MondainRegion
    {
        public TwistedWealdDesert(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }

        public static void Initialize()
        {
            EventSink.Login += Desert_OnLogin;
        }

        private static void Desert_OnLogin(LoginEventArgs e)
        {
            Mobile m = e.Mobile;

            if (m.Region.IsPartOf<TwistedWealdDesert>() && m.AccessLevel < AccessLevel.GameMaster)
                m.SendSpeedControl(SpeedControlType.WalkSpeed);
        }
    }
}
