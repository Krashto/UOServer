using System;
using System.Collections;
using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;

namespace Server.Custom.Spells.NewSpells.Aeromancie
{
	public class AveuglementSpell : Spell
	{
		private static Hashtable m_Timers = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Aveuglement", "[Aveuglement]",
				SpellCircle.Eighth,
				212,
				9041,
				Reagent.EssenceAeromancie
			);

		public override int RequiredAptitudeValue { get { return 1; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Aeromancie }; } }
		public override SkillName CastSkill { get { return SkillName.SpiritSpeak; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public AveuglementSpell(Mobile caster, Item scroll)
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
			else if (CheckHSequence(m))
			{
				SpellHelper.Turn(Caster, m);

				if (IsActive(m))
					Deactivate(m);

				var duration = GetDurationForSpell(3);

				Timer t = new InternalTimer(m, DateTime.Now + duration);
				m_Timers[m] = t;
				t.Start();

				BuffInfo.AddBuff(m, new BuffInfo(BuffIcon.AuraOfNausea, 1153792, 1153819, duration, m, $"{duration.TotalSeconds}\t{duration.TotalSeconds}\t{duration.TotalSeconds}\t{duration.TotalSeconds}"));

				m.Emote($"*Est aveuglé{(m.Female ? "e" : "")}*");
				CustomUtility.ApplySimpleSpellEffect(m, "Aveuglement", duration, AptitudeColor.Aeromancie, SpellEffectType.Malus);

				m.FixedParticles(14217, 10, 20, 5013, 1942, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
				m.PlaySound(508);
			}

			FinishSequence();
		}

		public static bool IsActive(Mobile attacker)
		{
			return m_Timers.ContainsKey(attacker);
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
				BuffInfo.RemoveBuff(m, BuffIcon.AuraOfNausea);
				CustomUtility.ApplySimpleSpellEffect(m, "Aveuglement", AptitudeColor.Aeromancie, SpellSequenceType.End, SpellEffectType.Malus);
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
			private AveuglementSpell m_Owner;

			public InternalTarget(AveuglementSpell owner)
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