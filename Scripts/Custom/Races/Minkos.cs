﻿using Server.Items;

namespace Server.Custom.Races
{
	class Minkos : BaseRace
	{
		public override string Background => "Les Minkos";

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
			RegisterRace(new Minkos(6, 6));
		}

		public Minkos(int raceID, int raceIndex) : base(raceID, raceIndex, "Minko", "Minkos", 400, 401, 402, 403)
		{
		}


		public override bool ValidateEquipment(Item item)
		{
			return true;
		}

		public override BaseRaceGumps GetSkin(int hue)
		{
			var itemId = 41509;

			switch (hue)
			{
				case 1823:
					itemId = 41509;
					break;
				case 1820:
					itemId = 41509;
					break;
				case 1824:
					itemId = 41505;
					break;
				case 1821:
					itemId = 41505;
					break;
				case 1819:
					itemId = 41503;
					break;
				case 1825:
					itemId = 41503;
					break;
				case 1822:
					itemId = 41504; //
					break;
				case 1826:
					itemId = 41504;
					break;
				default:
					break;
			}
			return new CorpsDwemer(itemId, hue);
		}

		public override int GetGumpId(bool female, int hue)
		{
			var gumpid = 52090;

			switch (hue)
			{
				case 1823:
					gumpid = 52090;
					break;
				case 1820:
					gumpid = 52090;
					break;
				case 1824:
					gumpid = 52086;
					break;
				case 1821:
					gumpid = 52086;
					break;
				case 1819:
					gumpid = 52084;
					break;
				case 1825:
					gumpid = 52084;
					break;
				case 1822:
					gumpid = 52085; //
					break;
				case 1826:
					gumpid = 52085;
					break;
				default:
					break;
			}

			if (female)
				gumpid += 10000;

			return gumpid;
		}
	}
}

namespace Server.Items
{
	public class CorpsDwemer : BaseRaceGumps
	{
		[Constructable]
		public CorpsDwemer() : this(0)
		{
		}

		[Constructable]
		public CorpsDwemer(int id, int hue) : base(id, hue)
		{
			Name = "Dwemer";
		}

		public CorpsDwemer(Serial serial)
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
