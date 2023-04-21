using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using System;

namespace Server.Custom.Spells.NewSpells.Roublardise
{
	public class CoupArriereSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Coup arriere", "[Coup arriere]",
				SpellCircle.Eighth,
				203,
				9051,
				Reagent.EssenceRoublardise
			);

		public override int RequiredAptitudeValue { get { return 3; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Roublardise }; } }
		public override SkillName CastSkill { get { return SkillName.Hiding; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public override TimeSpan CastDelayBase => TimeSpan.Zero;
		public override double CastDelayFastScalar => 0;
		public override double CastDelaySecondsPerTick => 1;
		public override TimeSpan CastDelayMinimum => TimeSpan.Zero;

		public override int CastRecoveryBase => 0;
		public override int CastRecoveryFastScalar => 0;
		public override int CastRecoveryPerSecond => 1;
		public override int CastRecoveryMinimum => 0;

		public CoupArriereSpell(Mobile caster, Item scroll)
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

				Caster.MoveToWorld(MoveTo(m), Caster.Map);

				Caster.Attack(m);

				CustomUtility.ApplySimpleSpellEffect(m, "Coup arriere", AptitudeColor.Roublardise, SpellEffectType.Damage);
			}

			FinishSequence();
		}

		private Point3D MoveTo(Mobile from)
		{
			var x = from.Location.X;
			var y = from.Location.Y;

			switch (from.Direction)
			{
				case Direction.North:	{ x--; y++; break; }
				case Direction.Right:	{ x--; break; }
				case Direction.East:	{ x--; y--; break; }
				case Direction.Down:	{ y--; break; }
				case Direction.South:	{ x++; y--; break; }
				case Direction.Left:	{ x++;; break; }
				case Direction.West:	{ x++; y--; break; }
				case Direction.Up:		{ y++; break; }
			}

			return new Point3D(x, y, from.Z);
		}


		private class InternalTarget : Target
		{
			private CoupArriereSpell m_Owner;

			public InternalTarget(CoupArriereSpell owner)
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