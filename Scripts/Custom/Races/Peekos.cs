using Server.Items;

namespace Server.Custom.Races
{
	class Peekos : BaseRace
	{
		public override string Background => " Les Peekos sont une race d'hommes-lion originaire de la savane ayant vécu en clans nomades avant le cataclysme. Ils transmirent leur mémoire collective et coutumes par tradition orale, limitant ainsi toute trace écrite de leurs origines à des spéculations.  Certains voient en eux des monstres dotés d’une faculté de parole alors que, pour d’autres, ce peuple tirerait ses origines dans le fruit de curieuses expérimentations par des mages transgressant les limites de la nature.\r\nAvant le cataclysme, les Peekos vivaient simplement en petits villages claniques dans la savane, bâtis en roseaux tissés et pouvant être déplacés au gré des saisons. Cependant, sur les modestes villages exposés des grandes plaines, le cataclysme eut un effet dévastateur : les clans Peekos furent décimés, et seule une poignée de ces grands fauves fut épargnée. Les rares survivants convergèrent vers Colognan, pistant les colonnes de rescapés, dans l’espoir d’éviter l’extinction. ";

		public override int[] SkinHues => new int[] { 2151, 2244, 2350, 2368 };

		public static void Configure()
		{
			/* Here we configure all races. Some notes:
			* 
			* 1) The first 32 races are reserved for core use.
			* 2) Race 0x7F is reserved for core use.
			* 3) Race 0xFF is reserved for core use.
			* 4) Changing or removing any predefined races may cause server instability.
			*/
			RegisterRace(new Peekos(8, 8));
		}

		public Peekos(int raceID, int raceIndex) : base(raceID, raceIndex, "Peeko", "Peekos", 400, 401, 402, 403)
		{
		}

		public override bool ValidateEquipment(Item item)
		{
			return true;
		}

		public override BaseRaceGumps GetSkin(int hue)
		{
			return new CorpsPeekos(hue);
		}

		public override int GetGumpId(bool female, int hue)
		{
			var gumpid = 52097;
			return female ? gumpid + 10000 : gumpid;
		}
	}
}

namespace Server.Items
{
	public class CorpsPeekos : BaseRaceGumps
	{
		[Constructable]
		public CorpsPeekos() : this(0)
		{
		}

		[Constructable]
		public CorpsPeekos(int hue) : base(0xA226, hue)
		{
			Name = "Peekos";
		}

		public CorpsPeekos(Serial serial)
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

