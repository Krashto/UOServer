using Server.Items;

namespace Server.Custom.Races
{
	class Nomade : BaseRace
	{
		public override string Background => "En temps jadis précédant le cataclysme, les anciens bannis des fleurons de l’humanité refluèrent vers le grand désert. Pour beaucoup, il ne s’agissait que de truands vivant sans lendemain sur une terre aride abandonnée par les anciennes puissances. Les circonstances en firent des nomades, une nouvelle nation humaine à part entière, assurant sa survie par ses nouvelles coutumes loin des attaches des grandes cités. Le grand cataclysme exposa les nomades aux dangers auxquels leurs contreparties bien nichées dans de hautes forteresses ou opulentes cités furent épargnées. Brigands et gitans d’alors furent décimés par les plaies déclenchées par la catastrophe, ce qui permit à une figure iconique de s'illustrer. Rassemblant les populaces au gré de marchés, de persuasion, et même en graissant des pattes, Maleek prit la tête d’un grand convoi émergeant du désert à destination de terres épargnées par le désastre. Le nom de ce grand convoi, Sable-Rouge, et le nom du caravanier à sa tête ont marqué les esprits et suscitent l’admiration encore à ce jour. ";

		public override int[] SkinHues => new int[] { 1031, 1032, 1034, 1035, 1036 };

		public static void Configure()
		{
			/* Here we configure all races. Some notes:
			* 
			* 1) The first 32 races are reserved for core use.
			* 2) Race 0x7F is reserved for core use.
			* 3) Race 0xFF is reserved for core use.
			* 4) Changing or removing any predefined races may cause server instability.
			*/
			RegisterRace(new Nomade(11, 11));
		}

		public Nomade(int raceID, int raceIndex) : base(raceID, raceIndex, "Nomade", "Nomades", 400, 401, 402, 403)
		{
		}

		public override bool ValidateEquipment(Item item)
		{
			return true;
		}

		public override BaseRaceGumps GetSkin(int hue)
		{
			return new CorpsNomade(hue);
		}

		public override int GetGumpId(bool female, int hue)
		{
			var gumpid = 52090;
			return female ? gumpid + 10000 : gumpid;
		}
	}
}

namespace Server.Items
{
	public class CorpsNomade : BaseRaceGumps
	{
		[Constructable]
		public CorpsNomade() : this(0)
		{
		}

		[Constructable]
		public CorpsNomade(int hue) : base(0xA225, hue)
		{
			Name = "Nomade";
		}

		public CorpsNomade(Serial serial)
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

