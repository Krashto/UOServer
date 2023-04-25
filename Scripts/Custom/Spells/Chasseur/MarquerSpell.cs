using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using System.Collections;
using System;

namespace Server.Custom.Spells.NewSpells.Chasseur
{
	public class MarquerSpell : Spell
	{
		public static Hashtable m_Timers = new Hashtable();
		public static Hashtable m_Timers2 = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Marquer", "[Marquer]",
				SpellCircle.Sixth,
				230,
				9022,
				Reagent.EssenceChasseur
			);

		public override int RequiredAptitudeValue { get { return 2; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Chasseur }; } }
		public override SkillName CastSkill { get { return SkillName.Tracking; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public MarquerSpell(Mobile caster, Item scroll)
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
			else if (CheckSequence())
			{
				SpellHelper.Turn(Caster, m);

				Deactivate(m);

				var duration = GetDurationForSpell(10);

				Timer t = new InternalTimer(m, DateTime.Now + duration);
				m_Timers[m] = t;
				t.Start();

				Timer t2 = new InternalTimer(m, DateTime.Now + duration);
				m_Timers2[Caster] = t2;
				t.Start();

				CustomUtility.ApplySimpleSpellEffect(m, "Marquer", duration, AptitudeColor.Chasseur, SpellEffectType.Malus);
				CustomUtility.ApplySimpleSpellEffect(Caster, "Marquer", duration, AptitudeColor.Chasseur, SpellEffectType.Bonus);
			}

			FinishSequence();
		}

		public static bool IsActive(Mobile m)
		{
			return m_Timers.ContainsKey(m);
		}

		public static bool IsAttackSpeedBonusActive(Mobile m)
		{
			return m_Timers2.ContainsKey(m);
		}

		public static void Deactivate(Mobile m)
		{
			if (m == null)
				return;

			var t = (Timer)m_Timers[m];

			if (t != null)
			{
				t.Stop();
				m_Timers.Remove(m);

				CustomUtility.ApplySimpleSpellEffect(m, "Marquer", AptitudeColor.Chasseur, SpellSequenceType.End, SpellEffectType.Malus);
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

		private class InternalTarget : Target
		{
			private MarquerSpell m_Owner;

			public InternalTarget(MarquerSpell owner)
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