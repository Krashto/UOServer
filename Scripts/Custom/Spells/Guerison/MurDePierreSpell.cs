using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Mobiles;
using Server.Misc;
using System;

namespace Server.Custom.Spells.NewSpells.Guerison
{
	public class MurDePierreSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Mur de pierre", "[Mur de pierre]",
				SpellCircle.First,
				212,
				9061,
				Reagent.EssenceGuerison
			);

		public override int RequiredAptitudeValue { get { return 5; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Guerison }; } }
		public override SkillName CastSkill { get { return SkillName.Healing; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public MurDePierreSpell(Mobile caster, Item scroll)
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
			{
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			}
			else if (SpellHelper.CheckTown(p, Caster) && SpellHelper.CheckWater(new Point3D(p), Caster.Map) && CheckSequence())
			{
				SpellHelper.Turn(Caster, p);

				SpellHelper.GetSurfaceTop(ref p);

				int dx = Caster.Location.X - p.X;
				int dy = Caster.Location.Y - p.Y;
				int rx = (dx - dy) * 44;
				int ry = (dx + dy) * 44;

				bool eastToWest;

				if (rx >= 0 && ry >= 0)
				{
					eastToWest = false;
				}
				else if (rx >= 0)
				{
					eastToWest = true;
				}
				else if (ry >= 0)
				{
					eastToWest = true;
				}
				else
				{
					eastToWest = false;
				}

				Effects.PlaySound(p, Caster.Map, 0x1F6);

				for (int i = -2; i <= 2; ++i)
				{
					Point3D loc = new Point3D(eastToWest ? p.X + i : p.X, eastToWest ? p.Y : p.Y + i, p.Z);

					if (SpellHelper.CheckWater(loc, Caster.Map) && SpellHelper.CheckField(loc, Caster.Map))
					{
						Item item = new InternalItem(loc, Caster.Map, Caster, this);
						Effects.SendLocationParticles(item, 0x376A, 9, 10, 5025);
					}
				}
			}

			FinishSequence();
		}

		[DispellableField]
		private class InternalItem : Item
		{
			private readonly Mobile m_Caster;
			private Timer m_Timer;
			private DateTime m_End;
			private MurDePierreSpell m_Owner;
			public InternalItem(Point3D loc, Map map, Mobile caster, MurDePierreSpell owner)
				: base(0x82)
			{
				Movable = false;

				MoveToWorld(loc, map);

				m_Caster = caster;
				m_Owner = owner;

				if (Deleted)
					return;

				var duration = m_Owner.GetDurationForSpell(10);

				if (InquisitionSpell.IsActive(m_Caster))
					duration += m_Owner.GetDurationForSpell(5);

				m_Timer = new InternalTimer(this, duration);
				m_Timer.Start();

				m_End = DateTime.UtcNow + TimeSpan.FromSeconds(10.0);
			}

			public InternalItem(Serial serial)
				: base(serial)
			{
			}

			public override bool BlocksFit => true;
			public override void Serialize(GenericWriter writer)
			{
				base.Serialize(writer);

				writer.Write(1); // version

				writer.WriteDeltaTime(m_End);
			}

			public override void Deserialize(GenericReader reader)
			{
				base.Deserialize(reader);

				int version = reader.ReadInt();

				switch (version)
				{
					case 1:
						{
							m_End = reader.ReadDeltaTime();

							m_Timer = new InternalTimer(this, m_End - DateTime.UtcNow);
							m_Timer.Start();

							break;
						}
					case 0:
						{
							TimeSpan duration = TimeSpan.FromSeconds(10.0);

							m_Timer = new InternalTimer(this, duration);
							m_Timer.Start();

							m_End = DateTime.UtcNow + duration;

							break;
						}
				}
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
			private readonly MurDePierreSpell m_Owner;
			public InternalTarget(MurDePierreSpell owner)
				: base(15, true, TargetFlags.None)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is IPoint3D)
					m_Owner.Target((IPoint3D)o);
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}