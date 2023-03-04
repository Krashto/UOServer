using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseForgefer : LivreClasse
	{
        [Constructable]
        public LivreClasseForgefer() : this(Classe.Forgefer)
        {
        }

        [Constructable]
        public LivreClasseForgefer(Classe classe) : base(classe)
        {
            Name = "livre de forgefer";
        }

        public LivreClasseForgefer(Serial serial) : base(serial)
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