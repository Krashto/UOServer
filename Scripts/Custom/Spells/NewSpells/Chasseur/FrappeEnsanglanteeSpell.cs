using System;
using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Items;
using VitaNex.FX;

namespace Server.Custom.Spells.NewSpells.Chasseur
{
	public class FrappeEnsanglanteeSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Frappe ensanglantée", "Kal Vas Flam",
				SpellCircle.Seventh,
				245,
				9042,
				Reagent.SpidersSilk,
				Reagent.SulfurousAsh,
				Reagent.BlackPearl
			);

		public override int RequiredAptitudeValue { get { return 6; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Chasseur }; } }
		public override SkillName CastSkill { get { return SkillName.Tracking; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public FrappeEnsanglanteeSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public override bool DelayedDamage { get { return true; } }

		public void Target(Mobile m)
		{
			if (!Caster.CanSee(m))
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			else if (CheckHSequence(m))
			{
				SpellHelper.Turn(Caster, m);

				Disturb(m);

				ExplodeFX.Blood.CreateInstance(Caster, Caster.Map, 1).Send();

				SpellHelper.CheckReflect((int)Circle, Caster, ref m);

				BleedAttack.BeginBleed(m, Caster, true);

				MortalStrike.BeginWound(m, TimeSpan.FromSeconds(6.0));

				m.FixedParticles(0x3709, 10, 30, 5052, EffectLayer.LeftFoot);
				m.PlaySound(0x208);
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private FrappeEnsanglanteeSpell m_Owner;

			public InternalTarget(FrappeEnsanglanteeSpell owner)
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