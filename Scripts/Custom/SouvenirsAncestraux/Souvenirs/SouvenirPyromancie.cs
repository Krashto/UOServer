namespace Server.Custom.Items.SouvenirsAncestraux.Souvenirs
{
	public class SouvenirPyromancie : BaseSouvenir
	{
		[Constructable]
		public SouvenirPyromancie() : this(1)
		{
		}

		[Constructable]
		public SouvenirPyromancie(int amount) : base(amount)
		{
			Name = "Souvenir Ancestral: Pyromancie";
			Hue = (int)AptitudeColor.Pyromancie;
		}

		public SouvenirPyromancie(Serial serial) : base(serial)
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