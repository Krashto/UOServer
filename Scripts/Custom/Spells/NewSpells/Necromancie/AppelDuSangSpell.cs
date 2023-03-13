using Server.Custom.Aptitudes;
using Server.Spells;
using VitaNex.FX;

namespace Server.Custom.Spells.NewSpells.Necromancie
{
	public class AppelDuSangSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Appel du sang", "Kal Vas Xen In Corp",
				SpellCircle.Eighth,
				269,
				9070,
				false,
				Reagent.GraveDust,
				Reagent.DaemonBlood,
				Reagent.PigIron
			);

		public override int RequiredAptitudeValue { get { return 9; } }
		public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Necromancie }; } }
		public override SkillName CastSkill { get { return SkillName.Necromancy; } }
		public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

		public AppelDuSangSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{
		}

		public override bool CheckCast()
		{
			if (!base.CheckCast())
				return false;

			if (Caster.Followers + 4 > Caster.FollowersMax)
			{
				Caster.SendLocalizedMessage(1049645); // You have too many followers to summon that creature.
				return false;
			}

			return true;
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				var duration = GetDurationForSpell(30, 1.2);

				SpellHelper.Summon(new SummonedBloodElemental(), Caster, 0x217, duration, false, false);

				ExplodeFX.Blood.CreateInstance(Caster, Caster.Map, 5);
			}

			FinishSequence();
		}
	}
}