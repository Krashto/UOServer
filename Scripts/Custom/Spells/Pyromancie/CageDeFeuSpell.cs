using System;
using Server.Targeting;
using Server.Misc;
using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Custom.Spells.NewSpells.Totemique;
using Server.Mobiles;

namespace Server.Custom.Spells.NewSpells.Pyromancie
{
	public class CageDeFeuSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Cage de feu", "[Cage de feu]",
				SpellCircle.Sixth,
				230,
				9052,
				Reagent.EssencePyromancie
			);

		public override int RequiredAptitudeValue { get { return 9; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Pyromancie }; } }
		public override SkillName CastSkill { get { return SkillName.Magery; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public CageDeFeuSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(Mobile m)
		{
			if (!Caster.CanSee(m))
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			else if (CheckHSequence(m))
			{
				SpellHelper.Turn(Caster, m);

				var duration = GetDurationForSpell(5, 1);

				CustomUtility.ApplySimpleSpellEffect(Caster, "Cage de feu", duration, AptitudeColor.Pyromancie, SpellEffectType.Bonus);
				CustomUtility.ApplySimpleSpellEffect(m, "Cage de feu", duration, AptitudeColor.Pyromancie, SpellEffectType.Malus);

				int range = 12;
				int hue = 2737;

				int startX = m.Location.X - range / 2;
				int startY = m.Location.Y - range / 2;
				int endY = m.Location.Y + range / 2;

				for (int y = startY; y <= endY; y++)
					new InternalItem(0x3956, hue, new Point3D(startX, y, m.Location.Z), Caster, Caster.Map, duration, true);

				startX = m.Location.X - range / 2;
				startY = m.Location.Y - range / 2;
				int endX = m.Location.X + range / 2;

				for (int x = startX; x <= endX; x++)
					new InternalItem(0x3946, hue, new Point3D(x, startY, m.Location.Z), Caster, Caster.Map, duration, true);

				startX = m.Location.X - range / 2;
				startY = m.Location.Y + range / 2;
				endX = m.Location.X + range / 2;

				for (int x = startX; x <= endX; x++)
					new InternalItem(0x3946, hue, new Point3D(x, startY, m.Location.Z), Caster, Caster.Map, duration, true);

				startX = m.Location.X + range / 2;
				startY = m.Location.Y - range / 2;
				endY = m.Location.Y + range / 2;

				for (int y = startY; y <= endY; y++)
					new InternalItem(0x3956, hue, new Point3D(startX, y, m.Location.Z), Caster, Caster.Map, duration, true);
			}

			FinishSequence();
		}

		[DispellableField]
		private class InternalItem : Item
		{
			private readonly Timer m_Timer;
			private readonly Mobile m_Caster;
			public override bool BlocksFit => true;

			public InternalItem(int itemID, int hue, Point3D loc, Mobile caster, Map map, TimeSpan duration, bool visible) : base(itemID)
			{
				Movable = false;
				Visible = visible;
				Hue = hue;

				MoveToWorld(loc, map);

				m_Caster = caster;

				if (Deleted)
					return;

				m_Timer = new InternalTimer(this, duration);
				m_Timer.Start();
			}

			public InternalItem(Serial serial)
				: base(serial)
			{
				m_Timer = new InternalTimer(this, TimeSpan.FromSeconds(5.0));
				m_Timer.Start();
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

			public override bool OnMoveOver(Mobile m)
			{
				int noto;

				if (m is PlayerMobile)
				{
					noto = Notoriety.Compute(m_Caster, m);
					if (noto == Notoriety.Enemy || noto == Notoriety.Ally)
						return false;

					if (m.Map != null && (m.Map.Rules & MapRules.FreeMovement) == 0)
						return false;
				}
				return base.OnMoveOver(m);
			}

			public override void OnAfterDelete()
			{
				base.OnAfterDelete();

				if (m_Timer != null)
					m_Timer.Stop();
			}

			private class InternalTimer : Timer
			{
				private readonly InternalItem m_Item;
				public InternalTimer(InternalItem item, TimeSpan duration)
					: base(duration)
				{
					Priority = TimerPriority.OneSecond;
					m_Item = item;
				}

				protected override void OnTick()
				{
					m_Item.Delete();
				}
			}
		}

		public class InternalTarget : Target
		{
			private readonly CageDeFeuSpell m_Owner;

			public InternalTarget(CageDeFeuSpell owner)
				: base(15, true, TargetFlags.None)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is Mobile)
					m_Owner.Target((Mobile)o);
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}