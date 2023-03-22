using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Mobiles;
using Server.Network;

namespace Server.Custom.Spells.NewSpells.Guerison
{
	public class RayonCelesteSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Rayon celeste", "[Rayon celeste]",
				SpellCircle.First,
				212,
				9061,
				Reagent.Garlic,
				Reagent.Ginseng
			);

		public override int RequiredAptitudeValue { get { return 4; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Guerison }; } }
		public override SkillName CastSkill { get { return SkillName.Healing; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public RayonCelesteSpell(Mobile caster, Item scroll)
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
			else if (CheckBSequence(m))
			{
				SpellHelper.Turn(Caster, m);

				double toHeal;

				toHeal = Caster.Skills[CastSkill].Value * 0.2 + Caster.Skills[DamageSkill].Value * 0.2;
				toHeal += Utility.Random(1, 5);

				toHeal = SpellHelper.AdjustValue(Caster, toHeal, Aptitude.Guerison);

				if (InquisitionSpell.IsActive(Caster))
					toHeal *= 1.5;

				m.Heal((int)toHeal);

				m.FixedParticles(0x376A, 9, 32, 5005, EffectLayer.Waist);
				m.PlaySound(0x1F2);
			}

			FinishSequence();
		}

		public class InternalTarget : Target
		{
			private RayonCelesteSpell m_Owner;

			public InternalTarget(RayonCelesteSpell owner)
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