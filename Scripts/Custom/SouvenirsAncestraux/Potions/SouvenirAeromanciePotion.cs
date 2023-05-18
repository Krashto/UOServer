namespace Server.Custom.Items.SouvenirsAncestraux.Souvenirs
{
	public class SouvenirAeromanciePotion : BaseSouvenirPotion
	{
		public override SetAptitudeType SetType => SetAptitudeType.Aeromancie;

		[Constructable]
		public SouvenirAeromanciePotion() : this(1)
		{
		}

		[Constructable]
		public SouvenirAeromanciePotion(int amount) : base()
		{
			Name = "Souvenir Ancestral: Aéromancie";
			Amount = amount;
			Hue = (int)AptitudeColor.Aeromancie;
		}

		public SouvenirAeromanciePotion(Serial serial) : base(serial)
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