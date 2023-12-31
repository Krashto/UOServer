using Server.Engines.Craft;

namespace Server.Items
{
    [Flipable(0x0FBF, 0x0FC0)]
    public class ScribesPen : BaseTool
    {
        public override CraftSystem CraftSystem => DefInscription.CraftSystem;

        [Constructable]
        public ScribesPen()
            : base(0x0FBF)
        {
			Name = "Plume d'�criture";
			Weight = 1;
		}

        [Constructable]
        public ScribesPen(int uses)
            : base(uses, 0x0FBF)
        {
            Weight = 1.0;
			Name = "Plume d'�criture";
			Hue = 0;
        }

        public ScribesPen(Serial serial)
            : base(serial)
        {
        }


        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}