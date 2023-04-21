using Server.Custom;

namespace Server.Items
{
	public class EssenceHydromancie : BaseReagent
	{
		[Constructable]
		public EssenceHydromancie() : this(1)
		{
		}

		[Constructable]
		public EssenceHydromancie(int amount) : base(0x0F91, amount)
		{
			Name = "Essence: Hydromancie";
			Hue = (int)AptitudeColor.Hydromancie;
		}

		public EssenceHydromancie(Serial serial) : base(serial)
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