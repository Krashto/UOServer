using System;
using System.Collections;
using Server.Targeting;
using Server.Misc;
using Server.Items;
using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Custom.Spells.NewSpells.Chasseur;

namespace Server.Custom.Spells.NewSpells.Aeromancie
{
	public class TornadoSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Tornado", "Evo Wis An Por Grav",
				SpellCircle.Third,
				215,
				9041,
				false,
				Reagent.BlackPearl,
				Reagent.SpidersSilk,
				Reagent.Ginseng
			);

		public override int RequiredAptitudeValue { get { return 4; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Aeromancie }; } }
		public override SkillName CastSkill { get { return SkillName.SpiritSpeak; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public TornadoSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget(this);
		}

		public void Target(IPoint3D p)
		{
			if (!Caster.CanSee(p))
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			else if (SpellHelper.CheckTown(p, Caster) && CheckSequence())
			{
				SpellHelper.Turn(Caster, p);

				SpellHelper.GetSurfaceTop(ref p);

				Effects.PlaySound(p, Caster.Map, 0x20C);

				var itemID = 0x3709;

				var duration = GetDurationForSpell(0.7);

				var loc = new Point3D(p.X, p.Y, p.Z);
				new InternalItem(itemID, loc, Caster, Caster.Map, duration, 1);

				loc = new Point3D(p.X, p.Y - 1, p.Z);
				new InternalItem(itemID, loc, Caster, Caster.Map, duration, 1);

				loc = new Point3D(p.X, p.Y + 1, p.Z);
				new InternalItem(itemID, loc, Caster, Caster.Map, duration, 1);

				loc = new Point3D(p.X + 1, p.Y, p.Z);
				new InternalItem(itemID, loc, Caster, Caster.Map, duration, 1);

				loc = new Point3D(p.X + 1, p.Y - 1, p.Z);
				new InternalItem(itemID, loc, Caster, Caster.Map, duration, 1);

				loc = new Point3D(p.X + 1, p.Y + 1, p.Z);
				new InternalItem(itemID, loc, Caster, Caster.Map, duration, 1);

				loc = new Point3D(p.X - 1, p.Y, p.Z);
				new InternalItem(itemID, loc, Caster, Caster.Map, duration, 1);

				loc = new Point3D(p.X - 1, p.Y - 1, p.Z);
				new InternalItem(itemID, loc, Caster, Caster.Map, duration, 1);

				loc = new Point3D(p.X - 1, p.Y + 1, p.Z);
				new InternalItem(itemID, loc, Caster, Caster.Map, duration, 1);
			}

			FinishSequence();
		}

		[DispellableField]
		public class InternalItem : Item
		{
			private Timer m_Timer;
			private DateTime m_End;
			private Mobile m_Caster;

			public override bool BlocksFit { get { return true; } }

			public InternalItem(int itemID, Point3D loc, Mobile caster, Map map, TimeSpan duration, int val)
				: base(itemID)
			{
				var canFit = SpellHelper.AdjustField(ref loc, map, 12, false);

				Hue = 0x895;
				Visible = false;
				Movable = false;

				MoveToWorld(loc, map);

				if (caster.InLOS(this))
					Visible = true;
				else
					Delete();

				if (!Deleted && VerifyOtherFields(caster))
					Delete();

				if (Deleted)
					return;

				m_Caster = caster;

				m_End = DateTime.Now + duration;

				m_Timer = new InternalTimer(this, TimeSpan.FromSeconds(Math.Abs(val) * 0.2), caster.InLOS(this), canFit);
				m_Timer.Start();
			}

			public bool VerifyOtherFields(Mobile caster)
			{
				var map = Map;

				var test = false;

				IPooledEnumerable eable = map.GetItemsInRange(Location, 0);

				if (Deleted)
					return false;

				foreach (Item item in eable)
				{
					if (item != null && this == item)
						continue;

					if (item != null && (item is InternalItem))
					{
						caster.SendMessage("Vous ne pouvez pas lancer un tornado au même endroit qu'un autre mur.");
						test = true;
					}
				}

				return test;
			}

			public override void OnAfterDelete()
			{
				base.OnAfterDelete();

				if (m_Timer != null)
					m_Timer.Stop();
			}

			public InternalItem(Serial serial) : base(serial)
			{
			}

			public override void Serialize(GenericWriter writer)
			{
				base.Serialize(writer);

				writer.Write(1); // version

				writer.Write(m_Caster);
				writer.WriteDeltaTime(m_End);
			}

			public override void Deserialize(GenericReader reader)
			{
				base.Deserialize(reader);

				var version = reader.ReadInt();

				switch (version)
				{
					case 1:
						{
							m_Caster = reader.ReadMobile();

							goto case 0;
						}
					case 0:
						{
							m_End = reader.ReadDeltaTime();

							m_Timer = new InternalTimer(this, TimeSpan.Zero, true, true);
							m_Timer.Start();

							break;
						}
				}
			}

			public override bool OnMoveOver(Mobile m)
			{
				if (Visible && m_Caster != null && SpellHelper.ValidIndirectTarget(m_Caster, m) && m_Caster.CanBeHarmful(m, false))
				{
					m_Caster.DoHarmful(m);

					var damage = Utility.Random(20, 30);

					damage = (int)SpellHelper.AdjustValue(m_Caster, damage, Aptitude.Aeromancie);

					AOS.Damage(m, m_Caster, damage, 0, 0, 100, 0, 0);
					m.PlaySound(0x208);
					Delete();
				}

				return true;
			}

			private class InternalTimer : Timer
			{
				private InternalItem m_Item;
				private bool m_InLOS, m_CanFit;

				private static Queue m_Queue = new Queue();

				public InternalTimer(InternalItem item, TimeSpan delay, bool inLOS, bool canFit) : base(delay, TimeSpan.FromSeconds(1.0))
				{
					m_Item = item;
					m_InLOS = inLOS;
					m_CanFit = canFit;

					Priority = TimerPriority.TwoFiftyMS;
				}

				protected override void OnTick()
				{
					if (m_Item.Deleted)
						return;

					if (!m_Item.Visible)
					{
						if (m_InLOS && m_CanFit)
							m_Item.Visible = true;
						else
							m_Item.Delete();

						if (!m_Item.Deleted)
						{
							m_Item.ProcessDelta();
							Effects.SendLocationParticles(EffectItem.Create(m_Item.Location, m_Item.Map, EffectItem.DefaultDuration), 0x376A, 9, 10, 5029);
						}
					}
					else if (DateTime.Now > m_Item.m_End)
					{
						m_Item.Delete();
						Stop();
					}
					else
					{
						var map = m_Item.Map;
						var caster = m_Item.m_Caster;

						if (map != null && caster != null)
						{
							foreach (var m in m_Item.GetMobilesInRange(0))
								if (m.Z + 16 > m_Item.Z && m_Item.Z + 12 > m.Z && SpellHelper.ValidIndirectTarget(caster, m) && caster.CanBeHarmful(m, false))
									m_Queue.Enqueue(m);

							var todelete = false;

							while (m_Queue.Count > 0)
							{
								var m = (Mobile)m_Queue.Dequeue();

								caster.DoHarmful(m);

								var damage = Utility.Random(20, 30);

								damage = (int)SpellHelper.AdjustValue(caster, damage, Aptitude.Aeromancie);

								AOS.Damage(m, caster, damage, 0, 0, 100, 0, 0);
								m.PlaySound(0x208);

								todelete = true;
							}

							if (todelete)
							{
								m_Item.Delete();
								Stop();
							}
						}
					}
				}
			}
		}

		private class InternalTarget : Target
		{
			private TornadoSpell m_Owner;

			public InternalTarget(TornadoSpell owner)
				: base(12, true, TargetFlags.Harmful)
			{
				m_Owner = owner;
			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is IPoint3D)
					m_Owner.Target((IPoint3D)o);
			}

			protected override void OnTargetFinish(Mobile from)
			{
				m_Owner.FinishSequence();
			}
		}
	}
}