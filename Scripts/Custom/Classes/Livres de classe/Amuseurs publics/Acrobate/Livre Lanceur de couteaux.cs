using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseLanceurDeCouteaux : LivreClasse
	{
        [Constructable]
        public LivreClasseLanceurDeCouteaux() : this(Classe.LanceurDeCouteaux)
        {
        }

        [Constructable]
        public LivreClasseLanceurDeCouteaux(Classe classe) : base(classe)
        {
            Name = "livre de lanceur de couteaux";
        }

        public LivreClasseLanceurDeCouteaux(Serial serial) : base(serial)
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