using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseFrancTireur : LivreClasse
	{
        [Constructable]
        public LivreClasseFrancTireur() : this(Classe.FrancTireur)
        {
        }

        [Constructable]
        public LivreClasseFrancTireur(Classe classe) : base(classe)
        {
            Name = "livre de franc-tireur";
        }

        public LivreClasseFrancTireur(Serial serial) : base(serial)
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