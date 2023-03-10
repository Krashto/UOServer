using System.Collections;
using Server.Custom.Aptitudes;
using Server.Spells;
using System;
using System.Web.UI.WebControls;

namespace Server.Custom.Spells.NewSpells.Hydromancie
{
	public class AvatarDuFroidSpell : Spell
	{
		private static Hashtable m_Timers = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Avatar du froid", "Wis Quas",
				SpellCircle.First,
				206,
				9002,
				Reagent.Bloodmoss,
				Reagent.SulfurousAsh
			);

		public override int RequiredAptitudeValue { get { return 9; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Hydromancie }; } }
		public override SkillName CastSkill { get { return SkillName.Healing; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public AvatarDuFroidSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			if (IsActive(Caster))
				StopTimer(Caster);
			else
			{
				var duration = GetDurationForSpell(0.1);

				Caster.Freeze(duration);
				Caster.Blessed = true;

				Timer t = new InternalTimer(Caster, duration);
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
			private Mobile m_Mobile;

			public InternalTimer(Mobile m, TimeSpan duration)
				: base(duration)
			{
				m_Mobile = m;
				Priority = TimerPriority.TwoFiftyMS;
			}

			protected override void OnTick()
			{
				if (m_Timers.ContainsKey(m_Mobile))
					m_Timers.Remove(m_Mobile);
				m_Mobile.Frozen = false;
				m_Mobile.Blessed = false;
			}
		}
	}
}