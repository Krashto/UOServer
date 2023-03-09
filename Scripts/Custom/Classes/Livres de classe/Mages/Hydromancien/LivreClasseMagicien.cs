using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseMagicien : LivreClasse
	{
        [Constructable]
        public LivreClasseMagicien() : this(Classe.Magicien)
        {
        }

        [Constructable]
        public LivreClasseMagicien(Classe classe) : base(classe)
        {
            Name = "livre de magicien";
        }

        public LivreClasseMagicien(Serial serial) : base(serial)
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