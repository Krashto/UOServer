namespace Server.Custom.Items.SouvenirsAncestraux.Souvenirs
{
	public class SouvenirChasseurPotion : BaseSouvenirPotion
	{
		public override SetAptitudeType SetType => SetAptitudeType.Chasseur;

		[Constructable]
		public SouvenirChasseurPotion() : this(1)
		{
		}

		[Constructable]
		public SouvenirChasseurPotion(int amount) : base()
		{
			Name = "Souvenir Ancestral: Chasseur";
			Amount = amount;
			Hue = (int)AptitudeColor.Chasseur;
		}

		public SouvenirChasseurPotion(Serial serial) : base(serial)
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