namespace Server.Custom.Items.SouvenirsAncestraux.Souvenirs
{
	public class SouvenirPyromanciePotion : BaseSouvenirPotion
	{
		public override SetAptitudeType SetType => SetAptitudeType.Pyromancie;

		[Constructable]
		public SouvenirPyromanciePotion() : this(1)
		{
		}

		[Constructable]
		public SouvenirPyromanciePotion(int amount) : base()
		{
			Name = "Souvenir Ancestral: Pyromancie";
			Amount = amount;
			Hue = (int)AptitudeColor.Pyromancie;
		}

		public SouvenirPyromanciePotion(Serial serial) : base(serial)
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