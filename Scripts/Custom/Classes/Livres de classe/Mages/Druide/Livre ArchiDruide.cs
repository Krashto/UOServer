using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseArchiDruide : LivreClasse
	{
        [Constructable]
        public LivreClasseArchiDruide() : this(Classe.ArchiDruide)
        {
        }

        [Constructable]
        public LivreClasseArchiDruide(Classe classe) : base(classe)
        {
            Name = "livre d'archi druide";
        }

        public LivreClasseArchiDruide(Serial serial) : base(serial)
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