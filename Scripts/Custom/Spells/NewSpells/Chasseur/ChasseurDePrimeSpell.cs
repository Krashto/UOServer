using System;
using Server.Targeting;
using System.Collections;
using Server.Custom.Aptitudes;
using Server.Spells;

namespace Server.Custom.Spells.NewSpells.Chasseur
{
	public class ChasseurDePrimeSpell : Spell
	{
		private static Hashtable m_Table = new Hashtable();
		public static Hashtable m_Timers = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Chasseur de prime", "Bet Grav Corp",
				SpellCircle.Seventh,
				236,
				9031,
				Reagent.SulfurousAsh,
				Reagent.Ginseng,
				Reagent.MandrakeRoot
			);

		public override int RequiredAptitudeValue { get { return 9; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Chasseur }; } }
		public override SkillName CastSkill { get { return SkillName.Tracking; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public ChasseurDePrimeSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(Mobile m)
		{
			if (!Caster.CanSee(m))
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			else if (CheckSequence())
			{
				SpellHelper.Turn(Caster, m);

				if (MarquerSpell.IsActive(m))
				{
					StopTimer(m);

					var value = SpellHelper.AdjustValue(Caster, Caster.Skills[CastSkill].Value / 20 + Caster.Skills[DamageSkill].Value / 20, Aptitude.Chasseur);

					var mods = new ResistanceMod[5]
							{
						new ResistanceMod( ResistanceType.Physical, -(int)value),
						new ResistanceMod( ResistanceType.Fire, -(int)value ),
						new ResistanceMod( ResistanceType.Cold, -(int)value ),
						new ResistanceMod( ResistanceType.Poison, -(int)value ),
						new ResistanceMod( ResistanceType.Energy, -(int)value ),
							};

					m_Table[m] = mods;

					foreach (var mod in mods)
						m.AddResistanceMod(mod);

					var duration = GetDurationForSpell(10, 0.1);

					Timer t = new InternalTimer(m, DateTime.Now + duration);
					m_Timers[m] = t;
					t.Start();

					m.FixedParticles(14217, 10, 20, 5013, 1942, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
					m.PlaySound(508);
				}
				else
				{
					Caster.SendMessage("La cible doit être paralysé ou doit saigner ou doit avoir été marqué par le sort 'Marquer' avant de pouvoir être touchée par ce sort.");
				}
			}

			FinishSequence();
		}

		public static bool IsActive(Mobile m)
		{
			return m_Table.ContainsKey(m);
		}

		public void StopTimer(Mobile m)
		{
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
				if (DateTime.Now >= m_Endtime && m_Timers.Contains(m_Target) || m_Target == null || m_Target.Deleted || !m_Target.Alive)
				{
					m_Timers.Remove(m_Target);

					m_Target.FixedParticles(14217, 10, 20, 5013, 1942, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
					m_Target.PlaySound(508);

					Stop();
				}
			}
		}

		private class InternalTarget : Target
		{
			private ChasseurDePrimeSpell m_Owner;

			public InternalTarget(ChasseurDePrimeSpell owner)
				: base(12, false, TargetFlags.Beneficial)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is Mobile)
					m_Owner.Target((Mobile)o);
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}
