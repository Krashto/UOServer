using System;
using Server.Custom.Aptitudes;
using Server.Spells;
using System.Collections;

namespace Server.Custom.Spells.NewSpells.Polymorphie
{
	public class FormeCycloniqueSpell : Spell
	{
		private static Hashtable m_Timers = new Hashtable();
		private static Hashtable m_Table = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Forme cyclonique", "Forme cyclonique",
				SpellCircle.Fifth,
				266,
				9040,
				false,
				Reagent.BlackPearl,
				Reagent.MandrakeRoot,
				Reagent.Nightshade
			);

		public override int RequiredAptitudeValue { get { return 1; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Polymorphie }; } }
		public override SkillName CastSkill { get { return SkillName.Anatomy; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public FormeCycloniqueSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			if (IsActive(Caster))
				StopTimer(Caster);
			else if (Caster.BodyMod != 0)
				Caster.SendMessage("Veuillez reprendre votre forme originelle avant de vous transformer à nouveau");
			else
			{
				var duration = GetDurationForSpell(30, 1.8);

				Caster.BodyMod = 13;

				var mod = new DefaultSkillMod(SkillName.Stealth, true, 20.0)
				{
					ObeyCap = false
				};
				Caster.AddSkillMod(mod);
				m_Table[Caster] = mod;

				Timer t = new InternalTimer(Caster, this, DateTime.Now + duration);
				m_Timers[Caster] = t;
				t.Start();
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
			var mod = m_Table[m] as SkillMod;

			if (t != null && mod != null)
			{
				t.Stop();
				m_Timers.Remove(m);
				Caster.RemoveSkillMod(mod);

				Caster.BodyMod = 0;

				m.FixedParticles(14217, 10, 20, 5013, 1942, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
				m.PlaySound(508);
			}
		}

		public class InternalTimer : Timer
		{
			private Mobile m_From;
			private FormeCycloniqueSpell m_Owner;
			private DateTime m_Endtime;

			public InternalTimer(Mobile from, FormeCycloniqueSpell owner, DateTime end)
				: base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
			{
				m_From = from;
				m_Owner = owner;
				m_Endtime = end;

				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				if (DateTime.Now >= m_Endtime && m_Timers.Contains(m_From) || m_From == null || m_From.Deleted || !m_From.Alive)
				{
					var t = m_Timers[m_From] as Timer;
					var mod = m_Table[m_From] as SkillMod;

					if (t != null && mod != null)
					{
						t.Stop();
						m_Timers.Remove(m_From);
						m_From.RemoveSkillMod(mod);

						m_From.BodyMod = 0;

						m_From.FixedParticles(14217, 10, 20, 5013, 1942, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
						m_From.PlaySound(508);
					}

					Stop();
				}
			}
		}
	}
}