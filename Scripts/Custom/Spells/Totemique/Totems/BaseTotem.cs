using System;
using System.Collections.Generic;
using Server.Mobiles;

namespace Server.Custom.Spells.NewSpells.Totemique
{
	public abstract class BaseTotem : BaseCreature
	{
		public override bool DeleteOnRelease => true;
		public override bool DeleteCorpseOnDeath => true;
		public bool MarcheASuivreEnable { get; set; }
		public bool SuperCharged { get; set; }
		public DateTime NextThinkingTime { get; set; }

		public BaseTotem(AIType ai, FightMode mode, int iRangePerception, int iRangeFight)
			: base(ai, mode, iRangePerception, iRangeFight, 0.2, 0.4)
		{
			CantWalk = true;
			ControlOrder = OrderType.Stay;
		}

		public BaseTotem(Serial serial)
			: base(serial)
		{
		}

		public override void OnThink()
		{
			NextThinkingTime = DateTime.Now + TimeSpan.FromSeconds(5);
		}

		public static bool CanSummonTotemType(Mobile caster, Type totem)
		{
			if (caster == null || !(caster is CustomPlayerMobile pm))
				return false;

			var allowed = true;
			foreach (var follower in pm.AllFollowers)
			{
				if (follower.GetType() == totem)
					return false;
			}

			return allowed;
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(1); // version

			writer.Write(MarcheASuivreEnable);

			writer.Write(SuperCharged);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();

			switch(version)
			{
				case 1:
					{
						MarcheASuivreEnable = reader.ReadBool();
						goto case 0;
					}
				case 0:
					{
						SuperCharged = reader.ReadBool();
						break;
					}
			}
		}
	}
}
