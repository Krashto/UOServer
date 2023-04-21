using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Targeting;
using VitaNex.FX;

namespace Server.Custom.Spells.NewSpells.Martial
{
	public class ChargeFurieuseSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Charge furieuse", "[Charge furieuse]",
				SpellCircle.Fourth,
				230,
				9041,
				Reagent.EssenceMartial
			);

		public override int RequiredAptitudeValue { get { return 5; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Martial }; } }
		public override SkillName CastSkill { get { return SkillName.Tactics; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public ChargeFurieuseSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
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

				MovingSpells.MoveMobileTo(Caster, Caster.Location, Caster.Direction, (int)Caster.GetDistanceToSqrt(m));
				ExplodeFX.Earth.CreateInstance(Caster.Location, Caster.Map, 2).Send();

				MovingSpells.MoveMobileTo(m, m.Location, MovingSpells.GetOppositeDirection(m.Direction), 3);
				ExplodeFX.Earth.CreateInstance(m.Location, m.Map, 2).Send();
				CustomUtility.ApplySimpleSpellEffect(m, "Charge furieuse", AptitudeColor.Martial, SpellEffectType.Move);
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private ChargeFurieuseSpell m_Owner;

			public InternalTarget(ChargeFurieuseSpell owner)
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