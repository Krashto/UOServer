using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Items;
using Server.Mobiles;
using Server.Misc;
using System;

namespace Server.Custom.Spells.NewSpells.Roublardise
{
	public class AppelSpirituelSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Appel spirituel", "[Appel spirituel]",
				SpellCircle.Fifth,
				203,
				9031,
				Reagent.EssenceTotemique
			);

		public override int RequiredAptitudeValue { get { return 9; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Totemique }; } }
		public override SkillName CastSkill { get { return SkillName.AnimalTaming; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public AppelSpirituelSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
		{
		}

		public override bool CheckCast()
		{
			if (SpellHelper.CheckCombat(Caster))
			{
				Caster.SendLocalizedMessage(1005564, "", 0x22); // Wouldst thou flee during the heat of battle??
				return false;
			}

			return base.CheckCast();
		}

		public override void OnCast()
		{
			if (SpellHelper.CheckCombat(Caster))
			{
				Caster.SendLocalizedMessage(1005564, "", 0x22); // Wouldst thou flee during the heat of battle??
			}
			else if (CheckSequence())
			{
				Caster.SendLocalizedMessage(501024); // You open a magical gate to another location

				Effects.PlaySound(Caster.Location, Caster.Map, 0x20E);

				double duration = GetDurationForSpell(15, 1).TotalSeconds;

				InternalItem gate = new InternalItem(new Point3D(1120, 1407, 0), Map.Felucca, duration);
				gate.Hue = (int)AptitudeColor.Totemique;
				gate.MoveToWorld(Caster.Location, Caster.Map);
			}

			FinishSequence();
		}

		[DispellableField]
		private class InternalItem : Moongate
		{
			private double m_Duration;

			public InternalItem(Point3D target, Map map, double duration) : base(target, map)
			{
				Map = map;
				m_Duration = duration;

				Dispellable = true;

				InternalTimer t = new InternalTimer(this, m_Duration);
				t.Start();
			}

			public InternalItem(Serial serial) : base(serial)
			{
			}

			public override void Serialize(GenericWriter writer)
			{
				base.Serialize(writer);
			}

			public override void Deserialize(GenericReader reader)
			{
				base.Deserialize(reader);

				Delete();
			}

			private class InternalTimer : Timer
			{
				private Item m_Item;

				public InternalTimer(Item item, double duration) : base(TimeSpan.FromSeconds(duration))
				{
					Priority = TimerPriority.OneSecond;
					m_Item = item;
				}

				protected override void OnTick()
				{
					m_Item.Delete();
				}
			}
		}
	}
}