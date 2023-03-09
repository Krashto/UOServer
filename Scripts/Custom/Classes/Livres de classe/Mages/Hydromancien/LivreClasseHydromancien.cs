using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseHydromancien : LivreClasse
	{
        [Constructable]
        public LivreClasseHydromancien() : this(Classe.Hydromancien)
        {
        }

        [Constructable]
        public LivreClasseHydromancien(Classe classe) : base(classe)
        {
            Name = "livre de Hydromancien";
        }

        public LivreClasseHydromancien(Serial serial) : base(serial)
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