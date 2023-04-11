using Server.Items;

namespace Server.Custom.Races
{
	class Drakos : BaseRace
	{
		public override string Background => "Les Drakos sont une race d'hommes-lézards. Ils ont une apparence reptilienne, avec des écailles et une queue, et leur couleur de peau varie selon leur lignée ancestrale. Les Drakos sont généralement considérés comme discrets et réservés, préférant souvent rester en retrait plutôt que de se mêler aux autres races. Ils ont développé une grande capacité d'adaptation.\r\n\r\nLe goût vestimentaire de ces reptiles se résume à porter des haillons ou des petits vêtements pas trop porté sur la splendeur de couleur noir ou vert pour se fondre dans la masse marécageuse. Tendance à rester en retrait dans les marécages, la tangente des Drakos est de se sentir libre de leur action en communion avec leur côté bestial.\r\n\r\nLes anciens villages Drakos étaient construits au cœur de ces marécages et sont souvent composés de petites huttes de bois et de roseaux, reliées entre elles par des ponts en bois. Les Drakos sont très liés à la nature et sont souvent capables de se fondre parfaitement dans leur environnement, devenant quasiment invisible aux yeux des étrangers. Ils sont également connus pour leur habileté dans les techniques de chasse et de pêche. Les Drakos ont une culture riche et ancienne, basée sur les traditions orales et les histoires transmises de génération en génération. Ils ont une grande méfiance envers les pratiques magiques étrangères. Bien qu'ils soient souvent considérés comme distants, les Drakos sont loyaux envers ceux qu'ils considèrent comme leur famille et leur communauté, et peuvent se montrer redoutables en cas de menace.\r\n\r\nD’étranges coutumes religieuses est au cœur des Drakos. Leurs croyances sont liées aux instincts primaires, c’est-à-dire la survie, le groupe, l’expression, créatrice ou même pouvoir. Plusieurs ancêtres Drakos ont réussi de grands exploits dans les marécages de terre sèche comme d’autres ont amener les morts et désolation. Est-ce le côté bestial des Drakos qui les font devenir fou ? C’est à se demander.\r\n\r\nL’amour chez les Drakos est un sujet très complexe. Ils s’accouplent seulement pour faire perdurer leur race. Sans être en amour, sans être en désir. C’est une question de fondation et de perdu ration des lignées Drakos. ";

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
			return new CorpsDrako(itemId, hue);
		}

		public override int GetGumpId(bool female, int hue)
		{
			var gumpid = 52098;

			switch (hue)
			{
				case 1823:
					gumpid = 52098;
					break;
				case 1820:
					gumpid = 52098;
					break;
				case 1824:
					gumpid = 52098;
					break;
				case 1821:
					gumpid = 52098;
					break;
				case 1819:
					gumpid = 52098;
					break;
				case 1825:
					gumpid = 52098;
					break;
				case 1822:
					gumpid = 52098; //
					break;
				case 1826:
					gumpid = 52098;
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
	public class CorpsDrako : BaseRaceGumps
	{
		[Constructable]
		public CorpsDrako() : this(0)
		{
		}

		[Constructable]
		public CorpsDrako(int id, int hue) : base(id, hue)
		{
			Name = "Drako";
		}

		public CorpsDrako(Serial serial)
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

