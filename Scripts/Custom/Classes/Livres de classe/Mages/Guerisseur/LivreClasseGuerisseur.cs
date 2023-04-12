using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseGuerisseur : LivreClasse
	{
        [Constructable]
        public LivreClasseGuerisseur() : this(Classe.Guerisseur)
        {
        }

        [Constructable]
        public LivreClasseGuerisseur(Classe classe) : base(classe)
        {
            Name = "livre de Gu�risseur";
        }

        public LivreClasseGuerisseur(Serial serial) : base(serial)
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