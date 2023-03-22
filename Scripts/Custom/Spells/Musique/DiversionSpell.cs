using Server.Targeting;
using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Mobiles;
using System;
using Server.Engines.CannedEvil;
using Server.Items;
using Server.Network;

namespace Server.Custom.Spells.NewSpells.Geomancie
{
	public class DiversionSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Diversion", "[Diversion]",
				SpellCircle.Second,
				203,
				9041,
				Reagent.BlackPearl,
				Reagent.Garlic,
				Reagent.SulfurousAsh
			);

		public override int RequiredAptitudeValue { get { return 1; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Musique }; } }
		public override SkillName CastSkill { get { return SkillName.Musicianship; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public DiversionSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new DiversionTarget();
		}

		public void Target(Mobile m)
		{
			if (!Caster.CanSee(m))
				Caster.SendLocalizedMessage(500237); // Target can not be seen.
			else if (CheckHSequence(m))
			{
				var source = Caster;

				SpellHelper.Turn(source, m);

				m.SendLocalizedMessage(500616); // You hear lovely music, and forget to continue battling!
				m.Combatant = null;
				m.Warmode = false;

				if (m is BaseCreature && !((BaseCreature)m).BardPacified)
					((BaseCreature)m).Pacify(Caster, DateTime.UtcNow + TimeSpan.FromSeconds(30.0));
			}

			FinishSequence();
		}

		private class DiversionTarget : Target
		{
			public DiversionTarget()
				: base(12, false, TargetFlags.None)
			{
			}

			protected override void OnTarget(Mobile from, object targ)
			{
				if (targ is BaseCreature)
				{
					BaseCreature bc = (BaseCreature)targ;

					if (IsHerdable(bc))
					{
						if (bc.Controlled)
						{
							bc.PrivateOverheadMessage(MessageType.Regular, 0x3B2, 502467, from.NetState); // That animal looks tame already.
						}
						else
						{
							from.SendLocalizedMessage(502475); // Click where you wish the animal to go.
							from.Target = new InternalTarget(bc);
						}
					}
					else
					{
						from.SendLocalizedMessage(502468); // That is not a herdable animal.
					}
				}
				else
				{
					from.SendLocalizedMessage(502472); // You don't seem to be able to persuade that to move.
				}
			}

			private bool IsHerdable(BaseCreature bc)
			{
				return !(bc.IsParagon || bc.Controlled || bc.Summoned);
			}

			private class InternalTarget : Target
			{
				private readonly BaseCreature m_Creature;

				public InternalTarget(BaseCreature c)
					: base(10, true, TargetFlags.None)
				{
					m_Creature = c;
				}

				protected override void OnTarget(Mobile from, object targ)
				{
					if (targ is IPoint2D)
					{
						double min;
						double max;

						if (m_Creature.Tamable)
						{
							min = m_Creature.CurrentTameSkill - 30;
							max = m_Creature.CurrentTameSkill + 30 + Utility.Random(10);
						}
						else
						{
							min = 50;
							max = 75 + Utility.Random(10);
						}

						if (max <= from.Skills[SkillName.Musicianship].Value)
							m_Creature.PrivateOverheadMessage(MessageType.Regular, 0x3B2, 502471, from.NetState); // That wasn't even challenging.

						if (from.CheckTargetSkill(SkillName.Musicianship, m_Creature, min, max))
						{
							IPoint2D p = (IPoint2D)targ;

							if (targ != from)
								p = new Point2D(p.X, p.Y);

							m_Creature.TargetLocation = p;
							from.SendLocalizedMessage(502479); // The animal walks where it was instructed to.
						}
						else
						{
							from.SendLocalizedMessage(502472); // You don't seem to be able to persuade that to move.
						}
					}
				}
			}
		}
	}
}