using Server.Items;

namespace Server.Custom.Races
{
	class HautElfe : BaseRace
	{
		public override string Background => "Une maigre trace de l’existence des haut-elfes est recensée dans les plus lointaines archives. Malgré le peu d’information sur leurs origines, il est dit que les haut-elfes étaient les enfants de la mana, l’incarnation même des forces magiques bénéfiques du monde. On raconte qu’ils étaient les pionniers de l’apprivoisement des flux magiques par le biais des Mots de Pouvoir, ayant découvert la capacité de les écrire sur les parchemins par le biais de runes. La légende veut que, candides, ils aient partagé ces connaissances précieuses et pures avec les premiers hommes pour ensuite être cruellement trahis. Ces derniers auraient soi-disant dénaturé et corrompu ces arts à leur profit autant politique que commercial. Certains croient que cette légende se fonde sur la première page des interminables récits de la grande guerre qui a déchiré le continent de Casterral, opposant elfes et hommes.\r\n\r\nAvant le cataclysme, les haut-elfes vivaient en vase clos, se méfiant de tout autre peuple y compris les autres nations elfiques. Rares étaient les étrangers à pouvoir admirer la cité elfique de Lonn, le havre des Purs. Pendant le siège par l’Empire Riverain, le cataclysme ravagea leur civilisation et leur imposa un choix déchirant : quitter la mirifique cité, chef-d’œuvre des arts elfiques, ou se résoudre à périr. Ceux qui restèrent furent avalés par la terre avec Lonn. Quant aux survivants haut-elfes, ils durent se résoudre au plus douloureux des compromis, sacrifiant un peu de leur fierté et d’eux-mêmes pour cheminer vers le domaine de l’humanité afin de sauver leur vie. Sous l’égide du gouverneur riverain, plusieurs rongent leur frein avec l’espoir d’établir un jour un nouveau bastion elfique et reconstruire la cité pure à sa gloire de jadis.";

		public override int[] SkinHues => new int[] { 2107, 2108, 2109, 2110, 2111 };

		public static void Configure()
		{
			/* Here we configure all races. Some notes:
			* 
			* 1) The first 32 races are reserved for core use.
			* 2) Race 0x7F is reserved for core use.
			* 3) Race 0xFF is reserved for core use.
			* 4) Changing or removing any predefined races may cause server instability.
			*/
			RegisterRace(new HautElfe(0, 0));
		}

		public HautElfe(int raceID, int raceIndex) : base(raceID, raceIndex, "Haut-Elfe", "Haut-Elfes", 400, 401, 402, 403)
		{
		}

		public override bool ValidateEquipment(Item item)
		{
			return true;
		}

		public override BaseRaceGumps GetSkin(int hue)
		{
			return new CorpsHautElfe(hue);
		}

		public override int GetGumpId(bool female, int hue)
		{
			var gumpid = 52081;
			return female ? gumpid + 10000 : gumpid;
		}
	}
}

namespace Server.Items
{
	public class CorpsHautElfe : BaseRaceGumps
	{
		[Constructable]
		public CorpsHautElfe() : this(0)
		{
		}

		[Constructable]
		public CorpsHautElfe(int hue) : base(0xA21C, hue)
		{
			Name = "Haut-Elfe";
		}

		public CorpsHautElfe(Serial serial)
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

