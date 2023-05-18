namespace Server.Custom.Items.SouvenirsAncestraux.Souvenirs
{
	public abstract class BaseSouvenir : Item
	{
		public BaseSouvenir() : this(1)
		{
		}

		public BaseSouvenir(int amount) : base(0x2100)
		{
			Stackable = true;
			Amount = amount;
		}

		public BaseSouvenir(Serial serial) : base(serial)
		{
		}

		public override double DefaultWeight => 0.1;

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