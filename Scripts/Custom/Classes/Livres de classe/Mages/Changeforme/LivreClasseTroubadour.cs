using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseMultiforme : LivreClasse
	{
        [Constructable]
        public LivreClasseMultiforme() : this(Classe.Multiforme)
        {
        }

        [Constructable]
        public LivreClasseMultiforme(Classe classe) : base(classe)
        {
            Name = "livre de Multiforme";
        }

        public LivreClasseMultiforme(Serial serial) : base(serial)
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