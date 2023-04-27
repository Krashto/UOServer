using Server.Items;

namespace Server.Custom.Races
{
	class Nomade : BaseRace
	{
		public override string Background => "Anciens Riverains qui ont été banni des terres pour une question de vol, ainsi le premier Az Sudois naquis, le premier Nomades, Maleek migra dans les terres arides du désert pendant des jours, jusqu’au jour où il fonda la première nation Azudienne, Sable rouge. Ils sont connus pour être des guerriers agiles et forts, malgré tout, ils sont d’authentique marchandes. Négociateurs à leur heure, les Nomades ont toujours les mots exacts pour attirer l’attention sur les marchandises à portée de main.\r\n\r\nLes Nomades sont également connus pour leur détermination et leur résilience, qui leur ont permis de résister à l'invasion de leur pays par les Elv-dominion, une puissante alliance d'elfes, lors de la Grande Guerre. Cette résistance a finalement conduit à un accord de paix, mais les Nomades restent vigilants et prêts à se défendre contre toute menace qui pourrait peser sur leur territoire.\r\n\r\nLes Nomades ont un teint basané qui représente ainsi le dur labeur désertique. Des traits faciaux très prononcé sur le caractère du travail et de la pesanteur du soleil sur eux. Les Nomades Marchand ont l’habitude de porter de très longs vêtements qui couvrent l’entièreté de leurs corps, protégeant ainsi leur bourse, mais au final cache-t-il sur eux une arme volée ? Les Nomades plus militaires vont se vêtir sur des habits légers, pour représenter le signe de la liberté qu’ils ont vécu avec l’apparition de sable-rouge. \r\n En termes de culture, les Nomades ont une tradition orale riche et colorée, qui met en avant des contes et des légendes épiques. Ils sont également connus pour leur amour de la musique et de la danse, ainsi que pour leur artisanat, qui comprend notamment la fabrication de tapis et de poteries. Malgré tout, ils sont reconnus également pour faire de petit larcin ici et là, après tout la vie en Sable-rouge a été basé sur la pauvreté et la liberté d’action.\r\n\r\nLa croyance des Nomades se résume à vouer librement une adoration sur le premier Nomades, Maleek. Fier de leur propre peuple, les Nomades vont dire ouvertement sans gêne que ceci est la sainte mission de Maleek, les superstitieux les plus téméraires eux vont donner de l’or à la fontaine pour demander la grâce de Maleek. Ce qui ne vous tue pas, vous rend plus fort, tel est le dicton Nomades.\r\n\r\nNiveau amourette que dire de ces merveilleux gens des sables. Ils n’ont aucun attachement réel envers les siens. Pour eux, tout est une question de profit ou d’utilité. Charmeur à leur guise, il n’est pas rare d’entendre parler qu’un père Nomades détient une famille de vingt enfants avec vingt compagnes différente. Le plaisir est avant tout une chose qui les attire et cela se fait bien sentir dans leur culture en général.";

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

