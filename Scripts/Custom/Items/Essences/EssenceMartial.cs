﻿namespace Server.Items
{
	public class EssenceMartial : BaseReagent
	{
		[Constructable]
		public EssenceMartial() : this(1)
		{
		}

		[Constructable]
		public EssenceMartial(int amount) : base(0x0F91, amount)
		{
			Name = "Essence: Martial";
			Hue = 1935;
		}

		public EssenceMartial(Serial serial) : base(serial)
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