using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClassePillard : LivreClasse
	{
        [Constructable]
        public LivreClassePillard() : this(Classe.Pillard)
        {
        }

        [Constructable]
        public LivreClassePillard(Classe classe) : base(classe)
        {
            Name = "livre de pillard";
        }

        public LivreClassePillard(Serial serial) : base(serial)
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