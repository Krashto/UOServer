using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseCombattant : LivreClasse
	{
        [Constructable]
        public LivreClasseCombattant() : this(Classe.Combattant)
        {
        }

        [Constructable]
        public LivreClasseCombattant(Classe classe) : base(classe)
        {
            Name = "livre de combattant";
        }

        public LivreClasseCombattant(Serial serial) : base(serial)
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