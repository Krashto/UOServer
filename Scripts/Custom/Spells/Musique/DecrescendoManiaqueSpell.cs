using Server.Custom.Aptitudes;
using Server.Spells;
using System.Collections;
using System;

namespace Server.Custom.Spells.NewSpells.Geomancie
{
	public class DecrescendoManiaqueSpell : Spell
	{
		private static Hashtable m_Table = new Hashtable();
		private static Hashtable m_Timers = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Decrescendo maniaque", "[Decrescendo maniaque]",
				SpellCircle.First,
				212,
				9061,
				Reagent.MandrakeRoot,
				Reagent.Nightshade
			);

		public override int RequiredAptitudeValue { get { return 5; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Musique }; } }
		public override SkillName CastSkill { get { return SkillName.Musicianship; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public DecrescendoManiaqueSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			var targets = new ArrayList();

			var map = Caster.Map;

			if (map != null)
			{
				IPooledEnumerable eable = map.GetMobilesInRange(Caster.Location, (int)(1 + Caster.Skills[CastSkill].Value / 25));

				targets.Add(Caster);

				foreach (Mobile m in eable)
					if (Caster != m && SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeBeneficial(m, false))
						targets.Add(m);

				eable.Free();
			}

			if (targets.Count > 0)
			{
				for (var i = 0; i < targets.Count; ++i)
				{
					var m = (Mobile)targets[i];

					if (IsActive(m))
						Deactivate(m);

					var duration = GetDurationForSpell(30, 0.15);

					var value = (Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 10;

					m_Table[m] = value;

					Timer t = new InternalTimer(m, DateTime.Now + duration);
					m_Timers[m] = t;
					t.Start();

					Caster.FixedParticles(0x375A, 10, 15, 5010, EffectLayer.Waist);
					Caster.PlaySound(0x28E);
				}
			}

			FinishSequence();
		}

		public static int GetValue(Mobile m)
		{
			return m_Table.ContainsKey(m) ? (int)m_Table[m] : 0;
		}


		public static bool IsActive(Mobile m)
		{
			return m_Table.ContainsKey(m);
		}

		public static void Deactivate(Mobile m)
		{
			if (m == null)
				return;

			var t = (Timer)m_Timers[m];
			var mod = (ResistanceMod)m_Table[m];

			if (t != null && mod != null)
			{
				t.Stop();

				m.RemoveResistanceMod(mod);

				m_Timers.Remove(m);
				m_Table.Remove(m);

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