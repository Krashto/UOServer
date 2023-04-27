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
				"Chasseur de prime", "[Chasseur de prime]",
				SpellCircle.Seventh,
				236,
				9031,
				Reagent.EssenceChasseur
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
					Deactivate(m);

					var value = SpellHelper.AdjustValue(Caster, (Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 5, Aptitude.Chasseur);

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

					m.UpdateResistances();

					m.Squelched = true;

					var duration = GetDurationForSpell(8);

					CustomUtility.ApplySimpleSpellEffect(m, "Chasseur de prime", duration, AptitudeColor.Chasseur, SpellEffectType.Malus);

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

				m.UpdateResistances();

				m.Squelched = false;

				CustomUtility.ApplySimpleSpellEffect(m, "Chasseur de prime", AptitudeColor.Chasseur, SpellSequenceType.End, SpellEffectType.Malus);
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

		private class InternalTarget : Target
		{
			private ChasseurDePrimeSpell m_Owner;

			public InternalTarget(ChasseurDePrimeSpell owner)
				: base(12, false, TargetFlags.Harmful)
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
