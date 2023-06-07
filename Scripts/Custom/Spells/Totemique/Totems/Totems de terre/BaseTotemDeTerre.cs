﻿using Server.Mobiles;

namespace Server.Custom.Spells.NewSpells.Totemique
{
	public abstract class BaseTotemDeTerre : BaseTotem
	{
		public BaseTotemDeTerre(AIType ai, FightMode mode, int iRangePerception, int iRangeFight)
			: base(ai, mode, iRangePerception, iRangeFight)
		{
		}

		public BaseTotemDeTerre(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
		}
	}
}
