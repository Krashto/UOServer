using Server.Items;

namespace Server.Custom.Races
{
	class Drakos : BaseRace
	{
		public override string Background => "Toute référence à l’histoire précédant le cataclysme est considérée taboue par les Drakos. Pour eux, le cataclysme constitue la manifestation de la volonté des esprits élémentaires à sortir le peuple reptilien de son isolement, comme un nouveau-né de sa coquille. Peu est dit sur les Drakos, sinon qu’ils sont des hommes-lézards originaires d'un grand marécage dont le terrain peu hospitalier les auraient protégés des ambitions humaines et des créatures hostiles avant le grand cataclysme.";

		public override int[] SkinHues => new int[] { 2796, 2283, 2354, 2281, 2299 };

		public static void Configure()
		{
			/* Here we configure all races. Some notes:
			* 
			* 1) The first 32 races are reserved for core use.
			* 2) Race 0x7F is reserved for core use.
			* 3) Race 0xFF is reserved for core use.
			* 4) Changing or removing any predefined races may cause server instability.
			*/
			RegisterRace(new Drakos(1, 1));
		}

		public Drakos(int raceID, int raceIndex) : base(raceID, raceIndex, "Drako", "Drakos", 400, 401, 402, 403)
		{
		}

		public override bool ValidateEquipment(Item item)
		{
			return true;
		}

		public override BaseRaceGumps GetSkin(int hue)
		{
			return new CorpsDrakos(hue);
		}

		public override int GetGumpId(bool female, int hue)
		{
			var gumpid = 52098;
			return female ? gumpid + 10000 : gumpid;
		}
	}
}

namespace Server.Items
{
	public class CorpsDrakos : BaseRaceGumps
	{
		[Constructable]
		public CorpsDrakos() : this(0)
		{
		}

		[Constructable]
		public CorpsDrakos(int hue) : base(0xA227, hue)
		{
			Name = "Drakos";
		}

		public CorpsDrakos(Serial serial)
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

