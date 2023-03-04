using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseMaraudeur : LivreClasse
	{
        [Constructable]
        public LivreClasseMaraudeur() : this(Classe.Maraudeur)
        {
        }

        [Constructable]
        public LivreClasseMaraudeur(Classe classe) : base(classe)
        {
            Name = "livre de maraudeur";
        }

        public LivreClasseMaraudeur(Serial serial) : base(serial)
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