using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseApprenti : LivreClasse
	{
        [Constructable]
        public LivreClasseApprenti() : this(Classe.Apprenti)
        {
        }

        [Constructable]
        public LivreClasseApprenti(Classe classe) : base(classe)
        {
            Name = "livre d'Apprenti";
        }

        public LivreClasseApprenti(Serial serial) : base(serial)
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