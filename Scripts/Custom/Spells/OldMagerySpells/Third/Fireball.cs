using Server.Mobiles;
using Server.Targeting;
using System;
namespace Server.Spells.Third
{
    public class FireballSpell : MagerySpell
    {
        private static readonly SpellInfo m_Info = new SpellInfo(
            "Fireball", "Vas Flam",
			SpellCircle.Third,
            203,
			9041,
            Reagent.BlackPearl);
        public FireballSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override SpellCircle Circle => SpellCircle.Third;
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

                double damage = GetNewAosDamage(mob, 19, 1, 5, mob is PlayerMobile);

				SpellHelper.CheckReflect((int)SpellCircle.Third, Caster, ref mob);

				if (damage > 0)
                {
                    Caster.MovingParticles(m, 0x36D4, 7, 0, false, true, 9502, 4019, 0x160);
                    Caster.PlaySound(0x15E);

                    SpellHelper.Damage(this, mob, damage, 0, 100, 0, 0, 0);
                }
            }

            FinishSequence();
        }

        private class InternalTarget : Target
        {
            private readonly FireballSpell m_Owner;
            public InternalTarget(FireballSpell owner)
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
