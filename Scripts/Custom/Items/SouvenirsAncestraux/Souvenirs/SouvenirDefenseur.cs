namespace Server.Custom.Items.SouvenirsAncestraux.Souvenirs
{
	public class SouvenirDefenseur : BaseSouvenir
	{
		[Constructable]
		public SouvenirDefenseur() : this(1)
		{
		}

		[Constructable]
		public SouvenirDefenseur(int amount) : base(amount)
		{
			Name = "Souvenir: Défenseur";
			Hue = 2006;
		}

		public SouvenirDefenseur(Serial serial) : base(serial)
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