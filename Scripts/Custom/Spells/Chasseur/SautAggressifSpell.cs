using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;

namespace Server.Custom.Spells.NewSpells.Chasseur
{
	public class SautAggressifSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Saut aggressif", "[Saut aggressif]",
				SpellCircle.First,
				203,
				9051,
				Reagent.EssenceChasseur
			);

		public override int RequiredAptitudeValue { get { return 7; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Chasseur }; } }
		public override SkillName CastSkill { get { return SkillName.Tracking; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public SautAggressifSpell(Mobile caster, Item scroll)
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
			else if (Caster.GetDistanceToSqrt(m) > 2)
				Caster.SendMessage("Vous devez être plus proche de votre cible pour lancer cette attaque.");
			else if (CheckHSequence(m))
			{
				SpellHelper.Turn(Caster, m);

				Disturb(m);

				MovingSpells.MoveMobileTo(Caster, MovingSpells.GetOppositeDirection(Caster.Direction), 3);

				double damage = GetNewAosDamage(m, 6, 1, 2, false);

				if (CheckResisted(m))
				{
					damage *= 0.75;
					m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
				}

				SpellHelper.Damage(this, m, damage, 0, 100, 0, 0, 0);

				CustomUtility.ApplySimpleSpellEffect(m, "Saut aggressif", AptitudeColor.Chasseur, SpellEffectType.Damage);
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private SautAggressifSpell m_Owner;

			public InternalTarget(SautAggressifSpell owner)
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