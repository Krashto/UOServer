using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Mobiles;
using Server.Network;

namespace Server.Custom.Spells.NewSpells.Guerison
{
	public class MainCicatrisanteSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Main cicatrisante", "[Main cicatrisante]",
				SpellCircle.First,
				212,
				9061,
				Reagent.EssenceGuerison
			);

		public override int RequiredAptitudeValue { get { return 1; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Guerison }; } }
		public override SkillName CastSkill { get { return SkillName.Healing; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public MainCicatrisanteSpell(Mobile caster, Item scroll)
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
			{
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			}
			else if (m.IsDeadBondedPet)
			{
				Caster.SendLocalizedMessage(1060177); // You cannot heal a creature that is already dead!
			}
			else if (m is BaseCreature && ((BaseCreature)m).IsAnimatedDead)
			{
				Caster.SendLocalizedMessage(1061654); // You cannot heal that which is not alive.
			}
			else if (m.Poisoned)
			{
				Caster.LocalOverheadMessage(MessageType.Regular, 0x22, (Caster == m) ? 1005000 : 1010398);
			}
			else if (CheckSequence())
			{
				SpellHelper.Turn(Caster, m);

				double toHeal = Utility.RandomMinMax(5, 7);

				toHeal = SpellHelper.AdjustValue(Caster, toHeal, Aptitude.Guerison);

				if (InquisitionSpell.IsActive(Caster))
					toHeal *= 1.5;

				if (CustomUtility.IsMobileUndead(m))
					SpellHelper.Damage(this, m, toHeal, 0, 0, 0, 0, 100);
				else
					m.Heal((int)toHeal);

				CustomUtility.ApplySimpleSpellEffect(m, "Main cicatrisante", AptitudeColor.Guerison, SpellEffectType.Heal);
			}

			FinishSequence();
		}

		public class InternalTarget : Target
		{
			private MainCicatrisanteSpell m_Owner;

			public InternalTarget(MainCicatrisanteSpell owner)
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