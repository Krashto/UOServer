using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseNaturaliste : LivreClasse
	{
        [Constructable]
        public LivreClasseNaturaliste() : this(Classe.Naturaliste)
        {
        }

        [Constructable]
        public LivreClasseNaturaliste(Classe classe) : base(classe)
        {
            Name = "livre de Naturaliste";
        }

        public LivreClasseNaturaliste(Serial serial) : base(serial)
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