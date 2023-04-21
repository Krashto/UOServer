using System;
using System.Collections;
using Server.Items;
using Server.Custom.Aptitudes;
using Server.Spells;
using VitaNex.FX;

namespace Server.Custom.Spells.NewSpells.Aeromancie
{
	public class BrouillardSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Brouillard", "[Brouillard]",
				SpellCircle.Fifth,
				206,
				9002,
				Reagent.EssenceAeromancie
			);

		public override int RequiredAptitudeValue { get { return 2; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Aeromancie }; } }
		public override SkillName CastSkill { get { return SkillName.SpiritSpeak; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public BrouillardSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				if (IsActive(Caster))
					Deactivate(Caster);

				var duration = GetDurationForSpell(30, 2);

				Timer t = new InternalTimer(Caster, DateTime.Now + duration);
				m_Timers[Caster] = t;
				t.Start();

				ExplodeFX.Smoke.CreateInstance(Caster, Caster.Map, 1).Send();

				Caster.Hidden = true;
				Caster.AllowedStealthSteps = (int)SpellHelper.AdjustValue(Caster, 1 + Caster.Skills[CastSkill].Value / 2, Aptitude.Aeromancie);

				CustomUtility.ApplySimpleSpellEffect(Caster, "Brouillard", duration, AptitudeColor.Aeromancie);
			}

			FinishSequence();
		}

		public static Hashtable m_Timers = new Hashtable();

		public static bool IsActive(Mobile m)
		{
			return m_Timers[m] != null;
		}

		public static void Deactivate(Mobile m)
		{
			if (m == null)
				return;

			var t = (Timer)m_Timers[m];

			if (t != null)
			{
				t.Stop();
				m_Timers.Remove(m);
				m.RevealingAction();
				CustomUtility.ApplySimpleSpellEffect(m, "Brouillard", AptitudeColor.Aeromancie, SpellSequenceType.End);
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