namespace Server.Custom.Items.SouvenirsAncestraux.Souvenirs
{
	public class SouvenirMusiquePotion : BaseSouvenirPotion
	{
		public override SetAptitudeType SetType => SetAptitudeType.Musique;

		[Constructable]
		public SouvenirMusiquePotion() : this(1)
		{
		}

		[Constructable]
		public SouvenirMusiquePotion(int amount) : base()
		{
			Name = "Souvenir Ancestral: Musique";
			Amount = amount;
			Hue = (int)AptitudeColor.Musique;
		}

		public SouvenirMusiquePotion(Serial serial) : base(serial)
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