using System;
using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Custom.Spells.NewSpells.Polymorphie;
using System.Collections;
using VitaNex.FX;

namespace Server.Custom.Spells.NewSpells.Geomancie
{
	public class RacinesSpell : Spell
	{
		private static Hashtable m_Timers = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Racines", "An Por Choma",
				SpellCircle.Fifth,
				218,
				9012,
				Reagent.Garlic,
				Reagent.MandrakeRoot,
				Reagent.SpidersSilk
			);

		public override int RequiredAptitudeValue { get { return 9; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Geomancie }; } }
		public override SkillName CastSkill { get { return SkillName.MagicResist; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public RacinesSpell(Mobile caster, Item scroll)
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

				SpellHelper.CheckReflect((int)Circle, Caster, ref m);

				if (!IndomptableSpell.IsActive(m))
				{
					var duration = GetDurationForSpell(10);
					SpellHelper.Turn(Caster, m);

					ConcentricWaveFX.Brambles.CreateInstance(Caster, Caster.Map, Caster.Direction, (int)Caster.GetDistanceToSqrt(m.Location));

					var loc = new Point3D(m.X + 1, m.Y, m.Z);
					new InternalItem(0x0D3F, loc, Caster, m.Map, duration);
					loc = new Point3D(m.X + 1, m.Y + 1, m.Z);
					new InternalItem(0x0D40, loc, Caster, m.Map, duration);
					loc = new Point3D(m.X, m.Y + 1, m.Z);
					new InternalItem(0x3020, loc, Caster, m.Map, duration);
					loc = new Point3D(m.X, m.Y - 1, m.Z);
					new InternalItem(0x3022, loc, Caster, m.Map, duration);
					loc = new Point3D(m.X - 1, m.Y, m.Z);
					new InternalItem(0x3023, loc, Caster, m.Map, duration);

					m.CantWalk = true;
					BuffInfo.AddBuff(Caster, new BuffInfo(BuffIcon.Paralyze, 1095150, 1095151, duration, Caster));

					Timer t = new InternalTimer(Caster, DateTime.Now + duration);
					m_Timers[Caster] = t;
					t.Start();

					m.PlaySound(0x204);
					m.FixedEffect(0x376A, 6, 1);
				}
				else
					Caster.SendMessage("La cible est immunisée à la paralysie.");
			}

			FinishSequence();
		}

		public static bool IsActive(Mobile m)
		{
			return m_Timers.ContainsKey(m);
		}

		public static void Deactivate(Mobile m)
		{
			if (m == null)
				return;

			var t = m_Timers[m] as Timer;

			if (t != null)
			{
				t.Stop();
				m_Timers.Remove(m);

				m.CantWalk = false;

				m.FixedParticles(14217, 10, 20, 5013, 1942, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
				m.PlaySound(508);
			}
		}

		private class InternalItem : Item
		{
			private Timer m_Timer;
			private Mobile m_Caster;
			private TimeSpan m_Dura;

			public override bool BlocksFit { get { return true; } }

			public InternalItem(int itemID, Point3D loc, Mobile caster, Map map, TimeSpan duration) : base(itemID)
			{
				var canFit = SpellHelper.AdjustField(ref loc, map, 12, false);

				Visible = true;
				Movable = false;

				MoveToWorld(loc, map);

				m_Caster = caster;
				m_Dura = duration;
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
							m_Timer = new InternalTimer(this, m_Dura);
							m_Timer.Start();

							break;
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
		}

		public class InternalTarget : Target
		{
			private RacinesSpell m_Owner;

			public InternalTarget(RacinesSpell owner)
				: base(12, false, TargetFlags.Harmful)
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

		public class InternalTimer : Timer
		{
			private Mobile m_Mobile;
			private DateTime m_EndTime;

			public InternalTimer(Mobile m, DateTime endTime) : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
			{
				m_Mobile = m;
				m_EndTime = endTime;

				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				if (DateTime.Now >= m_EndTime && m_Timers.Contains(m_Mobile) || m_Mobile == null || m_Mobile.Deleted || !m_Mobile.Alive)
				{
					Deactivate(m_Mobile);
					Stop();
				}
			}
		}
	}
}