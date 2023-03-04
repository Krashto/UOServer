using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseBrute : LivreClasse
	{
        [Constructable]
        public LivreClasseBrute() : this(Classe.Brute)
        {
        }

        [Constructable]
        public LivreClasseBrute(Classe classe) : base(classe)
        {
            Name = "livre de brute";
        }

        public LivreClasseBrute(Serial serial) : base(serial)
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