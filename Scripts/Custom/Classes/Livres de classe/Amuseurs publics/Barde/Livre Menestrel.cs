using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseMenestrel : LivreClasse
	{
        [Constructable]
        public LivreClasseMenestrel() : this(Classe.Menestrel)
        {
        }

        [Constructable]
        public LivreClasseMenestrel(Classe classe) : base(classe)
        {
            Name = "livre de ménestrel";
        }

        public LivreClasseMenestrel(Serial serial) : base(serial)
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