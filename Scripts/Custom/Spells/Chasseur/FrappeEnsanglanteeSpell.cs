using System;
using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Items;
using VitaNex.FX;
using Server.Custom.Spells.NewSpells.Polymorphie;

namespace Server.Custom.Spells.NewSpells.Chasseur
{
	public class FrappeEnsanglanteeSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Frappe ensanglantee", "[Frappe ensanglantee]",
				SpellCircle.Seventh,
				245,
				9042,
				Reagent.EssenceChasseur
			);

		public override int RequiredAptitudeValue { get { return 5; } }
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

				if (!InsensibleSpell.IsActive(m))
				{
					Disturb(m);

					ExplodeFX.Blood.CreateInstance(Caster, Caster.Map, 1).Send();

					SpellHelper.CheckReflect((int)Circle, Caster, ref m);

					MortalStrike.BeginWound(m, TimeSpan.FromSeconds(6.0));
					BleedAttack.BeginBleed(m, Caster, true);

					CustomUtility.ApplySimpleSpellEffect(m, "Frappe ensanglantée", AptitudeColor.Chasseur, SpellEffectType.Damage);
				}
				else
					Caster.SendMessage("La cible est immunisée aux saignements.");
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