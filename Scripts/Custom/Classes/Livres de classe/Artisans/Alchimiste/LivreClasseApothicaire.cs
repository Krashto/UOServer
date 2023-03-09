using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseApothicaire : LivreClasse
	{
        [Constructable]
        public LivreClasseApothicaire() : this(Classe.Apothicaire)
        {
        }

        [Constructable]
        public LivreClasseApothicaire(Classe classe) : base(classe)
        {
            Name = "livre d'apothicaire";
        }

        public LivreClasseApothicaire(Serial serial) : base(serial)
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