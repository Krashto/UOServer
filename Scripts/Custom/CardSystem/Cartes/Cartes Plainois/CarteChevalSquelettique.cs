namespace Server.Items
{
	public class CarteChevalSquelettique : BaseCard
	{
		public override int Level => 4;
		public override CardEnchantType EnchantType => CardEnchantType.BonusStam;

		[Constructable]
		public CarteChevalSquelettique() : base(1940)
		{
			Name = "Carte Cheval Squelettique";
		}

		public CarteChevalSquelettique(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}