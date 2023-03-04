using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseFervent : LivreClasse
	{
        [Constructable]
        public LivreClasseFervent() : this(Classe.Fervent)
        {
        }

        [Constructable]
        public LivreClasseFervent(Classe classe) : base(classe)
        {
            Name = "livre de fervent";
        }

        public LivreClasseFervent(Serial serial) : base(serial)
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