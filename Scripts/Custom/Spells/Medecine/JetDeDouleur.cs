using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;
using Server.Custom.Aptitudes;

namespace Server.Spells
{
	public class JetDeDouleurSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Jet de douleur", "In Sar",
				SpellCircle.Eighth,
				203,
				9031,
				Reagent.GraveDust,
				Reagent.PigIron,
                Reagent.BatWing
            );

        public override int RequiredAptitudeValue { get { return 9; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.Medecine }; } }

        public override SkillName CastSkill { get { return SkillName.Magery; } }
        public override SkillName DamageSkill { get { return SkillName.Forensics; } }

        public JetDeDouleurSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public override bool DelayedDamage{ get{ return false; } }

		public void Target( Mobile m )
		{
            if (CheckHSequence(m))
            {
                SpellHelper.Turn(Caster, m);

                Disturb(m);

                SpellHelper.CheckReflect((int)this.Circle, Caster, ref m);

                m.FixedParticles(0x37C4, 1, 8, 9916, 39, 3, EffectLayer.Head);
                m.FixedParticles(0x37C4, 1, 8, 9502, 39, 4, EffectLayer.Head);
                m.PlaySound(0x210);

                double damage = GetNewAosDamage(m, 50, 1, 4, true);

                AOS.Damage(m, Caster, (int)damage, 0, 0, 0, 0, 100);
            }

			FinishSequence();
		}

		private class InternalTarget : Target
		{
            private JetDeDouleurSpell m_Owner;

            public InternalTarget(JetDeDouleurSpell owner)
                : base(12, false, TargetFlags.Harmful)
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
					m_Owner.Target( (Mobile) o );
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}