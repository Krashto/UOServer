using Server.Targeting;
using Server.Items;
using Server.Custom.Aptitudes;
using Server.Spells;
using System.Collections;
using System;
using Server.Custom.Spells.NewSpells.Polymorphie;
using Server.Network;

namespace Server.Custom.Spells.NewSpells.Roublardise
{
	public class CoupureDesTendonsSpell : Spell
	{
		private static Hashtable m_Timers = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Coupure Des Tendons", "[Coupure Des Tendons]",
				SpellCircle.Fourth,
				206,
				9002,
				Reagent.BlackPearl,
				Reagent.SpidersSilk,
				Reagent.Garlic
			);

		public override int RequiredAptitudeValue { get { return 8; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Roublardise }; } }
		public override SkillName CastSkill { get { return SkillName.Hiding; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public CoupureDesTendonsSpell(Mobile caster, Item scroll)
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
				var source = Caster;

				SpellHelper.Turn(source, m);

				if (IsActive(m))
					Deactivate(m);

				Disturb(m);

				SpellHelper.CheckReflect((int)Circle, Caster, ref m);

				if (!InsensibleSpell.IsActive(m))
				{
					m.PlaySound(22);
					m.FixedEffect(0x923, 3, 30);
					BleedAttack.BeginBleed(m, Caster, true);
				}
				else
					Caster.SendMessage("Votre cible est immunis�e aux saignements.");

				var duration = GetDurationForSpell(4, 1.8);

				Timer t = new InternalTimer(m, DateTime.Now + duration);
				m_Timers[m] = t;
				t.Start();

				if (!IndomptableSpell.IsActive(m))
				{
					m.SendSpeedControl(SpeedControlType.WalkSpeed);
					m.FixedParticles(14217, 10, 20, 5013, 1942, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
					m.PlaySound(508);
				}
				else
					Caster.SendMessage("Votre cible est immunis�e aux ralentissements.");
			}

			FinishSequence();
		}

		public static bool IsActive(Mobile m)
		{
			return m_Timers.ContainsKey(m);
		}

		public static void Deactivate(Mobile m)
		{
			var t = m_Timers[m] as Timer;

			if (t != null)
			{
				t.Stop();
				m_Timers.Remove(m);
				m.SendSpeedControl(SpeedControlType.Disable);

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

		private class InternalTarget : Target
		{
			private CoupureDesTendonsSpell m_Owner;

			public InternalTarget(CoupureDesTendonsSpell owner)
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