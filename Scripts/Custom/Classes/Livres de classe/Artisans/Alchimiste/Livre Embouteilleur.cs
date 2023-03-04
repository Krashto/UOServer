using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseEmbouteilleur : LivreClasse
	{
        [Constructable]
        public LivreClasseEmbouteilleur() : this(Classe.Embouteilleur)
        {
        }

        [Constructable]
        public LivreClasseEmbouteilleur(Classe classe) : base(classe)
        {
            Name = "livre d'embouteilleur";
        }

        public LivreClasseEmbouteilleur(Serial serial) : base(serial)
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