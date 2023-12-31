using System;
using System.Collections;
using Server.Targeting;
using Server.Misc;
using Server.Items;
using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Mobiles;
using Server.Custom.Spells.NewSpells.Guerison;

namespace Server.Custom.Spells.NewSpells.Geomancie
{
	public class MurDePlanteSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Mur De Plante", "[Mur De Plante]",
				SpellCircle.Sixth,
				230,
				9052,
				Reagent.EssenceGeomancie
			);

		public override int RequiredAptitudeValue { get { return 6; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Geomancie }; } }
		public override SkillName CastSkill { get { return SkillName.MagicResist; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public MurDePlanteSpell(Mobile caster, Item scroll)
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
			else if (CheckSequence())
			{
				SpellHelper.Turn(Caster, p);

				SpellHelper.GetSurfaceTop(ref p);

				var dx = Caster.Location.X - p.X;
				var dy = Caster.Location.Y - p.Y;
				var rx = (dx - dy) * 44;
				var ry = (dx + dy) * 44;

				bool eastToWest;

				if (rx >= 0 && ry >= 0)
					eastToWest = false;
				else if (rx >= 0)
					eastToWest = true;
				else if (ry >= 0)
					eastToWest = true;
				else
					eastToWest = false;

				Effects.PlaySound(p, Caster.Map, 0x20B);

				var duration = GetDurationForSpell(10);

				if (InquisitionSpell.IsActive(m_Caster))
					duration += GetDurationForSpell(5);

				for (var i = -3; i <= 3; ++i)
				{
					var loc = new Point3D(eastToWest ? p.X + i : p.X, eastToWest ? p.Y : p.Y + i, p.Z);

					new InternalItem(Utility.Random(0x0DB8, 1), loc, Caster, Caster.Map, this, duration, i);
				}
			}

			FinishSequence();
		}

		[DispellableField]
		private class InternalItem : Item
		{
			private Timer m_Timer;
			private DateTime m_End;
			private Mobile m_Caster;
			private MurDePlanteSpell m_Owner;

			public override bool BlocksFit { get { return true; } }

			public InternalItem(int itemID, Point3D loc, Mobile caster, Map map, MurDePlanteSpell owner, TimeSpan duration, int val) : base(itemID)
			{
				var canFit = SpellHelper.AdjustField(ref loc, map, 12, false);

				Visible = false;
				Movable = false;
				Light = LightType.Circle300;

				MoveToWorld(loc, map);

				m_Caster = caster;
				m_Owner = owner;

				m_End = DateTime.Now + duration;

				m_Timer = new InternalTimer(this, TimeSpan.FromSeconds(Math.Abs(val) * 0.2), caster.InLOS(this), canFit);
				m_Timer.Start();
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

				writer.Write(0); // version

				writer.Write(m_Caster);
				writer.WriteDeltaTime(m_End);
			}

			public override void Deserialize(GenericReader reader)
			{
				base.Deserialize(reader);

				var version = reader.ReadInt();

				switch (version)
				{
					case 0:
						{
							m_Caster = reader.ReadMobile();
							m_End = reader.ReadDeltaTime();

							m_Timer = new InternalTimer(this, TimeSpan.Zero, true, true);
							m_Timer.Start();

							break;
						}
				}
			}

			public void ApplyPoisonTo(Mobile m)
			{
				if (m_Caster == null)
					return;

				Poison p;

				var total = 100.0;
				
				if (m_Owner != null)
					total = m_Caster.Skills[m_Owner.CastSkill].Value + m_Caster.Skills[m_Owner.DamageSkill].Value;

				if (total >= 175)
					p = Poison.Deadly;
				else if (total > 140)
					p = Poison.Greater;
				else if (total > 100)
					p = Poison.Regular;
				else
					p = Poison.Lesser;

				m.ApplyPoison(m_Caster, p);
			}

			public override bool OnMoveOver(Mobile m)
			{
				if (Visible && m_Caster != null && m_Caster != m && SpellHelper.ValidIndirectTarget(m_Caster, m) && m_Caster.CanBeHarmful(m, false) && m_Caster.InLOS(m) && !CustomPlayerMobile.IsInEquipe(m_Caster, m))
				{
					m_Caster.DoHarmful(m);

					ApplyPoisonTo(m);
					m.PlaySound(0x474);
				}

				return true;
			}

			private class InternalTimer : Timer
			{
				private InternalItem m_Item;
				private bool m_InLOS, m_CanFit;

				private static Queue m_Queue = new Queue();

				public InternalTimer(InternalItem item, TimeSpan delay, bool inLOS, bool canFit) : base(delay, TimeSpan.FromSeconds(1.5))
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

					if (!m_Item.Visible)
					{
						if (m_InLOS && m_CanFit)
							m_Item.Visible = true;
						else
							m_Item.Delete();

						if (!m_Item.Deleted)
						{
							m_Item.ProcessDelta();
							Effects.SendLocationParticles(EffectItem.Create(m_Item.Location, m_Item.Map, EffectItem.DefaultDuration), 0x376A, 9, 10, 5040);
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
							var eastToWest = m_Item.ItemID == 0x3915;
							IPooledEnumerable eable = map.GetMobilesInBounds(new Rectangle2D(m_Item.X - 2, m_Item.Y - 2, 4, 4));

							foreach (Mobile m in eable)
								if (m.Z + 16 > m_Item.Z && m_Item.Z + 12 > m.Z && SpellHelper.ValidIndirectTarget(caster, m) && caster.CanBeHarmful(m, false) && caster.InLOS(m) && !CustomPlayerMobile.IsInEquipe(caster, m))
									m_Queue.Enqueue(m);

							eable.Free();

							while (m_Queue.Count > 0)
							{
								var m = (Mobile)m_Queue.Dequeue();

								if (m != m_Item.m_Caster)
								{
									caster.DoHarmful(m);

									m_Item.ApplyPoisonTo(m);
									CustomUtility.ApplySimpleSpellEffect(m, "Mur de plante", AptitudeColor.Geomancie, SpellEffectType.Damage);
								}
							}
						}
					}
				}
			}
		}

		private class InternalTarget : Target
		{
			private MurDePlanteSpell m_Owner;

			public InternalTarget(MurDePlanteSpell owner)
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