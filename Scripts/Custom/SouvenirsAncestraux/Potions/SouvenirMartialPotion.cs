namespace Server.Custom.Items.SouvenirsAncestraux.Souvenirs
{
	public class SouvenirMartialPotion : BaseSouvenirPotion
	{
		public override SetAptitudeType SetType => SetAptitudeType.Martial;

		[Constructable]
		public SouvenirMartialPotion() : this(1)
		{
		}

		[Constructable]
		public SouvenirMartialPotion(int amount) : base()
		{
			Name = "Souvenir Ancestral: Martial";
			Amount = amount;
			Hue = (int)AptitudeColor.Martial;
		}

		public SouvenirMartialPotion(Serial serial) : base(serial)
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