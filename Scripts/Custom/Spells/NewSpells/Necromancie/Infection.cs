using System;
using System.Collections;
using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Mobiles;

namespace Server.Custom.Spells.NewSpells.Necromancie
{
	public class InfectionSpell : Spell
	{
		private static Hashtable m_Registry = new Hashtable();
		public static Hashtable Registry { get { return m_Registry; } }
		public static Hashtable m_Table = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Infection", "Des Sanct",
				SpellCircle.Fifth,
				227,
				9031,
				Reagent.Nightshade,
				Reagent.Garlic,
				Reagent.SulfurousAsh
			);

		public override int RequiredAptitudeValue { get { return 3; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Necromancie }; } }
		public override SkillName CastSkill { get { return SkillName.Necromancy; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public InfectionSpell(Mobile caster, Item scroll)
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
				ToogleCurse(this, Caster, m);

			FinishSequence();
		}

		public static void ToogleCurse(Spell spell, Mobile Caster, Mobile m)
		{
			SpellHelper.Turn(Caster, m);

			SpellHelper.CheckReflect((int)spell.Circle, Caster, ref m);

			var duration = spell.GetDurationForSpell(1);

			SpellHelper.AddStatCurse(Caster, m, StatType.Str, duration); SpellHelper.DisableSkillCheck = true;
			SpellHelper.AddStatCurse(Caster, m, StatType.Dex, duration);
			SpellHelper.AddStatCurse(Caster, m, StatType.Int, duration); SpellHelper.DisableSkillCheck = false;

			new InternalTimer(m, duration).Start();

			BuffInfo.AddBuff(m, new BuffInfo(BuffIcon.Curse, 1075835, 1075836, duration, m));

			if (m.Spell != null)
				m.Spell.OnCasterHurt();

			m.Paralyzed = false;

			m.FixedParticles(0x374A, 10, 15, 5028, EffectLayer.Waist);
			m.PlaySound(0x1EA);
		}

		private class InternalTimer : Timer
		{
			private Mobile m_Mobile;

			public InternalTimer(Mobile targ, TimeSpan duration)
				: base(duration)
			{
				m_Mobile = targ;
			}

			protected override void OnTick()
			{
				if (m_Mobile == null || m_Mobile.Deleted)
					return;

				BuffInfo.RemoveBuff(m_Mobile, BuffIcon.Curse);

				m_Mobile.PlaySound(0x1ED);
				m_Mobile.FixedParticles(0x375A, 10, 15, 5037, EffectLayer.Waist);
			}
		}

		private class InternalTarget : Target
		{
			private InfectionSpell m_Owner;

			public InternalTarget(InfectionSpell owner)
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