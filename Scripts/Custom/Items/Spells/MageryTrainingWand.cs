namespace Server.Custom.Items.Spells
{
	public class MageryTrainingWand : BaseTrainingWand
	{
		public override SkillName DefSkill => SkillName.Magery;

		[Constructable]
		public MageryTrainingWand() : base()
		{
			Hue = (int)AptitudeColor.Pyromancie;
		}

		public MageryTrainingWand(Serial serial) : base(serial)
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
