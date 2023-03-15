using System;
using System.Collections;
using Server.Custom.Aptitudes;
using Server.Spells;
using VitaNex.FX;

namespace Server.Custom.Spells.NewSpells.Aeromancie
{
	public class TornadoSpell : Spell
	{
		private static Hashtable m_Timers = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Tornado", "Evo Wis An Por Grav",
				SpellCircle.Third,
				215,
				9041,
				false,
				Reagent.BlackPearl,
				Reagent.SpidersSilk,
				Reagent.Ginseng
			);

		public override int RequiredAptitudeValue { get { return 4; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Aeromancie }; } }
		public override SkillName CastSkill { get { return SkillName.SpiritSpeak; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public TornadoSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			if (IsActive(Caster))
				StopTimer(Caster);

			var duration = GetDurationForSpell(2, 0.05);

			Timer t = new InternalTimer(Caster, this, DateTime.Now + duration);
			m_Timers[Caster] = t;
			t.Start();

			Caster.FixedParticles(14217, 10, 20, 5013, 1942, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
			Caster.PlaySound(508);
			
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
			private Mobile m_From;
			private TornadoSpell m_Owner;
			private DateTime m_Endtime;

			public InternalTimer(Mobile from, TornadoSpell owner, DateTime end)
				: base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
			{
				m_From = from;
				m_Owner = owner;
				m_Endtime = end;

				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				var targets = new ArrayList();

				var map = m_From.Map;

				var range = 1;

				ExplodeFX.Tornado.CreateInstance(m_From, m_From.Map, range).Send();

				if (map != null)
				{
					IPooledEnumerable eable = map.GetMobilesInRange(m_From.Location, range);

					foreach (Mobile m in eable)
						if (m_From != m && SpellHelper.ValidIndirectTarget(m_From, m) && m_From.CanBeHarmful(m, false))
							targets.Add(m);

					eable.Free();
				}

				if (targets.Count > 0)
				{
					for (var i = 0; i < targets.Count; ++i)
					{
						var m = (Mobile)targets[i];

						var source = m_From;

						if (m_Owner.CheckResisted(m))
							m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
						else
						{
							SpellHelper.Turn(m, source);


							Disturb(m);

							double damage = m_Owner.GetNewAosDamage(m, 8, 1, 6, true);

							MovingSpells.PushMobileTo(m, m.Location, MovingSpells.GetOppositeDirection(source.Direction), 2);

							source.MovingParticles(m, 0x36D4, 7, 0, false, true, 342, 0, 9502, 4019, 0x160, 0);
							source.PlaySound(0x44B);

							SpellHelper.Damage(m_Owner, m, damage, 0, 100, 0, 0, 0);
						}
					}
				}

				if (DateTime.Now >= m_Endtime && m_Timers.Contains(m_From) || m_From == null || m_From.Deleted || !m_From.Alive)
				{
					var t = m_Timers[m_From] as Timer;

					if (t != null)
					{
						t.Stop();
						m_Timers.Remove(m_From);

						m_From.FixedParticles(14217, 10, 20, 5013, 1942, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
						m_From.PlaySound(508);
					}

					Stop();
				}
			}
		}
	}
}