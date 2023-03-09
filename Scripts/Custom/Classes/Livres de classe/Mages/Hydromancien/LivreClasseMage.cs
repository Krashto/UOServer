using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseMage : LivreClasse
	{
        [Constructable]
        public LivreClasseMage() : this(Classe.Mage)
        {
        }

        [Constructable]
        public LivreClasseMage(Classe classe) : base(classe)
        {
            Name = "livre de mage";
        }

        public LivreClasseMage(Serial serial) : base(serial)
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