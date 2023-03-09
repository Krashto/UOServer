using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseEcuyer : LivreClasse
	{
        [Constructable]
        public LivreClasseEcuyer() : this(Classe.Ecuyer)
        {
        }

        [Constructable]
        public LivreClasseEcuyer(Classe classe) : base(classe)
        {
            Name = "livre d'écuyer";
        }

        public LivreClasseEcuyer(Serial serial) : base(serial)
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