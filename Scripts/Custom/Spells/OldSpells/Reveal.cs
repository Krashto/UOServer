using System.Collections;
using Server.Targeting;

namespace Server.Spells.OldSpells
{
	public class RevealSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Reveal", "Wis Quas",
				SpellCircle.Sixth,
				206,
				9002,
				Reagent.Bloodmoss,
				Reagent.SulfurousAsh
            );

        public override int RequiredAptitudeValue { get { return 65; } }
        public override int RequiredMagicCapacity { get { return 6; } }
        //public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.SortsNonUtilises }; } }

		public RevealSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public void Target( IPoint3D p )
		{
			if ( !Caster.CanSee( p ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if ( CheckSequence() )
			{
				SpellHelper.Turn( Caster, p );

				SpellHelper.GetSurfaceTop( ref p );

				ArrayList targets = new ArrayList();

				Map map = Caster.Map;

				if ( map != null )
				{
                    double tile = 1 + (int)(Caster.Skills[SkillName.Magery].Value / 20.0);

					IPooledEnumerable eable = map.GetMobilesInRange( new Point3D( p ), (int)tile );

					foreach ( Mobile m in eable )
					{
						if ( m.Hidden && (m.AccessLevel == AccessLevel.Player || Caster.AccessLevel > m.AccessLevel) && Caster.CanBeHarmful( m, false, true ) && CheckDifficulty( Caster, m ) )
							targets.Add( m );
					}

					eable.Free();
				}

				for ( int i = 0; i < targets.Count; ++i )
				{
					Mobile m = (Mobile)targets[i];

					m.RevealingAction();

					m.FixedParticles( 0x375A, 9, 20, 5049, EffectLayer.Head );
					m.PlaySound( 0x1FD );
				}
			}

			FinishSequence();
		}

		// Reveal uses magery and detect hidden vs. hide and stealth 
		private static bool CheckDifficulty( Mobile from, Mobile m )
		{
			// Reveal always reveals vs. invisibility spell 
			if ( InvisibilitySpell.HasTimer( m ) )
				return true;

			double magery = from.Skills[SkillName.Magery].Value;
            double detectHidden = from.Skills[SkillName.DetectHidden].Value;

            double hiding = m.Skills[SkillName.Hiding].Value;
            double stealth = m.Skills[SkillName.Hiding].Value;

            double chance;

            if (hiding + stealth > 0)
				chance = (magery + detectHidden) - (hiding + stealth);
			else
				chance = 100;

			return chance > Utility.Random( 100 );
		}

		private class InternalTarget : Target
		{
			private RevealSpell m_Owner;

			public InternalTarget( RevealSpell owner ) : base( 12, true, TargetFlags.None )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				IPoint3D p = o as IPoint3D;

				if ( p != null )
					m_Owner.Target( p );
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}