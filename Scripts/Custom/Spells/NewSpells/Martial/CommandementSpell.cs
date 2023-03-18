using Server.Custom.Aptitudes;
using Server.Spells;
using System.Collections;
using System;

namespace Server.Custom.Spells.NewSpells.Martial
{
	public class CommandementSpell : Spell
	{
		private static Hashtable m_Timers = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Commandement", "Commandement",
				SpellCircle.First,
				212,
				9061,
				Reagent.MandrakeRoot,
				Reagent.Nightshade
			);

		public override int RequiredAptitudeValue { get { return 8; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Martial }; } }
		public override SkillName CastSkill { get { return SkillName.Tactics; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public CommandementSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			var targets = new ArrayList();

			var map = Caster.Map;

			if (map != null)
			{
				IPooledEnumerable eable = map.GetMobilesInRange(Caster.Location, (int)(1 + Caster.Skills[CastSkill].Value / 25));

				targets.Add(Caster);

				foreach (Mobile m in eable)
					if (Caster != m && SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeBeneficial(m, false))
						targets.Add(m);

				eable.Free();
			}

			if (targets.Count > 0)
			{
				for (var i = 0; i < targets.Count; ++i)
				{
					var m = (Mobile)targets[i];

					if (IsActive(m))
						StopTimer(m);

					var duration = GetDurationForSpell(20, 0.5);

					Timer t = new InternalTimer(m, DateTime.Now + duration);
					m_Timers[m] = t;
					t.Start();

					Caster.FixedParticles(0x375A, 10, 15, 5010, EffectLayer.Waist);
					Caster.PlaySound(0x28E);
				}
			}

			FinishSequence();
		}


		public static bool IsActive(Mobile m)
		{
			return m_Timers.ContainsKey(m);
		}

		public static void StopTimer(Mobile m)
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
	}
}