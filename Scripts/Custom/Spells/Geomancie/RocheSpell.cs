using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;

namespace Server.Custom.Spells.NewSpells.Geomancie
{
	public class RocheSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Roche", "[Roche]",
				SpellCircle.Second,
				203,
				9041,
				Reagent.EssenceGeomancie
			);

		public override int RequiredAptitudeValue { get { return 2; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Geomancie }; } }
		public override SkillName CastSkill { get { return SkillName.MagicResist; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public RocheSpell(Mobile caster, Item scroll)
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

				SpellHelper.CheckReflect((int)Circle, ref source, ref m);

				double damage = GetNewAosDamage(m, 6, 1, 2, false);

				if (CheckResisted(m))
				{
					damage *= 0.75;

					m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
				}

				source.MovingParticles(m, 0x11B6, 7, 0, false, true, 342, 0, 9502, 4019, 0x160, 0);
				source.PlaySound(0x44B);

				SpellHelper.Damage(this, m, damage, 100, 0, 0, 0, 0);

				CustomUtility.ApplySimpleSpellEffect(m, "Roche", AptitudeColor.Geomancie, SpellEffectType.Damage);
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private RocheSpell m_Owner;

			public InternalTarget(RocheSpell owner)
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