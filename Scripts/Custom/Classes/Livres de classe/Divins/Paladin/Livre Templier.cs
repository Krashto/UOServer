using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseTemplier : LivreClasse
	{
        [Constructable]
        public LivreClasseTemplier() : this(Classe.Templier)
        {
        }

        [Constructable]
        public LivreClasseTemplier(Classe classe) : base(classe)
        {
            Name = "livre de templier";
        }

        public LivreClasseTemplier(Serial serial) : base(serial)
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