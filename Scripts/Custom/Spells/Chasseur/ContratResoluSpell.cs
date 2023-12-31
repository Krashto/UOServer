using System;
using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Custom.Spells.NewSpells.Chasseur;
using Server.Items;
using VitaNex.FX;
using Server.Network;
using Server.Custom.Spells.NewSpells.Hydromancie;
using Server.Custom.Spells.NewSpells.Roublardise;

namespace Server.Custom.Spells.NewSpells.Geomancie
{
	public class ContratResoluSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Contrat Resolu", "[Contrat Resolu]",
				SpellCircle.Fifth,
				218,
				9012,
				Reagent.EssenceChasseur
			);

		public override int RequiredAptitudeValue { get { return 10; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Chasseur }; } }
		public override SkillName CastSkill { get { return SkillName.Tracking; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public ContratResoluSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(Mobile m)
		{
			if (!Caster.CanSee(m))
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			else if (CheckHSequence(m))
			{
				SpellHelper.Turn(Caster, m);

				if (m.Hits <= (m.HitsMax * 0.3) && MarquerSpell.IsActive(m) && BleedAttack.IsBleeding(m))
				{
					Caster.MoveToWorld(m.Location, m.Map);
					m.Damage(100);

					ExplodeFX.Blood.CreateInstance(Caster, Caster.Map, 5).Send();

					CustomUtility.ApplySimpleSpellEffect(m, "Contrat r�solu", AptitudeColor.Chasseur, SpellEffectType.Damage);
				}
				else
				{
					Caster.SendMessage("La cible doit �tre paralys� et doit saigner et doit avoir �t� marqu� par le sort 'Marquer' avant de pouvoir �tre touch�e par ce sort.");
				}
			}

			FinishSequence();
		}

		public class InternalTarget : Target
		{
			private ContratResoluSpell m_Owner;

			public InternalTarget(ContratResoluSpell owner)
				: base(12, false, TargetFlags.Harmful)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is Mobile)
					m_Owner.Target((Mobile)o);
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}