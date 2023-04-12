using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseSoigneur : LivreClasse
	{
        [Constructable]
        public LivreClasseSoigneur() : this(Classe.Soigneur)
        {
        }

        [Constructable]
        public LivreClasseSoigneur(Classe classe) : base(classe)
        {
            Name = "livre de Soigneur";
        }

        public LivreClasseSoigneur(Serial serial) : base(serial)
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