using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;

namespace Server.Custom.Spells.NewSpells.Defenseur
{
	public class CoupDeBouclierSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Coup de bouclier", "[Coup de bouclier]",
				SpellCircle.Second,
				203,
				9041,
				Reagent.EssenceDefenseur
			);

		public override int RequiredAptitudeValue { get { return 1; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Defenseur }; } }
		public override SkillName CastSkill { get { return SkillName.Parry; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public CoupDeBouclierSpell(Mobile caster, Item scroll)
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
			{
				var source = Caster;

				SpellHelper.Turn(source, m);

				Disturb(m);

				Caster.Animate(AnimationType.Parry, 0);

				double damage = GetNewAosDamage(m, 6, 1, 2, false);

				if (CheckResisted(m))
				{
					damage *= 0.75;

					m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
				}

				SpellHelper.Damage(this, m, damage, 100, 0, 0, 0, 0);
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private CoupDeBouclierSpell m_Owner;

			public InternalTarget(CoupDeBouclierSpell owner)
				: base(2, false, TargetFlags.Harmful)
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