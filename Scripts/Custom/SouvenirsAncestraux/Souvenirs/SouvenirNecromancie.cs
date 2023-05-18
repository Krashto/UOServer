namespace Server.Custom.Items.SouvenirsAncestraux.Souvenirs
{
	public class SouvenirNecromancie : BaseSouvenir
	{
		[Constructable]
		public SouvenirNecromancie() : this(1)
		{
		}

		[Constructable]
		public SouvenirNecromancie(int amount) : base(amount)
		{
			Name = "Souvenir Ancestral: Necromancie";
			Hue = (int)AptitudeColor.Necromancie;
		}

		public SouvenirNecromancie(Serial serial) : base(serial)
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

			var version = reader.ReadInt();
		}
	}
}