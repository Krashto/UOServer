using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseForgeron : LivreClasse
	{
        [Constructable]
        public LivreClasseForgeron() : this(Classe.Forgeron)
        {
        }

        [Constructable]
        public LivreClasseForgeron(Classe classe) : base(classe)
        {
            Name = "livre de forgeron";
        }

        public LivreClasseForgeron(Serial serial) : base(serial)
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