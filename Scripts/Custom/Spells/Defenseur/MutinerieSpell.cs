using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Mobiles;

namespace Server.Custom.Spells.NewSpells.Defenseur
{
	public class MutinerieSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Mutinerie", "[Mutinerie]",
				SpellCircle.Second,
				203,
				9041,
				Reagent.BlackPearl,
				Reagent.Garlic,
				Reagent.SulfurousAsh
			);

		public override int RequiredAptitudeValue { get { return 4; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Defenseur }; } }
		public override SkillName CastSkill { get { return SkillName.Parry; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public MutinerieSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				var targets = Caster.GetMobilesInRange(5);

				foreach (var targ in targets)
				{
					if (CustomPlayerMobile.IsInEquipe(Caster, targ))
						continue;

					if (targ is BaseCreature creature && creature.Controlled && CustomPlayerMobile.IsInEquipe(Caster, creature.ControlMaster))
						continue;

					targ.Combatant = Caster;
					targ.Emote($"*Est provoqué{(targ.Female ? "e" : "")} par {Caster.Name}*");
					Caster.Combatant = targ;
					Caster.Emote($"*Provoque {targ.Name}*");
				}
			}

			FinishSequence();
		}
	}
}