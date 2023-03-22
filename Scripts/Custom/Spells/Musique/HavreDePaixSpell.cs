using Server.Custom.Aptitudes;
using Server.Spells;
using System.Collections;
using System;
using Server.Mobiles;

namespace Server.Custom.Spells.NewSpells.Geomancie
{
	public class HavreDePaixSpell : Spell
	{
		private static Hashtable m_Table = new Hashtable();
		private static Hashtable m_Timers = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Havre de paix", "[Havre de paix]",
				SpellCircle.First,
				212,
				9061,
				Reagent.MandrakeRoot,
				Reagent.Nightshade
			);

		public override int RequiredAptitudeValue { get { return 10; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Musique }; } }
		public override SkillName CastSkill { get { return SkillName.Musicianship; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public HavreDePaixSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			var targets = new ArrayList();

			var map = Caster.Map;

			if (map != null)
			{
				IPooledEnumerable eable = map.GetMobilesInRange(Caster.Location, (int)(1 + Caster.Skills[CastSkill].Value / 25));

				foreach (Mobile m in eable)
					if (Caster != m && SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeHarmful(m, false))
						targets.Add(m);

				eable.Free();
			}

			if (targets.Count > 0)
			{
				for (var i = 0; i < targets.Count; ++i)
				{
					var m = (Mobile)targets[i];

					SpellHelper.Turn(Caster, m);

					m.SendLocalizedMessage(500616); // You hear lovely music, and forget to continue battling!
					m.Combatant = null;
					m.Warmode = false;

					if (m is BaseCreature && !((BaseCreature)m).BardPacified)
						((BaseCreature)m).Pacify(Caster, DateTime.UtcNow + TimeSpan.FromSeconds(30.0));

					Caster.FixedParticles(0x375A, 10, 15, 5010, EffectLayer.Waist);
					Caster.PlaySound(0x28E);
				}
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