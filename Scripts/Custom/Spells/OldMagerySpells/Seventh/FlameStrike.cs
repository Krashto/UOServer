using Server.Mobiles;
using Server.Targeting;

namespace Server.Spells.Seventh
{
    public class FlameStrikeSpell : MagerySpell
    {
        private static readonly SpellInfo m_Info = new SpellInfo(
            "Flame Strike", "Kal Vas Flam",
			SpellCircle.Seventh,
            245,
			9042,
            Reagent.SpidersSilk,
            Reagent.SulfurousAsh);
        public FlameStrikeSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override SpellCircle Circle => SpellCircle.Seventh;
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

                Mobile source = Caster;

                SpellHelper.CheckReflect((int)SpellCircle.Seventh, source, ref mob);

                double damage = GetNewAosDamage(mob, 48, 1, 5, mob is PlayerMobile);

                if (m != null)
                {
                    m.FixedParticles(0x3709, 10, 30, 5052, EffectLayer.LeftFoot);
                    m.PlaySound(0x208);
                }

                if (damage > 0)
                {
                    SpellHelper.Damage(this, mob, damage, 0, 100, 0, 0, 0);
                }
            }

            FinishSequence();
        }

        private class InternalTarget : Target
        {
            private readonly FlameStrikeSpell m_Owner;
            public InternalTarget(FlameStrikeSpell owner)
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
