using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseNecromage : LivreClasse
	{
        [Constructable]
        public LivreClasseNecromage() : this(Classe.Necromage)
        {
        }

        [Constructable]
        public LivreClasseNecromage(Classe classe) : base(classe)
        {
            Name = "livre de nécromage";
        }

        public LivreClasseNecromage(Serial serial) : base(serial)
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