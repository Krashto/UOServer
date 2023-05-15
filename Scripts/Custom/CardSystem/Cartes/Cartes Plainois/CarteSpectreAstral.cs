namespace Server.Items
{
	public class CarteSpectreAstral : BaseCard
	{
		public override int Level => 2;
		public override CardEnchantType EnchantType => CardEnchantType.AttackChance;

		[Constructable]
		public CarteSpectreAstral() : base(1940)
		{
			Name = "Carte Spectre Astral";
		}

		public CarteSpectreAstral( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}