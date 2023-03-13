using Server.Custom.Classes;

namespace Server.Items
{
	[FlipableAttribute(0xFBE, 0xFBD)]
	public class LivreClasseAucune : LivreClasse
	{
		[Constructable]
		public LivreClasseAucune() : this(Classe.Aucune)
		{
		}

		[Constructable]
		public LivreClasseAucune(Classe classe) : base(classe)
		{
			Name = "Livre d'oubli de classe";
		}

		public LivreClasseAucune(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}