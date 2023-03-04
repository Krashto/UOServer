using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseVoleur : LivreClasse
	{
        [Constructable]
        public LivreClasseVoleur() : this(Classe.Voleur)
        {
        }

        [Constructable]
        public LivreClasseVoleur(Classe classe) : base(classe)
        {
            Name = "livre de voleur";
        }

        public LivreClasseVoleur(Serial serial) : base(serial)
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