using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClassePyromancien : LivreClasse
	{
        [Constructable]
        public LivreClassePyromancien() : this(Classe.Pyromancien)
        {
        }

        [Constructable]
        public LivreClassePyromancien(Classe classe) : base(classe)
        {
            Name = "livre de Pyromancien";
        }

        public LivreClassePyromancien(Serial serial) : base(serial)
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