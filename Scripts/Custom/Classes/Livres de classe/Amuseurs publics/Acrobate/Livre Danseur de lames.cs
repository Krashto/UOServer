using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseDanseurDeLames : LivreClasse
	{
        [Constructable]
        public LivreClasseDanseurDeLames() : this(Classe.DanseurDeLames)
        {
        }

        [Constructable]
        public LivreClasseDanseurDeLames(Classe classe) : base(classe)
        {
            Name = "livre de danseur de lames";
        }

        public LivreClasseDanseurDeLames(Serial serial) : base(serial)
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