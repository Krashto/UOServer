using System;
using Server.Custom.Aptitudes;
using Server.Spells;
using System.Collections;

namespace Server.Custom.Spells.NewSpells.Polymorphie
{
	public class FormeEnflammeeSpell : Spell
	{
		private static Hashtable m_Timers = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Forme enflammée", "Kal Vas Xen Flam",
				SpellCircle.Sixth,
				269,
				9050,
				false,
				Reagent.SulfurousAsh,
				Reagent.SpidersSilk,
				Reagent.SulfurousAsh
			);

		public override int RequiredAptitudeValue { get { return 3; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Polymorphie }; } }
		public override SkillName CastSkill { get { return SkillName.Anatomy; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public FormeEnflammeeSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			if (IsActive(Caster))
				StopTimer(Caster);

			var duration = GetDurationForSpell(30, 1.8);

			Caster.BodyMod = 15;

			Timer t = new InternalTimer(Caster, this, DateTime.Now + duration);
			m_Timers[Caster] = t;
			t.Start();

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

				Caster.BodyMod = -1;

				m.FixedParticles(14217, 10, 20, 5013, 1942, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
				m.PlaySound(508);
			}
		}

		public class InternalTimer : Timer
		{
			private Mobile m_Target;
			FormeEnflammeeSpell m_Owner;
			private DateTime m_Endtime;

			public InternalTimer(Mobile target, FormeEnflammeeSpell owner, DateTime end)
				: base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
			{
				m_Target = target;
				m_Endtime = end;

				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				var targets = new ArrayList();

				var map = m_Target.Map;

				if (map != null)
				{
					IPooledEnumerable eable = map.GetMobilesInRange(m_Target.Location, 2);

					foreach (Mobile m in eable)
						if (m_Target != m && SpellHelper.ValidIndirectTarget(m_Target, m) && m_Target.CanBeHarmful(m, false))
							targets.Add(m);

					eable.Free();
				}

				if (targets.Count > 0)
				{
					for (var i = 0; i < targets.Count; ++i)
					{
						var m = (Mobile)targets[i];

						var source = m_Target;

						SpellHelper.Turn(source, m);

						Disturb(m);

						double damage = m_Owner.GetNewAosDamage(m, 8, 1, 6, true);

						if (m_Owner.CheckResisted(m))
						{
							damage *= 0.75;

							m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
						}

						source.MovingParticles(m, 0x36D4, 7, 0, false, true, 342, 0, 9502, 4019, 0x160, 0);
						source.PlaySound(0x44B);

						SpellHelper.Damage(m_Owner, m, damage, 0, 100, 0, 0, 0);
					}
				}

				if (DateTime.Now >= m_Endtime && m_Timers.Contains(m_Target) || m_Target == null || m_Target.Deleted || !m_Target.Alive)
				{
					var t = m_Timers[m_Target] as Timer;

					if (t != null)
					{
						t.Stop();
						m_Timers.Remove(m_Target);

						m_Target.BodyMod = -1;

						m_Target.FixedParticles(14217, 10, 20, 5013, 1942, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
						m_Target.PlaySound(508);
					}

					Stop();
				}
			}
		}
	}
}