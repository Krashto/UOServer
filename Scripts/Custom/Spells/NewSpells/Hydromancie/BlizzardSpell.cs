using System;
using System.Collections;
using Server.Mobiles;
using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Custom.Spells.NewSpells.Polymorphie;
using Server.Network;
using VitaNex.FX;

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

				var range = (int)SpellHelper.AdjustValue(Caster, 1 + Caster.Skills[SkillName.Magery].Value / 15, Aptitude.Hydromancie);

				ExplodeFX.Snow.CreateInstance(Caster, Caster.Map, range);

				if (map != null)
					foreach (var m in Caster.GetMobilesInRange(range))
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

						if (!FormeElectrisanteSpell.IsActive(m))
						{
							m.SendSpeedControl(SpeedControlType.WalkSpeed);

							m.FixedParticles(14217, 10, 20, 5013, 1942, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
							m.PlaySound(508);
						}
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
				: base(TimeSpan.Zero, TimeSpan.FromSeconds(2.0))
			{
				m_From = from;
				m_Mobile = m;
				Priority = TimerPriority.TwoFiftyMS;

				m_MaxCount = 5;
			}

			protected override void OnTick()
			{
				if (!m_Mobile.Alive || m_Mobile.Deleted || ++m_Count == m_MaxCount)
				{
					if (m_Timers.ContainsKey(m_Mobile))
						m_Timers.Remove(m_Mobile);
					m_Mobile.SendSpeedControl(SpeedControlType.Disable);
					Stop();
				}
				else
				{
					ExplodeFX.Snow.CreateInstance(m_Mobile, m_Mobile.Map, 2);
					m_Mobile.Stam -= 5;
					m_Mobile.Hits -= 1;
				}
			}
		}
	}
}