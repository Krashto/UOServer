using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseProtecteur : LivreClasse
	{
        [Constructable]
        public LivreClasseProtecteur() : this(Classe.Protecteur)
        {
        }

        [Constructable]
        public LivreClasseProtecteur(Classe classe) : base(classe)
        {
            Name = "livre de protecteur";
        }

        public LivreClasseProtecteur(Serial serial) : base(serial)
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