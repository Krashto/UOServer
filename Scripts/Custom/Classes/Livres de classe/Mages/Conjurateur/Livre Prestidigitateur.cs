using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClassePrestidigitateur : LivreClasse
	{
        [Constructable]
        public LivreClassePrestidigitateur() : this(Classe.Prestidigitateur)
        {
        }

        [Constructable]
        public LivreClassePrestidigitateur(Classe classe) : base(classe)
        {
            Name = "livre de prestidigitateur";
        }

        public LivreClassePrestidigitateur(Serial serial) : base(serial)
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