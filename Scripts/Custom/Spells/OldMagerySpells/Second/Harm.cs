using Server.Mobiles;
using Server.Targeting;

namespace Server.Spells.Second
{
    public class HarmSpell : MagerySpell
    {
        private static readonly SpellInfo m_Info = new SpellInfo(
            "Harm", "An Mani",
			SpellCircle.Second,
            212,
			9001,
            Reagent.Nightshade,
            Reagent.SpidersSilk);
        public HarmSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override SpellCircle Circle => SpellCircle.Second;
        public override bool DelayedDamage => false;
        public override void OnCast()
        {
            Caster.Target = new InternalTarget(this);
        }

        //public override double GetSlayerDamageScalar(Mobile target)
        //{
        //    return 1.0; //This spell isn't affected by slayer spellbooks
        //}

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
                Mobile source = Caster;

                SpellHelper.CheckReflect((int)SpellCircle.Second, source, ref mob);

                double damage = GetNewAosDamage(mob, 17, 1, 5, mob is PlayerMobile);

                if (!Caster.InRange(m, 2))
                    damage *= 0.25; // 1/4 damage at > 2 tile range
                else if (!Caster.InRange(m, 1))
                    damage *= 0.50; // 1/2 damage at 2 tile range

                if (mob != null)
                {
                    mob.FixedParticles(0x374A, 10, 30, 5013, 1153, 2, EffectLayer.Waist);
                    mob.PlaySound(0x0FC);
                }
                else
                {
                    Effects.SendLocationParticles(m, 0x374A, 10, 30, 1153, 2, 5013, 0);
                    Effects.PlaySound(m.Location, m.Map, 0x0FC);
                }

                if (damage > 0)
                {
                    SpellHelper.Damage(this, mob, damage, 0, 0, 100, 0, 0);
                }
            }

            FinishSequence();
        }

        private class InternalTarget : Target
        {
            private readonly HarmSpell m_Owner;
            public InternalTarget(HarmSpell owner)
                : base(10, false, TargetFlags.Harmful)
            {
                m_Owner = owner;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is IDamageable)
                {
                    m_Owner.Target((IDamageable)o);
                }
            }

            protected override void OnTargetFinish(Mobile from)
            {
                m_Owner.FinishSequence();
            }
        }
    }
}
