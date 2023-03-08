using System;
using Server.Mobiles;
using Server.Custom.Aptitudes;
using Server.Spells;
using System.Collections;

namespace Server.Custom.Spells.NewSpells.Aeromancie
{
	public class VentFavorableSpell : Spell
	{
		private static Hashtable m_Table = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Vent Favorable", "In Vas Ex Beh Bal",
				SpellCircle.First,
				233,
				9012,
				false,
				Reagent.Bloodmoss,
				Reagent.Ginseng,
				Reagent.Garlic
			);

		public override int RequiredAptitudeValue { get { return 9; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Aeromancie }; } }
		public override SkillName CastSkill { get { return SkillName.SpiritSpeak; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public VentFavorableSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				var duration = GetDurationForSpell(0.8);

				var endtime = DateTime.Now + duration;

				new VentFavorableTimer((CustomPlayerMobile)Caster, endtime).Start();

				Caster.PlaySound(163);
			}

			FinishSequence();
		}

		public static bool IsActive(Mobile m)
		{
			return m_Table.ContainsKey(m);
		}

		private class VentFavorableTimer : Timer
		{
			private CustomPlayerMobile m_Target;
			private DateTime m_End;

			public VentFavorableTimer(CustomPlayerMobile target, DateTime endTime)
				: base(TimeSpan.Zero, TimeSpan.FromSeconds(3))
			{
				m_Target = target;
				m_End = endTime;
				target.PlaySound(99);

				Priority = TimerPriority.TwoFiftyMS;
			}

			protected override void OnTick()
			{
				if (m_Target == null)
				{
					Stop();
					return;
				}
				else if (m_Target != null && (!m_Target.Alive || DateTime.Now >= m_End))
				{
					Stop();
				}

				if (m_Target != null)
					m_Target.FixedParticles(0x3779, 5, 10, 5052, EffectLayer.LeftFoot);
			}
		}

	}
}