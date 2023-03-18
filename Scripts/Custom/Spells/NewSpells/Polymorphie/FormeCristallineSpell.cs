using System;
using Server.Custom.Aptitudes;
using Server.Spells;
using System.Collections;

namespace Server.Custom.Spells.NewSpells.Polymorphie
{
	public class FormeCristallineSpell : Spell
	{
		private static Hashtable m_Timers = new Hashtable();
		private static Hashtable m_Table = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Forme cristalline", "Kal Vas Xen Crystal",
				SpellCircle.Eighth,
				269,
				9070,
				false,
				Reagent.BlackPearl,
				Reagent.BlackPearl,
				Reagent.SpidersSilk
			);

		public override int RequiredAptitudeValue { get { return 7; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Polymorphie }; } }
		public override SkillName CastSkill { get { return SkillName.Anatomy; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public FormeCristallineSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			if (IsActive(Caster))
				StopTimer(Caster);
			else if (Caster.BodyMod != 0)
				Caster.SendMessage("Veuillez reprendre votre forme originelle avant de vous transformer à nouveau");
			else
			{
				var duration = GetDurationForSpell(30, 1.8);

				Caster.BodyMod = 300;

				var value = SpellHelper.AdjustValue(Caster, Caster.Skills[CastSkill].Value / 20 + Caster.Skills[DamageSkill].Value / 20, Aptitude.Polymorphie);

				var mods = new ResistanceMod[]
				{
					new ResistanceMod( ResistanceType.Cold, (int)value),
					new ResistanceMod( ResistanceType.Poison, (int)value),
				};

				m_Table[Caster] = mods;

				foreach (var mod in mods)
					Caster.AddResistanceMod(mod);

				Timer t = new InternalTimer(Caster, DateTime.Now + duration);
				m_Timers[Caster] = t;
				t.Start();
			}

			FinishSequence();
		}

		public static bool IsActive(Mobile m)
		{
			return m_Table.ContainsKey(m);
		}

		public void StopTimer(Mobile m)
		{
			var t = m_Timers[m] as Timer;
			var mods = m_Table[m] as ResistanceMod[];

			if (t != null && mods != null)
			{
				t.Stop();
				m_Timers.Remove(m);
				m_Table.Remove(m);

				Caster.BodyMod = 0;

				foreach (var mod in mods)
					m.RemoveResistanceMod(mod);

				m.FixedParticles(14217, 10, 20, 5013, 1942, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
				m.PlaySound(508);
			}
		}

		public class InternalTimer : Timer
		{
			private Mobile m_Mobile;
			private DateTime m_Endtime;

			public InternalTimer(Mobile target, DateTime end)
				: base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
			{
				m_Mobile = target;
				m_Endtime = end;

				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				if (m_Mobile.Hits > 1)
					m_Mobile.Hits--;

				if (DateTime.Now >= m_Endtime && m_Timers.Contains(m_Mobile) || m_Mobile == null || m_Mobile.Deleted || !m_Mobile.Alive)
				{
					var t = m_Timers[m_Mobile] as Timer;
					var mods = m_Table[m_Mobile] as ResistanceMod[];

					if (t != null && mods != null)
					{
						t.Stop();
						m_Timers.Remove(m_Mobile);
						m_Table.Remove(m_Mobile);

						m_Mobile.BodyMod = 0;

						foreach (var mod in mods)
							m_Mobile.RemoveResistanceMod(mod);

						m_Mobile.FixedParticles(14217, 10, 20, 5013, 1942, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
						m_Mobile.PlaySound(508);
					}

					Stop();
				}
			}
		}
	}
}