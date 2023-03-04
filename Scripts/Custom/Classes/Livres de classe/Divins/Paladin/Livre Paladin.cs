using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClassePaladin : LivreClasse
	{
        [Constructable]
        public LivreClassePaladin() : this(Classe.Paladin)
        {
        }

        [Constructable]
        public LivreClassePaladin(Classe classe) : base(classe)
        {
            Name = "livre de paladin";
        }

        public LivreClassePaladin(Serial serial) : base(serial)
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