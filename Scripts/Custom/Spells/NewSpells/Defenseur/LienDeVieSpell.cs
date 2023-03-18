using Server.Custom.Aptitudes;
using Server.Spells;
using System.Collections;
using System;
using Server.Targeting;

namespace Server.Custom.Spells.NewSpells.Defenseur
{
	public class LienDeVieSpell : Spell
	{
		private static Hashtable m_Timers = new Hashtable();
		private static Hashtable m_Table = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Lien de vie", "Lien de vie",
				SpellCircle.Second,
				203,
				9041,
				Reagent.BlackPearl,
				Reagent.Garlic,
				Reagent.SulfurousAsh
			);

		public override int RequiredAptitudeValue { get { return 6; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Defenseur }; } }
		public override SkillName CastSkill { get { return SkillName.Parry; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public LienDeVieSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(Mobile m)
		{
			if (CheckSequence())
			{
				if (IsActive(Caster))
					StopTimer(Caster);

				m_Table[m] = Caster;

				var duration = GetDurationForSpell(30, 1.8);

				Timer t = new InternalTimer(Caster, DateTime.Now + duration);
				m_Timers[Caster] = t;
				t.Start();
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private LienDeVieSpell m_Owner;

			public InternalTarget(LienDeVieSpell owner)
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

		public static Mobile GetProtector(Mobile m)
		{
			return m_Table.ContainsKey(m) ? (Mobile)m_Table[m] : null;
		}

		public static bool IsActive(Mobile m)
		{
			return m_Table.ContainsKey(m);
		}

		public void StopTimer(Mobile m)
		{
			var t = m_Timers[m] as Timer;

			if (t != null)
			{
				t.Stop();
				m_Timers.Remove(m);
				m_Table.Remove(m);

				m.FixedParticles(14217, 10, 20, 5013, 1942, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
				m.PlaySound(508);
			}
		}

		public class InternalTimer : Timer
		{
			private Mobile m_Target;
			private DateTime m_Endtime;

			public InternalTimer(Mobile target, DateTime end)
				: base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
			{
				m_Target = target;
				m_Endtime = end;

				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				if (DateTime.Now >= m_Endtime && m_Timers.Contains(m_Target) || m_Target == null || m_Target.Deleted || !m_Target.Alive)
				{
					var t = m_Timers[m_Target] as Timer;

					if (t != null)
					{
						t.Stop();
						m_Timers.Remove(m_Target);
						m_Table.Remove(m_Target);

						m_Target.FixedParticles(14217, 10, 20, 5013, 1942, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
						m_Target.PlaySound(508);
					}

					Stop();
				}
			}
		}
	}
}