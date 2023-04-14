﻿namespace Server.Custom.Items.SouvenirsAncestraux.Souvenirs
{
	public class SouvenirHydromancie : BaseSouvenir
	{
		[Constructable]
		public SouvenirHydromancie() : this(1)
		{
		}

		[Constructable]
		public SouvenirHydromancie(int amount) : base(amount)
		{
			Name = "Souvenir: Hydromancie";
			Hue = 1264;
		}

		public SouvenirHydromancie(Serial serial) : base(serial)
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