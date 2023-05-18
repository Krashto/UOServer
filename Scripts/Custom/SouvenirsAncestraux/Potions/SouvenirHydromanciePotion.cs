namespace Server.Custom.Items.SouvenirsAncestraux.Souvenirs
{
	public class SouvenirHydromanciePotion : BaseSouvenirPotion
	{
		public override SetAptitudeType SetType => SetAptitudeType.Hydromancie;

		[Constructable]
		public SouvenirHydromanciePotion() : this(1)
		{
		}

		[Constructable]
		public SouvenirHydromanciePotion(int amount) : base()
		{
			Name = "Souvenir Ancestral: Hydromancie";
			Amount = amount;
			Hue = (int)AptitudeColor.Hydromancie;
		}

		public SouvenirHydromanciePotion(Serial serial) : base(serial)
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