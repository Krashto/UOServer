using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseEvocateur : LivreClasse
	{
        [Constructable]
        public LivreClasseEvocateur() : this(Classe.Evocateur)
        {
        }

        [Constructable]
        public LivreClasseEvocateur(Classe classe) : base(classe)
        {
            Name = "livre d'évocateur";
        }

        public LivreClasseEvocateur(Serial serial) : base(serial)
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