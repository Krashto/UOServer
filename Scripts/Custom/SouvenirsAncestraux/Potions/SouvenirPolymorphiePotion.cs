namespace Server.Custom.Items.SouvenirsAncestraux.Souvenirs
{
	public class SouvenirPolymorphiePotion : BaseSouvenirPotion
	{
		public override SetAptitudeType SetType => SetAptitudeType.Polymorphie;

		[Constructable]
		public SouvenirPolymorphiePotion() : this(1)
		{
		}

		[Constructable]
		public SouvenirPolymorphiePotion(int amount) : base()
		{
			Name = "Souvenir Ancestral: Polymorphie";
			Amount = amount;
			Hue = (int)AptitudeColor.Polymorphie;
		}

		public SouvenirPolymorphiePotion(Serial serial) : base(serial)
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