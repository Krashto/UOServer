using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseBarbare : LivreClasse
	{
        [Constructable]
        public LivreClasseBarbare() : this(Classe.Barbare)
        {
        }

        [Constructable]
        public LivreClasseBarbare(Classe classe) : base(classe)
        {
            Name = "livre de barbare";
        }

        public LivreClasseBarbare(Serial serial) : base(serial)
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