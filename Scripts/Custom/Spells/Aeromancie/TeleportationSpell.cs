using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using VitaNex.FX;

namespace Server.Custom.Spells.NewSpells.Aeromancie
{
	public class TeleportationSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Teleportation", "[Teleportation]",
				SpellCircle.Third,
				215,
				9031,
				Reagent.EssenceAeromancie
			);

		public override int RequiredAptitudeValue { get { return 3; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Aeromancie }; } }
		public override SkillName CastSkill { get { return SkillName.SpiritSpeak; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public TeleportationSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
		{
		}

		public override bool CheckCast()
		{
			if (Server.Misc.WeightOverloading.IsOverloaded(Caster))
			{
				Caster.SendLocalizedMessage(502359, "", 0x22); // Thou art too encumbered to move.
				return false;
			}

			return base.CheckCast(); //SpellHelper.CheckTravel( Caster, TravelCheckType.TeleportFrom );
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(IPoint3D p)
		{
			var orig = p;
			var map = Caster.Map;

			SpellHelper.GetSurfaceTop(ref p);

			if (Caster.Mounted)
				Caster.SendMessage("Vous ne pouvez pas vous téléporter à dos de cheval.");
			else if (Server.Misc.WeightOverloading.IsOverloaded(Caster))
				Caster.SendLocalizedMessage(502359, "", 0x22); // Thou art too encumbered to move.
			else if (!SpellHelper.CheckTravel(Caster, map, new Point3D(p), TravelCheckType.TeleportTo))
			{
			}
			else if (map == null || !map.CanSpawnMobile(p.X, p.Y, p.Z))
				Caster.SendLocalizedMessage(501942); // That location is blocked.
			else if (SpellHelper.CheckMulti(new Point3D(p), map))
				Caster.SendLocalizedMessage(501942); // That location is blocked.
			else if (!Caster.CanSee(p))
				Caster.SendMessage("Vous ne pouvez pas voir l'endroit où vous désirez vous téléporter.");
			else if (CheckSequence())
			{
				SpellHelper.Turn(Caster, orig);

				var from = Caster.Location;
				var to = new Point3D(p);

				Caster.Location = to;
				Caster.ProcessDelta();

				if (Caster.Player)
				{
					ExplodeFX.Smoke.CreateInstance(from, map, 0).Send();
					ExplodeFX.Smoke.CreateInstance(to, map, 0).Send();
				}
				else
					Caster.FixedParticles(0x376A, 9, 32, 0x13AF, EffectLayer.Waist);

				Caster.PlaySound(0x1FE);
			}

			FinishSequence();
		}

		public class InternalTarget : Target
		{
			private TeleportationSpell m_Owner;

			public InternalTarget(TeleportationSpell owner)
				: base(12, true, TargetFlags.None)
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