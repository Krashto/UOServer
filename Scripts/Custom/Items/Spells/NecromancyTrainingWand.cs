namespace Server.Custom.Items.Spells
{
	public class NecromancyTrainingWand : BaseTrainingWand
	{
		public override SkillName DefSkill => SkillName.Necromancy;

		[Constructable]
		public NecromancyTrainingWand() : base()
		{
		}

		public NecromancyTrainingWand(Serial serial) : base(serial)
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
