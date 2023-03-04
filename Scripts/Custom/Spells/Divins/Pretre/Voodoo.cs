using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Spells;
using Server.Custom.Aptitudes;

namespace Server.Custom.Spells.Divins.Pretre
{
	public class VoodooSpell : ReligiousSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Voodoo", "Ota Desi Maga",
				SpellCircle.Eighth,
				212,
				9041
			);

		public override int RequiredAptitudeValue { get { return 11; } }
		public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.MagieAncestrale }; } }

		public VoodooSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			if (Caster is CustomPlayerMobile)
			{
				var pm = (CustomPlayerMobile)Caster;

				if (Religion.GetGodGroupName(pm) != CiliasGroups.Yen)
				{
					pm.SendMessage("Vous devez prier un des dieux de Yen pour pouvoir utiliser ce sort.");
					FinishSequence();
					return;
				}
			}

			Caster.Target = new InternalTarget(this);
		}

		public override bool DelayedDamage { get { return false; } }

		public void Target(CustomPlayerMobile m)
		{
			if (!Caster.CanSee(m))
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			else if (CheckSequence())
			{
				SpellHelper.Turn(Caster, m);

				var duration = GetDurationForSpell(0.1);

				m.Freeze(duration);

				m.FixedParticles(2339, 10, 15, 5013, 1328, 0, EffectLayer.CenterFeet);
				m.PlaySound(527);
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private VoodooSpell m_Owner;

			public InternalTarget(VoodooSpell owner)
				: base(12, false, TargetFlags.Beneficial)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is CustomPlayerMobile)
					m_Owner.Target((CustomPlayerMobile)o);
				else
					from.SendMessage("Vous ne pouvez que cibler les joueurs!");
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}