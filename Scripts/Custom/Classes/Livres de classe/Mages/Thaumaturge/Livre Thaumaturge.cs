using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseThaumaturge : LivreClasse
	{
        [Constructable]
        public LivreClasseThaumaturge() : this(Classe.Thaumaturge)
        {
        }

        [Constructable]
        public LivreClasseThaumaturge(Classe classe) : base(classe)
        {
            Name = "livre de thaumaturge";
        }

        public LivreClasseThaumaturge(Serial serial) : base(serial)
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