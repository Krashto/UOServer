using Server.Items;

namespace Server.Custom.Races
{
	class DemiElfe : BaseRace
	{
		public override string Background => "Les Demi-Elfes sont un peuple de demi-elfe originaire de la région de Haute-Roche. Ils sont souvent considérés comme le résultat d'un mélange de sang elfique et humain, ce qui leur confère une certaine capacité magique et une grande souplesse d'esprit.\r\n\r\nLes Demi-Elfes sont connus pour leur curiosité de la magie et des arcanes qui recouvre le monde des vivants, qu'ils utilisent souvent dans leur vie quotidienne. Ils ont une grande affinité pour l’hydromancie et sont souvent sollicités pour leurs compétences en tant que guérisseurs et alchimistes.\r\n\r\nIls sont représentant d’un sang unique, le mélange parfait entre elfe et humain. Pour cela, ils ne craignent pas de s’exhiber à porter des vêtements qui représente ainsi leur symbiose parfaite. Allant à de très grande robe de cérémonie majestueuse comme à d’habit militaire plus rustre. La couleur Bleu est représentation de leur union entre le Rouge des Riverains et le jaune des Haut-Elfes. En termes d'apparence physique, les Demi-Elfes ont une peau claire et des cheveux foncés, souvent bouclés. Ils ont également une apparence fine et élancée, avec des traits de visage délicats. Leurs oreilles semi pointue sont signe de leur mixte entre les Riverains et les Haut-Elfes.\r\n\r\nLes Demi-Elfes ont une culture riche et complexe, avec une histoire qui remonte à plusieurs milliers d'années. Ils sont connus pour leur amour de l'art et de la musique, ainsi que pour leur sophistication culturelle. Les Demi-Elfes sont également connus pour leur fierté et leur sens de l'honneur, et ils sont souvent considérés comme des diplomates habiles et des négociateurs astucieux.\r\n\r\nPour les croyances religieuse, Les Demi-Elfes sont la balance parfaite en termes de croyance. Pour eux, les ancêtres, comme les esprits élémentaires et les esprits de la forêt sont un ensemble. Le tout d’être conforme pour faire respecter les puissances d’un tout. Tel une chaine alimentaire, un engrenage éternel.\r\n\r\nPour les relations amoureuses. Les Demi-Elfes sont amoureux d’une idée conçue tel d’un peuple en parfaite harmonie. Pouvant aimer autant les humains que les elfes. Pour eux, l’idée de pouvoir procréer une vie qui porte les deux sangs est une bénédiction. Serait-ce pour envahir les terres et étendre leur pouvoir ou simplement car ils sont adorateurs de l’évolution ?";

		public override int[] SkinHues => new int[] { 1037, 1039, 1102, 1110, 1114 };

		public static void Configure()
		{
			/* Here we configure all races. Some notes:
			* 
			* 1) The first 32 races are reserved for core use.
			* 2) Race 0x7F is reserved for core use.
			* 3) Race 0xFF is reserved for core use.
			* 4) Changing or removing any predefined races may cause server instability.
			*/
			RegisterRace(new DemiElfe(4, 4));
		}

		public DemiElfe(int raceID, int raceIndex) : base(raceID, raceIndex, "Demi-Elfe", "Demi-Elfes", 400, 401, 402, 403)
		{
		}

		public override bool ValidateEquipment(Item item)
		{
			return true;
		}

		public override BaseRaceGumps GetSkin(int hue)
		{
			return new CorpsDemiElfe(hue);
		}

		public override int GetGumpId(bool female, int hue)
		{
			var gumpid = 52083;
			return female ? gumpid + 10000 : gumpid;
		}
	}
}

namespace Server.Items
{
	public class CorpsDemiElfe : BaseRaceGumps
	{
		[Constructable]
		public CorpsDemiElfe() : this(0)
		{
		}

		[Constructable]
		public CorpsDemiElfe(int hue) : base(0xA21E, hue)
		{
			Name = "Demi-Elfe";
		}

		public CorpsDemiElfe(Serial serial)
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

