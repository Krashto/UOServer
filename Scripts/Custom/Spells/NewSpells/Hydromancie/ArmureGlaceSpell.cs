using Server.Custom.Aptitudes;
using Server.Spells;
using System;
using System.Collections;

namespace Server.Custom.Spells.NewSpells.Hydromancie
{
	public class ArmureGlaceSpell : Spell
	{
		private static Hashtable m_Table = new Hashtable();
		private static Hashtable m_Timers = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Armure de glace", "In Jux Sanct",
				SpellCircle.Seventh,
				242,
				9012,
				Reagent.Garlic,
				Reagent.MandrakeRoot,
				Reagent.SpidersSilk
			);

		public override int RequiredAptitudeValue { get { return 1; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Hydromancie }; } }
		public override SkillName CastSkill { get { return SkillName.Healing; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public ArmureGlaceSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			if (IsActive(Caster))
				StopTimer(Caster);

			var duration = GetDurationForSpell(0.15);

			var value = 1 + (Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 600;

			ResistanceMod mod = new ResistanceMod(ResistanceType.Cold, (int)value);

			m_Table[Caster] = mod;
			Caster.AddResistanceMod(mod);

			Timer t = new InternalTimer(Caster, DateTime.Now + duration);
			m_Timers[Caster] = t;
			t.Start();

			Caster.FixedParticles(0x375A, 10, 15, 5010, EffectLayer.Waist);
			Caster.PlaySound(0x28E);

			FinishSequence();
		}

		public static bool IsActive(Mobile m)
		{
			return m_Table.ContainsKey(m);
		}

		public void StopTimer(Mobile m)
		{
			var t = m_Timers[m] as Timer;
			var mod = m_Table[m] as ResistanceMod;

			if (t != null && mod != null)
			{
				t.Stop();
				m_Timers.Remove(m);
				m_Table.Remove(m);

				m.RemoveResistanceMod(mod);

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
				if (DateTime.Now >= m_Endtime && m_Table.Contains(m_Target) || m_Target == null || m_Target.Deleted || !m_Target.Alive)
				{
					var mod = m_Table[m_Target] as ResistanceMod;

					if (mod != null)
						m_Target.RemoveResistanceMod(mod);

					m_Table.Remove(m_Target);
					m_Timers.Remove(m_Target);

					m_Target.FixedParticles(14217, 10, 20, 5013, 1942, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
					m_Target.PlaySound(508);

					Stop();
				}
			}
		}
	}
}
