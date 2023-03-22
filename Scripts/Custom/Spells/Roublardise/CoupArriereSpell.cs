using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;

namespace Server.Custom.Spells.NewSpells.Roublardise
{
	public class CoupArriereSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Coup arriere", "[Coup arriere]",
				SpellCircle.Eighth,
				203,
				9051,
				Reagent.Nightshade,
				Reagent.NoxCrystal,
				Reagent.BlackPearl
			);

		public override int RequiredAptitudeValue { get { return 4; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Roublardise }; } }
		public override SkillName CastSkill { get { return SkillName.Hiding; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public override int CastDelayBase { get { return 0; } }
		public override int CastDelayCircleScalar { get { return 0; } }
		public override int CastDelayFastScalar { get { return 0; } }
		public override int CastDelayPerSecond { get { return 1; } }
		public override int CastDelayMinimum { get { return 0; } }

		public override int CastRecoveryBase { get { return 0; } }
		public override int CastRecoveryCircleScalar { get { return 0; } }
		public override int CastRecoveryFastScalar { get { return 0; } }
		public override int CastRecoveryPerSecond { get { return 1; } }
		public override int CastRecoveryMinimum { get { return 0; } }

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
				
				m.FixedParticles(0x374A, 10, 15, 5021, EffectLayer.Waist);
				m.PlaySound(0x474);
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