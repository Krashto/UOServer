using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseCouturier : LivreClasse
	{
        [Constructable]
        public LivreClasseCouturier() : this(Classe.Couturier)
        {
        }

        [Constructable]
        public LivreClasseCouturier(Classe classe) : base(classe)
        {
            Name = "livre de couturier";
        }

        public LivreClasseCouturier(Serial serial) : base(serial)
        {
        }

		public override void Serialize( GenericWriter writer )
		{
            base.Serialize(writer);

            writer.Write((int)0); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
        }
	}
}