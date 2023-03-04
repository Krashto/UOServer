using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseConjurateur : LivreClasse
	{
        [Constructable]
        public LivreClasseConjurateur() : this(Classe.Conjurateur)
        {
        }

        [Constructable]
        public LivreClasseConjurateur(Classe classe) : base(classe)
        {
            Name = "livre de conjurateur";
        }

        public LivreClasseConjurateur(Serial serial) : base(serial)
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