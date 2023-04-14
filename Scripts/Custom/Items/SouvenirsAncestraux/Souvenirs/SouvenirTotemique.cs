namespace Server.Custom.Items.SouvenirsAncestraux.Souvenirs
{
	public class SouvenirTotemique : BaseSouvenir
	{
		[Constructable]
		public SouvenirTotemique() : this(1)
		{
		}

		[Constructable]
		public SouvenirTotemique(int amount) : base(amount)
		{
			Name = "Souvenir: Totemique";
			Hue = 1139;
		}

		public SouvenirTotemique(Serial serial) : base(serial)
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