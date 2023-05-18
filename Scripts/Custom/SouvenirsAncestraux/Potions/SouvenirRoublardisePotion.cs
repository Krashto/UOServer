namespace Server.Custom.Items.SouvenirsAncestraux.Souvenirs
{
	public class SouvenirRoublardisePotion : BaseSouvenirPotion
	{
		public override SetAptitudeType SetType => SetAptitudeType.Roublardise;

		[Constructable]
		public SouvenirRoublardisePotion() : this(1)
		{
		}

		[Constructable]
		public SouvenirRoublardisePotion(int amount) : base()
		{
			Name = "Souvenir Ancestral: Roublardise";
			Amount = amount;
			Hue = (int)AptitudeColor.Roublardise;
		}

		public SouvenirRoublardisePotion(Serial serial) : base(serial)
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