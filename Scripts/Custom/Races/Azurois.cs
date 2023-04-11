using Server.Items;

namespace Server.Custom.Races
{
	class Azurois : BaseRace
	{
		public override string Background => "L'ancienne légion Azurienne qui aura combattu l’invasion Elvuruks dans les terres du Nord, Le peu de survivants de cette bataille ne voulant pas perdre la face de leur défaite décida de concevoir un campement qui se nomme Terre-Froide. Ainsi la première nation Az Norois vie le jour. Dernier survivant de la bataille du Mont Idir, ils sont connus pour leur grande résistance au climat, leur peau pâle et leurs cheveux blonds\r\n\r\nLes Azorois sont fiers de leur héritage guerrier, valorisant la force et l'endurance de leurs guerriers. Ils ont une forte tradition militaire et sont souvent impliqués dans des conflits armés, que ce soit pour défendre leur territoire ou pour en conquérir de nouveaux.\r\n\r\nLe goût vestimentaire des Azorois se résume à tout ce qui a trait à la fourrure et au cuir, sensiblement représenter par des habits de couleur bleu et blanc en relation avec leur nouvelle terre celle de Terre-Froide. Autrement dit l’allure la plus glacial possible pour intimider leurs adversaires.  D’attitude bon vivant, les Azorois sont avant tout reconnu comme être des gens fiers de leur racine. Fidèle à leur nature festive dans l’adversité sans pour autant être dangereuse. Les Azorois aiment se surpasser et épater la galerie dans leur prouesse physique comme politique. Tendance à ne pas mâcher leur mot, les Azorois se prononce sans gêne sur tous les sujets\r\n\r\nLa culture Azoroise est profondément imprégnée de leur environnement naturel, avec des traditions qui célèbrent les saisons et les changements climatiques, ainsi que des rituels qui honorent les esprits des montagnes et des rivières. Ils ont également une forte tradition orale, avec des contes et des légendes épiques qui racontent des histoires de héros et de batailles.\r\n\r\nMalgré ce que peut représenter les Azorois, ils sont fidèles à leur partenaire et vouent cœur et âme à la protection de leur nid familial. La liaison amoureuse des Azorois se consiste à pouvoir impressionner sur le champ de bataille car au final, ils finiront tous dans le grand havre à pouvoir boire et se battre éternellement.\r\n";

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

		public Azurois(int raceID, int raceIndex) : base(raceID, raceIndex, "Azorois", "Azorois", 400, 401, 402, 403)
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
			return new CorpsAzorois(itemId, hue);
		}

		public override int GetGumpId(bool female, int hue)
		{
			var gumpid = 52084;

			switch (hue)
			{
				case 1823:
					gumpid = 52084;
					break;
				case 1820:
					gumpid = 52084;
					break;
				case 1824:
					gumpid = 52084;
					break;
				case 1821:
					gumpid = 52084;
					break;
				case 1819:
					gumpid = 52084;
					break;
				case 1825:
					gumpid = 52084;
					break;
				case 1822:
					gumpid = 52084; //
					break;
				case 1826:
					gumpid = 52084;
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
	public class CorpsAzorois : BaseRaceGumps
	{
		[Constructable]
		public CorpsAzorois() : this(0)
		{
		}

		[Constructable]
		public CorpsAzorois(int id, int hue) : base(id, hue)
		{
			Name = "Azorois";
		}

		public CorpsAzorois(Serial serial)
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

