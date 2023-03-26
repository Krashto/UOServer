using System;
using Server.Mobiles;

namespace Server.Custom.Spells.NewSpells.Totemique
{
	public abstract class BaseTotem : BaseCreature
	{
		public bool SuperCharged { get; set; }
		public DateTime NextThinkingTime { get; set; }

		public BaseTotem(AIType ai, FightMode mode, int iRangePerception, int iRangeFight)
			: base(ai, mode, iRangePerception, iRangeFight, 0, 0)
		{
		}

		public BaseTotem(Serial serial)
			: base(serial)
		{
		}

		public override void OnThink()
		{
			NextThinkingTime = DateTime.Now + TimeSpan.FromSeconds(5);
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0); // version

			writer.Write(SuperCharged);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();

			switch(version)
			{
				case 0:
					{
						SuperCharged = reader.ReadBool();
						break;
					}
			}
		}
	}
}
