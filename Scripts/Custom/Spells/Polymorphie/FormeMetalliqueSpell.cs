using System;
using Server.Custom.Aptitudes;
using Server.Spells;
using System.Collections;
using Server.Items;

namespace Server.Custom.Spells.NewSpells.Polymorphie
{
	public class FormeMetalliqueSpell : Spell
	{
		private static Hashtable m_Timers = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Forme metallique", "[Forme metallique]",
				SpellCircle.Eighth,
				269,
				9050,
				Reagent.EssencePolymorphie
			);

		public override int RequiredAptitudeValue { get { return 2; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Polymorphie }; } }
		public override SkillName CastSkill { get { return SkillName.Anatomy; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public FormeMetalliqueSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			if (IsActive(Caster))
				Deactivate(Caster);
			else if (Caster.BodyMod != 0)
				Caster.SendMessage("Veuillez reprendre votre forme originelle avant de vous transformer à nouveau");
			else if (CheckSequence())
			{
				var duration = GetDurationForSpell(30, 2);

				Caster.BodyMod = 111;
				Caster.HueMod = 0;

				Timer t = new InternalTimer(Caster, DateTime.Now + duration);
				m_Timers[Caster] = t;
				t.Start();

				CustomUtility.ApplySimpleSpellEffect(Caster, "Forme metallique", duration, AptitudeColor.Polymorphie);
			}

			FinishSequence();
		}

		public static int GetValue(Mobile m)
		{
			return IsActive(m) ? (int)m.Skills[SkillName.Anatomy].Value / 30 + (int)m.Skills[SkillName.EvalInt].Value / 30 : 0;
		}

		public static bool IsActive(Mobile m)
		{
			return m_Timers.ContainsKey(m);
		}

		public static void Deactivate(Mobile m)
		{
			if (m == null)
				return;

			var t = m_Timers[m] as Timer;

			if (t != null)
			{
				t.Stop();
				m_Timers.Remove(m);

				m.BodyMod = 0;
				m.HueMod = -1;

				CustomUtility.ApplySimpleSpellEffect(m, "Forme metallique", AptitudeColor.Polymorphie, SpellSequenceType.End);
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