using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Custom.Aptitudes;

namespace Server.Spells
{
	public class EclairSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Eclair", "Por Ort Grav",
				SpellCircle.Fourth,
				239,
				9021,
				Reagent.MandrakeRoot,
				Reagent.SulfurousAsh,
                Reagent.BlackPearl
            );

        public override int RequiredAptitudeValue { get { return 3; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.Destruction }; } }

        public EclairSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
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

                Disturb(m);

                SpellHelper.CheckReflect((int)this.Circle, Caster, ref m);

                double damage = GetNewAosDamage(m, 15, 1, 3, true);

                damage = (int)SpellHelper.AdjustValue(Caster, damage, NAptitude.Destruction);

                if (CheckResisted(m))
                {
                    damage *= 0.75;

                    m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
                }

				m.BoltEffect( 0 );

                SpellHelper.Damage( this, m, damage, 0, 0, 0, 0, 100 );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
            private EclairSpell m_Owner;

            public InternalTarget(EclairSpell owner)
                : base(12, false, TargetFlags.Harmful)
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