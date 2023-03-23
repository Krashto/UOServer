using Server.Targeting;

namespace Server.Spells.OldSpells
{
	public class LightningSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Lightning", "Por Ort Grav",
				SpellCircle.Fourth,
				239,
				9021,
				Reagent.MandrakeRoot,
				Reagent.SulfurousAsh
            );

        public override int RequiredAptitudeValue { get { return 45; } }
        public override int RequiredMagicCapacity { get { return 4; } }
        //public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.SortsNonUtilises }; } }

		public LightningSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public void Target( Mobile m )
		{
			if ( !Caster.CanSee( m ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if ( CheckHSequence( m ) )
			{
				SpellHelper.Turn( Caster, m );

                SpellHelper.CheckReflect((int)this.Circle, Caster, ref m);

                double damage = Utility.RandomMinMax(14, 20);
				damage *= 2;

				if (CheckResisted(m))
                {
                    damage *= 0.75;

                    m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
                }

                damage *= GetDamageScalar(m);

				m.BoltEffect( 0 );

				SpellHelper.Damage( this, m, damage, 0, 0, 0, 0, 100 );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private LightningSpell m_Owner;

			public InternalTarget( LightningSpell owner ) : base( 12, false, TargetFlags.Harmful )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
					m_Owner.Target( (Mobile)o );
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}