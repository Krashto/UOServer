using System.Collections;
using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Items;
using Server.Custom.Spells.NewSpells.Polymorphie;

namespace Server.Custom.Spells.NewSpells.Geomancie
{
	public class EmpalementSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Empalement", "[Empalement]",
				SpellCircle.Eighth,
				233,
				9042,
				false,
				Reagent.SulfurousAsh,
				Reagent.SulfurousAsh,
				Reagent.SulfurousAsh
			);

		public override int RequiredAptitudeValue { get { return 4; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Geomancie }; } }
		public override SkillName CastSkill { get { return SkillName.MagicResist; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public EmpalementSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public override bool DelayedDamage { get { return true; } }

		public void Target(IPoint3D p)
		{
			if (!Caster.CanSee(p))
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			else if (CheckSequence())
			{
				SpellHelper.Turn(Caster, p);

				if (p is Item)
					p = ((Item)p).GetWorldLocation();

				var targets = new ArrayList();

				var map = Caster.Map;

				if (map != null)
				{
					IPooledEnumerable eable = map.GetMobilesInRange(new Point3D(p), (int)(1 + Caster.Skills[CastSkill].Value / 25));

					foreach (Mobile m in eable)
						if (Caster != m && SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeHarmful(m, false))
							targets.Add(m);

					eable.Free();
				}

				if (targets.Count > 0)
				{
					Effects.PlaySound(p, Caster.Map, 0x160);

					for (var i = 0; i < targets.Count; ++i)
					{
						var m = (Mobile)targets[i];

						if (!InsensibleSpell.IsActive(m))
						{
							Disturb(m);

							if (!CheckResisted(m))
								BleedAttack.BeginBleed(m, Caster, true);
							else
								m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.

							Caster.MovingParticles(m, 0x36D4, 7, 0, false, true, 9501, 1, 0, 0x100);
						}
						else
							Caster.SendMessage($"{m.Name} est immunisé{(m.Female ? "e" : "")} aux saignements.");
					}
				}
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private EmpalementSpell m_Owner;

			public InternalTarget(EmpalementSpell owner)
				: base(12, true, TargetFlags.Harmful)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				var p = o as IPoint3D;

				if (p != null)
					m_Owner.Target(p);
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}