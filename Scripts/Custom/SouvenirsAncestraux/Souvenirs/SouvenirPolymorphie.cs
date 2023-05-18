namespace Server.Custom.Items.SouvenirsAncestraux.Souvenirs
{
	public class SouvenirPolymorphie : BaseSouvenir
	{
		[Constructable]
		public SouvenirPolymorphie() : this(1)
		{
		}

		[Constructable]
		public SouvenirPolymorphie(int amount) : base(amount)
		{
			Name = "Souvenir Ancestral: Polymorphie";
			Hue = (int)AptitudeColor.Polymorphie;
		}

		public SouvenirPolymorphie(Serial serial) : base(serial)
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