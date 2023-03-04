using System;
using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Items;
using Server.Misc;
using System.Collections;

namespace Server.Spells
{
	public class FulgurationSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Fulguration", "Por Ort Grav Vas Flam",
				SpellCircle.Eighth,
				239,
				9021,
				Reagent.MandrakeRoot,
				Reagent.SulfurousAsh,
                Reagent.Ginseng
            );

        public override int RequiredAptitudeValue { get { return 11; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.Destruction }; } }

        public FulgurationSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
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
                SpellHelper.Turn(Caster, m);

                SpellHelper.CheckReflect((int)this.Circle, Caster, ref m);

                double damage = GetNewAosDamage(m, 35, 1, 5, true);

                damage = (int)SpellHelper.AdjustValue(Caster, damage, NAptitude.Destruction);

                m.BoltEffect(0);

                Effects.PlaySound(m.Location, Caster.Map, 0x20C);

                int itemID = 0x398C;

                TimeSpan duration = GetDurationForSpell(0.5);

                new InternalItem(this, itemID, m.Location, Caster, Caster.Map, duration, 0);

                SpellHelper.Damage(this, m, damage, 0, 0, 0, 0, 100);
            }

			FinishSequence();
		}

		private class InternalTarget : Target
		{
            private FulgurationSpell m_Owner;

            public InternalTarget(FulgurationSpell owner)
                : base(12, false, TargetFlags.Harmful)
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

		[DispellableField]
		public class InternalItem : Item
		{
			private Spell m_Spell;
			private Timer m_Timer;
			private DateTime m_End;
			private Mobile m_Caster;

			public override bool BlocksFit { get { return true; } }

			public InternalItem(Spell spell, int itemID, Point3D loc, Mobile caster, Map map, TimeSpan duration, int val)
				: base(itemID)
			{
				bool canFit = SpellHelper.AdjustField(ref loc, map, 12, false);

				Visible = false;
				Movable = false;
				Light = LightType.Circle300;

				MoveToWorld(loc, map);

				if (caster.InLOS(this))
					Visible = true;
				else
					Delete();

				if (!this.Deleted && VerifyOtherFields(caster))
					Delete();

				if (Deleted)
					return;

				m_Spell = spell;
				m_Caster = caster;

				m_End = DateTime.Now + duration;

				m_Timer = new InternalTimer(this, TimeSpan.FromSeconds(Math.Abs(val) * 0.2), caster.InLOS(this), canFit);
				m_Timer.Start();
			}

			public bool VerifyOtherFields(Mobile caster)
			{
				Map map = this.Map;
				bool test = false;

				IPooledEnumerable eable = map.GetItemsInRange(this.Location, 0);

				if (this.Deleted)
					return false;

				foreach (Item item in eable)
				{
					if (item != null && this == item)
						continue;

					if (item != null && (item is FulgurationSpell.InternalItem || item is GeyserSpell.InternalItem))
					{
						caster.SendMessage("Vous ne pouvez pas lancer un mur de feu au même endroit qu'un autre mur.");
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

				writer.Write((int)1); // version

				writer.Write(m_Caster);
				writer.WriteDeltaTime(m_End);
			}

			public override void Deserialize(GenericReader reader)
			{
				base.Deserialize(reader);

				int version = reader.ReadInt();

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

					int damage = Utility.Random(30, 40);

					damage = (int)SpellHelper.AdjustValue(m_Caster, damage, NAptitude.Destruction);

					AOS.Damage(m, m_Caster, damage, 0, 100, 0, 0, 0);
					m.PlaySound(0x208);
					this.Delete();
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

					if (m_Item == null)
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
						Map map = m_Item.Map;
						Mobile caster = m_Item.m_Caster;

						if (map != null && caster != null)
						{
							foreach (Mobile m in m_Item.GetMobilesInRange(0))
							{
								if ((m.Z + 16) > m_Item.Z && (m_Item.Z + 12) > m.Z && SpellHelper.ValidIndirectTarget(caster, m) && caster.CanBeHarmful(m, false))
									m_Queue.Enqueue(m);
							}

							bool todelete = false;

							while (m_Queue.Count > 0)
							{
								Mobile m = (Mobile)m_Queue.Dequeue();

								caster.DoHarmful(m);

								double damage = Utility.RandomMinMax(30, 40);

								damage = (int)SpellHelper.AdjustValue(caster, damage, NAptitude.Destruction);

								AOS.Damage(m, caster, (int)damage, 0, 100, 0, 0, 0);
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
	}
}