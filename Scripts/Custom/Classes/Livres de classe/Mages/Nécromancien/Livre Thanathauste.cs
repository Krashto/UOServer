using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseThanathauste : LivreClasse
	{
        [Constructable]
        public LivreClasseThanathauste() : this(Classe.Thanathauste)
        {
        }

        [Constructable]
        public LivreClasseThanathauste(Classe classe) : base(classe)
        {
            Name = "livre de thanathauste";
        }

        public LivreClasseThanathauste(Serial serial) : base(serial)
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