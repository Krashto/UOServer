namespace Server.Custom.Items.Spells
{
	public class MagicResistTrainingWand : BaseTrainingWand
	{
		public override SkillName DefSkill => SkillName.MagicResist;

		[Constructable]
		public MagicResistTrainingWand() : base()
		{
			Hue = (int)AptitudeColor.Geomancie;
		}

		public MagicResistTrainingWand(Serial serial) : base(serial)
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
