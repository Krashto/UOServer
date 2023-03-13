using Server.Targeting;
using Server.Items;
using Server.Custom.Aptitudes;
using Server.Spells;
using VitaNex.FX;

namespace Server.Custom.Spells.NewSpells.Aeromancie
{
	public class ExTeleportationSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Ex-Teleportation", "Rel Ex Por",
				SpellCircle.Third,
				215,
				9031,
				Reagent.Bloodmoss,
				Reagent.MandrakeRoot
			);

		public override int RequiredAptitudeValue { get { return 6; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Aeromancie }; } }
		public override SkillName CastSkill { get { return SkillName.SpiritSpeak; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public ExTeleportationSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
		{
		}

		public override bool CheckCast()
		{
			if (Server.Misc.WeightOverloading.IsOverloaded(Caster))
			{
				Caster.SendLocalizedMessage(502359, "", 0x22); // Thou art too encumbered to move.
				return false;
			}

			return base.CheckCast();
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(Mobile m)
		{
			var orig = m;
			var map = Caster.Map;

			if (Server.Misc.WeightOverloading.IsOverloaded(Caster))
				Caster.SendLocalizedMessage(502359, "", 0x22); // Thou art too encumbered to move.
			else if (!SpellHelper.CheckTravel(Caster, map, new Point3D(m.Location), TravelCheckType.TeleportTo))
			{
			}
			else if (!Caster.CanSee(m))
				Caster.SendMessage("Vous ne pouvez pas voir l'endroit où vous désirez vous téléporter.");
			else if (CheckSequence())
			{
				SpellHelper.Turn(Caster, orig);

				var from = Caster.Location;
				var to = m.Location;

				Caster.Location = to;
				m.Location = from;
				m.Frozen = false;

				ExplodeFX.Smoke.CreateInstance(from, map, 1);
				ExplodeFX.Smoke.CreateInstance(to, map, 1);

				m.PlaySound(0x1FE);
			}

			FinishSequence();
		}

		public class InternalTarget : Target
		{
			private ExTeleportationSpell m_Owner;

			public InternalTarget(ExTeleportationSpell owner)
				: base(12, true, TargetFlags.None)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				var p = o as Mobile;

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