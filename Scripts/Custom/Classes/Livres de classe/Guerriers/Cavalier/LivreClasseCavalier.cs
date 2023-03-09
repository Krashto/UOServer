using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseCavalier : LivreClasse
	{
        [Constructable]
        public LivreClasseCavalier() : this(Classe.Cavalier)
        {
        }

        [Constructable]
        public LivreClasseCavalier(Classe classe) : base(classe)
        {
            Name = "livre de Cavalier";
        }

        public LivreClasseCavalier(Serial serial) : base(serial)
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