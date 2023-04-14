namespace Server.Custom.Items.SouvenirsAncestraux.Souvenirs
{
	public class SouvenirMartial : BaseSouvenir
	{
		[Constructable]
		public SouvenirMartial() : this(1)
		{
		}

		[Constructable]
		public SouvenirMartial(int amount) : base(amount)
		{
			Name = "Souvenir: Martial";
			Hue = 1105;
		}

		public SouvenirMartial(Serial serial) : base(serial)
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