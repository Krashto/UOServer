using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseIntermediaireDivin : LivreClasse
	{
        [Constructable]
        public LivreClasseIntermediaireDivin() : this(Classe.IntermediaireDivin)
        {
        }

        [Constructable]
        public LivreClasseIntermediaireDivin(Classe classe) : base(classe)
        {
            Name = "livre d'intermédiaire divin";
        }

        public LivreClasseIntermediaireDivin(Serial serial) : base(serial)
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