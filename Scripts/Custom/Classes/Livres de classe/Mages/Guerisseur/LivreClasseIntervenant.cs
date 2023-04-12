using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseIntervenant : LivreClasse
	{
        [Constructable]
        public LivreClasseIntervenant() : this(Classe.Intervenant)
        {
        }

        [Constructable]
        public LivreClasseIntervenant(Classe classe) : base(classe)
        {
            Name = "livre d'intervenant";
        }

        public LivreClasseIntervenant(Serial serial) : base(serial)
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