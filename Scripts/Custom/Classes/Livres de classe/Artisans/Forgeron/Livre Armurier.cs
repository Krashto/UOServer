using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseArmurier : LivreClasse
	{
        [Constructable]
        public LivreClasseArmurier() : this(Classe.Armurier)
        {
        }

        [Constructable]
        public LivreClasseArmurier(Classe classe) : base(classe)
        {
            Name = "livre d'armurier";
        }

        public LivreClasseArmurier(Serial serial) : base(serial)
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