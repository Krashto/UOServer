using System;
using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using VitaNex.FX;
using System.Collections;

namespace Server.Custom.Spells.NewSpells.Hydromancie
{
	public class FolieArdenteSpell : Spell
	{
		private static Hashtable m_Timers = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Folie Ardente", "In Vas Jux Flam",
				SpellCircle.Seventh,
				Core.AOS ? 239 : 215,
				9011,
				Reagent.Garlic,
				Reagent.MandrakeRoot,
				Reagent.SulfurousAsh
			);

		public override int RequiredAptitudeValue { get { return 7; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Pyromancie }; } }
		public override SkillName CastSkill { get { return SkillName.Magery; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public FolieArdenteSpell(Mobile caster, Item scroll)
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

				if (IsActive(m))
					StopTimer(m);

				var duration = GetDurationForSpell(5, 2);

				Timer t = new InternalTimer(m, DateTime.Now + duration);
				m_Timers[m] = t;
				t.Start();

				ConcentricWaveFX.SmallTornado.CreateInstance(m, m.Map, 0);

				m.Emote($"Est d�sorient�{(m.Female ? "e" : "")}");

				m.FixedParticles(14217, 10, 20, 5013, 1942, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
				m.PlaySound(508);
			}

			FinishSequence();
		}

		public static bool IsActive(Mobile attacker)
		{
			return m_Timers.ContainsKey(attacker);
		}

		public void StopTimer(Mobile m)
		{
			var t = (Timer)m_Timers[m];

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
					m_Timers.Remove(m_Target);

					m_Target.FixedParticles(14217, 10, 20, 5013, 1942, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
					m_Target.PlaySound(508);

					Stop();
				}
			}
		}

		private class InternalTarget : Target
		{
			private FolieArdenteSpell m_Owner;

			public InternalTarget(FolieArdenteSpell owner)
				: base(12, false, TargetFlags.Beneficial)
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