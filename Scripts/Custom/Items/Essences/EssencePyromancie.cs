using Server.Custom;

namespace Server.Items
{
	public class EssencePyromancie : BaseReagent
	{
		[Constructable]
		public EssencePyromancie() : this(1)
		{
		}

		[Constructable]
		public EssencePyromancie(int amount) : base(0x0F91, amount)
		{
			Name = "Essence: Pyromancie";
			Hue = (int)AptitudeColor.Pyromancie;
		}

		public EssencePyromancie(Serial serial) : base(serial)
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