using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;

namespace Server.Custom.Spells.NewSpells.Guerison
{
	public class FerveurDivineSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Ferveur divine", "[Ferveur divine]",
				SpellCircle.First,
				212,
				9061,
				Reagent.EssenceGuerison
			);

		public override int RequiredAptitudeValue { get { return 7; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Guerison }; } }
		public override SkillName CastSkill { get { return SkillName.Healing; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public FerveurDivineSpell(Mobile caster, Item scroll)
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

				var mMana = m.Mana;
				m.Mana = Caster.Mana;
				Caster.Mana = mMana;

				Caster.SendMessage($"Vous avez échangé votre banque de mana avec {m.Name}.");
				Caster.MovingParticles(m, 0x379F, 7, 0, false, false, 3043, 0, 0);
				CustomUtility.ApplySimpleSpellEffect(Caster, "Ferveur divine", AptitudeColor.Guerison, SpellEffectType.Bonus);

				m.SendMessage($"{Caster.Name} a échangé sa banque de mana avec vous.");
				CustomUtility.ApplySimpleSpellEffect(m, "Ferveur divine", AptitudeColor.Guerison, SpellEffectType.Malus);
			}

			FinishSequence();
		}

		public class InternalTarget : Target
		{
			private FerveurDivineSpell m_Owner;

			public InternalTarget(FerveurDivineSpell owner)
				: base(12, false, TargetFlags.None)
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