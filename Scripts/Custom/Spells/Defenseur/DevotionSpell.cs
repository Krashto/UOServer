using Server.Custom.Aptitudes;
using Server.Spells;
using System.Collections;
using System;
using Server.Mobiles;

namespace Server.Custom.Spells.NewSpells.Defenseur
{
	public class DevotionSpell : Spell
	{
		private static Hashtable m_Timers = new Hashtable();
		private static Hashtable m_Table = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Devotion", "[Devotion]",
				SpellCircle.Second,
				203,
				9041,
				Reagent.BlackPearl,
				Reagent.Garlic,
				Reagent.SulfurousAsh
			);

		public override int RequiredAptitudeValue { get { return 3; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Defenseur }; } }
		public override SkillName CastSkill { get { return SkillName.Parry; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public DevotionSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				if (IsActive(Caster))
					Deactivate(Caster);

				Caster.PlaySound(0x232);

				IEntity from = new Entity(Serial.Zero, new Point3D(Caster.X, Caster.Y, Caster.Z), Caster.Map);
				IEntity to = new Entity(Serial.Zero, new Point3D(Caster.X, Caster.Y, Caster.Z + 50), Caster.Map);
				Effects.SendMovingParticles(from, to, 0x1B72, 1, 0, false, false, 33, 3, 9501, 1, 0, EffectLayer.Head, 0x100);

				var value = 0;

				if (Caster is CustomPlayerMobile pm)
					value += pm.Aptitudes.Defenseur * 3;

				m_Table[Caster] = value;

				var duration = GetDurationForSpell(30, 0.25);

				Timer t = new InternalTimer(Caster, DateTime.Now + duration);
				m_Timers[Caster] = t;
				t.Start();
			}

			FinishSequence();
		}

		public static int GetValue(Mobile m)
		{
			return m_Table.ContainsKey(m) ? (int)m_Table[m] : 0;
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
	}
}