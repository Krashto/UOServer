namespace Server.Custom.Items.SouvenirsAncestraux.Souvenirs
{
	public class SouvenirTotemiquePotion : BaseSouvenirPotion
	{
		public override SetAptitudeType SetType => SetAptitudeType.Totemique;

		[Constructable]
		public SouvenirTotemiquePotion() : this(1)
		{
		}

		[Constructable]
		public SouvenirTotemiquePotion(int amount) : base()
		{
			Name = "Souvenir Ancestral: Totemique";
			Amount = amount;
			Hue = (int)AptitudeColor.Totemique;
		}

		public SouvenirTotemiquePotion(Serial serial) : base(serial)
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