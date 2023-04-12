namespace Server.Items
{
	public class EssenceMusique : BaseReagent
	{
		[Constructable]
		public EssenceMusique() : this(1)
		{
		}

		[Constructable]
		public EssenceMusique(int amount) : base(0x0F91, amount)
		{
			Name = "Essence: Musique";
			Hue = 1250;
		}

		public EssenceMusique(Serial serial) : base(serial)
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