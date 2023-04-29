﻿using Server.Custom.Items.TrainingWeapon;

namespace Server.Items
{
    [Flipable(0xF5C, 0xF5D)]
	public class TrainingMace : BaseTrainingMeleeWeapon
	{
		[Constructable]
		public TrainingMace()
			: base(0xF5C)
		{
			Name = "Masse d'entrainement";
		}

		public TrainingMace(Serial serial)
			: base(serial)
		{
		}

		public override int StrengthReq => 1;
		public override int MinDamage => 1;
		public override int MaxDamage => 1;
		public override float Speed => 3.25f;

		public override int DefHitSound => 0x237;
		public override int DefMissSound => 0x23A;
		public override int InitMinHits => 100;
		public override int InitMaxHits => 100;
		public override SkillName DefSkill => SkillName.Macing;
		public override WeaponType DefType => WeaponType.Bashing;
		public override WeaponAnimation DefAnimation => WeaponAnimation.Bash1H;

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
