using System;
using System.Collections;
using Server.Custom.Aptitudes;
using Server.Spells;

namespace Server.Custom.Spells.NewSpells.Martial
{
	public class SecondSouffleSpell : Spell
	{
		private static Hashtable m_Table = new Hashtable();
		private static Hashtable m_Timers = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Second Souffle", "[Second Souffle]",
				SpellCircle.First,
				212,
				9061,
				Reagent.EssenceMartial
			);

		public override int RequiredAptitudeValue { get { return 1; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Martial }; } }
		public override SkillName CastSkill { get { return SkillName.Tactics; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public SecondSouffleSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			if (IsActive(Caster))
				Deactivate(Caster);
			else if (CheckSequence())
			{
				var value = (Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 20;
				m_Table[Caster] = value;

				var duration = GetDurationForSpell(10);

				Timer t = new InternalTimer(Caster, DateTime.Now + duration);
				m_Timers[Caster] = t;
				t.Start();

				CustomUtility.ApplySimpleSpellEffect(Caster, "Second Souffle", duration, AptitudeColor.Martial);
			}

			FinishSequence();
		}

		public static double GetValue(Mobile m)
		{
			return IsActive(m) ? (double)m_Table[m] : 0.0;
		}

		public static bool IsActive(Mobile m)
		{
			return m_Table.ContainsKey(m);
		}

		public static void Deactivate(Mobile m)
		{
			if (m == null)
				return;

			var t = m_Timers[m] as Timer;
			var v = m_Table[m] as double?;

			if (t != null && v != null)
			{
				t.Stop();
				m_Timers.Remove(m);
				m_Table.Remove(m);

				CustomUtility.ApplySimpleSpellEffect(m, "Second Souffle", AptitudeColor.Martial, SpellSequenceType.End);
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