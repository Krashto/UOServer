using Server.Items;
using Server.Mobiles;

namespace Server.Custom.Spells.NewSpells.Totemique
{
	[CorpseName("an earth elemental corpse")]
	public class TotemDeTerre : BaseTotem
	{
		[Constructable]
		public TotemDeTerre() : base(AIType.AI_Mage, FightMode.Closest, 10, 5)
		{
			Name = "Totem de terre";
			Body = 14;
			BaseSoundID = 268;

			SetStr(200);
			SetDex(70);
			SetInt(70);

			SetHits(180);

			SetDamage(14, 21);

			SetDamageType(ResistanceType.Physical, 100);

			SetResistance(ResistanceType.Physical, 65, 75);
			SetResistance(ResistanceType.Fire, 40, 50);
			SetResistance(ResistanceType.Cold, 40, 50);
			SetResistance(ResistanceType.Poison, 40, 50);
			SetResistance(ResistanceType.Energy, 40, 50);

			SetSkill(SkillName.MagicResist, 65.0);
			SetSkill(SkillName.Tactics, 100.0);
			SetSkill(SkillName.Wrestling, 90.0);

			ControlSlots = 1;
			AddItem(new LightSource());
		}

		public TotemDeTerre(Serial serial)
			: base(serial)
		{
		}

		public override double DispelDifficulty => 117.5;

		public override double DispelFocus => 45.0;

		public override void OnThink()
		{
			var mobiles = GetMobilesInRange(5);

			foreach (var m in mobiles)
			{
				if (m == ControlMaster)
					continue;

				m.Combatant = this;
				Combatant = m;
			}
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