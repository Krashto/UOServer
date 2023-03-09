using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseInventeur : LivreClasse
	{
        [Constructable]
        public LivreClasseInventeur() : this(Classe.Inventeur)
        {
        }

        [Constructable]
        public LivreClasseInventeur(Classe classe) : base(classe)
        {
            Name = "livre d'inventeur";
        }

        public LivreClasseInventeur(Serial serial) : base(serial)
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