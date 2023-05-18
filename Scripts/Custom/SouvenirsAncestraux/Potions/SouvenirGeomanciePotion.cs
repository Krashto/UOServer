namespace Server.Custom.Items.SouvenirsAncestraux.Souvenirs
{
	public class SouvenirGeomanciePotion : BaseSouvenirPotion
	{
		public override SetAptitudeType SetType => SetAptitudeType.Geomancie;

		[Constructable]
		public SouvenirGeomanciePotion() : this(1)
		{
		}

		[Constructable]
		public SouvenirGeomanciePotion(int amount) : base()
		{
			Name = "Souvenir Ancestral: Geomancie";
			Amount = amount;
			Hue = (int)AptitudeColor.Geomancie;
		}

		public SouvenirGeomanciePotion(Serial serial) : base(serial)
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