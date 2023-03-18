using System;
using System.Collections;
using Server.Custom.Aptitudes;
using Server.Spells;

namespace Server.Custom.Spells.NewSpells.Polymorphie
{
	public class FormeTerrestreSpell : Spell
	{
		private static Hashtable m_Table = new Hashtable();
		private static Hashtable m_Timers = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Forme terrestre", "Kal Vas Xen Ylem Choma",
				SpellCircle.Third,
				269,
				9020,
				false,
				Reagent.Bloodmoss,
				Reagent.MandrakeRoot,
				Reagent.BlackPearl
			);

		public override int RequiredAptitudeValue { get { return 3; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Polymorphie }; } }
		public override SkillName CastSkill { get { return SkillName.Anatomy; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public FormeTerrestreSpell(Mobile caster, Item scroll)
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

				Caster.BodyMod = 14;

				var value = SpellHelper.AdjustValue(Caster, Caster.Skills[CastSkill].Value / 20 + Caster.Skills[DamageSkill].Value / 20, Aptitude.Polymorphie);

				var mods = new ResistanceMod[]
				{
					new ResistanceMod( ResistanceType.Physical, (int)value),
					new ResistanceMod( ResistanceType.Fire, -(int)(value / 2) ),
					new ResistanceMod( ResistanceType.Energy, -(int)(value / 2) )
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
			private Mobile m_Target;
			private DateTime m_Endtime;

			public InternalTimer(Mobile target, DateTime end)
				: base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
			{
				m_Target = target;
				m_Endtime = end;

				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				if (DateTime.Now >= m_Endtime && m_Table.Contains(m_Target) || m_Target == null || m_Target.Deleted || !m_Target.Alive)
				{
					var t = m_Timers[m_Target] as Timer;
					var mods = m_Table[m_Target] as ResistanceMod[];

					if (t != null && mods != null)
					{
						t.Stop();
						m_Timers.Remove(m_Target);
						m_Table.Remove(m_Target);

						m_Target.BodyMod = 0;

						foreach (var mod in mods)
							m_Target.RemoveResistanceMod(mod);

						m_Target.FixedParticles(14217, 10, 20, 5013, 1942, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
						m_Target.PlaySound(508);
					}

					Stop();
				}
			}
		}
	}
}