using System;
using System.Collections;
using Server.Custom.Aptitudes;
using Server.Spells;

namespace Server.Custom.Spells.NewSpells.Pyromancie
{
	public class BouclierDeFeuSpell : Spell
	{
		private static Hashtable m_Table = new Hashtable();
		private static Hashtable m_Timers = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Bouclier de feu", "[Bouclier de feu]",
				SpellCircle.First,
				266,
				9040,
				Reagent.Bloodmoss,
				Reagent.MandrakeRoot,
				Reagent.SulfurousAsh
			);

		public override int RequiredAptitudeValue { get { return 1; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Pyromancie }; } }
		public override SkillName CastSkill { get { return SkillName.Magery; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public BouclierDeFeuSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
		{
		}

		public Type m_Creature;
		public int m_ControlSlots;

		public BouclierDeFeuSpell(Mobile caster, Item scroll, Type type, int controlSlot)
			: base(caster, scroll, m_Info)
		{
			m_Creature = type;
			m_ControlSlots = controlSlot;
		}

		public override void OnCast()
		{
			if (IsActive(Caster))
				Deactivate(Caster);

			var duration = GetDurationForSpell(15);

			var value = (Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 20;

			ResistanceMod mod = new ResistanceMod(ResistanceType.Fire, (int)value);

			m_Table[Caster] = mod;
			Caster.AddResistanceMod(mod);

			Timer t = new InternalTimer(Caster, DateTime.Now + duration);
			m_Timers[Caster] = t;
			t.Start();

			Caster.FixedParticles(0x375A, 10, 15, 5010, EffectLayer.Waist);
			Caster.PlaySound(0x28E);

			FinishSequence();
		}

		public static bool IsActive(Mobile m)
		{
			return m_Table.ContainsKey(m);
		}

		public static void Deactivate(Mobile m)
		{
			var t = m_Timers[m] as Timer;
			var mod = m_Table[m] as ResistanceMod;

			if (t != null && mod != null)
			{
				t.Stop();
				m_Timers.Remove(m);
				m_Table.Remove(m);

				m.RemoveResistanceMod(mod);

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