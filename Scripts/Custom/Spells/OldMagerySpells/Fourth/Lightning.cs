using Server.Mobiles;
using Server.Targeting;

namespace Server.Spells.Fourth
{
    public class LightningSpell : MagerySpell
    {
        private static readonly SpellInfo m_Info = new SpellInfo(
            "Lightning", "Por Ort Grav",
			SpellCircle.Fourth,
            239,
			9021,
            Reagent.MandrakeRoot,
            Reagent.SulfurousAsh);
        public LightningSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override SpellCircle Circle => SpellCircle.Fourth;
        public override bool DelayedDamage => false;
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
                Mobile source = Caster;
                SpellHelper.Turn(Caster, m.Location);

                SpellHelper.CheckReflect((int)SpellCircle.Fourth, source, ref mob);

                double damage = GetNewAosDamage(mob, 23, 1, 4, mob is PlayerMobile);

                if (m is Mobile)
                {
                    Effects.SendBoltEffect(m, true, 0, false);
                }
                else
                {
                    Effects.SendBoltEffect(EffectMobile.Create(m.Location, m.Map, EffectMobile.DefaultDuration), true, 0, false);
                }

                if (damage > 0)
                {
                    SpellHelper.Damage(this, mob, damage, 0, 0, 0, 0, 100);
                }
            }

            FinishSequence();
        }

        private class InternalTarget : Target
        {
            private readonly LightningSpell m_Owner;
            public InternalTarget(LightningSpell owner)
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
