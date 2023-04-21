using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;

namespace Server.Custom.Spells.NewSpells.Guerison
{
	public class RemedeSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Remede", "[Remede]",
				SpellCircle.First,
				212,
				9061,
				Reagent.EssenceGuerison
			);

		public override int RequiredAptitudeValue { get { return 2; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Guerison }; } }
		public override SkillName CastSkill { get { return SkillName.Healing; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public RemedeSpell(Mobile caster, Item scroll)
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
			else if (CheckBSequence(m))
			{
				SpellHelper.Turn(Caster, m);

				var p = m.Poison;

				if (p != null)
				{
					double chanceToCure = 10000 + (int)(Caster.Skills[CastSkill].Value * 75) - (p.Level + 1) * 2500;
					chanceToCure /= 100;

					chanceToCure = SpellHelper.AdjustValue(Caster, chanceToCure, Aptitude.Chasseur);

					if ((int)chanceToCure > Utility.Random(100))
						if (m.CurePoison(Caster))
						{
							if (Caster != m)
								Caster.SendLocalizedMessage(1010058); // You have cured the target of all poisons!

							m.SendLocalizedMessage(1010059); // You have been cured of all poisons.
						}
					else
						m.SendLocalizedMessage(1010060); // You have failed to cure your target!
				}

				CustomUtility.ApplySimpleSpellEffect(m, "Remede", AptitudeColor.Guerison, SpellEffectType.Heal);
			}

			FinishSequence();
		}

		public class InternalTarget : Target
		{
			private RemedeSpell m_Owner;

			public InternalTarget(RemedeSpell owner)
				: base(12, false, TargetFlags.Beneficial)
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