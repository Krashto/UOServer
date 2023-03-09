using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseSage : LivreClasse
	{
        [Constructable]
        public LivreClasseSage() : this(Classe.Sage)
        {
        }

        [Constructable]
        public LivreClasseSage(Classe classe) : base(classe)
        {
            Name = "livre de sage";
        }

        public LivreClasseSage(Serial serial) : base(serial)
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