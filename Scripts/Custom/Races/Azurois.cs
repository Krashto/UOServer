﻿using Server.Items;

namespace Server.Custom.Races
{
	class Azurois : BaseRace
	{
		public override string Background => "Les Azurois";

		public override int[] SkinHues => new int[] { 1823, 1820, 1824, 1821, 1819, 1825, 1822, 1826 };

		public static void Configure()
		{
			/* Here we configure all races. Some notes:
			* 
			* 1) The first 32 races are reserved for core use.
			* 2) Race 0x7F is reserved for core use.
			* 3) Race 0xFF is reserved for core use.
			* 4) Changing or removing any predefined races may cause server instability.
			*/
			RegisterRace(new Azurois(9, 9));
		}

		public Azurois(int raceID, int raceIndex) : base(raceID, raceIndex, "Azurois", "Azurois", 400, 401, 402, 403)
		{
		}

		public override bool ValidateEquipment(Item item)
		{
			return true;
		}

		public override BaseRaceGumps GetSkin(int hue)
		{
			return new CorpsAzurois(0xA21F, hue);
		}

		public override int GetGumpId(bool female, int hue)
		{
			var gumpid = 52084;
			return female ? gumpid + 10000 : gumpid;
		}
	}
}

namespace Server.Items
{
	public class CorpsAzurois : BaseRaceGumps
	{
		[Constructable]
		public CorpsAzurois() : this(0)
		{
		}

		[Constructable]
		public CorpsAzurois(int id, int hue) : base(id, hue)
		{
			Name = "Azurois";
		}

		public CorpsAzurois(Serial serial)
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

