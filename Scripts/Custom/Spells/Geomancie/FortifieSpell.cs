using System;
using System.Collections;
using Server.Custom.Aptitudes;
using Server.Spells;

namespace Server.Custom.Spells.NewSpells.Geomancie
{
	public class FortifieSpell : Spell
	{
		private static Hashtable m_Table = new Hashtable();
		private static Hashtable m_Timers = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Fortifie", "[Fortifie]",
				SpellCircle.First,
				212,
				9061,
				Reagent.EssenceGeomancie
			);

		public override int RequiredAptitudeValue { get { return 1; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Geomancie }; } }
		public override SkillName CastSkill { get { return SkillName.MagicResist; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public FortifieSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			if (IsActive(Caster))
				Deactivate(Caster);
			else if (CheckSequence())
			{
				var value = SpellHelper.AdjustValue(Caster, (Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 10, Aptitude.Geomancie);

				ResistanceMod mod = new ResistanceMod(ResistanceType.Physical, (int)value);

				m_Table[Caster] = mod;
				Caster.AddResistanceMod(mod);
				Caster.UpdateResistances();

				var duration = GetDurationForSpell(15);

				Timer t = new InternalTimer(Caster, DateTime.Now + duration);
				m_Timers[Caster] = t;
				t.Start();

				CustomUtility.ApplySimpleSpellEffect(Caster, "Fortifie", duration, AptitudeColor.Geomancie);
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
			var mod = m_Table[m] as ResistanceMod;

			if (t != null && mod != null)
			{
				t.Stop();
				m_Timers.Remove(m);
				m_Table.Remove(m);

				m.RemoveResistanceMod(mod);

				m.UpdateResistances();

				CustomUtility.ApplySimpleSpellEffect(m, "Fortifie", AptitudeColor.Geomancie, SpellSequenceType.End);
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