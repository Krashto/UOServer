using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
    [Flipable(0x0FBF, 0x0FC0)]
    public class SpellsPen : BaseTool
    {
		public override CraftSystem CraftSystem { get { return DefSpells.CraftSystem; } }

		[Constructable]
        public SpellsPen()
            : base(0x1F19)
        {
        }

        [Constructable]
        public SpellsPen(int uses)
            : base(uses, 0x1F19)
        {
            Weight = 1.0;
			Hue = 2079;
			Name = "Cristal de compétences";
        }

        public SpellsPen(Serial serial)
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