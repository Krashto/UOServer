namespace Server.Custom.Items.SouvenirsAncestraux.Souvenirs
{
	public class SouvenirGuerisonPotion : BaseSouvenirPotion
	{
		public override SetAptitudeType SetType => SetAptitudeType.Guerison;

		[Constructable]
		public SouvenirGuerisonPotion() : this(1)
		{
		}

		[Constructable]
		public SouvenirGuerisonPotion(int amount) : base()
		{
			Name = "Souvenir Ancestral: Guerison";
			Amount = amount;
			Hue = (int)AptitudeColor.Guerison;
		}

		public SouvenirGuerisonPotion(Serial serial) : base(serial)
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