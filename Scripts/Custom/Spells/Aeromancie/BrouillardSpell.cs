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
				Effects.SendLocationParticles(EffectItem.Create(new Point3D(Caster.X, Caster.Y, Caster.Z + 16), Caster.Map, EffectItem.DefaultDuration), 0x376A, 10, 15, 5045);
				Caster.PlaySound(0x3C4);

				Deactivate(Caster);

				Caster.Hidden = true;
				Caster.AllowedStealthSteps = (int)SpellHelper.AdjustValue(Caster, 1 + Caster.Skills[CastSkill].Value / 2, Aptitude.Aeromancie);
				Caster.SendLocalizedMessage(502730); // You begin to move quietly.

				ExplodeFX.Smoke.CreateInstance(Caster, Caster.Map, 1).Send();

				var duration = GetDurationForSpell(30, 2);

				Timer t = new InternalTimer(Caster, DateTime.Now + duration);
				m_Timers[Caster] = t;
				t.Start();
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
				m.SendMessage("Le brouillard prend fin.");
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