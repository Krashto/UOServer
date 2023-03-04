using Server.Targeting;

namespace Server.Spells.OldSpells
{
	public class HarmSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Harm", "An Mani",
				SpellCircle.Second,
				212,
				9041,
				Reagent.Nightshade,
				Reagent.SpidersSilk
            );

        public override int RequiredAptitudeValue { get { return 20; } }
        public override int RequiredMagicCapacity { get { return 2; } }
        //public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.SortsNonUtilises }; } }

		public HarmSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public override bool DelayedDamage{ get{ return false; } }

        public void Target(Mobile m)
        {
            if (!Caster.CanSee(m))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (CheckHSequence(m))
            {
                SpellHelper.Turn(Caster, m);

                SpellHelper.CheckReflect((int)this.Circle, Caster, ref m);

                double damage = Utility.RandomMinMax(1, 12);

                if (CheckResisted(m))
                {
                    damage *= 0.75;

                    m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
                }

                damage *= GetDamageScalar(m);

                m.FixedParticles(0x374A, 10, 15, 5013, EffectLayer.Waist);
                m.PlaySound(0x1F1);

                SpellHelper.Damage(this, m, damage, 0, 0, 100, 0, 0);
            }

            FinishSequence();
        }

		private class InternalTarget : Target
		{
			private HarmSpell m_Owner;

			public InternalTarget( HarmSpell owner ) : base( 12, false, TargetFlags.Harmful )
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