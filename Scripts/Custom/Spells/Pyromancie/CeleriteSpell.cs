using System;
using Server.Custom.Aptitudes;
using Server.Spells;
using System.Collections;

namespace Server.Custom.Spells.NewSpells.Pyromancie
{
	public class CeleriteSpell : Spell
	{
		private static Hashtable m_Timers = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Celerite", "[Celerite]",
				SpellCircle.First,
				233,
				9012,
				Reagent.EssencePyromancie
			);

		public override int RequiredAptitudeValue { get { return 3; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Pyromancie }; } }
		public override SkillName CastSkill { get { return SkillName.Magery; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public CeleriteSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				var duration = GetDurationForSpell(15);

				Timer t = new InternalTimer(Caster, DateTime.Now + duration);
				t.Start();

				CustomUtility.ApplySimpleSpellEffect(Caster, "Celerite", duration, AptitudeColor.Pyromancie);
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
				CustomUtility.ApplySimpleSpellEffect(m, "Celerite", AptitudeColor.Pyromancie, SpellSequenceType.End);
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