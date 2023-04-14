namespace Server.Custom.Items.SouvenirsAncestraux.Souvenirs
{
	public class SouvenireMusique : BaseSouvenir
	{
		[Constructable]
		public SouvenireMusique() : this(1)
		{
		}

		[Constructable]
		public SouvenireMusique(int amount) : base(amount)
		{
			Name = "Souvenire: Musique";
			Hue = 1250;
		}

		public SouvenireMusique(Serial serial) : base(serial)
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