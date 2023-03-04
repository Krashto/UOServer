using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseAlchimiste : LivreClasse
	{
        [Constructable]
        public LivreClasseAlchimiste() : this(Classe.Alchimiste)
        {
        }

        [Constructable]
        public LivreClasseAlchimiste(Classe classe) : base(classe)
        {
            Name = "livre d'alchimiste";
        }

        public LivreClasseAlchimiste(Serial serial) : base(serial)
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