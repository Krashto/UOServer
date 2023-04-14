namespace Server.Custom.Items.SouvenirsAncestraux.Souvenirs
{
	public class SouvenirAeromancie : BaseSouvenir
	{
		[Constructable]
		public SouvenirAeromancie() : this(1)
		{
		}

		[Constructable]
		public SouvenirAeromancie(int amount) : base(amount)
		{
			Name = "Souvenir Ancestral: Aéromancie";
			Hue = 1153;
		}

		public SouvenirAeromancie(Serial serial) : base(serial)
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