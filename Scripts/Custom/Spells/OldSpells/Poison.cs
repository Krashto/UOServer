using Server.Targeting;

namespace Server.Spells.OldSpells
{
	public class PoisonSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Poison", "In Nox",
				SpellCircle.Sixth,
				203,
				9051,
				Reagent.Nightshade
            );

        public override int RequiredAptitudeValue { get { return 65; } }
        public override int RequiredMagicCapacity { get { return 6; } }
        //public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.SortsNonUtilises }; } }

		public PoisonSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
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

				SpellHelper.CheckReflect( (int)this.Circle, Caster, ref m );

				if ( m.Spell != null )
					m.Spell.OnCasterHurt();

				m.Frozen = false;
				m.Paralyzed = false;
				m.CantWalk = false;

				/*if (CheckResisted(m))
                {
                    m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
                }
                else
                {*/
				int level;

                double total = (Caster.Skills[SkillName.Magery].Value + Caster.Skills[SkillName.Magery].Value);

                if (total >= 200.0 && 3 > Utility.Random(10))
                    level = 3;
                else if (total > 140.0)
                    level = 2;
                else if (total > 90.0)
                    level = 1;
                else
                    level = 0;

                if (level > 0 && CheckResisted(m))
                {
                    level = 0;
                    m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
                }

                m.ApplyPoison(Caster, Poison.GetPoison(level));

				m.FixedParticles( 0x374A, 10, 15, 5021, EffectLayer.Waist );
				m.PlaySound( 0x474 );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private PoisonSpell m_Owner;

			public InternalTarget( PoisonSpell owner ) : base( 12, false, TargetFlags.Harmful )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
				{
					m_Owner.Target( (Mobile)o );
				}
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}