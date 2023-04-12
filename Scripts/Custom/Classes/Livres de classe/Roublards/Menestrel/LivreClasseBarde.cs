using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseBarde : LivreClasse
	{
        [Constructable]
        public LivreClasseBarde() : this(Classe.Barde)
        {
        }

        [Constructable]
        public LivreClasseBarde(Classe classe) : base(classe)
        {
            Name = "livre de barde";
        }

        public LivreClasseBarde(Serial serial) : base(serial)
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