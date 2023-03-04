using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseNecromancien : LivreClasse
	{
        [Constructable]
        public LivreClasseNecromancien() : this(Classe.Necromancien)
        {
        }

        [Constructable]
        public LivreClasseNecromancien(Classe classe) : base(classe)
        {
            Name = "livre de nécromancien";
        }

        public LivreClasseNecromancien(Serial serial) : base(serial)
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