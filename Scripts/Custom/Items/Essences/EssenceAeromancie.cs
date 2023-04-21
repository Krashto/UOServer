using Server.Custom;

namespace Server.Items
{
	public class EssenceAeromancie : BaseReagent
	{
		[Constructable]
		public EssenceAeromancie() : this(1)
		{
		}

		[Constructable]
		public EssenceAeromancie(int amount) : base(0x0F91, amount)
		{
			Name = "Essence: Aéromancie";
			Hue = (int)AptitudeColor.Aeromancie;
		}

		public EssenceAeromancie(Serial serial) : base(serial)
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