using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Custom.Aptitudes;

namespace Server.Spells
{
	public class SouffleDEspritSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Souffle D'esprit", "Por Corp Wis",
				SpellCircle.Fifth,
				218,
				9032,
				Reagent.BlackPearl,
				Reagent.MandrakeRoot,
				Reagent.Garlic
            );

        public override int RequiredAptitudeValue { get { return 7; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.Medecine }; } }

        public SouffleDEspritSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public override bool DelayedDamage{ get{ return true; } }

		public void Target( Mobile m )
		{
			if ( !Caster.CanSee( m ) )
			{
				Caster.SendMessage("Vous ne pouvez voir votre cible" ); // Target can not be seen.
			}
			else if ( CheckHSequence( m ) )
			{
                SpellHelper.Turn(Caster, m);

                Disturb(m);

                SpellHelper.CheckReflect((int)this.Circle, Caster, ref m);
				
				CustomPlayerMobile from = (CustomPlayerMobile)Caster;
				
                int casterMana = Caster.Mana;
				int targetMana = m.Mana;
				double aptoff = from.GetAptitudeValue(NAptitude.Medecine) * 0.25;

                double intdamage = (double)casterMana / (double)targetMana;

                if (intdamage < 0)
                    intdamage = 0;

                double damage = intdamage * 50;

                if (m is BaseCreature)
					damage *= 2;

                damage += damage * aptoff;

                if (damage <= 20)
                    damage = 20;
                else if (damage >= 120)
					damage = 120;
				
                Caster.FixedParticles(0x374A, 10, 15, 2038, EffectLayer.Head);

                m.FixedParticles(0x374A, 10, 15, 5038, EffectLayer.Head);
                m.PlaySound(0x213);

                SpellHelper.Damage(this, m, damage, 0, 0, 0, 0, 100);
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
            private SouffleDEspritSpell m_Owner;

            public InternalTarget(SouffleDEspritSpell owner)
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