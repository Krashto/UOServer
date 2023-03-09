using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseMaitreArcher : LivreClasse
	{
        [Constructable]
        public LivreClasseMaitreArcher() : this(Classe.MaitreArcher)
        {
        }

        [Constructable]
        public LivreClasseMaitreArcher(Classe classe) : base(classe)
        {
            Name = "livre de maitre archer";
        }

        public LivreClasseMaitreArcher(Serial serial) : base(serial)
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