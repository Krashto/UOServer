using System.Collections;
using Server.Items;
using Server.Custom.Aptitudes;
using Server.Spells;

namespace Server.Custom.Spells.NewSpells.Roublardise
{
	public class EvasionSpell : Spell
	{
		private static Hashtable m_Registry = new Hashtable();
		public static Hashtable Registry { get { return m_Registry; } }

		private static SpellInfo m_Info = new SpellInfo(
				"Évasion", "In Por Ort Jux",
				SpellCircle.First,
				236,
				9011,
				Reagent.BlackPearl
			);

		public override int RequiredAptitudeValue { get { return 5; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Roublardise }; } }
		public override SkillName CastSkill { get { return SkillName.Hiding; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public override int CastDelayBase { get { return 0; } }
		public override int CastDelayCircleScalar { get { return 0; } }
		public override int CastDelayFastScalar { get { return 0; } }
		public override int CastDelayPerSecond { get { return 1; } }
		public override int CastDelayMinimum { get { return 0; } }

		public override int CastRecoveryBase { get { return 0; } }
		public override int CastRecoveryCircleScalar { get { return 0; } }
		public override int CastRecoveryFastScalar { get { return 0; } }
		public override int CastRecoveryPerSecond { get { return 1; } }
		public override int CastRecoveryMinimum { get { return 0; } }
		public EvasionSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
		{
		}

		public void GetLocation()
		{
			var X = Utility.Random(-10, 20);
			var Y = Utility.Random(-10, 20);

			var total = Caster.Location;

			IPoint3D p = new Point3D(total.X + X, total.Y + Y, total.Z);

			var orig = p;
			var map = Caster.Map;

			SpellHelper.GetSurfaceTop(ref p);

			point = new Point3D(p);

			if (Server.Misc.WeightOverloading.IsOverloaded(Caster))
			{
				Check = false;
				Count++;
				return;
			}
			else if (!SpellHelper.CheckTravel(Caster, TravelCheckType.TeleportFrom))
			{
				Check = false;
				Count++;
				return;
			}
			else if (!SpellHelper.CheckTravel(Caster, map, new Point3D(p), TravelCheckType.TeleportTo))
			{
				Check = false;
				Count++;
				return;
			}
			else if (map == null || !map.CanSpawnMobile(p.X, p.Y, p.Z))
			{
				Check = false;
				Count++;
				return;
			}
			else if (SpellHelper.CheckMulti(new Point3D(p), map))
			{
				Check = false;
				Count++;
				return;
			}
			else if (!Caster.CanSee(new Point3D(p)) || !Caster.InLOS(new Point3D(p)))
			{
				Check = false;
				Count++;
				return;
			}

			Check = true;
		}

		public Point3D point = new Point3D(0, 0, 0);
		public bool Check = false;
		public int Count = 0;

		public override void OnCast()
		{
			if (CheckSequence())
			{
				while ((!Check || point == Caster.Location || point == new Point3D(0, 0, 0)) && Count < 30)
					GetLocation();

				if (!Check)
					Caster.SendMessage("Vous ne pouvez pas vous téléporter dans les environs.");
				else
				{
					SpellHelper.Turn(Caster, point);

					var m = Caster;

					var to = point;

					var from = m.Location;

					m.Location = to;
					m.ProcessDelta();

					Caster.Hidden = true;
					Caster.AllowedStealthSteps = (int)SpellHelper.AdjustValue(Caster, 1 + Caster.Skills[SkillName.Magery].Value / 2, Aptitude.Roublardise);
					Caster.SendLocalizedMessage(502730); // You begin to move quietly.

					if (m.Player)
					{
						Effects.SendLocationParticles(EffectItem.Create(from, m.Map, EffectItem.DefaultDuration), 0x3728, 10, 10, 2023);
						Effects.SendLocationParticles(EffectItem.Create(to, m.Map, EffectItem.DefaultDuration), 0x3728, 10, 10, 5023);
					}
					else
						m.FixedParticles(0x376A, 9, 32, 0x13AF, EffectLayer.Waist);

					m.PlaySound(0x1FE);
				}
			}
			FinishSequence();
		}

	}
}