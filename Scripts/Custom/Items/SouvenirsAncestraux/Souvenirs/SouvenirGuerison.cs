namespace Server.Custom.Items.SouvenirsAncestraux.Souvenirs
{
	public class SouvenirGuerison : BaseSouvenir
	{
		[Constructable]
		public SouvenirGuerison() : this(1)
		{
		}

		[Constructable]
		public SouvenirGuerison(int amount) : base(amount)
		{
			Name = "Souvenir: Guérison";
			Hue = 2006;
		}

		public SouvenirGuerison(Serial serial) : base(serial)
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