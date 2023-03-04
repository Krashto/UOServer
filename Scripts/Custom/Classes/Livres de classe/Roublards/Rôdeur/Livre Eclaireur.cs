using System;
using Server.Custom.Classes;

namespace Server.Items
{
    [FlipableAttribute(0xFBE, 0xFBD)]
    public class LivreClasseEclaireur : LivreClasse
	{
        [Constructable]
        public LivreClasseEclaireur() : this(Classe.Eclaireur)
        {
        }

        [Constructable]
        public LivreClasseEclaireur(Classe classe) : base(classe)
        {
            Name = "livre d'éclaireur";
        }

        public LivreClasseEclaireur(Serial serial) : base(serial)
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