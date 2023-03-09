using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseRoublard : LivreClasse
	{
        [Constructable]
        public LivreClasseRoublard() : this(Classe.Roublard)
        {
        }

        [Constructable]
        public LivreClasseRoublard(Classe classe) : base(classe)
        {
            Name = "livre de Roublard";
        }

        public LivreClasseRoublard(Serial serial) : base(serial)
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