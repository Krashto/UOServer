namespace Server.Custom.Items.SouvenirsAncestraux.Souvenirs
{
	public class SouvenirMusique : BaseSouvenir
	{
		[Constructable]
		public SouvenirMusique() : this(1)
		{
		}

		[Constructable]
		public SouvenirMusique(int amount) : base(amount)
		{
			Name = "Souvenir Ancestral: Musique";
			Hue = (int)AptitudeColor.Musique;
		}

		public SouvenirMusique(Serial serial) : base(serial)
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