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
				"Forme cristalline", "[Forme cristalline]",
				SpellCircle.Eighth,
				269,
				9070,
				Reagent.EssencePolymorphie
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
				Deactivate(Caster);
			else
				BaseTransformationSpell.DeactivateAllTransformation(Caster);

			if (CheckSequence())
			{
				var duration = GetDurationForSpell(30, 2);

				Caster.BodyMod = 300;
				Caster.HueMod = 0;

				var value = SpellHelper.AdjustValue(Caster, (Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 10, Aptitude.Polymorphie);

				var mods = new ResistanceMod[]
				{
					new ResistanceMod( ResistanceType.Cold, (int)value),
					new ResistanceMod( ResistanceType.Poison, (int)value),
				};

				m_Table[Caster] = mods;

				foreach (var mod in mods)
					Caster.AddResistanceMod(mod);

				Caster.UpdateResistances();

				Timer t = new InternalTimer(Caster, DateTime.Now + duration);
				m_Timers[Caster] = t;
				t.Start();

				CustomUtility.ApplySimpleSpellEffect(Caster, "Forme cristalline", duration, AptitudeColor.Polymorphie);
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

			var t = m_Timers[m] as Timer;
			var mods = m_Table[m] as ResistanceMod[];

			if (t != null && mods != null)
			{
				t.Stop();
				m_Timers.Remove(m);
				m_Table.Remove(m);

				m.BodyMod = 0;
				m.HueMod = -1;

				foreach (var mod in mods)
					m.RemoveResistanceMod(mod);

				m.UpdateResistances();

				CustomUtility.ApplySimpleSpellEffect(m, "Forme cristalline", AptitudeColor.Polymorphie, SpellSequenceType.End);
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
				if (m_Mobile.Hits >= 5)
					m_Mobile.Hits -= 2;

				if (DateTime.Now >= m_EndTime && m_Timers.Contains(m_Mobile) || m_Mobile == null || m_Mobile.Deleted || !m_Mobile.Alive)
				{
					Deactivate(m_Mobile);
					Stop();
				}
			}
		}
	}
}