using Server.Custom;

namespace Server.Items
{
	public class EssenceGeomancie : BaseReagent
	{
		[Constructable]
		public EssenceGeomancie() : this(1)
		{
		}

		[Constructable]
		public EssenceGeomancie(int amount) : base(0x0F91, amount)
		{
			Name = "Essence: Géomancie";
			Hue = (int)AptitudeColor.Geomancie;
		}

		public EssenceGeomancie(Serial serial) : base(serial)
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