using System;
using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using System.Collections;

namespace Server.Custom.Spells.NewSpells.Pyromancie
{
	public class FolieArdenteSpell : Spell
	{
		private static Hashtable m_Timers = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Folie ardente", "[Folie ardente]",
				SpellCircle.Seventh,
				239,
				9011,
				Reagent.EssencePyromancie
			);

		public override int RequiredAptitudeValue { get { return 10; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Pyromancie }; } }
		public override SkillName CastSkill { get { return SkillName.Magery; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public FolieArdenteSpell(Mobile caster, Item scroll)
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

				SpellHelper.CheckReflect((int)Circle, Caster, ref m);

				double damage = Utility.RandomMinMax(25, 35);

				if (CheckResisted(m))
				{
					damage *= 0.75;

					m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
				}

				damage *= GetDamageScalar(m);

				m.FixedParticles(0x3709, 10, 30, 5052, EffectLayer.LeftFoot);
				m.PlaySound(0x208);

				SpellHelper.Damage(this, m, damage, 0, 100, 0, 0, 0);

				var duration = GetDurationForSpell(2);

				Timer t = new InternalTimer(this, Caster, m, damage * 0.5, DateTime.Now + duration);
				m_Timers[m] = t;
				t.Start();

				CustomUtility.ApplySimpleSpellEffect(m, "Folie ardente", duration, AptitudeColor.Pyromancie, SpellEffectType.Damage);
			}

			FinishSequence();
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

				CustomUtility.ApplySimpleSpellEffect(m, "Folie ardente", AptitudeColor.Pyromancie, SpellSequenceType.End);
			}
		}

		public class InternalTimer : Timer
		{
			private Mobile m_Mobile;
			private Mobile m_Caster;
			private DateTime m_EndTime;
			private double m_Damage;
			private Spell m_Owner;

			public InternalTimer(Spell owner, Mobile caster, Mobile m, double damage, DateTime endTime) : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
			{
				m_Owner = owner;
				m_Caster = caster;
				m_Mobile = m;
				m_Damage = damage;
				m_EndTime = endTime;

				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				SpellHelper.CheckReflect((int)m_Owner.Circle, m_Caster, ref m_Mobile);

				if (m_Owner.CheckResisted(m_Mobile))
				{
					m_Damage *= 0.75;

					m_Mobile.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
				}

				CustomUtility.ApplySimpleSpellEffect(m_Mobile, "Folie ardente", AptitudeColor.Pyromancie, SpellEffectType.Damage);

				SpellHelper.Damage(m_Owner, m_Mobile, m_Damage, 0, 100, 0, 0, 0);

				if (DateTime.Now >= m_EndTime && m_Timers.Contains(m_Mobile) || m_Mobile == null || m_Mobile.Deleted || !m_Mobile.Alive)
				{
					Deactivate(m_Mobile);
					Stop();
				}
			}
		}

		private class InternalTarget : Target
		{
			private FolieArdenteSpell m_Owner;

			public InternalTarget(FolieArdenteSpell owner)
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
