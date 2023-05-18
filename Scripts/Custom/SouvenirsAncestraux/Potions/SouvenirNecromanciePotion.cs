namespace Server.Custom.Items.SouvenirsAncestraux.Souvenirs
{
	public class SouvenirNecromanciePotion : BaseSouvenirPotion
	{
		public override SetAptitudeType SetType => SetAptitudeType.Necromancie;

		[Constructable]
		public SouvenirNecromanciePotion() : this(1)
		{
		}

		[Constructable]
		public SouvenirNecromanciePotion(int amount) : base()
		{
			Name = "Souvenir Ancestral: Necromancie";
			Amount = amount;
			Hue = (int)AptitudeColor.Necromancie;
		}

		public SouvenirNecromanciePotion(Serial serial) : base(serial)
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