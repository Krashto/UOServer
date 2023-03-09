using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseAeromancien : LivreClasse
	{
        [Constructable]
        public LivreClasseAeromancien() : this(Classe.Aeromancien)
        {
        }

        [Constructable]
        public LivreClasseAeromancien(Classe classe) : base(classe)
        {
            Name = "livre d'aéromancien";
        }

        public LivreClasseAeromancien(Serial serial) : base(serial)
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