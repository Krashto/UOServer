using Server.Items;

namespace Server.Custom.Races
{
	class Nain : BaseRace
	{
		public override string Background => "L’arrivée du premier Nains, Kilivar, est arriver après le cataclysme. Cette lignée, perdue dans les montagnes, a été enfin réveillée par l’éveil du volcan. Nains est l’appellation de cette peuplade par les armées Riverainnes. Min, pour minuscule ou provenance des Mines et Kos pour les étrangers.\r\n\r\nLes Nains sont souvent représentés comme des êtres de petite taille, généralement trapus et musclés, avec des barbes et des cheveux épais. Ils sont souvent associés aux mines, aux forges et à la fabrication d'objets en métal et en pierre. Ils sont souvent considérés comme des artisans et des travailleurs acharnés, et sont souvent fiers de leur habileté à travailler le métal.\r\n\r\nLes Nains ont souvent tendance à parler fort et à se faire entendre pour tout et rien. Bavasseur de première peu importe la circonstance, ils ont tendance à dire ouvertement sans se soucier des représailles. L’envie de devenir riche par le dur labeur est la quête principale à laquelle tout Nains désir accéder.\r\n\r\nL’habit du Nains moyen est d’arborer le vêtement auquel il est associé dans son métier. Que ce soit un tablier pour un forgeron, une armure pour un guerrier, une longue toge pour l’étude des sortilèges. Les couleurs de la terre et des roches sont souvent associer à eux, que ce soit par le brun ou le gris. Les Nains aiment par-dessus tout salir leur vêtement car un vêtement propre signifie que tu es un fainéant.   Les Nains sont également souvent représentés comme étant fiers et têtus, et sont souvent en conflit avec d'autres races ou cultures. Ils ont souvent leur propre langue et leur propre culture distinctes, et sont souvent en mesure de se protéger efficacement contre les menaces extérieures grâce à leur habileté en combat et leur capacité à travailler le métal.\r\n\r\nIls vouent un culte principal aux esprits des montagnes et à la forge. Quoi que sensiblement certains héros du passé, tel l’ancêtre Wilard, général de la première nation Nains ou encore Baduk maître forgeron réputer. Ils sont fiers de leur héros et ne se gênent pas de citer leur nom en signe de fierté.\r\n\r\nMalgré leur obstination à être riche et fier, ils sont des être d’amour et d’eau fraîche. On comble l’amour par le ventre et le dialecte ici est également pareil. Les Nains sont des êtres qui s’aiment dans la simplicité, que ce soit une baguette de pain ou un gâteau à la citrouille.";

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

