namespace Server.Items
{
    public class FancyBearingTheCrestOfBlackthorn2 : FancyRobe
    {
        public override bool IsArtifact => true;

        [Constructable]
        public FancyBearingTheCrestOfBlackthorn2()
            : base()
        {
            ReforgedSuffix = ReforgedSuffix.Blackthorn;
            Attributes.LowerManaCost = 1;
            Attributes.BonusMana = 5;
            Hue = 1306;
        }

        public FancyBearingTheCrestOfBlackthorn2(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(1);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            if (version == 0)
            {
                MaxHitPoints = 0;
                HitPoints = 0;
            }
        }
    }
}