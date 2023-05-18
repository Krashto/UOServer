namespace Server.Custom.Items.SouvenirsAncestraux.Souvenirs
{
	public class SouvenirDefenseurPotion : BaseSouvenirPotion
	{
		public override SetAptitudeType SetType => SetAptitudeType.Defenseur;

		[Constructable]
		public SouvenirDefenseurPotion() : this(1)
		{
		}

		[Constructable]
		public SouvenirDefenseurPotion(int amount) : base()
		{
			Name = "Souvenir Ancestral: Defenseur";
			Amount = amount;
			Hue = (int)AptitudeColor.Defenseur;
		}

		public SouvenirDefenseurPotion(Serial serial) : base(serial)
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