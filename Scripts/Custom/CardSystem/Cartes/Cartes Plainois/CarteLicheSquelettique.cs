namespace Server.Items
{
	public class CarteLicheSquelettique : BaseCard
	{
		public override int Level => 1;
		public override CardEnchantType EnchantType => CardEnchantType.CastRecovery;

		[Constructable]
		public CarteLicheSquelettique() : base(1940)
		{
			Name = "Carte Liche Squelette";
		}

		public CarteLicheSquelettique(Serial serial) : base(serial)
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