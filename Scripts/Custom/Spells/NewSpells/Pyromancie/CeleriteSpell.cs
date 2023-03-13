using System;
using Server.Custom.Aptitudes;
using Server.Spells;
using System.Collections;

namespace Server.Custom.Spells.NewSpells.Aeromancie
{
	public class CeleriteSpell : Spell
	{
		private static Hashtable m_Table = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"C�l�rit�", "In Vas Rapid",
				SpellCircle.First,
				233,
				9012,
				false,
				Reagent.Bloodmoss,
				Reagent.Ginseng,
				Reagent.Garlic
			);

		public override int RequiredAptitudeValue { get { return 3; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Pyromancie }; } }
		public override SkillName CastSkill { get { return SkillName.Magery; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public CeleriteSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				var duration = GetDurationForSpell(10, 1.8);

				var endtime = DateTime.Now + duration;

				Timer t = new CeleriteTimer(Caster, endtime);
				t.Start();

				Caster.PlaySound(163);
			}

			FinishSequence();
		}

		public static bool IsActive(Mobile m)
		{
			return m_Table.ContainsKey(m);
		}

		private class CeleriteTimer : Timer
		{
			private Mobile m_Mobile;
			private DateTime m_End;

			public CeleriteTimer(Mobile target, DateTime endTime)
				: base(TimeSpan.Zero, TimeSpan.FromSeconds(1))
			{
				m_Mobile = target;
				m_End = endTime;
				target.PlaySound(99);

				Priority = TimerPriority.TwoFiftyMS;
			}

			protected override void OnTick()
			{
				if (m_Mobile == null)
				{
					Stop();
					return;
				}
				else if (m_Mobile != null && (!m_Mobile.Alive || DateTime.Now >= m_End))
				{
					Stop();
				}

				if (m_Mobile != null)
					m_Mobile.FixedParticles(0x3779, 5, 10, 5052, EffectLayer.LeftFoot);
			}
		}

	}
}