using Server.Items;

namespace Server.Custom.Races
{
	class Montagnard : BaseRace
	{
		public override string Background => "L'ancienne légion Riverainne qui aura combattu l’invasion Demi-orcs dans les terres du Nord, Le peu de survivants de cette bataille ne voulant pas perdre la face de leur défaite décida de concevoir un campement qui se nomme Terre-Froide. Ainsi la première nation Az Norois vie le jour. Dernier survivant de la bataille du Mont Idir, ils sont connus pour leur grande résistance au climat, leur peau pâle et leurs cheveux blonds\r\n\r\nLes Montagnards sont fiers de leur héritage guerrier, valorisant la force et l'endurance de leurs guerriers. Ils ont une forte tradition militaire et sont souvent impliqués dans des conflits armés, que ce soit pour défendre leur territoire ou pour en conquérir de nouveaux.\r\n\r\nLe goût vestimentaire des Montagnards se résume à tout ce qui a trait à la fourrure et au cuir, sensiblement représenter par des habits de couleur bleu et blanc en relation avec leur nouvelle terre celle de Terre-Froide. Autrement dit l’allure la plus glacial possible pour intimider leurs adversaires.  D’attitude bon vivant, les Montagnards sont avant tout reconnu comme être des gens fiers de leur racine. Fidèle à leur nature festive dans l’adversité sans pour autant être dangereuse. Les Montagnards aiment se surpasser et épater la galerie dans leur prouesse physique comme politique. Tendance à ne pas mâcher leur mot, les Montagnards se prononce sans gêne sur tous les sujets\r\n\r\nLa culture Montagnardse est profondément imprégnée de leur environnement naturel, avec des traditions qui célèbrent les saisons et les changements climatiques, ainsi que des rituels qui honorent les esprits des montagnes et des rivières. Ils ont également une forte tradition orale, avec des contes et des légendes épiques qui racontent des histoires de héros et de batailles.\r\n\r\nMalgré ce que peut représenter les Montagnards, ils sont fidèles à leur partenaire et vouent cœur et âme à la protection de leur nid familial. La liaison amoureuse des Montagnards se consiste à pouvoir impressionner sur le champ de bataille car au final, ils finiront tous dans le grand havre à pouvoir boire et se battre éternellement.";

		public override int[] SkinHues => new int[] { 1002, 1003, 1004, 1023, 1045 };

		public static void Configure()
		{
			/* Here we configure all races. Some notes:
			* 
			* 1) The first 32 races are reserved for core use.
			* 2) Race 0x7F is reserved for core use.
			* 3) Race 0xFF is reserved for core use.
			* 4) Changing or removing any predefined races may cause server instability.
			*/
			RegisterRace(new Montagnard(9, 9));
		}

		public Montagnard(int raceID, int raceIndex) : base(raceID, raceIndex, "Montagnard", "Montagnards", 400, 401, 402, 403)
		{
		}

		public override bool ValidateEquipment(Item item)
		{
			return true;
		}

		public override BaseRaceGumps GetSkin(int hue)
		{
			return new CorpsMontagnard(hue);
		}

		public override int GetGumpId(bool female, int hue)
		{
			var gumpid = 52084;
			return female ? gumpid + 10000 : gumpid;
		}
	}
}

namespace Server.Items
{
	public class CorpsMontagnard : BaseRaceGumps
	{
		[Constructable]
		public CorpsMontagnard() : this(0)
		{
		}

		[Constructable]
		public CorpsMontagnard(int hue) : base(0xA21F, hue)
		{
			Name = "Montagnard";
		}

		public CorpsMontagnard(Serial serial)
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

