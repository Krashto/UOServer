using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseInvocateur : LivreClasse
	{
        [Constructable]
        public LivreClasseInvocateur() : this(Classe.Invocateur)
        {
        }

        [Constructable]
        public LivreClasseInvocateur(Classe classe) : base(classe)
        {
            Name = "livre de Invocateur";
        }

        public LivreClasseInvocateur(Serial serial) : base(serial)
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