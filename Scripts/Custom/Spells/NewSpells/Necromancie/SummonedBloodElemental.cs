using Server.Mobiles;

namespace Server.Custom.Spells.NewSpells.Necromancie
{
	[CorpseName("a lich corpse")]
	public class SummonedBloodElemental : BaseCreature
	{
		public override double DispelDifficulty { get { return 90; } }
		public override double DispelFocus { get { return 70.0; } }
		public override bool DeleteCorpseOnDeath { get { return true; } }

		[Constructable]
		public SummonedBloodElemental() : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			Name = "Elemental de sang";
			Body = 159;
			BaseSoundID = 278;

			SetStr(526, 615);
			SetDex(66, 85);
			SetInt(226, 350);

			SetHits(316, 369);

			SetDamage(17, 27);

			SetDamageType(ResistanceType.Physical, 0);
			SetDamageType(ResistanceType.Poison, 50);
			SetDamageType(ResistanceType.Energy, 50);

			SetResistance(ResistanceType.Physical, 55, 65);
			SetResistance(ResistanceType.Fire, 20, 30);
			SetResistance(ResistanceType.Cold, 40, 50);
			SetResistance(ResistanceType.Poison, 50, 60);
			SetResistance(ResistanceType.Energy, 30, 40);

			SetSkill(SkillName.EvalInt, 85.1, 100.0);
			SetSkill(SkillName.Magery, 85.1, 100.0);
			SetSkill(SkillName.Meditation, 10.4, 50.0);
			SetSkill(SkillName.MagicResist, 80.1, 95.0);
			SetSkill(SkillName.Tactics, 80.1, 100.0);
			SetSkill(SkillName.Wrestling, 80.1, 100.0);

			VirtualArmor = 71;

			ControlSlots = 4;
		}

		public SummonedBloodElemental(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
		}
	}
}