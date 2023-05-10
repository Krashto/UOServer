using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Custom.Spells.NewSpells.Totemique
{
	[CorpseName("a water elemental corpse")]
	public class TotemDenergie : BaseTotem
	{
		private DateTime m_EndTime { get; set; }

		[Constructable]
		public TotemDenergie() : this(TimeSpan.FromSeconds(30))
		{
		}

		public TotemDenergie(TimeSpan duration) : base(AIType.AI_Melee, FightMode.Closest, 10, 1)
		{
			m_EndTime = DateTime.Now + duration;

			Name = "Totem d'énergie";
			Body = 164;
			BaseSoundID = 278;
			Blessed = true;

			SetStr(200);
			SetDex(70);
			SetInt(100);

			SetHits(165);

			SetDamage(12, 16);

			SetDamageType(ResistanceType.Physical, 0);
			SetDamageType(ResistanceType.Cold, 100);

			SetResistance(ResistanceType.Physical, 50, 60);
			SetResistance(ResistanceType.Fire, 20, 30);
			SetResistance(ResistanceType.Cold, 70, 80);
			SetResistance(ResistanceType.Poison, 45, 55);
			SetResistance(ResistanceType.Energy, 40, 50);

			SetSkill(SkillName.Meditation, 90.0);
			SetSkill(SkillName.EvalInt, 80.0);
			SetSkill(SkillName.Magery, 80.0);
			SetSkill(SkillName.MagicResist, 75.0);
			SetSkill(SkillName.Tactics, 100.0);
			SetSkill(SkillName.Wrestling, 85.0);

			ControlSlots = 1;
		}

		public TotemDenergie(Serial serial)
			: base(serial)
		{
		}

		public override double DispelDifficulty => 117.5;
		public override int Level => 4;

		public override double DispelFocus => 45.0;

		public override void OnThink()
		{
			CantWalk = !MarcheASuivreEnable;

			if (m_EndTime < DateTime.Now)
				Delete();

			if (NextThinkingTime >= DateTime.Now)
				return;

			base.OnThink();
		}

		public override void OnDeath(Container c)
		{
			Delete();
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			reader.ReadInt();
		}
	}
}
