using Server.Items;

namespace Server.Custom.Races
{
	class ElfeDesBois : BaseRace
	{
		public override string Background => "Les Elfes des bois, également connus sous le nom d'Elfes des bois, sont un peuple elfique qui habite la forêt d'Éradin. Ils sont connus pour leur agilité, leur maîtrise de l'arc et leur relation étroite avec la nature. Ces dresseurs et pisteur de la forêt d’Éradin sont reconnu partout sur le continent de Casterral pour être les meilleurs explorateurs des terres.\r\n\r\nLes Elfes des bois ont une apparence distincte, avec leur peau brune et leurs traits de visage fins. Ils ont souvent les cheveux sombres, qui sont portés en tresses ou en chignons. Les Elfes des bois ont également la fâcheuse habitude de rentrer en transe et demander l’appel des esprits de la forêt avant toute chose. Ce qui fait d’eux reconnus comme des sauvages distinguer malgré leurs mœurs enjouées de la vie\r\n\r\nLes Elfes des bois ont souvent tendance à porté des vêtements représentatif des saisons. Ce qui permet de les distinguer et de renouveler très souvent leur tenue vestimentaire. Ils détestent par-dessus tout la couleur du rouge et du doré puisque cela représente la couleur des Riverains qui ont mis à feu et à sang la culture Elfes des bois pour tirer profit des ressources d’Éradin. Les Elfes des bois ont une culture qui est étroitement liée à la nature, et qui valorise la liberté, la chasse et la collecte des fruits de la forêt. Ils ont une grande expertise en matière de survie en milieu forestier, et sont capables de vivre en harmonie avec la nature sans la détruire. Cependant, il arrive que la rage de la forêt aussi incontrôlable soit-elle font d’eux des êtres enragé qui ont tendance à perdre patience devant le manque de respect de la faune et de ses ressources.\r\n\r\nLes Elfes des bois croient aux esprits de la forêt. Chaque offrande, chaque festivité sont liées à un animal de la forêt. Pour eux, chaque créature mérite qu’on lui attarde une importance, car sans les abeilles, il n’y aurait pas de miel, sans créature chassé, il n’y aurait pas de prédateur et ainsi de suite.\r\n\r\nL’amour chez les Elfes des bois est composé par les totems ancestraux qui ont été distribués dans leur culture. Une personne désignée par le totem du loup risque de tomber en amour avec la force de caractère d’une louve. Si un Elfes des bois est désigné par le totem du hibou, il risque d’être attiré par la sagesse d’un hibou restant ainsi dans le respect des espèces animales.";

		public override int[] SkinHues => new int[] { 1806, 1826, 1825, 1824, 1809 };

		public static void Configure()
		{
			/* Here we configure all races. Some notes:
			* 
			* 1) The first 32 races are reserved for core use.
			* 2) Race 0x7F is reserved for core use.
			* 3) Race 0xFF is reserved for core use.
			* 4) Changing or removing any predefined races may cause server instability.
			*/
			RegisterRace(new ElfeDesBois(3, 3));
		}

		public ElfeDesBois(int raceID, int raceIndex) : base(raceID, raceIndex, "Elfe des bois", "Elfes des bois", 400, 401, 402, 403)
		{
		}

		public override bool ValidateEquipment(Item item)
		{
			return true;
		}

		public override BaseRaceGumps GetSkin(int hue)
		{
			return new CorpsElfeDesBois(hue);
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
	public class CorpsElfeDesBois : BaseRaceGumps
	{
		[Constructable]
		public CorpsElfeDesBois() : this(0)
		{
		}

		[Constructable]
		public CorpsElfeDesBois(int hue) : base(0xA21C, hue)
		{
			Name = "Elfe des bois";
		}

		public CorpsElfeDesBois(Serial serial)
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

