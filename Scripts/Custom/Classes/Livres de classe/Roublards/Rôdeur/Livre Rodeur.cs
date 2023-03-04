using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseRodeur : LivreClasse
	{
        [Constructable]
        public LivreClasseRodeur() : this(Classe.Rodeur)
        {
        }

        [Constructable]
        public LivreClasseRodeur(Classe classe) : base(classe)
        {
            Name = "livre de rodeur";
        }

        public LivreClasseRodeur(Serial serial) : base(serial)
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