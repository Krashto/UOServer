using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;

namespace Server.Custom.Spells.NewSpells.Chasseur
{
	public class SautAggressifSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Saut aggressif", "Ju",
				SpellCircle.First,
				203,
				9051,
				Reagent.Nightshade
			);

		public override int RequiredAptitudeValue { get { return 2; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Geomancie }; } }
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
			else if (CheckHSequence(m))
			{
				SpellHelper.Turn(Caster, m);

				Disturb(m);

				MovingSpells.PushMobileTo(Caster, Caster.Location, MovingSpells.GetOppositeDirection(Caster.Direction), 3);

				double damage = GetNewAosDamage(m, 6, 1, 2, false);

				if (CheckResisted(m))
				{
					damage *= 0.75;
					m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
				}

				Caster.MovingParticles(m, 0x36D4, 7, 0, false, true, 342, 0, 9502, 4019, 0x160, 0);
				Caster.PlaySound(0x44B);

				SpellHelper.Damage(this, m, damage, 0, 100, 0, 0, 0);
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