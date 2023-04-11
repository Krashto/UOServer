using Server.Items;

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
			return new CorpsMinkos(0xA220, hue);
		}

		public override int GetGumpId(bool female, int hue)
		{
			var gumpid = 52085;
			return female ? gumpid + 10000 : gumpid;
		}
	}
}

namespace Server.Items
{
	public class CorpsMinkos : BaseRaceGumps
	{
		[Constructable]
		public CorpsMinkos() : this(0)
		{
		}

		[Constructable]
		public CorpsMinkos(int id, int hue) : base(id, hue)
		{
			Name = "Minkos";
		}

		public CorpsMinkos(Serial serial)
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

