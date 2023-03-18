using System;
using Server.Custom.Spells.NewSpells.Polymorphie;
using Server.Targeting;

namespace Server.Spells.OldSpells
{
	public class ParalyzeSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Paralyze", "An Ex Por",
				SpellCircle.Sixth,
				218,
				9012,
				Reagent.Garlic,
				Reagent.MandrakeRoot,
				Reagent.SpidersSilk
            );

        public override int RequiredAptitudeValue { get { return 65; } }
        public override int RequiredMagicCapacity { get { return 6; } }
        ////public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.SortsNonUtilises }; } }

		public ParalyzeSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
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
            else if (CheckHSequence(m))
            {
				if (!IndomptableSpell.IsActive(m))
				{
					SpellHelper.Turn(Caster, m);

					SpellHelper.CheckReflect((int)this.Circle, Caster, ref m);

					double duration = 5.0 + (Caster.Skills[SkillName.Magery].Value * 0.2);

					//duration = SpellHelper.AdjustValue(Caster, duration, NAptitude.MagieProlongee);

					if (CheckResisted(m))
						duration *= 0.75;

					m.Paralyze(TimeSpan.FromSeconds(duration));

					m.PlaySound(0x204);
					m.FixedEffect(0x376A, 6, 1);
				}
				else
					Caster.SendMessage("La cible est immunisée à la paralysie.");
			}

			FinishSequence();
		}

		public class InternalTarget : Target
		{
			private ParalyzeSpell m_Owner;

			public InternalTarget( ParalyzeSpell owner ) : base( 12, false, TargetFlags.Harmful )
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