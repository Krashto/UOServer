using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseMirmillon : LivreClasse
	{
        [Constructable]
        public LivreClasseMirmillon() : this(Classe.Mirmillon)
        {
        }

        [Constructable]
        public LivreClasseMirmillon(Classe classe) : base(classe)
        {
            Name = "livre de mirmillon";
        }

        public LivreClasseMirmillon(Serial serial) : base(serial)
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