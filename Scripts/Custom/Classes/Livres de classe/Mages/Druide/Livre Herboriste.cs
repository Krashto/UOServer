using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseHerboriste : LivreClasse
	{
        [Constructable]
        public LivreClasseHerboriste() : this(Classe.Herboriste)
        {
        }

        [Constructable]
        public LivreClasseHerboriste(Classe classe) : base(classe)
        {
            Name = "livre de herboriste";
        }

        public LivreClasseHerboriste(Serial serial) : base(serial)
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