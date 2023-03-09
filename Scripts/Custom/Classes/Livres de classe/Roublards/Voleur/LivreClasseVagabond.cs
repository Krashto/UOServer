using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseVagabond : LivreClasse
	{
        [Constructable]
        public LivreClasseVagabond() : this(Classe.Vagabond)
        {
        }

        [Constructable]
        public LivreClasseVagabond(Classe classe) : base(classe)
        {
            Name = "livre du Vagabond";
        }

        public LivreClasseVagabond(Serial serial) : base(serial)
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