using Server.Custom;

namespace Server.Items
{
	public class EssenceDefenseur : BaseReagent
	{
		[Constructable]
		public EssenceDefenseur() : this(1)
		{
		}

		[Constructable]
		public EssenceDefenseur(int amount) : base(0x0F91, amount)
		{
			Name = "Essence: Défenseur";
			Hue = (int)AptitudeColor.Defenseur;
		}

		public EssenceDefenseur(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}