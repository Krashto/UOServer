using System;
using System.Text;
using Server;
using Server.Mobiles;
using Server.Network;

namespace Server.Spells
{
	public abstract class ReligiousSpell : Spell
	{
        public override SkillName CastSkill { get { return SkillName.SpiritSpeak; } }
        public override SkillName DamageSkill { get { return SkillName.EvalInt; } }

        public ReligiousSpell(Mobile caster, Item scroll, SpellInfo info) : base(caster, scroll, info)
		{
        }
	}
}