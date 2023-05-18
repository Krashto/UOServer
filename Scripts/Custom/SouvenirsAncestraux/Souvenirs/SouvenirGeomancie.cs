namespace Server.Custom.Items.SouvenirsAncestraux.Souvenirs
{
	public class SouvenirGeomancie : BaseSouvenir
	{
		[Constructable]
		public SouvenirGeomancie() : this(1)
		{
		}

		[Constructable]
		public SouvenirGeomancie(int amount) : base(amount)
		{
			Name = "Souvenir Ancestral: Géomancie";
			Hue = (int)AptitudeColor.Geomancie;
		}

		public SouvenirGeomancie(Serial serial) : base(serial)
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