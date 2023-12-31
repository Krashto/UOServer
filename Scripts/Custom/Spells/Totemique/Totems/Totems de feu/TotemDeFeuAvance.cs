using System;
using System.Linq;
using Server.Items;
using Server.Mobiles;
using Server.Spells;

namespace Server.Custom.Spells.NewSpells.Totemique
{
	[CorpseName("a fire elemental corpse")]
	public class TotemDeFeuAvance : BaseTotemDeFeu
	{
		[Constructable]
		public TotemDeFeuAvance() : base(AIType.AI_Melee, FightMode.Closest, 10, 1)
		{
			Name = "Totem de feu";
			Body = 15;
			BaseSoundID = 838;

			SetStr(200);
			SetDex(200);
			SetInt(100);

			SetDamage(9, 14);

			SetDamageType(ResistanceType.Physical, 0);
			SetDamageType(ResistanceType.Fire, 100);

			SetResistance(ResistanceType.Physical, 50, 60);
			SetResistance(ResistanceType.Fire, 70, 80);
			SetResistance(ResistanceType.Cold, 0, 10);
			SetResistance(ResistanceType.Poison, 50, 60);
			SetResistance(ResistanceType.Energy, 50, 60);

			SetSkill(SkillName.EvalInt, 90.0);
			SetSkill(SkillName.Magery, 90.0);
			SetSkill(SkillName.MagicResist, 85.0);
			SetSkill(SkillName.Tactics, 100.0);
			SetSkill(SkillName.Wrestling, 92.0);

			ControlSlots = 3;
			CantWalk = true;
			ControlOrder = OrderType.Stay;
			AddItem(new LightSource());
		}

		public TotemDeFeuAvance(Serial serial)
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

					double damage = 50;

					if (SuperCharged)
						damage *= 2;

					if (mobiles.Count() > 2)
						damage = damage * 2 / mobiles.Count();

					if (damage > 25)
						damage = 25;

					MovingParticles(m, 0x36D4, 7, 0, false, true, 9501, 1, 0, 0x100);

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
