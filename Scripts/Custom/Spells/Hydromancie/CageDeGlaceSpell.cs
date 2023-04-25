using System;
using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using System.Collections;
using Server.Custom.Spells.NewSpells.Polymorphie;

namespace Server.Custom.Spells.NewSpells.Hydromancie
{
	public class CageDeGlaceSpell : Spell
	{
		private static Hashtable m_Timers = new Hashtable();

		private static SpellInfo m_Info = new SpellInfo(
				"Cage de glace", "[Cage de glace]",
				SpellCircle.First,
				212,
				9041,
				Reagent.EssenceHydromancie
			);

		public override int RequiredAptitudeValue { get { return 4; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Hydromancie }; } }
		public override SkillName CastSkill { get { return SkillName.Meditation; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public CageDeGlaceSpell(Mobile caster, Item scroll)
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

				if (!IndomptableSpell.IsActive(m))
				{
					SpellHelper.CheckReflect((int)Circle, Caster, ref m);

					var duration = GetDurationForSpell(4);

					m.Paralyze(duration);

					Timer t = new InternalTimer(this, m, DateTime.Now + duration);
					m_Timers[m] = t;
					t.Start();

					var loc = new Point3D(m.X + 1, m.Y, m.Z);
					new InternalItem(0x9CB8, loc, Caster, m.Map, duration);
					loc = new Point3D(m.X + 1, m.Y + 1, m.Z);
					new InternalItem(0x9CB5, loc, Caster, m.Map, duration);
					loc = new Point3D(m.X, m.Y + 1, m.Z);
					new InternalItem(0x9CB7, loc, Caster, m.Map, duration);

					CustomUtility.ApplySimpleSpellEffect(m, "Cage de glace", duration, AptitudeColor.Hydromancie);
				}
				else
					Caster.SendMessage("La cible est immunisée à la paralysie.");
			}

			FinishSequence();
		}

		public static bool IsActive(Mobile m)
		{
			return m_Timers.ContainsKey(m);
		}

		public void Deactivate(Mobile m)
		{
			var t = m_Timers[m] as Timer;

			if (t != null)
			{
				t.Stop();
				m_Timers.Remove(m);
				CustomUtility.ApplySimpleSpellEffect(m, "Cage de glace", AptitudeColor.Hydromancie, SpellSequenceType.End);
			}
		}

		private class InternalItem : Item
		{
			private Timer m_Timer;
			private Mobile m_Caster;
			private TimeSpan m_Dura;

			public override bool BlocksFit { get { return true; } }

			public InternalItem(int itemID, Point3D loc, Mobile caster, Map map, TimeSpan duration) : base(itemID)
			{
				var canFit = SpellHelper.AdjustField(ref loc, map, 12, false);

				Visible = true;
				Movable = false;

				MoveToWorld(loc, map);

				m_Caster = caster;
				m_Dura = duration;
				m_Timer = new InternalTimer(this, duration);
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

				writer.Write(1); // version

				writer.Write(m_Caster);
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
							m_Timer = new InternalTimer(this, m_Dura);
							m_Timer.Start();

							break;
						}
				}
			}

			private class InternalTimer : Timer
			{
				private InternalItem m_Item;

				public InternalTimer(InternalItem item, TimeSpan duration) : base(duration)
				{
					m_Item = item;
					Priority = TimerPriority.FiftyMS;
				}

				protected override void OnTick()
				{
					if (m_Item.Deleted)
						return;

					m_Item.Delete();
				}
			}
		}

		public class InternalTarget : Target
		{
			private CageDeGlaceSpell m_Owner;

			public InternalTarget(CageDeGlaceSpell owner)
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

		public class InternalTimer : Timer
		{
			private CageDeGlaceSpell m_Owner;
			private Mobile m_Mobile;
			private DateTime m_Endtime;

			public InternalTimer(CageDeGlaceSpell owner, Mobile target, DateTime end)
				: base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
			{
				m_Owner = owner;
				m_Mobile = target;
				m_Endtime = end;

				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				if (DateTime.Now >= m_Endtime && m_Timers.Contains(m_Mobile) || m_Mobile == null || m_Mobile.Deleted || !m_Mobile.Alive)
				{
					m_Timers.Remove(m_Mobile);
					CustomUtility.ApplySimpleSpellEffect(m_Mobile, "Cage de glace", AptitudeColor.Hydromancie, SpellSequenceType.End);
					m_Owner.Deactivate(m_Mobile);
				}
			}
		}
	}
}