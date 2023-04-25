using Server.Custom.Aptitudes;
using Server.Spells;
using System.Collections;
using System;
using Server.Targeting;

namespace Server.Custom.Spells.NewSpells.Defenseur
{
	public class LienDeVieSpell : Spell
	{
		private static Hashtable m_Timers = new Hashtable();
		private static Hashtable m_Table = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Lien de vie", "[Lien de vie]",
				SpellCircle.Second,
				203,
				9041,
				Reagent.EssenceDefenseur
			);

		public override int RequiredAptitudeValue { get { return 6; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Defenseur }; } }
		public override SkillName CastSkill { get { return SkillName.Parry; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public LienDeVieSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(Mobile m)
		{
			if (CheckSequence())
			{
				if (IsActive(Caster))
					Deactivate(Caster);

				m_Table[m] = Caster;

				var duration = GetDurationForSpell(20);

				Timer t = new InternalTimer(Caster, DateTime.Now + duration);
				m_Timers[Caster] = t;
				t.Start();

				Timer t2 = new InternalTimer(m, DateTime.Now + duration);
				m_Timers[m] = t2;
				t.Start();

				CustomUtility.ApplySimpleSpellEffect(Caster, "Lien de vie", duration, AptitudeColor.Defenseur);
				CustomUtility.ApplySimpleSpellEffect(m, "Lien de vie", duration, AptitudeColor.Defenseur);
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private LienDeVieSpell m_Owner;

			public InternalTarget(LienDeVieSpell owner)
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

		public static Mobile GetProtector(Mobile m)
		{
			return m_Table.ContainsKey(m) ? (Mobile)m_Table[m] : null;
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

			if (t != null)
			{
				t.Stop();
				m_Timers.Remove(m);
				m_Table.Remove(m);

				CustomUtility.ApplySimpleSpellEffect(m, "Lien de vie", AptitudeColor.Defenseur, SpellSequenceType.End);
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