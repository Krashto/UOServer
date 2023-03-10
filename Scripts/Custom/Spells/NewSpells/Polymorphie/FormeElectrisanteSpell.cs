using System;
using Server.Custom.Aptitudes;
using Server.Spells;
using System.Collections;

namespace Server.Custom.Spells.NewSpells.Polymorphie
{
	public class FormeElectrisanteSpell : Spell
	{
		private static Hashtable m_Timers = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Forme électrisante", "Vas Corp Por",
				SpellCircle.Sixth,
				260,
				9032,
				false,
				Reagent.Bloodmoss,
				Reagent.BlackPearl,
				Reagent.Nightshade
			);

		public override int RequiredAptitudeValue { get { return 5; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Polymorphie }; } }
		public override SkillName CastSkill { get { return SkillName.Anatomy; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public FormeElectrisanteSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			if (IsActive(Caster))
			{
				StopTimer(Caster);
			}
			else
			{
				if (Caster.BodyMod == 0)
				{
					var duration = GetDurationForSpell(30, 1.8);

					Caster.BodyMod = 164;

					Timer t = new InternalTimer(Caster, DateTime.Now + duration);
					m_Timers[Caster] = t;
					t.Start();
				}
				else
				{
					Caster.SendMessage("Veuillez reprendre votre forme originelle avant de vous transformer à nouveau");
				}
			}

			FinishSequence();
		}

		public static bool IsActive(Mobile m)
		{
			return m_Timers.ContainsKey(m);
		}

		public void StopTimer(Mobile m)
		{
			var t = m_Timers[m] as Timer;

			if (t != null)
			{
				t.Stop();
				m_Timers.Remove(m);

				Caster.BodyMod = 0;

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

						m_Target.BodyMod = 0;

						m_Target.FixedParticles(14217, 10, 20, 5013, 1942, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
						m_Target.PlaySound(508);
					}

					Stop();
				}
			}
		}
	}
}