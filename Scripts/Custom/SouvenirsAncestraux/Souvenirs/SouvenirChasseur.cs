namespace Server.Custom.Items.SouvenirsAncestraux.Souvenirs
{
	public class SouvenirChasseur : BaseSouvenir
	{
		[Constructable]
		public SouvenirChasseur() : this(1)
		{
		}

		[Constructable]
		public SouvenirChasseur(int amount) : base(amount)
		{
			Name = "Souvenir Ancestral: Chasseur";
			Hue = (int)AptitudeColor.Chasseur;
		}

		public SouvenirChasseur(Serial serial) : base(serial)
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