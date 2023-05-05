using Server.Items;

namespace Server.Custom.Races
{
	class Nain : BaseRace
	{
		public override string Background => "Les archives tracent le récit décousu d’un peuple presque surnaturel, maitre de la pierre et de la montagne. La légende raconte même qu’à la suite du grand cataclysme, un éclaireur nain dénommé Kilivar aurait bravé les mers de plomb et les vagues agitées pour poser pied le premier sur le continent.  Le récit de Kilivar évoque des cités ancestrales naines de cet autre continent creusées à même le roc. Peu après l’arrivée de Kilivar, plusieurs autres nains affluaient déjà sur les berges du continent en quête d’un nouveau havre. ";

		public override int[] SkinHues => new int[] { 2310, 2311, 2316, 1864, 1868 };

		public static void Configure()
		{
			/* Here we configure all races. Some notes:
			* 
			* 1) The first 32 races are reserved for core use.
			* 2) Race 0x7F is reserved for core use.
			* 3) Race 0xFF is reserved for core use.
			* 4) Changing or removing any predefined races may cause server instability.
			*/
			RegisterRace(new Nain(6, 6));
		}

		public Nain(int raceID, int raceIndex) : base(raceID, raceIndex, "Nain", "Nains", 400, 401, 402, 403)
		{
		}

		public override bool ValidateEquipment(Item item)
		{
			return true;
		}

		public override BaseRaceGumps GetSkin(int hue)
		{
			return new CorpsNain(hue);
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
	public class CorpsNain : BaseRaceGumps
	{
		[Constructable]
		public CorpsNain() : this(0)
		{
		}

		[Constructable]
		public CorpsNain(int hue) : base(0xA220, hue)
		{
			Name = "Nain";
		}

		public CorpsNain(Serial serial)
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

