using Server.Items;

namespace Server.Custom.Races
{
	class Riverain : BaseRace
	{
		public override string Background => "Les Riverains sont un peuple humain originaire de Colognan. Ils sont connus pour leur culture sophistiquée, leur gouvernement organisé et leur capacité à influencer les événements politiques et militaires de Casterral. Vu qu’ils représentent la plus grosse armée du continent après le cataclysme.\r\n\r\nLes Riverains ont une apparence variée, mais ils ont souvent la peau claire et des traits de visage régulier. Ils sont souvent considérés comme des gens beaux et élégants, avec un certain raffinement dans leur apparence. Tendance à porter des vêtements rouges et or représentant de leur domination par le sang et l’or qu’ils ont engendré avec la guerre\r\n\r\nLes Riverains ont une culture riche et complexe, qui est largement influencée par leur histoire en tant que puissance impériale dominante. Ils ont un gouvernement organisé et sont connus pour leur capacité à administrer efficacement leur territoire. Ils sont également connus pour leur amour de la littérature et des arts.\r\n\r\nLes Riverains sont souvent considérés comme des négociateurs habiles et des stratèges militaires talentueux. Ils ont une grande force de caractère et sont souvent décrits comme étant très déterminés dans leurs actions. Ils ne se priveront pas pour exécuter les ordres demandés même si cela peut engendrer des émeutes ou désarroi au sein du bastion de Colognan puisque leur vision est d'obéir à l'échelle du pouvoir.\r\n\r\nNiveau religion, les Riverains croient en les ancêtres de la guerre et la discipline. Ils ne sont pas des êtres qui démontrent ouvertement leur sentiment ou leur relation publique. Ces hommes et femmes des familles nobles sont représentatifs par l’apparence avant toute chose.\r\n\r\nL’amour chez les Riverains est sensiblement relié à la politique et aux avantages que cela peut procurer. Politique, argent, militaire, siège Important. L’amour du grand A est très rare chez les Riverains même si parfois, on peut retrouver des personnes sensibles qui ont su se trouver. ";

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

