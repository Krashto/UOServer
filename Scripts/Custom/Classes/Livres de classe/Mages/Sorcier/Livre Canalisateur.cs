using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseCanalisateur : LivreClasse
	{
        [Constructable]
        public LivreClasseCanalisateur() : this(Classe.Canalisateur)
        {
        }

        [Constructable]
        public LivreClasseCanalisateur(Classe classe) : base(classe)
        {
            Name = "livre de canalisateur";
        }

        public LivreClasseCanalisateur(Serial serial) : base(serial)
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