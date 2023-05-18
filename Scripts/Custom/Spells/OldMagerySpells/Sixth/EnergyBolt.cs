using Server.Mobiles;
using Server.Targeting;
using System;

namespace Server.Spells.Sixth
{
    public class EnergyBoltSpell : MagerySpell
    {
        private static readonly SpellInfo m_Info = new SpellInfo(
            "Energy Bolt", "Corp Por",
			SpellCircle.Sixth,
            230,
			9022,
            Reagent.BlackPearl,
            Reagent.Nightshade);
        public EnergyBoltSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override SpellCircle Circle => SpellCircle.Sixth;
        public override bool DelayedDamage => true;
        public override void OnCast()
        {
            Caster.Target = new InternalTarget(this);
        }

        public void Target(IDamageable m)
        {
			Mobile mob = m as Mobile;

			if (mob == null)
			{
				Caster.SendMessage("Erreur");
			}
			else if (!Caster.CanSee(mob))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (CheckHSequence(mob))
            {
                SpellHelper.Turn(Caster, m);

                double damage = GetNewAosDamage(mob, 40, 1, 5, mob is PlayerMobile);

                // Do the effects
                Caster.MovingParticles(m, 0x379F, 7, 0, false, true, 3043, 4043, 0x211);
                Caster.PlaySound(0x20A);

                if (damage > 0)
                {
                    // Deal the damage
                    SpellHelper.Damage(this, mob, damage, 0, 0, 0, 0, 100);
                }
            }

            FinishSequence();
        }

        private class InternalTarget : Target
        {
            private readonly EnergyBoltSpell m_Owner;
            public InternalTarget(EnergyBoltSpell owner)
                : base(10, false, TargetFlags.Harmful)
            {
                m_Owner = owner;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is IDamageable)
                    m_Owner.Target((IDamageable)o);
            }

            protected override void OnTargetFinish(Mobile from)
            {
                m_Owner.FinishSequence();
            }
        }
    }
}
