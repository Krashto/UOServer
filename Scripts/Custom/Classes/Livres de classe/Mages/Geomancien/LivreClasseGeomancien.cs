using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseGeomancien : LivreClasse
	{
        [Constructable]
        public LivreClasseGeomancien() : this(Classe.Geomancien)
        {
        }

        [Constructable]
        public LivreClasseGeomancien(Classe classe) : base(classe)
        {
            Name = "livre de G�omancien";
        }

        public LivreClasseGeomancien(Serial serial) : base(serial)
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