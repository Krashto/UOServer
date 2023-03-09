using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseTraqueur : LivreClasse
	{
        [Constructable]
        public LivreClasseTraqueur() : this(Classe.Traqueur)
        {
        }

        [Constructable]
        public LivreClasseTraqueur(Classe classe) : base(classe)
        {
            Name = "livre de Traqueur";
        }

        public LivreClasseTraqueur(Serial serial) : base(serial)
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