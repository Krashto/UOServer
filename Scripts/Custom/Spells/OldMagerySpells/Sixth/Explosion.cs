using Server.Targeting;
using System;
namespace Server.Spells.Sixth
{
    public class ExplosionSpell : MagerySpell
    {
        private static readonly SpellInfo m_Info = new SpellInfo(
            "Explosion", "Vas Ort Flam",
			SpellCircle.Sixth,
            230,
			9041,
            Reagent.Bloodmoss,
            Reagent.MandrakeRoot);
        public ExplosionSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override SpellCircle Circle => SpellCircle.Sixth;
        //public override bool DelayedDamageStacking => false;
        public override void OnCast()
        {
            Caster.Target = new InternalTarget(this);
        }

        public void Target(IDamageable m)
        {
            //if (HasDelayContext(m))
            //{
            //    DoHurtFizzle();
            //    return;
            //}

            if (!Caster.CanSee(m))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (Caster.CanBeHarmful(m) && CheckSequence())
            {
                SpellHelper.Turn(Caster, m);

				if (m is Mobile mob)
				{
					double damage = GetNewAosDamage(mob, 40, 1, 5, false);

					if (m != null)
					{
						m.FixedParticles(0x36BD, 20, 10, 5044, EffectLayer.Head);
						m.PlaySound(0x307);
					}
					else
					{
						Effects.SendLocationParticles(m, 0x36BD, 20, 10, 5044);
						Effects.PlaySound(m.Location, m.Map, 0x307);
					}

					if (damage > 0)
					{
						SpellHelper.Damage(this, mob, damage, 0, 100, 0, 0, 0);
					}
				}
			}

            FinishSequence();
        }

        private class InternalTarget : Target
        {
            private readonly ExplosionSpell m_Owner;
            public InternalTarget(ExplosionSpell owner)
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
