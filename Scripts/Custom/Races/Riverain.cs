using Server.Items;

namespace Server.Custom.Races
{
	class Riverain : BaseRace
	{
		public override string Background => " Les riverains sont un peuple humain originaire de Colognan, connus pour leur culture sophistiquée, leur gouvernement organisé et leur héritage militaire et politique. Avant le cataclysme, les riverains multipliaient les démonstrations de force dans un esprit de conquête qui les amenait sans cesse vers de nouveaux horizons. Une légion avait été dépêchée au Nord vouée à se mesurer aux demi-orques pour le contrôle des terres glacées. Dans l’optique de revendiquer, une autre a décimé en sauvages campagnes la forêt défendue chèrement par les dernières forces des elfes des bois. Le rêve motivant les troupes et assurant leur discipline a toujours été la promesse d’un Empire unique et absolu s’étirant d’un océan à l’autre. Pourtant, malgré leur vaillance, ce rêve était impossible à réaliser jusqu’au Cataclysme. Ses ravages ont permis la véritable expansion du dominion riverain, sonnant ses heures de gloire. Protégés par leur immense forteresse, préparés, disciplinés et entraînés, ils furent grandement épargnés ce qui apporta à leur porte un afflux de réfugiés d’abord des terres conquises, plus venus de terres plus lointaines et ravagées dans l’espoir de survivre. Tout détracteur fraîchement arrivé dans le dominion riverain découvrit à ses dépens la rigueur à préserver l’ordre établi. Certains riverains, parmi les plus traditionnalistes, voient Colognan comme la capitale de cet Empire avec pour devoir de dompter les terres sauvages et désolées laissées en friches par le cataclysme. \r\n";

		public override int[] SkinHues => new int[] { 1016, 1017, 1018, 1019, 1020 };

		public static void Configure()
		{
			/* Here we configure all races. Some notes:
			* 
			* 1) The first 32 races are reserved for core use.
			* 2) Race 0x7F is reserved for core use.
			* 3) Race 0xFF is reserved for core use.
			* 4) Changing or removing any predefined races may cause server instability.
			*/
			RegisterRace(new Riverain(7, 7));
		}

		public Riverain(int raceID, int raceIndex) : base(raceID, raceIndex, "Riverain", "Riverains", 400, 401, 402, 403)
		{
		}

		public override bool ValidateEquipment(Item item)
		{
			return true;
		}

		public override BaseRaceGumps GetSkin(int hue)
		{
			return new CorpsRiverain(hue);
		}

		public override int GetGumpId(bool female, int hue)
		{
			var gumpid = 52086;
			return female ? gumpid + 10000 : gumpid;
		}
	}
}

namespace Server.Items
{
	public class CorpsRiverain : BaseRaceGumps
	{
		[Constructable]
		public CorpsRiverain() : this(0)
		{
		}

		[Constructable]
		public CorpsRiverain(int hue) : base(0xA221, hue)
		{
			Name = "Riverain";
		}

		public CorpsRiverain(Serial serial)
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

