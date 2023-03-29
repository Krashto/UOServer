using Server.Items;
using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Mobiles;

namespace Server.Custom.Spells.NewSpells.Chasseur
{
	public class RugissementSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Rugissement", "[Rugissement]",
				SpellCircle.Second,
				203,
				9031,
				Reagent.Bloodmoss,
				Reagent.MandrakeRoot
			);

		public override int RequiredAptitudeValue { get { return 5; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Chasseur }; } }
		public override SkillName CastSkill { get { return SkillName.Tracking; } }
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

		public RugissementSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				if (CompagnonAnimalSpell.Table.Contains(Caster))
				{
					var bc = CompagnonAnimalSpell.Table[Caster] as BaseCreature;

					if (bc != null)
					{
						var targets = bc.GetMobilesInRange(5);

						foreach (var targ in targets)
						{
							if (CustomPlayerMobile.IsInEquipe(Caster, targ))
								continue;

							if (targ is BaseCreature creature && creature.Controlled && CustomPlayerMobile.IsInEquipe(Caster, creature.ControlMaster))
								continue;

							targ.Combatant = bc;
							targ.Emote($"*Est provoqué{(targ.Female ? "e" : "")} par {Caster.Name}*");
							bc.Combatant = targ;
							bc.Emote($"*Provoque {targ.Name}*");
						}
					}
				}
				else
					Caster.SendMessage("Vous n'avez pas de compagnon avec vous.");
			}

			FinishSequence();
		}
	}
}