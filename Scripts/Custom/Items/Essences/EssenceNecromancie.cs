﻿using Server.Custom;

namespace Server.Items
{
	public class EssenceNecromancie : BaseReagent
	{
		[Constructable]
		public EssenceNecromancie() : this(1)
		{
		}

		[Constructable]
		public EssenceNecromancie(int amount) : base(0x0F91, amount)
		{
			Name = "Essence: Nécromancie";
			Hue = (int)AptitudeColor.Necromancie;
		}

		public EssenceNecromancie(Serial serial) : base(serial)
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