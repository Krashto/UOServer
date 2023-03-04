using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseSorcier : LivreClasse
	{
        [Constructable]
        public LivreClasseSorcier() : this(Classe.Sorcier)
        {
        }

        [Constructable]
        public LivreClasseSorcier(Classe classe) : base(classe)
        {
            Name = "livre de sorcier";
        }

        public LivreClasseSorcier(Serial serial) : base(serial)
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