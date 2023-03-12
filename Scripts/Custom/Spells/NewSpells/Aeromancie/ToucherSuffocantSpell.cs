using System;
using Server.Targeting;
using System.Collections;
using Server.Custom.Aptitudes;
using Server.Spells;

namespace Server.Custom.Spells.NewSpells.Aeromancie
{
	public class ToucherSuffocantSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Toucher Suffocant", "Des Ex Sanct",
				SpellCircle.Fourth,
				224,
				9061,
				Reagent.Garlic,
				Reagent.SulfurousAsh,
				Reagent.Ginseng
			);

		public override int RequiredAptitudeValue { get { return 7; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Aeromancie }; } }
		public override SkillName CastSkill { get { return SkillName.SpiritSpeak; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public ToucherSuffocantSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		private static Hashtable m_Timers = new Hashtable();

		public void Target(Mobile m)
		{
			if (!Caster.CanSee(m))
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			else if (CheckHSequence(m))
			{
				var duration = GetDurationForSpell(0.1);
				var endtime = DateTime.Now + duration;

				SpellHelper.Turn(Caster, m);

				SpellHelper.CheckReflect((int)Circle, Caster, ref m);

				StopTimer(m);

				Timer t = new InternalTimer(endtime, m);

				m_Timers[m] = t;

				t.Start();

				m.Squelched = true;
			}

			FinishSequence();
		}

		public static bool StopTimer(Mobile m)
		{
			var t = (Timer)m_Timers[m];

			if (t != null)
			{
				t.Stop();
				m_Timers.Remove(m);
			}

			return t != null;
		}

		private class InternalTimer : Timer
		{
			private Mobile m_target;
			private DateTime ending;

			public InternalTimer(DateTime endtime, Mobile target)
				: base(TimeSpan.Zero, TimeSpan.FromSeconds(1))
			{
				ending = endtime;
				m_target = target;

				Priority = TimerPriority.TwoFiftyMS;
			}

			protected override void OnTick()
			{
				if (m_target == null || m_target.Deleted)
					return;

				if (DateTime.Now >= ending)
					Stop();
				else
				{
					m_target.FixedParticles(0x376A, 9, 32, 5005, EffectLayer.Waist);
					m_target.PlaySound(22);
					m_target.Squelched = false;
				}
			}
		}

		public class InternalTarget : Target
		{
			private ToucherSuffocantSpell m_Owner;

			public InternalTarget(ToucherSuffocantSpell owner)
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