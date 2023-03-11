using System;
using System.Collections;
using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Custom.Spells.NewSpells.Polymorphie;
using Server.Mobiles;

namespace Server.Custom.Spells.NewSpells.Hydromancie
{
	public class StatutDeGlaceSpell : Spell
	{
		public static Hashtable m_Timers = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Statut de glace", "An Tym",
				SpellCircle.Seventh,
				Core.AOS ? 239 : 215,
				9011,
				Reagent.Garlic,
				Reagent.MandrakeRoot,
				Reagent.SulfurousAsh
			);

		public override int RequiredAptitudeValue { get { return 6; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Hydromancie }; } }
		public override SkillName CastSkill { get { return SkillName.Healing; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public StatutDeGlaceSpell(Mobile caster, Item scroll)
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

				var duration = GetDurationForSpell(0.1);

				if (!FormeMetalliqueSpell.IsActive(m))
				{
					m.Paralyze(duration);

					Timer t = new InternalTimer(m, duration);
					m_Timers[m] = t;
					t.Start();
				}
				else
				{
					Caster.SendMessage("La cible est immunisée à la paralysie.");
				}
			}

			FinishSequence();
		}

		public static bool IsActive(Mobile m)
		{
			return m_Timers.ContainsKey(m);
		}

		public class InternalTimer : Timer
		{
			private Mobile m_Mobile;

			public InternalTimer(Mobile m, TimeSpan duration) : base(duration)
			{
				m_Mobile = m;
				Priority = TimerPriority.TwoFiftyMS;
			}

			protected override void OnTick()
			{
				if (m_Timers.ContainsKey(m_Mobile))
					m_Timers.Remove(m_Mobile);
				m_Mobile.Paralyzed = false;
			}
		}

		private class InternalTarget : Target
		{
			private StatutDeGlaceSpell m_Owner;

			public InternalTarget(StatutDeGlaceSpell owner)
				: base(12, true, TargetFlags.Beneficial)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				var m = o as Mobile;

				if (m != null)
					m_Owner.Target(m);
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}
