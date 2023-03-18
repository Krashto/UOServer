using System;
using System.Collections;
using Server.Targeting;
using Server.Misc;
using Server.Items;
using Server.Custom.Aptitudes;
using Server.Spells;

namespace Server.Custom.Spells.NewSpells.Geomancie
{
	public class CageDeFeuSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Cage de feu", "In Flam Grav",
				SpellCircle.Sixth,
				230,
				9052,
				false,
				Reagent.Garlic,
				Reagent.Nightshade,
				Reagent.NoxCrystal
			);

		public override int RequiredAptitudeValue { get { return 9; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Geomancie }; } }
		public override SkillName CastSkill { get { return SkillName.MagicResist; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public CageDeFeuSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(IPoint3D p)
		{
			if (!Caster.CanSee(p))
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			else if (CheckSequence())
			{
				SpellHelper.Turn(Caster, p);

				SpellHelper.GetSurfaceTop(ref p);

				var duration = GetDurationForSpell(5, 0.1);

				new InternalItem(0x3996, new Point3D(p.X - 3, p.Y - 3, p.Z), Caster, Caster.Map, duration, true);
				new InternalItem(0x3996, new Point3D(p.X - 3, p.Y - 2, p.Z), Caster, Caster.Map, duration, true);
				new InternalItem(0x3996, new Point3D(p.X - 3, p.Y - 1, p.Z), Caster, Caster.Map, duration, true);
				new InternalItem(0x3996, new Point3D(p.X - 3, p.Y + 0, p.Z), Caster, Caster.Map, duration, true);
				new InternalItem(0x3996, new Point3D(p.X - 3, p.Y + 1, p.Z), Caster, Caster.Map, duration, true);
				new InternalItem(0x3996, new Point3D(p.X - 3, p.Y + 2, p.Z), Caster, Caster.Map, duration, true);
				new InternalItem(0x3996, new Point3D(p.X - 3, p.Y + 3, p.Z), Caster, Caster.Map, duration, true);

				new InternalItem(0x398C, new Point3D(p.X - 3, p.Y - 3, p.Z), Caster, Caster.Map, duration, true);
				new InternalItem(0x398C, new Point3D(p.X - 2, p.Y - 3, p.Z), Caster, Caster.Map, duration, true);
				new InternalItem(0x398C, new Point3D(p.X - 1, p.Y - 3, p.Z), Caster, Caster.Map, duration, true);
				new InternalItem(0x398C, new Point3D(p.X + 0, p.Y - 3, p.Z), Caster, Caster.Map, duration, true);
				new InternalItem(0x398C, new Point3D(p.X + 1, p.Y - 3, p.Z), Caster, Caster.Map, duration, true);
				new InternalItem(0x398C, new Point3D(p.X + 2, p.Y - 3, p.Z), Caster, Caster.Map, duration, true);
				new InternalItem(0x398C, new Point3D(p.X + 3, p.Y - 3, p.Z), Caster, Caster.Map, duration, true);

				new InternalItem(0x398C, new Point3D(p.X - 3, p.Y + 3, p.Z), Caster, Caster.Map, duration, true);
				new InternalItem(0x398C, new Point3D(p.X - 2, p.Y + 3, p.Z), Caster, Caster.Map, duration, true);
				new InternalItem(0x398C, new Point3D(p.X - 1, p.Y + 3, p.Z), Caster, Caster.Map, duration, true);
				new InternalItem(0x398C, new Point3D(p.X + 0, p.Y + 3, p.Z), Caster, Caster.Map, duration, true);
				new InternalItem(0x398C, new Point3D(p.X + 1, p.Y + 3, p.Z), Caster, Caster.Map, duration, true);
				new InternalItem(0x398C, new Point3D(p.X + 2, p.Y + 3, p.Z), Caster, Caster.Map, duration, true);
				new InternalItem(0x398C, new Point3D(p.X + 3, p.Y + 3, p.Z), Caster, Caster.Map, duration, true);

				new InternalItem(0x3996, new Point3D(p.X + 3, p.Y - 3, p.Z), Caster, Caster.Map, duration, true);
				new InternalItem(0x3996, new Point3D(p.X + 3, p.Y - 2, p.Z), Caster, Caster.Map, duration, true);
				new InternalItem(0x3996, new Point3D(p.X + 3, p.Y - 1, p.Z), Caster, Caster.Map, duration, true);
				new InternalItem(0x3996, new Point3D(p.X + 3, p.Y + 0, p.Z), Caster, Caster.Map, duration, true);
				new InternalItem(0x3996, new Point3D(p.X + 3, p.Y + 1, p.Z), Caster, Caster.Map, duration, true);
				new InternalItem(0x3996, new Point3D(p.X + 3, p.Y + 2, p.Z), Caster, Caster.Map, duration, true);
				new InternalItem(0x3996, new Point3D(p.X + 3, p.Y + 3, p.Z), Caster, Caster.Map, duration, true);
			}

			FinishSequence();
		}

		[DispellableField]
		private class InternalItem : Item
		{
			private Timer m_Timer;
			private DateTime m_End;
			private Mobile m_Caster;

			public override bool BlocksFit { get { return true; } }

			public InternalItem(int itemID, Point3D loc, Mobile caster, Map map, TimeSpan duration, bool visible) : base(itemID)
			{
				var canFit = SpellHelper.AdjustField(ref loc, map, 12, false);

				Visible = false;
				Movable = false;
				Light = LightType.Circle300;

				MoveToWorld(loc, map);

				m_Caster = caster;

				m_End = DateTime.Now + duration;

				m_Timer = new InternalTimer(this, duration);
				m_Timer.Start();
			}

			public override void OnAfterDelete()
			{
				base.OnAfterDelete();

				if (m_Timer != null)
					m_Timer.Stop();
			}

			public InternalItem(Serial serial) : base(serial)
			{
			}

			public override void Serialize(GenericWriter writer)
			{
				base.Serialize(writer);

				writer.Write(1); // version

				writer.Write(m_Caster);
				writer.WriteDeltaTime(m_End);
			}

			public override void Deserialize(GenericReader reader)
			{
				base.Deserialize(reader);

				var version = reader.ReadInt();

				switch (version)
				{
					case 1:
						{
							m_Caster = reader.ReadMobile();

							goto case 0;
						}
					case 0:
						{
							m_End = reader.ReadDeltaTime();

							break;
						}
				}
			}
		}

		private class InternalTimer : Timer
		{
			private InternalItem m_Item;

			public InternalTimer(InternalItem item, TimeSpan duration) : base(duration)
			{
				m_Item = item;

				Priority = TimerPriority.FiftyMS;
			}

			protected override void OnTick()
			{
				if (m_Item.Deleted)
					return;

				m_Item.Delete();
			}
		}

		private class InternalTarget : Target
		{
			private CageDeFeuSpell m_Owner;

			public InternalTarget(CageDeFeuSpell owner)
				: base(12, true, TargetFlags.Harmful)
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