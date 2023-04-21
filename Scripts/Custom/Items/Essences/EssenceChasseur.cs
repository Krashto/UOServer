using Server.Custom;

namespace Server.Items
{
	public class EssenceChasseur : BaseReagent
	{
		[Constructable]
		public EssenceChasseur() : this(1)
		{
		}

		[Constructable]
		public EssenceChasseur(int amount) : base(0x0F91, amount)
		{
			Name = "Essence: Chasseur";
			Hue = (int)AptitudeColor.Chasseur;
		}

		public EssenceChasseur(Serial serial) : base(serial)
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