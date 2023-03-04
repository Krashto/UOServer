using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseAcrobate : LivreClasse
	{
        [Constructable]
        public LivreClasseAcrobate() : this(Classe.Acrobate)
        {
        }

        [Constructable]
        public LivreClasseAcrobate(Classe classe) : base(classe)
        {
            Name = "livre d'acrobate";
        }

        public LivreClasseAcrobate(Serial serial) : base(serial)
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