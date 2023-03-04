using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseBerseker : LivreClasse
	{
        [Constructable]
        public LivreClasseBerseker() : this(Classe.Berseker)
        {
        }

        [Constructable]
        public LivreClasseBerseker(Classe classe) : base(classe)
        {
            Name = "livre de berseker";
        }

        public LivreClasseBerseker(Serial serial) : base(serial)
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