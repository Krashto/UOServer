using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseChampion : LivreClasse
	{
        [Constructable]
        public LivreClasseChampion() : this(Classe.Champion)
        {
        }

        [Constructable]
        public LivreClasseChampion(Classe classe) : base(classe)
        {
            Name = "livre de champion";
        }

        public LivreClasseChampion(Serial serial) : base(serial)
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