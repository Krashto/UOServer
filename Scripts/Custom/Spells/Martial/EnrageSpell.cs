using System;
using System.Collections;
using Server.Custom.Aptitudes;
using Server.Spells;

namespace Server.Custom.Spells.NewSpells.Martial
{
	public class EnrageSpell : Spell
	{
		private static Hashtable m_Table = new Hashtable();
		private static Hashtable m_Timers = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Enrage", "[Enrage]",
				SpellCircle.Third,
				269,
				9020,
				false,
				Reagent.Bloodmoss,
				Reagent.MandrakeRoot,
				Reagent.BlackPearl
			);

		public override int RequiredAptitudeValue { get { return 6; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Martial }; } }
		public override SkillName CastSkill { get { return SkillName.Tactics; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public EnrageSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			if (IsActive(Caster))
			{
				Deactivate(Caster);
			}
			else
			{
				var duration = GetDurationForSpell(30, 1.8);

				var value = Caster.Skills[CastSkill].Value / 20 + Caster.Skills[DamageSkill].Value / 20;

				var mods = new ResistanceMod[5]
						{
					new ResistanceMod( ResistanceType.Physical, -(int)value),
					new ResistanceMod( ResistanceType.Fire, -(int)value ),
					new ResistanceMod( ResistanceType.Cold, -(int)value ),
					new ResistanceMod( ResistanceType.Poison, -(int)value ),
					new ResistanceMod( ResistanceType.Energy, -(int)value ),
						};

				m_Table[Caster] = mods;

				foreach (var mod in mods)
					Caster.AddResistanceMod(mod);

				Timer t = new InternalTimer(Caster, DateTime.Now + duration);
				m_Timers[Caster] = t;
				t.Start();
			}

			FinishSequence();
		}

		public static bool IsActive(Mobile m)
		{
			return m_Table.ContainsKey(m);
		}

		public static void Deactivate(Mobile m)
		{
			if (m == null)
				return;

			var t = m_Timers[m] as Timer;
			var mods = m_Table[m] as ResistanceMod[];

			if (t != null && mods != null)
			{
				t.Stop();
				m_Timers.Remove(m);
				m_Table.Remove(m);

				foreach (var mod in mods)
					m.RemoveResistanceMod(mod);

				m.FixedParticles(14217, 10, 20, 5013, 1942, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
				m.PlaySound(508);
			}
		}

		public class InternalTimer : Timer
		{
			private Mobile m_Mobile;
			private DateTime m_EndTime;

			public InternalTimer(Mobile m, DateTime endTime) : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
			{
				m_Mobile = m;
				m_EndTime = endTime;

				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				if (DateTime.Now >= m_EndTime && m_Timers.Contains(m_Mobile) || m_Mobile == null || m_Mobile.Deleted || !m_Mobile.Alive)
				{
					Deactivate(m_Mobile);
					Stop();
				}
			}
		}
	}
}