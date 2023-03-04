using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseRepurgateur : LivreClasse
	{
        [Constructable]
        public LivreClasseRepurgateur() : this(Classe.Repurgateur)
        {
        }

        [Constructable]
        public LivreClasseRepurgateur(Classe classe) : base(classe)
        {
            Name = "livre de répurgateur";
        }

        public LivreClasseRepurgateur(Serial serial) : base(serial)
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