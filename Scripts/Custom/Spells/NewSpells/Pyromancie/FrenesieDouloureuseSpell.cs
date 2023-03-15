using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Items;

namespace Server.Custom.Spells.NewSpells.Roublardise
{
	public class FrenesieDouloureuseSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Fr�n�sie Douloureuse", "Pas Tym An Flam",
				SpellCircle.Fifth,
				203,
				9031,
				Reagent.BatWing,
				Reagent.NoxCrystal
			);

		public override int RequiredAptitudeValue { get { return 6; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Pyromancie }; } }
		public override SkillName CastSkill { get { return SkillName.Magery; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public FrenesieDouloureuseSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
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
				Disturb(m);

				SpellHelper.Turn(Caster, m);
				SpellHelper.Turn(m, Caster);

				MovingSpells.PushMobileTo(m, m.Location, MovingSpells.GetOppositeDirection(m.Direction), (int)Caster.GetDistanceToSqrt(m));

				m.Attack(Caster);
				Caster.Attack(m);

				BleedAttack.BeginBleed(m, Caster, true);

				m.FixedParticles(0x374A, 10, 15, 5021, EffectLayer.Waist);
				m.PlaySound(0x474);
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private FrenesieDouloureuseSpell m_Owner;

			public InternalTarget(FrenesieDouloureuseSpell owner)
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