using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using System.Collections;
using System;

namespace Server.Custom.Spells.NewSpells.Guerison
{
	public class FrayeurSpell : Spell
	{
		private static Hashtable m_Timers = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Frayeur", "[Frayeur]",
				SpellCircle.First,
				212,
				9061,
				Reagent.Garlic,
				Reagent.Ginseng
			);

		public override int RequiredAptitudeValue { get { return 6; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Guerison }; } }
		public override SkillName CastSkill { get { return SkillName.Healing; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public FrayeurSpell(Mobile caster, Item scroll)
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
			else if (CheckBSequence(m))
			{
				SpellHelper.Turn(Caster, m);

				var duration = GetDurationForSpell(2);

				Timer t = new InternalTimer(Caster, DateTime.Now + duration);
				m_Timers[Caster] = t;
				t.Start();

				m.Emote("*A terriblement peur*");

				m.FixedParticles(0x373A, 10, 15, 5012, EffectLayer.Waist);
				m.PlaySound(0x1E0);
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

				m.FixedParticles(14217, 10, 20, 5013, 1942, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
				m.PlaySound(508);
			}
		}

		public class InternalTimer : Timer
		{
			private Mobile m_Mobile;
			private DateTime m_EndTime;

			public InternalTimer(Mobile m, DateTime endTime) : base(TimeSpan.Zero, TimeSpan.FromMilliseconds(100))
			{
				m_Mobile = m;
				m_EndTime = endTime;

				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				try
				{
					m_Mobile.Direction = (Direction)Utility.Random((int)Direction.North, (int)Direction.Up);
					m_Mobile.NetState.BlockAllPackets = true;
					m_Mobile.Move(m_Mobile.Direction);
					m_Mobile.NetState.BlockAllPackets = false;
					m_Mobile.ProcessDelta();
				}
				catch (Exception e)
				{
					Diagnostics.ExceptionLogging.LogException(e);
				}

				if (DateTime.Now >= m_EndTime && m_Timers.Contains(m_Mobile) || m_Mobile == null || m_Mobile.Deleted || !m_Mobile.Alive)
				{
					Deactivate(m_Mobile);
					Stop();
				}
			}
		}

		public class InternalTarget : Target
		{
			private FrayeurSpell m_Owner;

			public InternalTarget(FrayeurSpell owner)
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
	}
}