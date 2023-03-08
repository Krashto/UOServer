using System;
using System.Collections;
using Server.Mobiles;
using Server.Custom.Aptitudes;
using Server.Spells;

namespace Server.Custom.Spells.NewSpells.Hydromancie
{
	public class BlizzardSpell : Spell
	{
		private static Hashtable m_Timers = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Blizzard", "In Vas Por Icy An Por",
				SpellCircle.Fifth,
				233,
				9012,
				false,
				Reagent.Bloodmoss,
				Reagent.Bloodmoss,
				Reagent.SulfurousAsh
			);

		public override int RequiredAptitudeValue { get { return 7; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Hydromancie }; } }
		public override SkillName CastSkill { get { return SkillName.Healing; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public BlizzardSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override bool DelayedDamage { get { return !Core.AOS; } }

		public override void OnCast()
		{
			var m_target = new ArrayList();

			if (SpellHelper.CheckTown(Caster, Caster) && CheckSequence())
			{
				m_target.Clear();

				var map = Caster.Map;

				if (map != null)
					foreach (var m in Caster.GetMobilesInRange((int)SpellHelper.AdjustValue(Caster, 1 + Caster.Skills[SkillName.Magery].Value / 15, Aptitude.Hydromancie)))
						if (Caster != m && SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeHarmful(m, false) && (!Core.AOS || Caster.InLOS(m)) && !CustomPlayerMobile.IsInEquipe(Caster, m))
							m_target.Add(m);

				for (var i = 0; i < m_target.Count; ++i)
				{
					var m = (Mobile)m_target[i];

					if (Caster.CanSee(m))
					{
						Caster.DoHarmful(m);

						Timer t = new InternalTimer(Caster, m);
						m_Timers[m] = t;
						t.Start();
					}
				}
			}

			FinishSequence();
		}

		public static bool IsActive(Mobile m)
		{
			return m_Timers.ContainsKey(m);
		}

		private class InternalTimer : Timer
		{
			private readonly Mobile m_From;
			private readonly Mobile m_Mobile;
			private int m_Count;
			private readonly int m_MaxCount;

			public InternalTimer(Mobile from, Mobile m)
				: base(TimeSpan.FromSeconds(1.0), TimeSpan.FromSeconds(1.0))
			{
				m_From = from;
				m_Mobile = m;
				Priority = TimerPriority.TwoFiftyMS;

				m_MaxCount = 10;
			}

			protected override void OnTick()
			{
				if (!m_Mobile.Alive || m_Mobile.Deleted)
				{
					if (m_Timers.ContainsKey(m_Mobile))
						m_Timers.Remove(m_Mobile);
					Stop();
				}
				else
				{
					m_Mobile.Stam -= 5;
					m_Mobile.Hits -= 1;

					if (++m_Count == m_MaxCount)
					{
						if (m_Timers.ContainsKey(m_Mobile))
							m_Timers.Remove(m_Mobile);
						Stop();
					}
				}
			}
		}
	}
}