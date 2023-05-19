using System;
using System.Linq;
using Server.Items;
using Server.Mobiles;
using Server.Spells;

namespace Server.Custom.Spells.NewSpells.Totemique
{
	[CorpseName("an air elemental corpse")]
	public class TotemDuVent : BaseTotem
	{
		[Constructable]
		public TotemDuVent() : base(AIType.AI_Melee, FightMode.Closest, 10, 1)
		{
			Name = "Totem du vent";
			Body = 13;
			Hue = 0x4001;
			BaseSoundID = 655;

			SetStr(200);
			SetDex(200);
			SetInt(100);

			SetHits(150);
			SetStam(50);

			SetDamage(6, 9);

			SetDamageType(ResistanceType.Physical, 50);
			SetDamageType(ResistanceType.Energy, 50);

			SetResistance(ResistanceType.Physical, 40, 50);
			SetResistance(ResistanceType.Fire, 30, 40);
			SetResistance(ResistanceType.Cold, 35, 45);
			SetResistance(ResistanceType.Poison, 50, 60);
			SetResistance(ResistanceType.Energy, 70, 80);

			SetSkill(SkillName.Meditation, 90.0);
			SetSkill(SkillName.EvalInt, 70.0);
			SetSkill(SkillName.Magery, 70.0);
			SetSkill(SkillName.MagicResist, 60.0);
			SetSkill(SkillName.Tactics, 100.0);
			SetSkill(SkillName.Wrestling, 80.0);

			ControlSlots = 3;
		}

		public TotemDuVent(Serial serial)
			: base(serial)
		{
		}

		public override double DispelDifficulty => 117.5;
		public override int Level => 2;
		public override double DispelFocus => 45.0;

		public override void OnThink()
		{
			CantWalk = !MarcheASuivreEnable;

			if (NextThinkingTime >= DateTime.Now)
				return;

			var mobiles = GetMobilesInRange(5);

			var count = 0;

			foreach (var m in mobiles)
			{
				if (count >= 3)
					break;

				if (m == ControlMaster || !CanSee(m) || !InLOS(m))
					continue;

				if (m is BaseTotem totem && totem.ControlMaster == ControlMaster)
					continue;

				if (CustomPlayerMobile.IsInEquipe(ControlMaster, m))
					continue;

				if (m.AccessLevel > AccessLevel.Player || m.Blessed || m is BaseVendor)
					continue;

				if (CanSee(m))
				{
					SpellHelper.Turn(this, m);

					double damage = 100;

					if (SuperCharged)
						damage *= 2;

					if (mobiles.Count() > 2)
						damage = damage * 2 / mobiles.Count();

					if (damage > 50)
						damage = 50;

					Effects.SendBoltEffect(m, true, 0, false);

					m.Damage((int)damage);

					count++;
				}
			}

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
