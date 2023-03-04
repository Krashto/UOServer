using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseChevalier : LivreClasse
	{
        [Constructable]
        public LivreClasseChevalier() : this(Classe.Chevalier)
        {
        }

        [Constructable]
        public LivreClasseChevalier(Classe classe) : base(classe)
        {
            Name = "livre de chevalier";
        }

        public LivreClasseChevalier(Serial serial) : base(serial)
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