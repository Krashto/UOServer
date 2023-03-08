using Server.Custom.Aptitudes;
using Server.Spells;
using Server.Items;

namespace Server.Custom.Spells.NewSpells.Chasseur
{
	public class RicochetSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Ricochet", "Por Ort Grav",
				SpellCircle.Fourth,
				239,
				9021,
				Reagent.MandrakeRoot,
				Reagent.SulfurousAsh,
				Reagent.BlackPearl
			);

		public override int RequiredAptitudeValue { get { return 3; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Chasseur }; } }
		public override SkillName CastSkill { get { return SkillName.Tracking; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public RicochetSpell(Mobile caster, Item scroll) : base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			WeaponAbility.SetCurrentAbility(Caster, WeaponAbility.WhirlwindAttack);
			Caster.SendMessage("Votre prochain coup sera porté à tous les ennemis proche de vous.");
			FinishSequence();
		}
	}
}