using Server.Custom.Aptitudes;
using Server.Spells;
using VitaNex.FX;
using System;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using System.Collections;

namespace Server.Custom.Spells.NewSpells.Martial
{
	public class SautDevastateurSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Saut devastateur", "[Saut devastateur]",
				SpellCircle.Eighth,
				203,
				9051,
				Reagent.EssenceMartial
			);

		public override int RequiredAptitudeValue { get { return 3; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Martial }; } }
		public override SkillName CastSkill { get { return SkillName.Tactics; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public override TimeSpan CastDelayBase => TimeSpan.Zero;
		public override double CastDelayFastScalar => 0;
		public override double CastDelaySecondsPerTick => 1;
		public override TimeSpan CastDelayMinimum => TimeSpan.Zero;

		public override int CastRecoveryBase => 0;
		public override int CastRecoveryFastScalar => 0;
		public override int CastRecoveryPerSecond => 1;
		public override int CastRecoveryMinimum => 0;

		public SautDevastateurSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				var oldLocation = Caster.Location;

				ConcentricWaveFX.Fire.CreateInstance(Caster.Location, Caster.Map, Caster.Direction, 3).Send();

				MovingSpells.MoveMobileTo(Caster, Caster.Direction, 3);

				int dx = Caster.Location.X - oldLocation.X;
				int dy = Caster.Location.Y - oldLocation.Y;
				int rx = (dx - dy) * 44;
				int ry = (dx + dy) * 44;

				bool eastToWest;

				if (rx >= 0 && ry >= 0)
					eastToWest = false;
				else if (rx >= 0)
					eastToWest = true;
				else if (ry >= 0)
					eastToWest = true;
				else
					eastToWest = false;

				Effects.PlaySound(Caster.Location, Caster.Map, 0x20C);

				int itemID = eastToWest ? 0x398C : 0x3996;

				Point3D pnt = new Point3D(Caster.Location);

				TimeSpan duration = GetDurationForSpell(5, 0.5);

				CustomUtility.ApplySimpleSpellEffect(Caster, "Saut devastateur", AptitudeColor.Martial, SpellEffectType.Move);

				if (SpellHelper.CheckField(pnt, Caster.Map))
					new FireFieldItem(itemID, pnt, Caster, Caster.Map, duration, 3);

				for (int i = 1; i <= 2; ++i)
				{
					Timer.DelayCall(TimeSpan.FromMilliseconds(i * 100), index =>
					{
						Point3D point = new Point3D(eastToWest ? pnt.X + index : pnt.X, eastToWest ? pnt.Y : pnt.Y + index, pnt.Z);
						SpellHelper.AdjustField(ref point, Caster.Map, 16, false);

						if (SpellHelper.CheckField(point, Caster.Map))
							new FireFieldItem(itemID, point, Caster, Caster.Map, duration, 3);

						point = new Point3D(eastToWest ? pnt.X + -index : pnt.X, eastToWest ? pnt.Y : pnt.Y + -index, pnt.Z);
						SpellHelper.AdjustField(ref point, Caster.Map, 16, false);

						if (SpellHelper.CheckField(point, Caster.Map))
							new FireFieldItem(itemID, point, Caster, Caster.Map, duration, 3);
					}, i);
				}
			}

			FinishSequence();
		}

		[DispellableField]
		public class FireFieldItem : Item
		{
			private Timer m_Timer;
			private DateTime m_End;
			private Mobile m_Caster;
			private int m_Damage;

			public Mobile Caster => m_Caster;

			public FireFieldItem(int itemID, Point3D loc, Mobile caster, Map map, TimeSpan duration)
				: this(itemID, loc, caster, map, duration, 2)
			{
			}

			public FireFieldItem(int itemID, Point3D loc, Mobile caster, Map map, TimeSpan duration, int damage)
				: base(itemID)
			{
				bool canFit = SpellHelper.AdjustField(ref loc, map, 12, false);

				Movable = false;
				Light = LightType.Circle300;

				MoveToWorld(loc, map);
				Effects.SendLocationParticles(EffectItem.Create(loc, map, EffectItem.DefaultDuration), 0x376A, 9, 10, 5029);

				m_Caster = caster;

				m_Damage = damage;

				m_End = DateTime.UtcNow + duration;

				m_Timer = new InternalTimer(this, caster.InLOS(this), canFit);
				m_Timer.Start();
			}

			public FireFieldItem(Serial serial)
				: base(serial)
			{
			}

			public override bool BlocksFit => true;
			public override void OnAfterDelete()
			{
				base.OnAfterDelete();

				if (m_Timer != null)
					m_Timer.Stop();
			}

			public override void Serialize(GenericWriter writer)
			{
				base.Serialize(writer);

				writer.Write(2); // version

				writer.Write(m_Damage);
				writer.Write(m_Caster);
				writer.WriteDeltaTime(m_End);
			}

			public override void Deserialize(GenericReader reader)
			{
				base.Deserialize(reader);

				int version = reader.ReadInt();

				switch (version)
				{
					case 2:
						{
							m_Damage = reader.ReadInt();
							goto case 1;
						}
					case 1:
						{
							m_Caster = reader.ReadMobile();

							goto case 0;
						}
					case 0:
						{
							m_End = reader.ReadDeltaTime();

							m_Timer = new InternalTimer(this, true, true);
							m_Timer.Start();

							break;
						}
				}

				if (version < 2)
					m_Damage = 2;
			}

			public override bool OnMoveOver(Mobile m)
			{
				if (Visible && m_Caster != null && m != m_Caster && SpellHelper.ValidIndirectTarget(m_Caster, m) && m_Caster.CanBeHarmful(m, false) && m_Caster.InLOS(m) && !CustomPlayerMobile.IsInEquipe(m_Caster, m))
				{
					if (SpellHelper.CanRevealCaster(m))
						m_Caster.RevealingAction();

					m_Caster.DoHarmful(m);

					int damage = m_Damage;

					AOS.Damage(m, m_Caster, damage, 0, 100, 0, 0, 0);
					m.PlaySound(0x208);

					if (m is BaseCreature)
						((BaseCreature)m).OnHarmfulSpell(m_Caster);
				}

				return true;
			}

			private class InternalTimer : Timer
			{
				private static readonly Queue m_Queue = new Queue();
				private readonly FireFieldItem m_Item;
				private readonly bool m_InLOS;
				private readonly bool m_CanFit;

				public InternalTimer(FireFieldItem item, bool inLOS, bool canFit)
					: base(TimeSpan.FromMilliseconds(500), TimeSpan.FromSeconds(1.0))
				{
					m_Item = item;
					m_InLOS = inLOS;
					m_CanFit = canFit;

					Priority = TimerPriority.FiftyMS;
				}

				protected override void OnTick()
				{
					if (m_Item.Deleted)
						return;

					if (DateTime.UtcNow > m_Item.m_End)
					{
						m_Item.Delete();
						Stop();
					}
					else
					{
						Map map = m_Item.Map;
						Mobile caster = m_Item.m_Caster;

						if (map != null && caster != null)
						{
							IPooledEnumerable eable = m_Item.GetMobilesInRange(0);

							foreach (Mobile m in eable)
							{
								if ((m.Z + 16) > m_Item.Z && (m_Item.Z + 12) > m.Z && m != caster && SpellHelper.ValidIndirectTarget(caster, m) && caster.CanBeHarmful(m, false) && caster.InLOS(m) && !CustomPlayerMobile.IsInEquipe(caster, m))
									m_Queue.Enqueue(m);
							}

							eable.Free();

							while (m_Queue.Count > 0)
							{
								Mobile m = (Mobile)m_Queue.Dequeue();

								if (SpellHelper.CanRevealCaster(m))
									caster.RevealingAction();

								caster.DoHarmful(m);

								int damage = m_Item.m_Damage;

								AOS.Damage(m, caster, damage, 0, 100, 0, 0, 0);
								m.PlaySound(0x208);

								if (m is BaseCreature)
									((BaseCreature)m).OnHarmfulSpell(caster);
							}
						}
					}
				}
			}
		}
	}
}